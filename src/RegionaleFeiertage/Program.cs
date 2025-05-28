using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegionaleFeiertage.CommandLine;
using Serilog;
using System;

Console.WriteLine("Starting application");

var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.ConfigureServices((context, services) =>
{
    services.AddHostedService<Worker>();
    services.AddTransient<CommandHandler>();
    services.AddSerilog();
});
// Use Serilog as the logging provider
hostBuilder.UseSerilog();

var host = hostBuilder.Build();
//var logger = host.Services.GetRequiredService<ILogger>();
await host.RunAsync();

//Makes Builder and runs it for you
//await hostBuilder.RunConsoleAsync();

