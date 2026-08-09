using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Declarative.Avalonia.AgentTools.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

namespace Declarative.Avalonia.AgentTools;

/// <summary>
/// Hosts the in-process MCP server (loopback HTTP/SSE via Kestrel) on a dedicated background thread.
/// </summary>
internal sealed class AgentInspectorServer
{
    private readonly AgentInspectorOptions _options;
    private readonly CancellationTokenSource _cts = new();
    private Thread? _thread;

    public AgentInspectorServer(AgentInspectorOptions options) => _options = options;

    public void Start()
    {
        _thread = new Thread(Run)
        {
            IsBackground = true,
            Name = "AgentInspectorServer"
        };
        _thread.Start();
    }

    public void Stop()
    {
        try
        {
            _cts.Cancel();
        }
        catch (ObjectDisposedException)
        {
        }
    }

    private void Run()
    {
        try
        {
            var builder = WebApplication.CreateBuilder();

            // Keep the GUI app's console quiet; the inspector is plumbing, not the app.
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Warning);

            // Bind strictly to loopback.
            builder.WebHost.UseUrls(_options.EndpointUrl);

            var mcp = builder.Services
                .AddMcpServer()
                .WithHttpTransport(transport => transport.Stateless = true)
                .WithTools<InspectionTools>();

            // Tier-2 remote-control surface is registered only behind the explicit opt-in flag.
            if (_options.EnableInteraction)
                mcp.WithTools<InteractionTools>();

            RegisterHostTools(mcp);

            var app = builder.Build();

            // Observe agent activity so the app can show a live "agent connected" status. Runs for every
            // request to the loopback endpoint; it only records a timestamp, so it adds no meaningful cost.
            app.Use(async (context, next) =>
            {
                AgentConnectionMonitor.NotifyActivity(context.Request.Path.Value);
                await next(context);
            });

            app.MapMcp();

            // Printed to both the debug output and stdout so it is visible under `dotnet watch`/`dotnet run`.
            var banner =
                $"[AgentInspector] MCP server listening on {_options.EndpointUrl} " +
                $"(add it to your agent's MCP client as a streamable-HTTP server).";
            Debug.WriteLine(banner);
            Console.WriteLine(banner);
            if (_options.EnableInteraction)
            {
                const string warning = "[AgentInspector] WARNING: interaction tools (invoke) are ENABLED.";
                Debug.WriteLine(warning);
                Console.WriteLine(warning);
            }

            // Observe the cancellation token so Stop() can shut the host down gracefully.
            // The IHost extension takes the token; WebApplication.RunAsync(string?) would shadow it.
            ((IHost)app).RunAsync(_cts.Token).GetAwaiter().GetResult();
        }
        catch (OperationCanceledException)
        {
            // Normal shutdown.
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[AgentInspector] failed to start on {_options.EndpointUrl}: {ex.Message}");
        }
    }

    /// <summary>
    /// Adds the application's own tool types (<see cref="AgentInspectorOptions.WithTools{TTools}"/>).
    /// </summary>
    /// <remarks>
    /// The tools are built here rather than handed to <c>WithTools&lt;T&gt;()</c> because the SDK would
    /// construct instance tool types from <em>this</em> host's DI container, which knows nothing about
    /// the application's services. Instead each type is instantiated once from
    /// <see cref="AgentInspectorOptions.Services"/> — so a tool can take <c>AppState</c> or a command
    /// service in its constructor — and its methods are bound to that instance.
    /// </remarks>
    private void RegisterHostTools(IMcpServerBuilder mcp)
    {
        foreach (var toolType in _options.ToolTypes)
        {
            if (AgentInspectorOptions.RequiresInteraction(toolType) && !_options.EnableInteraction)
            {
                Announce($"[AgentInspector] skipping host tools '{toolType.Name}': they are marked " +
                         "[AgentInteractionTools] and EnableInteraction is off.");
                continue;
            }

            try
            {
                mcp.WithTools(CreateHostTools(_options, toolType));
            }
            catch (Exception ex)
            {
                // One misconfigured host tool type must not take the whole inspector down: report it and
                // keep the built-in tools working.
                Announce($"[AgentInspector] could not register host tools '{toolType.FullName}': {Root(ex).Message}");
            }
        }
    }

    /// <summary>
    /// Binds one host tool type's <c>[McpServerTool]</c> methods to a single instance built from the
    /// application's service provider (static methods need no instance).
    /// </summary>
    internal static List<McpServerTool> CreateHostTools(AgentInspectorOptions options, Type toolType)
    {
        var methods = AgentInspectorOptions.GetToolMethods(toolType).ToList();
        object? instance = null;

        if (methods.Any(m => !m.IsStatic))
        {
            if (options.Services is { } services)
            {
                instance = ActivatorUtilities.CreateInstance(services, toolType);
            }
            else
            {
                // Without an app service provider the only thing we can build is a self-contained type.
                // Say so explicitly — "no parameterless constructor" on its own would send the reader
                // hunting for the wrong fix.
                var parameterless = toolType.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, binder: null, Type.EmptyTypes, modifiers: null);

                instance = parameterless?.Invoke(Array.Empty<object?>())
                           ?? throw new InvalidOperationException(
                               $"'{toolType.Name}' has instance tool methods but no parameterless constructor, and no " +
                               "service provider was given. Set AgentInspectorOptions.Services to your app's " +
                               "IServiceProvider so its constructor dependencies can be injected.");
            }
        }

        return methods
            .Select(method => McpServerTool.Create(method, method.IsStatic ? null : instance))
            .ToList();
    }

    private void Announce(string message)
    {
        Debug.WriteLine(message);
        Console.WriteLine(message);
    }

    private static Exception Root(Exception ex)
    {
        while (ex.InnerException is not null)
            ex = ex.InnerException;
        return ex;
    }
}
