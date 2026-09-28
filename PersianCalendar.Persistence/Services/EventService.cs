using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class EventService(HttpClient http) : IEventService
    {
        public Task<IReadOnlyList<Event>> GetByCalendarAsync(int calendarId, DateTime from, DateTime to)
            => ApiHttp.GetList<Event>(
                http,
                $"api/calendars/{calendarId}/events?from={Uri.EscapeDataString(from.ToString("o"))}&to={Uri.EscapeDataString(to.ToString("o"))}");

        public Task<Event?> GetByIdAsync(int id)
            => ApiHttp.GetOrDefault<Event>(http, $"api/events/{id}");

        public Task<Event> CreateAsync(Event evt)
            => ApiHttp.Post(http, "api/events", evt);

        public Task UpdateAsync(Event evt)
            => ApiHttp.Put(http, $"api/events/{evt.Id}", evt);

        public Task DeleteAsync(int id)
            => ApiHttp.Delete(http, $"api/events/{id}");
    }
}
