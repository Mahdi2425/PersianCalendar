using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// Base service providing common helpers for CRUD services.
    /// Concrete services inherit from this to share logic.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// Filters an in-memory collection applying soft-delete and active-state rules.
        /// </summary>
        protected static IEnumerable<T> ApplyBaseFilters<T>(IEnumerable<T> source)
            where T : EntityBase
        {
            foreach (var item in source)
            {
                if (!item.IsDeleted && item.IsActive)
                    yield return item;
            }
        }

        /// <summary>
        /// Updates the UpdatedAt timestamp before persisting.
        /// </summary>
        protected static void Touch<T>(T entity) where T : EntityBase
        {
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
