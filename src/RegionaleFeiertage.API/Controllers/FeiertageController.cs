using Microsoft.AspNetCore.Mvc;
using RegionaleFeiertage.Lib;
using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;

namespace RegionaleFeiertage.API.Controllers;

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

    [HttpGet("{feiertag}/{year}")]
    public ActionResult<string> GetFeiertag(string feiertag, int year)
    {
        var feiertagstr = feiertag.ToLower();
        var feiertaglist = Regionen.AllFeiertage(year).Feiertage;
        foreach (var tag in feiertaglist)
        {
            if (tag.Name.ToLower().Equals(feiertagstr))
            {
                return tag.Name + "\n" +tag.Datum + "\n" + tag.Status;
            }
        }
        return NotFound($"Feiertag {feiertagstr} ist unbekannt.");
    }
}