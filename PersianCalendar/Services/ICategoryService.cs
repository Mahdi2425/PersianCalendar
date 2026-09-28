using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<EventCategory>> GetAllAsync();
        Task<EventCategory?> GetByIdAsync(Guid id);
        Task<EventCategory> CreateAsync(EventCategory category);
        Task UpdateAsync(EventCategory category);
        Task DeleteAsync(Guid id);
    }
}
