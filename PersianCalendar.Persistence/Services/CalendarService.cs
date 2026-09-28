using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class CalendarService(HttpClient http) : ICalendarService
    {
        public Task<IReadOnlyList<Calendar>> GetAllAsync()
            => ApiHttp.GetList<Calendar>(http, "api/calendars");

        public Task<Calendar?> GetByIdAsync(int id)
            => ApiHttp.GetOrDefault<Calendar>(http, $"api/calendars/{id}");

        public Task<Calendar> CreateAsync(Calendar calendar)
            => ApiHttp.Post(http, "api/calendars", calendar);

        public Task UpdateAsync(Calendar calendar)
            => ApiHttp.Put(http, $"api/calendars/{calendar.Id}", calendar);

        public Task DeleteAsync(int id)
            => ApiHttp.Delete(http, $"api/calendars/{id}");
    }
}
