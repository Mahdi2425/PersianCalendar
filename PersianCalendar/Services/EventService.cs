using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of IEventService.
    /// Stores events in a thread-safe dictionary and queries by date range.
    /// </summary>
    public class EventService : BaseService, IEventService
    {
        private readonly Dictionary<Guid, Event> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns events belonging to a calendar within the given date range.
        /// </summary>
        public Task<IReadOnlyList<Event>> GetByCalendarAsync(Guid calendarId, DateTime from, DateTime to)
        {
            lock (_lock)
            {
                var items = _store.Values
                    .Where(e => e.CalendarId == calendarId && e.StartDate <= to && e.EndDate >= from)
                    .Where(e => !e.IsDeleted && e.IsActive)
                    .OrderBy(e => e.StartDate)
                    .ToList();
                return Task.FromResult<IReadOnlyList<Event>>(items);
            }
        }

        /// <summary>
        /// Returns a single event by id, or null when not found.
        /// </summary>
        public Task<Event?> GetByIdAsync(Guid id)
        {
            lock (_lock)
            {
                _store.TryGetValue(id, out var item);
                return Task.FromResult<Event?>(item);
            }
        }

        /// <summary>
        /// Creates a new event and returns the stored instance.
        /// </summary>
        public Task<Event> CreateAsync(Event evt)
        {
            lock (_lock)
            {
                Touch(evt);
                _store[evt.Id] = evt;
                return Task.FromResult<Event>(evt);
            }
        }

        /// <summary>
        /// Updates an existing event in place.
        /// </summary>
        public Task UpdateAsync(Event evt)
        {
            lock (_lock)
            {
                Touch(evt);
                _store[evt.Id] = evt;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Soft-deletes an event by id.
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
