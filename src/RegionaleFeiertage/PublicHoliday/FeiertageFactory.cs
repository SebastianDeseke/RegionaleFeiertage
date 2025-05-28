using System;
using RegionaleFeiertage.Regions;
using static RegionaleFeiertage.PublicHoliday.FeiertageDefinition;

namespace RegionaleFeiertage.PublicHoliday
{
    public static class FeiertageFactory
    {
        //All the common public holidays in Germany (9 total as of 2017)
        public static List<Func<int, Feiertag>> CreateCommonGermanFeiertagList(int year)
        {
            var feiern = new List<Func<int, Feiertag>>
            {
                Neujahr,
                Karfreitag,
                Ostermontag,
                TagDerArbeit,
                ChristiHimmelfahrt,
                TagDerDeutschenEinheit,
                Pfingstmontag,
                Weihnachten,
                ZweiterWeihnachtstag
            };

            if (year == 2017)
            {
                feiern.Add(Reformationstag);
            }
            return feiern;
        }

        public static List<Feiertag> FeiertagFunctionListToFeiertagList(List<Func<int, Feiertag>> funcs, int year)
        {
            //ah yes, lambda expretion
            return funcs.Select(f => f(year)).ToList();
        }

        public static List<Region> RegionFunctionListToRegionList(List<Func<int, bool, Region>> funcs, int year, bool includeSonntage)
        {
            //again
            return funcs.Select(f => f(year, includeSonntage)).ToList();
        }

        public static List<Feiertag> CreateFeiertagList(int year, List<Func<int, Feiertag>> extraFuncs)
        {
            var feiern = CreateCommonGermanFeiertagList(year);

            foreach (var f in extraFuncs)
            {
                if (year != 2017 || f(year).Name != Reformationstag(year).Name)
                {
                    feiern.Add(f);
                }
            }
            var list = FeiertagFunctionListToFeiertagList(feiern, year);
            list.Sort((a, b) => a.Datum.CompareTo(b.Datum));
            return list;
        }
    }
}