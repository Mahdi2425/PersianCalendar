using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// A public holiday for a given year/region.
    /// Holidays are read-only reference data surfaced on the calendar.
    /// </summary>
    public class Holiday : EntityBase
    {
        /// <summary>Display name of the holiday.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Persian (Jalali) day of the month (1-31).</summary>
        public int Day { get; set; }

        /// <summary>Persian (Jalali) month (1-12).</summary>
        public int Month { get; set; }

        /// <summary>Persian (Jalali) year.</summary>
        public int Year { get; set; }

        /// <summary>Region/culture code, e.g. "IR".</summary>
        public string Region { get; set; } = "IR";

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }
    }
}