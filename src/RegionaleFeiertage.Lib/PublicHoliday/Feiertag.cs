namespace RegionaleFeiertage.Lib.PublicHoliday;

public class Feiertag
{
    public DateTime Datum { get; set; }
    public string Name { get; set; }
    //official -> free day      unofficial -> not always recognized      recognized -> noted but not free        regional -> regional off
    public string Status { get; set; }

    public override string ToString()
    {
        return $"{Datum:yyyy-MM-dd} - {Name}";
    }
}