using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace RegionaleFeiertage.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private readonly Dictionary<string, Region> Region;

    [HttpGet]
    public ActionResult<Region> GetAllRegions(string region, int year, bool inculdeSonntage)
    {
        return RegionenService.GetRegion(region, year, inculdeSonntage);
    }
}
