using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface ICalendarService
    {
        Task<IReadOnlyList<Calendar>> GetAllAsync();
        Task<Calendar?> GetByIdAsync(Guid id);
        Task<Calendar> CreateAsync(Calendar calendar);
        Task UpdateAsync(Calendar calendar);
        Task DeleteAsync(Guid id);
    }
}
