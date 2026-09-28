using System;
using System.Globalization;
using PersianCalendar.Models;
using PC = System.Globalization.PersianCalendar;

namespace PersianCalendar.Services
{
    /// <summary>
    /// Converts between Persian (Jalali/Shamsi) and Gregorian dates.
    /// </summary>
    public class PersianDateService : IPersianDateService
    {
        private readonly PC _pc = new PC();

public PersianDate ToPersian(DateTime gregorian)
        {
            var utc = gregorian;
            if (gregorian.Kind == DateTimeKind.Unspecified)
            {
                utc = DateTime.Parse(gregorian.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                utc = gregorian.ToUniversalTime();
            }

            var year = _pc.GetYear(utc);
            var month = _pc.GetMonth(utc);
            var day = _pc.GetDayOfMonth(utc);
            var dow = (int)_pc.GetDayOfWeek(utc);

            return new PersianDate
            {
                Year = year,
                Month = month,
                Day = day,
                DayOfWeek = dow,
                DayOfWeekName = GetDayOfWeekName(year, month, day),
                GregorianDate = utc
            };
        }

        public DateTime ToGregorian(int year, int month, int day)
        {
            return _pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public PersianDate Today()
        {
            return ToPersian(DateTime.UtcNow);
        }

        public int GetDayOfWeek(int year, int month, int day)
        {
            var g = ToGregorian(year, month, day);
            return (int)_pc.GetDayOfWeek(g);
        }

        public string GetDayOfWeekName(int year, int month, int day)
        {
            var dow = GetDayOfWeek(year, month, day);

            return dow switch
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

        public bool IsLeapYear(int year)
        {
            return _pc.IsLeapYear(year);
        }

        public (int Year, int Month, int Day) GetMonthStart(int year, int month)
        {
            return (year, month, 1);
        }
    }
}
