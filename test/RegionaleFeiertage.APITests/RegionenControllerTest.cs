using RegionaleFeiertage.Lib.qPublicHoliday;
using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;
using Xunit;

namespace RegionaleFeiertage.APITests;

public class RegionenControllerTest
{
    [Fact]
    public void FullNameAndShortNameCheckerTest()
    {
        var regionfullstr = "Berlin";
        var regionshortstr = "B";

        var result = RegionenService.FullAndShortNameChecker();
    }
}