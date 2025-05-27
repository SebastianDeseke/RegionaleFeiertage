using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegionaleFeiertage.CommandLine;
using Serilog;
using System;

    Console.WriteLine ("Starting application");

    var host = Host.CreateDefaultBuilder(args);
    host.ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<CommandHandler>();
        services.AddSerilog();
    })
    .Build();
    // Use Serilog as the logging provider
    host.UseSerilog();

    await host.RunConsoleAsync();

