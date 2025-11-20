using System.Data;
using RegionaleFeiertage.Lib.Service;

namespace RegionaleFeiertage.Lib.PublicHoliday;


/* https://de.wikipedia.org/wiki/Kalenderrechnung

in allen deutschen Bundesländern folgende unbewegliche Feiertage:
01.01. (Neujahr)
01.05. (Maifeiertag)
03.10. (Tag der Deutschen Einheit)
25.12. (1. Weihnachtsfeiertag)
26.12. (2. Weihnachtsfeiertag)

in einigen Bundesländern unbewegliche Feiertage:
06.01. (Heilige Drei Könige)
15.08. (Mariä Himmelfahrt)
31.10. (Reformationstag)
01.11. (Allerheiligen)

bewegliche Feiertage in allen Bundesländern:
2 Tage vor Ostern (Karfreitag)
39 Tage nach Ostern (Christi Himmelfahrt)
49 Tage nach Ostern (Pfingstsonntag)
50 Tage nach Ostern (Pfingstmontag)
60 Tage nach Ostern (Fronleichnam)

Keine Feiertage
46 Tage vor Ostern (Aschermittwoch)
Mittwoch vor dem 23. November (Buß- und Bettag)
24.12. (Heiligabend)
31.12. (Silvester)
*/

/* Thanksgiving
4. Donnerstag im November */
public static class FeiertageDefinition
{
    // ----------------------------

