using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace RegionaleFeiertage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();

    [HttpGet]
    public ActionResult<List<string>> GetAllRegions()
    {
        var regions = RegionenService.GetAllRegionsString();
        return regions;
    }

    [HttpGet("{regionstr}/{year}")]
    public ActionResult<Region> GetRegion(string regionstr, int year, bool includeSonntage)
    {
        if (regdic.TryGetValue(regionstr, out Region result))
        {
            //getting the full region with feiertage
            var fullregion = RegionenService.GetRegion(regionstr, year, includeSonntage);
            return fullregion;
        }
        else
        {
            throw new ArgumentException($"Region '{regionstr}' unbekannt.");
        }
    }
}
