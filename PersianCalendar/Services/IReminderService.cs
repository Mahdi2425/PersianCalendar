using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface IReminderService
    {
        Task<IReadOnlyList<Reminder>> GetByEventAsync(Guid eventId);
        Task<Reminder> CreateAsync(Reminder reminder);
        Task UpdateAsync(Reminder reminder);
        Task DeleteAsync(Guid id);
    }
}
