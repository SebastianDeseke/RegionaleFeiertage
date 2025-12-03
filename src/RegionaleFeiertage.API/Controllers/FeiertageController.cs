using Microsoft.AspNetCore.Mvc;
using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;

namespace RegionaleFeiertage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeiertageController (ILogger<FeiertageController> logger): ControllerBase
{
    private readonly ILogger<FeiertageController> _logger = logger;

    [HttpGet]
    public ActionResult<List<Feiertag>> GetAllFeiertage(int year)
    {
        var feiertage = Regionen.AllFeiertage(year).Feiertage;
        _logger.LogInformation("GetAllFeiertage has been called");
        return feiertage;
    }

    [HttpGet("{feiertag}/{year}")]
    public ActionResult<string> GetFeiertag(string feiertag, int year)
    {
        var feiertagstr = RegionenService.Canonicalize(feiertag);
        var feiertaglist = Regionen.AllFeiertage(year).Feiertage;
        foreach (var tag in feiertaglist)
        {
            if (tag.Name.ToLower().Equals(feiertagstr))
            {
                _logger.LogInformation("Successfully found the feiertag {0}", tag.Name);
                return tag.Name + "\n" +tag.Datum + "\n" + tag.Status;
            }
        }
        _logger.LogInformation("Feiertag {0} ist unbekannt.", feiertagstr);
        return NotFound($"Feiertag {feiertagstr} ist unbekannt.");
    }
}