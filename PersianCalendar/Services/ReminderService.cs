using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of IReminderService.
    /// Stores reminders keyed by event id.
    /// Will be replaced by a backed (SQLite/EF) implementation later.
    /// </summary>
    public class ReminderService : BaseService, IReminderService
    {
        private readonly Dictionary<Guid, Reminder> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns all non-deleted, active reminders for an event.
        /// </summary>
        public Task<IReadOnlyList<Reminder>> GetByEventAsync(Guid eventId)
        {
            lock (_lock)
            {
                var items = _store.Values
                    .Where(r => r.EventId == eventId && !r.IsDeleted && r.IsActive)
                    .ToList();
                return Task.FromResult<IReadOnlyList<Reminder>>(items);
            }
        }

        /// <summary>
        /// Creates a new reminder and returns the stored instance.
        /// </summary>
        public Task<Reminder> CreateAsync(Reminder reminder)
        {
            lock (_lock)
            {
                Touch(reminder);
                _store[reminder.Id] = reminder;
                return Task.FromResult<Reminder>(reminder);
            }
        }

        /// <summary>
        /// Updates an existing reminder in place.
        /// </summary>
        public Task UpdateAsync(Reminder reminder)
        {
            lock (_lock)
            {
                Touch(reminder);
                _store[reminder.Id] = reminder;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Soft-deletes a reminder by id.
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
