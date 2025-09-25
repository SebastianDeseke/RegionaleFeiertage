using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;

namespace RegionaleFeiertage.LibTests;

public class FeiertageFactoryTest
{

    readonly List<Func<int, Feiertag>> commonholidays =
        [
            FeiertageDefinition.Neujahr,
            FeiertageDefinition.Karfreitag,
            FeiertageDefinition.Ostermontag,
            FeiertageDefinition.TagDerArbeit,
            FeiertageDefinition.ChristiHimmelfahrt,
            FeiertageDefinition.TagDerDeutschenEinheit,
            FeiertageDefinition.Pfingstmontag,
            FeiertageDefinition.Weihnachten,
            FeiertageDefinition.ZweiterWeihnachtstag
        ];

    [Fact]
    public void TestGermanStandardHoliday()
    {
        var year = 2024;
        var result = FeiertageFactory.CreateCommonGermanFeiertagList(year);
        var expected = commonholidays;

        Assert.Equal(expected, result);
    }
}