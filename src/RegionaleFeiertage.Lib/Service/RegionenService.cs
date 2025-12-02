using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;

namespace RegionaleFeiertage.Lib.Service;

public class RegionenService
{
    public static string Canonicalize(string input)
    {
        string lower = input.ToLower();
        return lower.Replace("-", "")
            .Replace("ä", "ae")
            .Replace("ö", "oe")
            .Replace("ü", "ue")
            .Replace("ß", "ss");
    }

    public static List<Region> GetAllRegions(int year, bool includeSonntage = false)
    {
        var regionFuncs = new List<Func<int, bool, Region>>
        {
        Regionen.BadenWürttemberg,
        Regionen.Bayern,
        Regionen.Berlin,
        Regionen.Brandenburg,
        Regionen.Bremen,
        Regionen.Hamburg,
        Regionen.Hessen,
        Regionen.MecklenburgVorpommern,
        Regionen.Niedersachsen,
        Regionen.NordrheinWestfalen,
        Regionen.RheinlandPfalz,
        Regionen.Saarland,
        Regionen.Sachsen,
        Regionen.SachsenAnhalt,
        Regionen.SchleswigHolstein,
        Regionen.Thüringen,
        Regionen.Deutschland
        };

        return FeiertageFactory.RegionFunctionListToRegionList(regionFuncs, year, includeSonntage);
    }

    public static List<string> GetAllRegionsString()
    {
        var regionFuncs = new List<string>
        {
        "Baden-Württemberg",
        "Bayern",
        "Berlin",
        "Brandenburg",
        "Bremen",
        "Hamburg",
        "Hessen",
        "Mecklenburg-Vorpommern",
        "Niedersachsen",
        "Nordrhein-Westfalen",
        "Rheinland-Pfalz",
        "Saarland",
        "Sachsen",
        "Sachsen-Anhalt",
        "Schleswig-Holstein",
        "Thüringen",
        };
        return regionFuncs;
    }

    public static Dictionary<string, Region> GetAllRegionsDictionary(bool includeSonntage = false)
    {
        var dic = new Dictionary<string, Region>
        {
            { "baden-wuerttemburg", new Region("Baden-Württemburg", "BW") },
            { "bayern", new Region("Bayern", "BY") },
            { "berlin", new Region("Berlin", "B") },
            { "brandenburg", new Region("Brandenburg", "BB") },
            { "bremen", new Region("Bremen", "HB") },
            { "hamburg", new Region("Hamburg", "HH") },
            { "hessen", new Region("Hessen", "HE") },
            { "mecklenburg-vorpommern", new Region("Mecklenburg-Vorpommern", "MV") },
            { "niedersachen", new Region("Niedersachsen", "NI") },
            { "nordrhein-westfalen", new Region("Nordrhein-Westfalen", "NRW") },
            { "rheinland-pfalz", new Region("Rheinland-Pfalz", "RP") },
            { "saarland", new Region("Saarland", "SL") },
            { "sachsen", new Region("Sachsen", "SN") },
            { "sachsen-anhalt", new Region("Sachsen-Anhalt", "ST") },
            { "schleswig-holstein", new Region("Schleswig-Holstein", "SH") },
            { "thueringen", new Region("Thüringen", "TH") }
        };

        return dic;
    }

    public static Region GetRegion(string region, int year, bool includingSundays = false)
    {
        var search = Canonicalize(region);
        var allRegions = GetAllRegions(year, includingSundays);

        foreach (var r in allRegions)
        {
            if (Canonicalize(r.Name).Equals(search) || Canonicalize(r.Shortname).Equals(search))
            {
                return r;
            }
        }
        throw new ArgumentException($"Region '{region}' unbekannt.");
    }

    public static List<string> GetAllRegionsString(int year)
    {
        var allRegions = GetAllRegions(year);
        var allRegionsString = new List<string>();
        foreach (var region in allRegions)
        {
            allRegionsString.Add(region.Name);
        }
        return allRegionsString;
    }

    public static void YearCheck(int year)
    {
        //check if the given year is within the start of the gregorian calendar
        if (!(year >= 1583))
        {
            throw new ArgumentOutOfRangeException(year.ToString(), "Year must be 1583 or later.");
        }
    }

    public static bool FullAndShortNameChecker (string regionstr, int year, bool includeSonntage)
    {
        bool result = false;
        var regions = GetAllRegions(year, includeSonntage);
        foreach( var reg in regions)
        {
            if(reg.Name.Equals(regionstr))
            {
                result = true;
            }
            else if (reg.Shortname.Equals(regionstr))
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }
}