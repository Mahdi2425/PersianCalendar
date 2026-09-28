using PersianCalendar.Domain;

namespace PersianCalendar.Application.Contracts
{
    public interface IReminderService
    {
        Task<IReadOnlyList<Reminder>> GetByEventAsync(int eventId);
        Task<Reminder> CreateAsync(Reminder reminder);
        Task UpdateAsync(Reminder reminder);
        Task DeleteAsync(int id);
    }
}