    // Neujahr is NewYear, a fixed date.
    public static Feiertag Neujahr(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 1, 1),
            Name = "Neujahr",
            Status = "official"
        };
    }

    // Epiphanias is Epiphany, a fixed date.
    public static Feiertag Epiphanias(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 1, 6),
            Name = "Epiphanias",
            Status = "regional"
        };
    }

    // HeiligeDreiKönige is another name for Epiphany, a fixed date.
    public static Feiertag HeiligeDreiKoenige(int year)
    {
        var e = Epiphanias(year);
        e.Name = "Heilige drei Könige";
        return e;
    }

    // Weltknuddeltag is World Hug Day or National Hugging Day, a fixed date.
    public static Feiertag Weltknuddeltag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 1, 21),
            Name = "Weltknuddeltag",
            Status = "special"
        };
    }

    // Valentinstag is Valentine's Day, a fixed date.
    public static Feiertag Valentinstag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 2, 14),
            Name = "Valentinstag",
            Status = "recognized"
        };
    }

    // InternationalerTagDesGedenkensAnDieOpferDesHolocaust is (International Holocaust Remembrance Day, a fixed date.
    public static Feiertag HolocaustGedenktag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 1, 27),
            Name = "Internationaler Tag des Gedenkens an die Opfer des Holocaust",
            Status = "special"
        };
    }

    // InternationalerFrauentag is International Women's Day, a fixed date.
    //since 2023 in BE and MV
    public static Feiertag InternationalerFrauentag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 3, 8),
            Name = "Internationaler Frauentag",
            Status = "regional" //nationwide recognized, only in BE and MV off
        };
    }

    // Josefitag is St Joseph's Day, a fixed date.
    public static Feiertag Josefitag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 3, 19),
            Name = "Josefitag",
            Status = "special"
        };
    }

    // Weiberfastnacht is a part of carnival, 52 days before Easter.
    public static Feiertag Weiberfastnacht(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-52),
            Name = "Weiberfastnacht",
            Status = "special"
        };
    }

    // Karnevalssonntag is the sunday of carnival, 49 days before Easter.
    public static Feiertag Karnevalssonntag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-49),
            Name = "Karnevalssonntag",
            Status = "special"
        };
    }

    // Rosenmontag is the monday of carnival, 48 days before Easter.
    public static Feiertag Rosenmontag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-48),
            Name = "Rosenmontag",
            Status = "special"
        };
    }

    // Fastnacht is shrovetide, the Tuesday of carnival, 47 days before Easter.
    public static Feiertag Fastnacht(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-47),
            Name = "Fastnacht",
            Status = "special"
        };
    }

    // Aschermittwoch is Ash Wednesday, 46 days before Easter.
    public static Feiertag Aschermittwoch(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-46),
            Name = "Aschermittwoch",
            Status = "special"
        };
    }

    // Palmsonntag is Palm Sunday , the last Sunday before Easter
    public static Feiertag Palmsonntag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-7),
            Name = "Palmsonntag",
            Status ="special"
        };
    }

    // Gründonnerstag is Holy Thursday or Maundy Thursday, the last Thursday before Eastern
    public static Feiertag Gruendonnerstag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-3),
            Name = "Gründonnerstag",
            Status = "special"
        };
    }

    // Karfreitag is Good Friday, the last Friday before Easter
    public static Feiertag Karfreitag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(-2),
            Name = "Karfreitag",
            Status = "official"
        };
    }

    // Ostern is Easter. Calculated by an extended Gauss algorithm.
    public static Feiertag Ostern(int year)
    {
        RegionenService.YearCheck(year);
        float A, B, C, P, Q, M, N, D, E;

        A = year % 19;
        B = year % 4;
        C = year % 7;
        P = year / 100;
        Q = (int)((13 + 8 * P) / 25);
        M = (int)(15 - Q + P - (int)(P / 4)) % 30;
        N = (int)(4 + P - (int)(P / 4)) % 7;
        D = (19 * A + M) % 30;
        E = (2 * B + 4 * C + 6 * D + N) % 7;
        int days = (int)(22 + D + E);
        int month;
        int day;
        // A corner case,
        // when D is 29
        if ((D == 29) && (E == 6))
        {
            month = 4;
            day = 19;
        }
        // Another corner case,
        // when D is 28
        else if ((D == 28) && (E == 6))
        {
            month = 4;
            day = 18;
        }
        else
        {
            // If days > 31, move to April
            // April = 4th Month
            if (days > 31)
            {
                month = 4;
                day = days - 31;
            }
            // Otherwise, stay on March
            // March = 3rd Month
            else
            {
                month = 3;
                day = days;
            }
        }

        return new Feiertag
        {
            Datum = new DateTime(year, month, day),
            Name = "Ostern",
            Status = "official"
        };
    }

    // BeginnSommerzeit is the start of daylight saving time. Last Sunday of March.
    public static Feiertag BeginnSommerzeit(int year)
    {
        var lastMarchDay = new DateTime(year, 3, 31);
        int daysBack = (7 + (int)lastMarchDay.DayOfWeek) % 7;
        return new Feiertag
        {
            Datum = lastMarchDay.AddDays(-daysBack),
            Name = "Beginn Sommerzeit",
            Status = "special"
        };
    }

    // Ostermontag is Easter Monday, the Monday after Easter.
    public static Feiertag Ostermontag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(1),
            Name = "Ostermontag",
            Status = "official"
        };
    }

    // Tag der Erde is Earth Day, a fixed date.
    public static Feiertag TagDerErde(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 4, 22),
            Name = "Tag der Erde",
            Status = "special"
        };
    }

    // Walpurgisnacht is Walpurgis Night, a fixed date.
    public static Feiertag Walpurgisnacht(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 4, 30),
            Name = "Walpurgisnacht",
            Status = "special"
        };
    }

    // TagDerArbeit is Labour Day, a fixed date.
    public static Feiertag TagDerArbeit(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 1),
            Name = "Tag der Arbeit",
            Status = "official"
        };
    }

    // InternationalerTagDerPressefreiheit is World Press Freedom Day, a fixed date.
    public static Feiertag InternationalerTagDerPressefreiheit(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 3),
            Name = "Internationaler Tag der Pressefreiheit",
            Status = "special"
        };
    }

    // Florianitag is St Florian's Day, a fixed date.
    public static Feiertag Florianitag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 4),
            Name = "Florianitag",
            Status = "special"
        };
    }

    // Star Wars Day is a fixed date.
    public static Feiertag StarWarsDay(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 4),
            Name = "Star Wars Day",
            Status = "special"
        };
    }

    // TagDerBefreiung is Victory in Europe Day, a fixed date.
    public static Feiertag TagDerBefreiung(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 8),
            Name = "Tag der Befreiung",
            Status = "special"
        };
    }

    // Muttertag is Mother's Day oder Mothering Sunday, the second Sunday in May.
    public static Feiertag Muttertag(int year)
    {
        var mayFirst = new DateTime(year, 5, 1);
        int offset = (7 - (int)mayFirst.DayOfWeek) % 7;
        return new Feiertag
        {
            Datum = mayFirst.AddDays(offset + 7),
            Name = "Muttertag",
            Status = "recognized"
        };
    }

    // ChristiHimmelfahrt is Ascension Day, 39 days after Easter, therefore always a Thursday.
    public static Feiertag ChristiHimmelfahrt(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(39),
            Name = "Christi Himmelfahrt",
            Status = "official"
        };
    }

    // Vatertag is Father's Day, same day a Ascension Day, 39 days after Easter, therefore always a Thursday.
    public static Feiertag Vatertag(int year)
    {
        var e = ChristiHimmelfahrt(year);
        e.Name = "Vatertag";
        return e;
    }

    // Handtuchtag is Towel Day, May 25. It is celebrated as a tribute to the author Douglas Adams by his fans.
    public static Feiertag Handtuchtag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 5, 25),
            Name = "Handtuchtag",
            Status = "special"
        };
    }

    // TowelDay is, May 25. It is celebrated as a tribute to the author Douglas Adams by his fans.
    public static Feiertag TowelDay(int year)
    {
        var e = Handtuchtag(year);
        e.Name = "Towel Day";
        return e;
    }

    // Pfingsten is Pentecost, 49 days after Easter.
    public static Feiertag Pfingsten(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(49),
            Name = "Pfingsten",
            Status = "special"
        };
    }

    // Pfingstmontag is Whit Monday, the monday after Pentecost.
    public static Feiertag Pfingstmontag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(50),
            Name = "Pfingstmontag",
            Status = "official"
        };
    }

    // Dreifaltigkeitssonntag is Trinity Sunday, the Sunday after Pentecost
    public static Feiertag Dreifaltigkeitssonntag(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(56),
            Name = "Dreifaltigkeitssonntag",
            Status = "special"
        };
    }

    // Fronleichnam is Corpus Christi, 60 days after Eastern, therefore always a Thursday.
    public static Feiertag Fronleichnam(int year)
    {
        return new Feiertag
        {
            Datum = Ostern(year).Datum.AddDays(60),
            Name = "Fronleichnam",
            Status = "regional" //recognized in NRW
        };
    }

    // InternationalerKindertag is special to Germany and Austrian and
    // is not the same as Weltkindertag (World Children's Day), a fixed date.
    public static Feiertag InternationalerKindertag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 6, 1),
            Name = "Internationaler Kindertag",
            Status = "special"
        };
    }

    // Weltumwelttag is World Environment Day, a fixed date.
    public static Feiertag Weltumwelttag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 6, 5),
            Name = "Weltumwelttag",
            Status = "special"
        };
    }

    // TagDesMeeres is World Oceans Day, a fixed date.
    public static Feiertag TagDesMeeres(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 6, 8),
            Name = "Tag des Meeres",
            Status = "special"
        };
    }

    // Weltblutspendetag is World Blood Donor Day, a fixed date.
    public static Feiertag Weltblutspendetag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 6, 14),
            Name = "Weltblutspendetag",
            Status = "special"
        };
    }

    // Weltflüchtlingstag is World Refugee Day, a fixed date.
    public static Feiertag Weltflüchtlingstag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 6, 20),
            Name = "Weltflüchtlingstag",
            Status = "special"
        };
    }

    // SystemAdministratorAppreciationDay is the last Fridy in July
    public static Feiertag SystemAdministratorAppreciationDay(int year)
    {
        var lastFridayJuly = new DateTime(year, 7, 31);
        int daysBack = (2 + (int)lastFridayJuly.DayOfWeek) % 7;
        return new Feiertag
        {
            Datum = lastFridayJuly.AddDays(-daysBack),
            Name = "System Administrator Appreciation Day",
            Status = "special"
        };
    }

    // MariäHimmelfahrt is Assumption Day, a fixed date.
    public static Feiertag MariäHimmelfahrt(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 8, 15),
            Name = "Mariä Himmelfahrt",
            Status = "regional"
        };
    }

    // Rupertitag is St Rupert's Day, a fixed date.
    public static Feiertag Rupertitag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 9, 24),
            Name = "Rupertitag",
            Status = "special"
        };
    }

    // TagDerDeutschenEinheit is German Unity Day, a fixed date.
    public static Feiertag TagDerDeutschenEinheit(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 10, 3),
            Name = "Tag der deutschen Einheit",
            Status = "official"
        };
    }

    // Erntedankfest is Thanksgiving or Harvest Festival, the first Sunday of October.
    // The german Erntedankfest is not the same than the US Thanksgiving.
    public static Feiertag Erntedankfest(int year)
    {
        var firstOfOctober = new DateTime(year, 10, 1);
        int daysToSunday = ((int)DayOfWeek.Sunday - (int)firstOfOctober.DayOfWeek + 7) % 7;
        return new Feiertag
        {
            Datum = firstOfOctober.AddDays(daysToSunday),
            Name = "Erntedankfest",
            Status = "special"
        };
    }

    // Reformationstag is Reformation Day, a fixed date.
    public static Feiertag Reformationstag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 10, 31),
            Name = "Reformationstag",
            Status = "regional"
        };
    }

    // Halloween is a fixed date.
    public static Feiertag Halloween(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 10, 31),
            Name = "Halloween",
            Status = "special"
        };
    }

    // BeginnWinterzeit is the end of daylight saving time. Last Sunday of October.
    public static Feiertag BeginnWinterzeit(int year)
    {
        var lastOfOctober = new DateTime(year, 10, 31);
        int daysBackToSunday = ((int)lastOfOctober.DayOfWeek + 7) % 7;
        return new Feiertag
        {
            Datum = lastOfOctober.AddDays(-daysBackToSunday),
            Name = "Beginn Winterzeit",
            Status = "special"
        };
    }

    // Allerheiligen is All Saints' Day or Allhallows, a fixed date
    public static Feiertag Allerheiligen(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 1),
            Name = "Allerheiligen",
            Status = "regional"
        };
    }

    // Allerseelen is All Souls' Day, the day after All Saints' Day,
    public static Feiertag Allerseelen(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 2),
            Name = "Allerseelen",
            Status = "special"
        };
    }

    // Martinstag or Skt. Martin is Martinmas, a fixed date
    public static Feiertag Martinstag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 11),
            Name = "Martinstag",
            Status = "special"
        };
    }

    // Internationaler Männertag is International Day Men's Day, a fixed date
    public static Feiertag InternationalerMännertag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 19),
            Name = "Internationaler Männertag",
            Status = "special"
        };
    }

    // Karnevalsbeginn is the beginning of carnival, a fixed date.
    public static Feiertag Karnevalsbeginn(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 11, 11, 11, 11),
            Name = "Karnevalsbeginn",
            Status = "special"
        };
    }

    // Leopolditag is St Leopold's Day, a fixed date.
    public static Feiertag Leopolditag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 11, 15),
            Name = "Leopolditag",
            Status = "special"
        };
    }

    // Weltkindertag is World Children's Day, a fixed date.
    public static Feiertag Weltkindertag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 9, 20),
            Name = "Weltkindertag",
            Status = "regional" //only in TH
        };
    }

    // BußUndBettag is Penance Day, 11 days before the first Sunday in Advent
    public static Feiertag BußUndBettTag(int year)
    {
        var nov22 = new DateTime(year, 11, 22);
        int daysBackToWednesday = ((int)nov22.DayOfWeek + 3) % 7;
        return new Feiertag
        {
            Datum = nov22.AddDays(-daysBackToWednesday),
            Name = "Buß- und Bettag",
            Status = "regional"
        };
    }

    // Thanksgiving in the US, the fourth Thursday of November.
    public static Feiertag Thanksgiving(int year)
    {
        var nov1 = new DateTime(year, 11, 1);
        int daysToThursday = ((int)DayOfWeek.Thursday - (int)nov1.DayOfWeek + 7) % 7;
        return new Feiertag
        {
            Datum = nov1.AddDays(21 + daysToThursday),
            Name = "Thanksgiving (US)",
            Status = "special"
        };
    }

    // Blackfriday is the Friday after Thanksgiving.
    public static Feiertag Blackfriday(int year)
    {
        var thanksgiving = Thanksgiving(year);
        return new Feiertag
        {
            Datum = thanksgiving.Datum.AddDays(1),
            Name = "Blackfriday",
            Status = "special"
        };
    }

    // Volkstrauertag is Remembrance Sunday, the second sunday before the first Sunday in Advent
    public static Feiertag Volkstrauertag(int year)
    {
        var ersterAdvent = ErsterAdvent(year);
        return new Feiertag
        {
            Datum = ersterAdvent.Datum.AddDays(-14),
            Name = "Volkstrauertag",
            Status = "recognized"
        };
    }

    // Nikolaus is St Nicholas' Day, a fixed date
    public static Feiertag Nikolaus(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 6),
            Name = "Nikolaus",
            Status = "recognized"
        };
    }

    // MariäUnbefleckteEmpfängnis is Day of Immaculate Conception, a fixed date.
    public static Feiertag MariäUnbefleckteEmpfängnis(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 8),
            Name = "Mariä unbefleckte Empfängnis",
            Status = "special"
        };
    }

    // Totensonntag is Sunday in commemoration of the dead, the last Sunday before the fourth Sunday in Advent
    public static Feiertag Totensonntag(int year)
    {
        var vierterAdvent = VierterAdvent(year);
        return new Feiertag
        {
            Datum = vierterAdvent.Datum.AddDays(-28),
            Name = "Totensonntag",
            Status = "recognized"
        };
    }

    // ErsterAdvent is the first Sunday in Advent
    public static Feiertag ErsterAdvent(int year)
    {
        var vierterAdvent = VierterAdvent(year);
        return new Feiertag
        {
            Datum = vierterAdvent.Datum.AddDays(-21),
            Name = "Erster Advent",
            Status = "recognized"
        };
    }

    // ZweiterAdvent is the second Sunday in Advent
    public static Feiertag ZweiterAdvent(int year)
    {
        var vierterAdvent = VierterAdvent(year);
        return new Feiertag
        {
            Datum = vierterAdvent.Datum.AddDays(-14),
            Name = "Zweiter Advent",
            Status = "recognized"
        };
    }

    // DritterAdvent is the third Sunday in Advent
    public static Feiertag DritterAdvent(int year)
    {
        var vierterAdvent = VierterAdvent(year);
        return new Feiertag
        {
            Datum = vierterAdvent.Datum.AddDays(-7),
            Name = "Dritter Advent",
            Status = "recognized"
        };
    }

    // VierterAdvent is the fourth Sunday in Advent
    public static Feiertag VierterAdvent(int year)
    {
        var dec24 = new DateTime(year, 12, 24);
        int daysBackToSunday = ((int)dec24.DayOfWeek + 7) % 7;
        return new Feiertag
        {
            Datum = dec24.AddDays(-daysBackToSunday),
            Name = "Vierter Advent",
            Status = "recognized"
        };
    }

    // Heiligabend is Christmas Eve, the last day before Christmas.
    public static Feiertag Heiligabend(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 24),
            Name = "Heiligabend",
            Status = "recognized"
        };
    }

    // Weihnachten is Christmas, a fixed date
    public static Feiertag Weihnachten(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 25),
            Name = "Weihnachten",
            Status = "official"
        };
    }

    // ZweiterWeihnachtstag is day after Christmas, a fixed date 
    //also known as Boxing Day
    public static Feiertag ZweiterWeihnachtstag(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 26),
            Name = "Zweiter Weihnachtstag",
            Status = "official"
        };
    }

    // Silvester is NewYearsEve, a fixed date.
    public static Feiertag Silvester(int year)
    {
        return new Feiertag
        {
            Datum = new DateTime(year, 12, 31),
            Name = "Silvester",
            Status = "official"
        };
    }

}