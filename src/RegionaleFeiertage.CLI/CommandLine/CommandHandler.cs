using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RegionaleFeiertage.Lib.Service;

namespace RegionaleFeiertage.CLI.CommandLine;

public class CommandHandler
{
    private readonly ILogger<CommandHandler> _logger;
    private readonly IConfiguration _config;

    public CommandHandler(ILogger<CommandHandler> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run(string[] args)
    {
        _logger.LogInformation("Parsing command-line arguments: {Args}", string.Join(" ", args));
        string region = "Alle";
        bool includeSonntage = false;
        bool asTaskjugglerCode = false;
        int? year = null;

        /* for (int i = 0; i < args.Length; i++)
                    {
                        switch (args[i])
                        {
                            case "--region":
                                if (i + 1 < args.Length)
                                {
                                    region = args[i + 1];
                                    i++;
                                }
                                break;
                            case "--year":
                                if (i + 1 < args.Length && int.TryParse(args[i + 1], out int y))
                                {
                                    year = y;
                                    i++;
                                }
                                break;
                        }
                    } */

        foreach (var arg in args)
        {
            if (arg.StartsWith("--region"))
                //using config to catch flags as they are saved at runtime
                region = _config.GetValue<string>("region").ToLower();
            else if (arg == "--includeSonntage")
                includeSonntage = true;
            else if (arg == "--asTaskjugglerCode")
                asTaskjugglerCode = true;
            else if (int.TryParse(arg, out int y))
                year = y;
        }

        if (year is null)
        {
            Console.WriteLine("Kein Jahr angegeben.");
            _logger.LogInformation("Kein Jahr angegeben.");
            return;
        }

        Console.WriteLine($"Jahr: {year}");
        Console.WriteLine($"Region: {region}");
        Console.WriteLine($"Inklusive Sonntage: {includeSonntage}");
        Console.WriteLine($"TaskJuggler Output: {asTaskjugglerCode}");


        var holidays = RegionenService.GetRegion(region, (int)year, includeSonntage);
        Console.WriteLine(holidays);

        // if (asTaskjugglerCode) {
        //     Console.WriteLine(TaskjugglerFormatter.Format(holidays));
        // }else {
        //     holidays.ForEach(h => Console.WriteLine($"{h.Datum:yyyy-MM-dd} - {h.Name}"));
        //}
    }
}
