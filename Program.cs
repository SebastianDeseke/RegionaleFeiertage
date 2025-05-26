using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;


var host = Host.CreateDefaultBuilder(args);
host.ConfigureServices ((context, service) => {

});

await host.RunConsoleAsync();

// Configure Serilog to write logs to a file
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  // Optional: Log to Console
    .WriteTo.File("logs/app-log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Use Serilog as the logging provider
builder.Host.UseSerilog();