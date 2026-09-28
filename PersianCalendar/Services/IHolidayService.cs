using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface IHolidayService
    {
        Task<IReadOnlyList<Holiday>> GetByYearAsync(int year, string region = "IR");
        Task<Holiday?> GetAsync(int year, int month, int day, string region = "IR");
        Task<IReadOnlyList<Holiday>> SearchAsync(string name, int? year = null);
    }
}
