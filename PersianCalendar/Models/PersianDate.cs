using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// A Persian (Jalali/Shamsi) date representation.
    /// Used for displaying and serializing calendar grid data.
    /// </summary>
    public class PersianDate
    {
        /// <summary>Persian year.</summary>
        public int Year { get; set; }

        /// <summary>Persian month (1-12).</summary>
        public int Month { get; set; }

        /// <summary>Persian day (1-31).</summary>
        public int Day { get; set; }

        /// <summary>Day of week name in Persian, e.g. "دوشنبه".</summary>
        public string DayOfWeekName { get; set; } = string.Empty;

        /// <summary>Day of week index (0=Saturday).</summary>
        public int DayOfWeek { get; set; }

        /// <summary>Whether this date is a public holiday.</summary>
        public bool IsHoliday { get; set; }

        /// <summary>Optional holiday name when IsHoliday is true.</summary>
        public string? HolidayName { get; set; }

        /// <summary>Corresponding Gregorian date (UTC).</summary>
        public DateTime GregorianDate { get; set; }

        /// <summary>Empty constructor for serialization.</summary>
        public PersianDate() { }

        public PersianDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString()
        {
            return $"{Year}/{Month:00}/{Day:00}";
        }
    }
}