namespace RegionaleFeiertage.CommandLine
{
    public class CommandHandler
    {
        public void Run(string[] args)
        {
            string region = "Alle";
            bool inklusiveSonntage = false;
            bool asTaskjugglerCode = false;
            int? year = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("--region="))
                    region = arg.Substring("--region=".Length);
                else if (arg == "--inklusiveSonntage")
                    inklusiveSonntage = true;
                else if (arg == "--asTaskjugglerCode")
                    asTaskjugglerCode = true;
                else if (int.TryParse(arg, out int y))
                    year = y;
            }

            if (year is null)
            {
                Console.WriteLine("❌ Kein Jahr angegeben.");
                return;
            }

            Console.WriteLine($"📅 Jahr: {year}");
            Console.WriteLine($"🌍 Region: {region}");
            Console.WriteLine($"📋 Inklusive Sonntage: {inklusiveSonntage}");
            Console.WriteLine($"📦 TaskJuggler Output: {asTaskjugglerCode}");

            // Your logic here
            var holidays = FeiertagsRechner.GetFeiertage(year.Value, region, inklusiveSonntage);

            if (asTaskjugglerCode)
                Console.WriteLine(TaskjugglerFormatter.Format(holidays));
            else
                holidays.ForEach(h => Console.WriteLine($"{h.Datum:yyyy-MM-dd} - {h.Name}"));
        }
    }
}
