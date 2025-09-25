namespace RegionaleFeiertage.Lib.PublicHoliday;

public class Feiertag
{
    public DateTime Datum { get; set; }
    public string Name { get; set; }
    //official -> standard free day      special -> not always recognized      recognized -> noted but not free        regional -> regional off
    public string Status { get; set; }

    public override string ToString()
    {
        return $"{Datum:yyyy-MM-dd} - {Name}";
    }

    //Assert.Equal() was comparing object references instead of actual content. 
    //Even with identical dates and names, different object instances were considered unequal.
    public override bool Equals(object obj)
    {
        if (obj is not Feiertag other) return false;
        return Datum == other.Datum && Name == other.Name && Status == other.Status;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Datum, Name, Status);
    }
}