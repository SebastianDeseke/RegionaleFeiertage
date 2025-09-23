using RegionaleFeiertage.Lib.Regions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace RegionaleFeiertage.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private readonly string _varibale;

    [HttpGet]
    public ActionResult<Region> GetAllRegions()
    {

    }
}
