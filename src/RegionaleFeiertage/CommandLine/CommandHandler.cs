using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RegionaleFeiertage.Regions;

namespace RegionaleFeiertage.CommandLine
{
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
            Console.WriteLine("Parsing command-line arguments: {0}", string.Join(" ", args));
            Console.WriteLine("Argumetn passed platform was {0}", _config.GetValue<string>("platform"));
            string region = "Alle";
            bool includeSonntage = false;
            bool asTaskjugglerCode = false;
            int? year = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("--region"))
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
                return;
            }

            Console.WriteLine($"Jahr: {year}");
            Console.WriteLine($"Region: {region}");
            Console.WriteLine($"Inklusive Sonntage: {includeSonntage}");
            Console.WriteLine($"TaskJuggler Output: {asTaskjugglerCode}");

            // Your logic here
            //var holidays = FeiertagsRechner.GetFeiertage(year.Value, region, inklusiveSonntage);

            // if (asTaskjugglerCode) {
            //     Console.WriteLine(TaskjugglerFormatter.Format(holidays));
            // }else {
            //     holidays.ForEach(h => Console.WriteLine($"{h.Datum:yyyy-MM-dd} - {h.Name}"));
            //}
        }

        public static string Canonicalize(string input)
        {
            string lower = input.ToLower();
            return lower.Replace("-", "")
                .Replace("ä", "ae")
                .Replace("ö", "oe")
                .Replace("ü", "ue")
                .Replace("ß", "ss");
        }

        public static Region GetRegion(string region, int year, bool includingSundays)
{
    var search = Canonicalize(region);
    var allRegions = Regionen.GetAllRegions(year, includingSundays); // You may need to implement this

    foreach (var r in allRegions)
    {
        if (Canonicalize(r.Name) == search || Canonicalize(r.Shortname) == search)
        {
            return r;
        }
    }

    throw new ArgumentException($"Region '{region}' unbekannt.");
}
    }
}
