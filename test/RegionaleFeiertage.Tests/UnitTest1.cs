using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;

namespace Feiertage.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var Berlin = Regionen.Berlin(2024);

        Assert.Equal("Berlin", Berlin.Name);
        Assert.Equal("B", Berlin.Shortname);
    }

    [Fact]
    public void TestEasterCalculation()
    {
        //2024-03-31
        var year = 2024;
        var result = FeiertageDefinition.Ostern(year);

        Assert.Equal("2024-03-31", result.Datum.ToString("yyyy-MM-dd"));
    }
}
