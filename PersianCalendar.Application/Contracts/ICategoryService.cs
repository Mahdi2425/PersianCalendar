using PersianCalendar.Domain;

namespace PersianCalendar.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<EventCategory>> GetAllAsync();
        Task<EventCategory?> GetByIdAsync(int id);
        Task<EventCategory> CreateAsync(EventCategory category);
        Task UpdateAsync(EventCategory category);
        Task DeleteAsync(int id);
    }
}
