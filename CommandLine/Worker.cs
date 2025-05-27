using Microsoft.Extensions.Hosting;

namespace RegionaleFeiertage.CommandLine
{
    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly CommandHandler _commandHandler;

        public Worker(IHostApplicationLifetime hostApplicationLifetime, CommandHandler commandHandler)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _commandHandler = commandHandler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _commandHandler.Run(Environment.GetCommandLineArgs().Skip(1).ToArray());
            _hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }
    }
}
