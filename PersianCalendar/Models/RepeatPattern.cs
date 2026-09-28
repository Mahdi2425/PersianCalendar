using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// Defines how an event recurs.
    /// Stored as a single enum on the event; expand on read for the calendar grid.
    /// </summary>
    public enum RepeatPattern
    {
        None = 0,
        Daily = 1,
        Weekly = 2,
        BiWeekly = 3,
        Monthly = 4,
        Yearly = 5,
        Custom = 6
    }
}