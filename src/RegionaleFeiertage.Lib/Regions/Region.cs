using RegionaleFeiertage.Lib.PublicHoliday;

namespace RegionaleFeiertage.Lib.Regions;

public class Region
{
    public string Name { get; set; }
    public string Shortname { get; set; }
    public List<Feiertag> Feiertage { get; set; }

    public Region(string name, string shortname, List<Feiertag> feiertage)
    {
        Name = name;
        Shortname = shortname;
        Feiertage = feiertage;
    }

    public override string ToString()
    {
        var result = $"{Name} ({Shortname})";
        foreach (var f in Feiertage)
        {
            result += $"\n  {f}";
        }
        return result;
    }
}
