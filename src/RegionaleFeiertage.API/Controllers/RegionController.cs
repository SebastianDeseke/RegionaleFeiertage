using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Serilog.Core;

namespace RegionaleFeiertage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();

    [HttpGet]
    public ActionResult<List<string>> GetAllRegionsString()
    {
        var regions = RegionenService.GetAllRegionsString();
        return regions;
    }

    [HttpGet("{regionstr}/{year}")]
    public ActionResult<Region> GetRegion(string regionstr, int year, bool includeSonntage)
    {
        Console.WriteLine("starting if checker");
        var value = RegionenService.Canonicalize(regionstr);
        var result = RegionenService.FullAndShortNameChecker(value, year, includeSonntage);
        return result;
    }
}
