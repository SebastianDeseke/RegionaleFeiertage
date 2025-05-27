using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;


// Configure Serilog to write logs to a file
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(Host.Configuration)
    .CreateLogger();

try
{
    Log.Information("Starting application");
    
    var host = Host.CreateDefaultBuilder(args);
    host.ConfigureServices((context, service) =>
    {

    })
    .Build();
    // Use Serilog as the logging provider
    host.UseSerilog();

await host.RunConsoleAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
