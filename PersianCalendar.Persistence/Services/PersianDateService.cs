using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PC = System.Globalization.PersianCalendar;

namespace PersianCalendar.Persistence.Services
{
    public class PersianDateService : IPersianDateService
    {
        private readonly PC _pc = new();

        public PersianDate ToPersian(DateTime gregorian)
        {
            var date = gregorian.Kind == DateTimeKind.Utc
                ? gregorian.ToLocalTime()
                : gregorian;

            var year = _pc.GetYear(date);
            var month = _pc.GetMonth(date);
            var day = _pc.GetDayOfMonth(date);
            var dow = (int)_pc.GetDayOfWeek(date);

            return new PersianDate
            {
                Year = year,
                Month = month,
                Day = day,
                DayOfWeek = dow,
                DayOfWeekName = GetDayOfWeekName(year, month, day),
                GregorianDate = date
            };
        }

        public DateTime ToGregorian(int year, int month, int day)
        {
            return _pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public PersianDate Today() => ToPersian(DateTime.Now);

        public int GetDayOfWeek(int year, int month, int day)
        {
            var g = ToGregorian(year, month, day);
            return (int)_pc.GetDayOfWeek(g);
        }

        public string GetDayOfWeekName(int year, int month, int day)
        {
            return GetDayOfWeek(year, month, day) switch
            {
                0 => "یکشنبه",
                1 => "دوشنبه",
                2 => "سه‌شنبه",
                3 => "چهارشنبه",
                4 => "پنجشنبه",
                5 => "جمعه",
                6 => "شنبه",
                _ => string.Empty
            };
        }

        public int DaysInMonth(int year, int month)
        {
            return month <= 6 ? 31 : month <= 11 ? 30 : IsLeapYear(year) ? 30 : 29;
        }

        public bool IsLeapYear(int year) => _pc.IsLeapYear(year);

        public (int Year, int Month, int Day) GetMonthStart(int year, int month) => (year, month, 1);
    }
}
