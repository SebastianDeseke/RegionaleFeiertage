using System.IO.Compression;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;

namespace RegionaleFeiertage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalendareFileGeneratorController(ILogger<CalendareFileGeneratorController> logger) : ControllerBase
{
    private readonly ILogger<CalendareFileGeneratorController> _logger = logger;

    /*using the iCal.Net package to return a iCal with all the Holidays 
    for the given paramaters*/
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();

    private static string MakeiCalString(List<Feiertag> feirtage)
    {
        var calendar = new Calendar();
        calendar.AddTimeZone(new VTimeZone("Europe/Berlin"));
        var rrule = new RecurrencePattern(FrequencyType.Yearly);
        foreach (var day in feirtage)
        {
            var calendarEvent = new CalendarEvent
            {
                //Name = day.Name,
                Summary = day.Name,
                Start = new CalDateTime(day.Datum),
                End = new CalDateTime(day.Datum.Date.AddDays(1)),
                //Duration = new Duration(1), how do iniate Duration with 1 day?
                //IsAllDay = true,
                RecurrenceRules = new List<RecurrencePattern> { rrule },
                //not the same as the satus I set
                Status = "CONFIRMED",
            };
            calendar.Events.Add(calendarEvent);
        }
        // use the iCal serializer to prevent parent child serialization loop
        var serializer = new CalendarSerializer();
        var serializedCalendar = serializer.SerializeToString(calendar);
        return serializedCalendar;
    }

    //To make feiertage list based on the region and year input
    private ActionResult<List<Feiertag>> MakeFeiertage(int year, string region, bool includeSonntag)
    {
        string regionCan = RegionenService.Canonicalize(region);
        if (!regdic.TryGetValue(region, out Region result))
        {
            _logger.LogInformation("Trygetvalue failed at MakeFeiertage. {Region} not found.", region);
            return NotFound($"Region '{region}' unbekannt.");
        }

        _logger.LogInformation("Getting region feiertage data for {RegionName}", result.Name);
        var feiertage = RegionenService.GetRegion(region, year, includeSonntag).Feiertage;
        return feiertage;
    }

    private void MakeZipFile(int year)
    {
        /*external folder only exists in docker container
        and is for the Zip file output*/
        string readPath = "/external/bical/";
        string zipPath = "/external/result.zip";
        for (int i = 0; i < 17; i++)
        {
            //create a ical file for all 16 bundesländer
            //and save into /external/bical/
        }
        ZipFile.CreateFromDirectory(readPath, zipPath);
        _logger.LogInformation("Created zip file at {ZipPath}", zipPath);
    }

    [HttpGet]
    public ActionResult<string> GetICalString(int year, string region, bool includeSonntag)
    {
        var feiertageResult = MakeFeiertage(year, region, includeSonntag);
        var feiertage = feiertageResult.Value;
        var icalstr = MakeiCalString(feiertage);
        _logger.LogInformation("Generated iCal string for region {Region} in year {Year}", region, year);
        _logger.LogDebug("iCal string content: {ICalString}", icalstr);
        return icalstr;
    }

    [HttpGet("calendar")]
    [Produces("text/calendar")]
    public IActionResult GetICal(int year, string region, bool includeSonntag)
    {
        var feiertageResult = MakeFeiertage(year, region, includeSonntag);
        var feiertage = feiertageResult.Value;
        var icalstr = MakeiCalString(feiertage);
        _logger.LogDebug("Serialized iCal content: {ICalString}", icalstr);

        // Make the response a proper iCalendar payload. Return as content with the
        // text/calendar MIME type
        var fileName = $"{region}-{year}.ics";
        Response.Headers.ContentDisposition = $"attachment; filename=\"{fileName}\"";
        return Content(icalstr, "text/calendar; charset=utf-8");
    }
}