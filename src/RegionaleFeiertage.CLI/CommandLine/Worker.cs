using System.Numerics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RegionaleFeiertage.CLI.CommandLine;

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly CommandHandler _commandHandler;
    private readonly ILogger<Worker> _logger;

    public Worker(IHostApplicationLifetime hostApplicationLifetime, CommandHandler commandHandler, ILogger<Worker> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _commandHandler = commandHandler;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker started...");
        _commandHandler.Run(Environment.GetCommandLineArgs().Skip(1).ToArray());
        _hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }
}
