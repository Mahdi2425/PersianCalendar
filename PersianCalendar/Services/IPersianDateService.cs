using System;
using System.Collections.Generic;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// Converts between Persian (Jalali) and Gregorian dates.
    /// </summary>
    public interface IPersianDateService
    {
        PersianDate ToPersian(DateTime gregorian);
        DateTime ToGregorian(int year, int month, int day);
        PersianDate Today();
        int GetDayOfWeek(int year, int month, int day);
        string GetDayOfWeekName(int year, int month, int day);
        int DaysInMonth(int year, int month);
        bool IsLeapYear(int year);
        (int Year, int Month, int Day) GetMonthStart(int year, int month);
    }
}
