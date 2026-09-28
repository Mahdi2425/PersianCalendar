using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of ICategoryService.
    /// Stores event categories in a thread-safe dictionary.
    /// </summary>
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly Dictionary<Guid, EventCategory> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns all non-deleted, active categories.
        /// </summary>
        public Task<IReadOnlyList<EventCategory>> GetAllAsync()
        {
            lock (_lock)
            {
                var items = ApplyBaseFilters(_store.Values).ToList();
                return Task.FromResult<IReadOnlyList<EventCategory>>(items);
            }
        }

        /// <summary>
        /// Returns a single category by id, or null when not found.
        /// </summary>
        public Task<EventCategory?> GetByIdAsync(Guid id)
        {
            lock (_lock)
            {
                _store.TryGetValue(id, out var item);
                return Task.FromResult<EventCategory?>(item);
            }
        }

        /// <summary>
        /// Creates a new category and returns the stored instance.
        /// </summary>
        public Task<EventCategory> CreateAsync(EventCategory category)
        {
            lock (_lock)
            {
                Touch(category);
                _store[category.Id] = category;
                return Task.FromResult<EventCategory>(category);
            }
        }

        /// <summary>
        /// Updates an existing category in place.
        /// </summary>
        public Task UpdateAsync(EventCategory category)
        {
            lock (_lock)
            {
                Touch(category);
                _store[category.Id] = category;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        /// Soft-deletes a category by id.
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
