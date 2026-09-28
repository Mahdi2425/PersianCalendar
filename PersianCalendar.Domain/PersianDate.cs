namespace PersianCalendar.Domain
{
    /// <summary>
    /// A Persian (Jalali/Shamsi) date representation used for display.
    /// This is not a persisted table.
    /// </summary>
    public class PersianDate
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public string DayOfWeekName { get; set; } = string.Empty;

        public int DayOfWeek { get; set; }

        public bool IsHoliday { get; set; }

        public string? HolidayName { get; set; }

        public DateTime GregorianDate { get; set; }

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
