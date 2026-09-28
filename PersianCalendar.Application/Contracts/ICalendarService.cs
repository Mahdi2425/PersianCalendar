using PersianCalendar.Domain;

namespace PersianCalendar.Application.Contracts
{
    public interface ICalendarService
    {
        Task<IReadOnlyList<Calendar>> GetAllAsync();
        Task<Calendar?> GetByIdAsync(int id);
        Task<Calendar> CreateAsync(Calendar calendar);
        Task UpdateAsync(Calendar calendar);
        Task DeleteAsync(int id);
    }
}
