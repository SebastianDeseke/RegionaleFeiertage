using Microsoft.AspNetCore.Mvc.Diagnostics;
using RegionaleFeiertage.PublicHoliday;
using static RegionaleFeiertage.PublicHoliday.FeiertageDefinition;

namespace RegionaleFeiertage.Region
{
    public static class Regionen
    {
        public static Region BadenWürttemberg(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Epiphanias, Fronleichnam, Allerheiligen };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Baden-Württemburg", "BW", feiertage);
        }

        public static Region Bayern(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Epiphanias, Fronleichnam, Allerheiligen };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Bayern", "BY", feiertage);
        }

        public static Region Berlin(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (year >= 2019)
            {
                funcs.Add(InternationalerFrauentag);
            }
            if (year == 2020)
            {
                funcs.Add(TagDerBefreiung);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Berlin", "B", feiertage);
        }

        public static Region Brandenburg(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (includeSonntage)
            {
                funcs.Add(Reformationstag);
            }
            else
            {
                funcs.AddRange([Ostern, Pfingsten, Reformationstag]);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Brandenburg", "BB", feiertage);
        }

        public static Region Bremen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (year >= 2018)
            {
                funcs.Add(Reformationstag);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Bremen", "HB", feiertage);
        }

        public static Region Hamburg(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (year >= 2018)
            {
                funcs.Add(Reformationstag);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Hamburg", "HH", feiertage);
        }

        public static Region Hessen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Fronleichnam };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Hessen", "HE", feiertage);
        }

        public static Region MecklenburgVorpommern(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Reformationstag };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Mecklenburg-Vorpommern", "MV", feiertage);
        }

        public static Region Niedersachsen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (year >= 2018)
            {
                funcs.Add(Reformationstag);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Niedersachsen", "NI", feiertage);
        }

        public static Region NordrheinWestfalen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Fronleichnam, Allerheiligen };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Nordrhein-Westfalen", "NRW", feiertage);
        }

        public static Region RheinlandPfalz(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Fronleichnam, Allerheiligen };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Rheinland-Pfalz", "RP", feiertage);
        }

        public static Region Saarland(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Fronleichnam, MariäHimmelfahrt, Allerheiligen };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Saarland", "SL", feiertage);
        }

        public static Region Sachsen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Reformationstag, BußUndBettTag };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Sachsen", "SN", feiertage);
        }

        public static Region SachsenAnhalt(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Epiphanias, Reformationstag };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Sachsen-Anhalt", "ST", feiertage);
        }

        public static Region SchleswigHolstein(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            if (year >= 2018)
            {
                funcs.Add(Reformationstag);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Schleswig-Holstein", "SH", feiertage);
        }

        public static Region Thüringen(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { Reformationstag };
            if (year >= 2019)
            {
                funcs.Add(Weltkindertag);
            }
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Thüringen", "TH", feiertage);
        }

        // Deutschland returns a Region object holding all public holidays that are Common in Germany
        public static Region Deutschland(int year, bool includeSonntage = false)
        {
            var funcs = new List<Func<int, Feiertag>> { };
            var feiertage = FeiertageFactory.CreateFeiertagList(year, funcs);
            return new Region("Deutschland", "DE", feiertage);
        }

        // All returns a Region object holding all public holidays/feast days known to this program.
        // Not all of them are public holidays (basically 'work free' days).
        public static Region All(int year, bool includeSonntage = false)
        {
            /* ffun := []func(int) Feiertag{Neujahr, Epiphanias, HeiligeDreiKönige, Valentinstag,
            HolocaustGedenktag, InternationalerFrauentag, Josefitag,
            Weiberfastnacht, Rosenmontag, Fastnacht, Aschermittwoch, Gründonnerstag, Karfreitag,
            BeginnSommerzeit, Ostermontag, Walpurgisnacht, TagDerArbeit, Staatsfeiertag,
            InternationalerTagDerPressefreiheit, Florianitag, TagDerBefreiung, Muttertag,
            ChristiHimmelfahrt, Vatertag, PfingstMontag, Fronleichnam, InternationalerKindertag,
            TagDesMeeres, Weltflüchtlingstag, MariäHimmelfahrt, Rupertitag, TagDerDeutschenEinheit,
            TagDerVolksabstimming, Nationalfeiertag, Reformationstag, Halloween, BeginnWinterzeit,
            Allerheiligen, Allerseelen, Martinstag, Karnevalsbeginn, Leopolditag, Weltkindertag, BußUndBettag,
            Thanksgiving, Blackfriday, Nikolaus, MariäUnbefleckteEmpfängnis, MariäEmpfängnis,
            Heiligabend, Weihnachten, Christtag, ZweiterWeihnachtsfeiertag, Stefanitag, Silvester}
            */

            var feiern = new List<Func<int, Feiertag>> {Epiphanias, Valentinstag, HolocaustGedenktag,
        Josefitag, Weiberfastnacht, Rosenmontag, Fastnacht, Aschermittwoch, Gruendonnerstag, InternationalerKindertag,
        TagDesMeeres, Weltflüchtlingstag, BeginnSommerzeit, Walpurgisnacht, InternationalerTagDerPressefreiheit,
        Weltknuddeltag, TagDerErde, StarWarsDay, Weltumwelttag, Weltblutspendetag, InternationalerMännertag,
        Florianitag, TagDerBefreiung, Muttertag, Vatertag, Handtuchtag, TowelDay,
        SystemAdministratorAppreciationDay, Rupertitag, TagDerVolksabstimmung, Halloween,
        BeginnWinterzeit, Allerseelen, Martinstag, Karnevalsbeginn, Leopolditag, Weltkindertag, BußUndBettTag,
        Thanksgiving, Blackfriday, Nikolaus, MariäUnbefleckteEmpfängnis, Heiligabend, Silvester
        };


            if (year != 2017)
            {
                feiern.Add(Reformationstag);

            }
            if (year >= 2019)
            {
                feiern.Add(InternationalerFrauentag);

            }
            //I might b lost in the sauce
            feiern.AddRange(FeiertageFactory.CreateCommonGermanFeiertagList(year));


            if (includeSonntage)
            {
                feiern.AddRange([Karnevalssonntag, Palmsonntag, Ostern, Pfingsten,
                    Dreifaltigkeitssonntag, Erntedankfest, Volkstrauertag, Totensonntag,
                    ErsterAdvent, ZweiterAdvent, DritterAdvent, VierterAdvent]);

            }
            var feiernlist = FeiertageFactory.FeiertagFunctionListToFeiertagList(feiern, year);

            //I swear I know how this works
            feiernlist.Sort((a, b) => a.Datum.CompareTo(b.Datum));

            return new Region("Alle", "All", feiernlist);
        }
    }
}