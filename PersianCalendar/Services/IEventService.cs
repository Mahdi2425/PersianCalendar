using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface IEventService
    {
        Task<IReadOnlyList<Event>> GetByCalendarAsync(Guid calendarId, DateTime from, DateTime to);
        Task<Event?> GetByIdAsync(Guid id);
        Task<Event> CreateAsync(Event evt);
        Task UpdateAsync(Event evt);
        Task DeleteAsync(Guid id);
    }
}
