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
    public ActionResult<List<string>> GetAllRegions(string region, int year, bool inculdeSonntage)
    {
        var regions = RegionenService.GetAllRegionsString(year);
        return regions;
    }

    [HttpGet("{regionstr}/{year}")]
    public ActionResult<Region> GetRegion(string regionstr, int year)
    {
        if (regdic.TryGetValue(regionstr, out Region result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException($"Region '{regionstr}' unbekannt.");
        }
    }
}
