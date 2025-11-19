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
public class CalendareFileGeneratorController : ControllerBase
{
    /*using the iCal.Net package to return a iCal with all the Holidays 
    for the given paramaters*/
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();

    private string MakeiCalString(List<Feiertag> feirtage)
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
        if (!regdic.TryGetValue(region, out Region result))
        {
            return NotFound($"Region '{region}' unbekannt.");
        }

        Console.WriteLine("Getting region feiertage data for " + result.Name);
        var feiertage = RegionenService.GetRegion(region, year, includeSonntag).Feiertage;
        return feiertage;
    }

    [HttpGet]
    public ActionResult<string> GetICalString(int year, string region, bool includeSonntag)
    {
        var feiertageResult = MakeFeiertage(year, region, includeSonntag);
        var feiertage = feiertageResult.Value;
        var icalstr = MakeiCalString(feiertage);
        return icalstr;
    }

    [HttpGet ("calendar")]
    [Produces("text/calendar")]
    public IActionResult GetICal(int year, string region, bool includeSonntag)
    {
        var feiertageResult = MakeFeiertage(year, region, includeSonntag);
        var feiertage = feiertageResult.Value;
        var icalstr = MakeiCalString(feiertage);

        // Make the response a proper iCalendar payload. Return as content with the
        // text/calendar MIME type
        var fileName = $"{region}-{year}.ics";
        Response.Headers.ContentDisposition = $"attachment; filename=\"{fileName}\"";
        return Content(icalstr, "text/calendar; charset=utf-8");
    }
}