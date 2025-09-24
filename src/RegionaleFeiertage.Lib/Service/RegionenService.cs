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

    public static Dictionary<string, Region> GetAllRegionsDictionary(bool includeSonntage = false)
    {
        var dic = new Dictionary<string, Region>
        {
            { "", new Region("Baden-Württemburg", "BW") },
            { "", new Region("Bayern", "BY") },
            { "", new Region("Berlin", "B") },
            { "", new Region("Brandenburg", "BB") },
            { "", new Region("Bremen", "HB") },
            { "", new Region("Hamburg", "HH") },
            { "", new Region("Hessen", "HE") },
            { "", new Region("Mecklenburg-Vorpommern", "MV") },
            { "", new Region("Niedersachsen", "NI") },
            { "", new Region("Nordrhein-Westfalen", "NRW") },
            { "", new Region("Rheinland-Pfalz", "RP") },
            { "", new Region("Saarland", "SL") },
            { "", new Region("Sachsen", "SN") },
            { "", new Region("Sachsen-Anhalt", "ST") },
            { "", new Region("Schleswig-Holstein", "SH") },
            { "", new Region("Thüringen", "TH") }
        };

        return dic;
    }

    public static Region GetRegion(string region, int year, bool includingSundays)
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
}