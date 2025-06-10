# 🇩🇪 Feiertage.NET
A C# library that provides functions for calculating German (and some international) public holidays.
Based on the structure and logic of the original [feiertage](https://github.com/wlbr/feiertage) Go package.
**Regional Public Holidays (en) Regionale Feiertage Ergänzen (de)**

## ✨ Features

- Calculates **fixed** and **movable** holidays (e.g., Easter, Reformationstag, Karfreitag, etc.)
- Includes regional holidays such as **Rupertitag**, **Leopolditag**, **Mariä Empfängnis**, etc.
- Supports special days like **Totensonntag**, **Karnevalsbeginn**, **Erster Advent**, and **Black Friday**
- Fully translated from Go to idiomatic and testable C# code
- Easily extendable and grouped by logic in static methods

## 📦 Usage

```bash
dotnet run -- --region <Bundesland> <Jahr>
```

## Method Usage

```csharp
using Feiertage;

// Get a single holiday
var easter = Feiertagsrechner.Ostersonntag(2025);
Console.WriteLine($"{easter.Name}: {easter.Datum.ToShortDateString()}");

// Or get a full list for a year (example if you implement it)
var all = Feiertagsrechner.AlleFeiertage(2025);
foreach (var tag in all)
{
    Console.WriteLine($"{tag.Name}: {tag.Datum:d}");
}
```

## 📚 Structure

All holiday methods follow the pattern:

```csharp
public static Feiertag Feiertagsname(int year)
{
    return new Feiertag
    {
        //calculations happen here
        Datum = new DateTime(...),
        Name = "Feiertagsname"
    };
}
```

The Feiertag class contains:

```csharp
public class Feiertag
{
    public DateTime Datum { get; set; }
    public string Name { get; set; }
}

public override string ToString() {}
```

## Covered Holidays

- Fixed date holidays (e.g., Neujahr, Weihnachten, Silvester)
- Easter-related movable holidays (e.g., Karfreitag, Pfingsten)
- Sunday-relative holidays (e.g., Erntedankfest, Advent Sundays)
- Country-specific or cultural days (e.g., Tag der deutschen Einheit, Martinstag)
- Special and modern observances (e.g., Black Friday, Karnevalsbeginn)

## Planned Improvements

- Regional filtering (e.g., Bavaria-only holidays)
- Wrong input and error handling
- Feiertagsrechner.AlleFeiertage(int year) convenience method
- Unit tests using xUnit
- NuGet package publication

## License

