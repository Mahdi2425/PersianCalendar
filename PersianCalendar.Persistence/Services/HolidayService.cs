using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class HolidayService(HttpClient http) : IHolidayService
    {
        public Task<IReadOnlyList<Holiday>> GetByYearAsync(int year, string region = "IR")
            => ApiHttp.GetList<Holiday>(http, $"api/holidays?year={year}&region={Uri.EscapeDataString(region)}");

        public Task<Holiday?> GetAsync(int year, int month, int day, string region = "IR")
            => ApiHttp.GetOrDefault<Holiday>(
                http,
                $"api/holidays/date?year={year}&month={month}&day={day}&region={Uri.EscapeDataString(region)}");

        public Task<IReadOnlyList<Holiday>> SearchAsync(string name, int? year = null)
        {
            var url = $"api/holidays/search?name={Uri.EscapeDataString(name)}";
            if (year.HasValue)
                url += $"&year={year.Value}";

            return ApiHttp.GetList<Holiday>(http, url);
        }
    }
}
