using Microsoft.AspNetCore.Mvc;
using RegionaleFeiertage.Lib;
using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;

namespace RegionaleFeiertage.API;

[ApiController]
[Route("api/[controller]")]
public class FeiertageController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Feiertag>> GetAllFeiertage(int year)
    {
        var feiertage = Regionen.AllFeiertage(year).Feiertage;
        return feiertage;
    }

    [HttpGet("{feiertagstr}/{year}")]
    public ActionResult<string> GetFeiertag(string feiertagstr, int year)
    {
        var feiertaglist = Regionen.AllFeiertage(year).Feiertage;
        foreach (var tag in feiertaglist)
        {
            if (tag.Name.Equals(feiertagstr))
            {
                return tag.Name;
            }
        }
        return NotFound($"Feiertag {feiertagstr} ist unbekannt.");
    }
}