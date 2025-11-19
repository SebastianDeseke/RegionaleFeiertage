using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Microsoft.AspNetCore.Mvc;
using RegionaleFeiertage.Lib;
using RegionaleFeiertage.Lib.PublicHoliday;
using RegionaleFeiertage.Lib.Regions;
using RegionaleFeiertage.Lib.Service;

namespace RegionaleFeiertage.API;

public class CalendareFileGeneratorController : ControllerBase
{
    /*using the iCal.Net package to return a iCal with all the Holidays 
    for the given paramaters*/
    private readonly Dictionary<string, Region> regdic = RegionenService.GetAllRegionsDictionary();

    public Calendar MakeiCal(List<Feiertag> feirtage)
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
                Status = "CONFIRMED",
            };
            calendar.Events.Add(calendarEvent);
        }
        return calendar;
    }

    [HttpGet]
    public ActionResult<Calendar> GetICalFile(int year, string region, bool includeSonntag)
    {
        var ical = new Calendar();
        if (regdic.TryGetValue(region, out Region result))
        {
            Console.WriteLine("Getting region feiertage data for " + result.Name);
            var feiertage = RegionenService.GetRegion(region, year, includeSonntag).Feiertage;
            ical = MakeiCal(feiertage);
        }
        else
        {
            ical = null;
            return NotFound($"Region '{region}' unbekannt.");
        }
        return ical;
    }
}