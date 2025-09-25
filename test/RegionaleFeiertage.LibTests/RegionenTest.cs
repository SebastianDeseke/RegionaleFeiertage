using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;
using Xunit;

namespace RegionaleFeiertage.LibTests;

public class RegionenTest
{
    //for testing Regionen output
    [Fact]
    public void Berlin()
    {
        var Berlin = Regionen.Berlin(2024);

        Assert.Equal("Berlin", Berlin.Name);
        Assert.Equal("B", Berlin.Shortname);
    }

    [Theory]
    [InlineData(1583, 1583, 4, 10)]
    [InlineData(1700, 1700, 4, 11)]
    [InlineData(1800, 1800, 4, 13)]
    [InlineData(1900, 1900, 4, 15)]
    [InlineData(2000, 2000, 4, 23)]
    [InlineData(2100, 2100, 3, 28)]
    [InlineData(1818, 1818, 3, 22)]
    [InlineData(1943, 1943, 4, 25)]
    [InlineData(2038, 2038, 4, 25)]
    [InlineData(1954, 1954, 4, 18)]
    [InlineData(1955, 1955, 4, 10)]
    [InlineData(2011, 2011, 4, 24)]
    [InlineData(2019, 2019, 4, 21)]
    [InlineData(2024, 2024, 3, 31)]
    public void EasterCalculationTest(int year, int expYear, int expMonth, int expDay)
    {
        //2024-03-31
        var result = FeiertageDefinition.Ostern(year);

        Assert.Equal(new DateTime(expYear, expMonth, expDay), result.Datum);
    }

    [Fact]
    public void BadenWürttembergTest()
    {
        var Badewuerttemberg = Regionen.BadenWürttemberg(2023);
        var holidays = Regionen.Deutschland(2023).Feiertage.ToList();
        holidays.Add(FeiertageDefinition.Epiphanias(2023));
        holidays.Add(FeiertageDefinition.Fronleichnam(2023));
        holidays.Add(FeiertageDefinition.Allerheiligen(2023));
        holidays.Sort((a, b) => a.Datum.CompareTo(b.Datum));

        Assert.Equal(expected: holidays, actual: Badewuerttemberg.Feiertage);
    }
}
