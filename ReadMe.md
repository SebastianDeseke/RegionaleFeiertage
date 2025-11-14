# 🇩🇪 Feiertage.NET
A C# library that provides functions for calculating German (and some international) public holidays.
Based on the structure and logic of the original [feiertage](https://github.com/wlbr/feiertage) Go package.
**Regional Public Holidays (en) Regionale Feiertage Ergänzen (de)**

## ✨ Features

- Calculates **fixed** and **movable** holidays (e.g., Easter, Reformationstag, Karfreitag, etc.)
- Includes regional holidays such as **Rupertitag**, **Mariä Empfängnis**, **Epiphanias**, etc.
- Supports special days like **Totensonntag**, **Karnevalsbeginn**, **Erster Advent**, and **Black Friday**
- Fully translated from Go to idiomatic and testable C# code
- Easily extendable and grouped by logic in static methods

## 📦 Usage

There are 3 folders under /src that cover different parts of this project. There is the Library (Lib), Command line interface (CLI) and the API therefor (API). Both the CLI and the API use the logic in the Library.

### Command Line Interface (CLI)

Under /src/RegionalFeiertage.CLI/:
```bash
dotnet run -- --region <Bundesland> <Jahr>
```

For example:
```bash
dotnet run -- --region Berlin 2022
```

### API

Under /src/RegionalFeiertage.API/:
```bash
dotnet run
```
Then under locahost got to /swagger to use swagger ui

## Method Usage

```csharp
using Feiertage;

// Get a single holiday
var easter = Feiertagsrechner.Ostersonntag(2025);
Console.WriteLine($"{easter.Name}: {easter.Datum.ToShortDateString()}");

// Or get a full list for a year
var all = Feiertagsrechner.AllFeiertage(2025);
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
        Datum = new DateTime(year, month, day),
        Name = "Feiertagsname"
        Status = "status"
    };
}
```

The Feiertag class contains:

```csharp
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
}
```

The Region class contains:

```csharp
public class Region {
    public string Name { get; set; }
    public string Shortname { get; set; }
    public List<Feiertag> Feiertage { get; set; }
}
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
This project is licensed under the GNU General Public License v3.0.
For alternative licensing options (e.g., commercial use), please contact me.
