using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of ICalendarService.
    /// Stores calendars in a thread-safe dictionary.
    /// </summary>
    public class CalendarService : BaseService, ICalendarService
    {
        private readonly Dictionary<Guid, Calendar> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns all non-deleted, active calendars.
        /// </summary>
        public Task<IReadOnlyList<Calendar>> GetAllAsync()
        {
            lock (_lock)
            {
                var items = ApplyBaseFilters(_store.Values).ToList();
                return Task.FromResult<IReadOnlyList<Calendar>>(items);
            }
        }

        /// <summary>
        /// Returns a single calendar by id, or null when not found.
        /// </summary>
        public Task<Calendar?> GetByIdAsync(Guid id)
        {
            lock (_lock)
            {
                _store.TryGetValue(id, out var item);
                return Task.FromResult<Calendar?>(item);
            }
        }

        /// <summary>
        /// Creates a new calendar and returns the stored instance.
        /// </summary>
        public Task<Calendar> CreateAsync(Calendar calendar)
        {
            lock (_lock)
            {
                Touch(calendar);
                _store[calendar.Id] = calendar;
                return Task.FromResult<Calendar>(calendar);
            }
        }

        /// <summary>
        /// Updates an existing calendar in place.
        /// </summary>
        public Task UpdateAsync(Calendar calendar)
        {
            lock (_lock)
            {
                Touch(calendar);
                _store[calendar.Id] = calendar;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Soft-deletes a calendar by id.
        /// </summary>
        public Task DeleteAsync(Guid id)
        {
            lock (_lock)
            {
                if (_store.TryGetValue(id, out var item))
                {
                    item.IsDeleted = true;
                    item.DeletedAt = DateTime.UtcNow;
                }
                return Task.CompletedTask;
            }
        }
    }
}
