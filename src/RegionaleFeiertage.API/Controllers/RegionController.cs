using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;
using Microsoft.AspNetCore.Mvc;

namespace RegionaleFeiertage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController (ILogger<RegionController> logger) : ControllerBase
{
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();
    private readonly ILogger<RegionController> _logger = logger;

    [HttpGet]
    public ActionResult<List<string>> GetAllRegionsString()
    {
        var regions = RegionenService.GetAllRegionsString();
        _logger.LogInformation("GetAllRegions has been called");
        return regions;
    }

    [HttpGet("{regionstr}/{year}")]
    public ActionResult<Region> GetRegion(string regionstr, int year, bool includeSonntage)
    {
        var value = RegionenService.Canonicalize(regionstr);
        var result = RegionenService.FullAndShortNameChecker(value, year, includeSonntage);
        _logger.LogInformation("The checker found the following region: {0}", result.Name);
        return result;
    }
}
