using System;

namespace RegionaleFeiertage.PublicHoliday
{
    public class Feiertag
    {
        public DateTime Datum { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Datum:yyyy-mm-dd} - {Name}"
        }
    }
}