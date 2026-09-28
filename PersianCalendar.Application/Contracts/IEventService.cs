using PersianCalendar.Domain;

namespace PersianCalendar.Application.Contracts
{
    public interface IEventService
    {
        Task<IReadOnlyList<Event>> GetByCalendarAsync(int calendarId, DateTime from, DateTime to);
        Task<Event?> GetByIdAsync(int id);
        Task<Event> CreateAsync(Event evt);
        Task UpdateAsync(Event evt);
        Task DeleteAsync(int id);
    }
}
