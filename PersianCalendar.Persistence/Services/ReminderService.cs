using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class ReminderService(HttpClient http) : IReminderService
    {
        public Task<IReadOnlyList<Reminder>> GetByEventAsync(int eventId)
            => ApiHttp.GetList<Reminder>(http, $"api/events/{eventId}/reminders");

        public Task<Reminder> CreateAsync(Reminder reminder)
            => ApiHttp.Post(http, "api/reminders", reminder);

        public Task UpdateAsync(Reminder reminder)
            => ApiHttp.Put(http, $"api/reminders/{reminder.Id}", reminder);

        public Task DeleteAsync(int id)
            => ApiHttp.Delete(http, $"api/reminders/{id}");
    }
}
