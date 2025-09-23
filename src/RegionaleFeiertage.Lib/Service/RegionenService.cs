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

    public static Region GetRegion(string region, int year, bool includingSundays)
    {
        var search = Canonicalize(region);
        var allRegions = Regionen.GetAllRegions(year, includingSundays);

        foreach (var r in allRegions)
        {
            if (Canonicalize(r.Name).Equals(search) || Canonicalize(r.Shortname).Equals(search))
            {
                return r;
            }
        }
        throw new ArgumentException($"Region '{region}' unbekannt.");
    }
}