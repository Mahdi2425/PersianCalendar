using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of IHolidayService.
    /// Stores public holidays keyed by Persian year/month/day and region.
    /// </summary>
    public class HolidayService : BaseService, IHolidayService
    {
        private readonly Dictionary<Guid, Holiday> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns all non-deleted, active holidays for a Persian year and region.
        /// </summary>
        public Task<IReadOnlyList<Holiday>> GetByYearAsync(int year, string region = "IR")
        {
            lock (_lock)
            {
                var items = _store.Values
                    .Where(h => h.Year == year && h.Region == region && !h.IsDeleted && h.IsActive)
                    .OrderBy(h => h.Month)
                    .ThenBy(h => h.Day)
                    .ToList();
                return Task.FromResult<IReadOnlyList<Holiday>>(items);
            }
        }

        /// <summary>
        /// Returns a single holiday matching year/month/day/region, or null.
        /// </summary>
        public Task<Holiday?> GetAsync(int year, int month, int day, string region = "IR")
        {
            lock (_lock)
            {
                var item = _store.Values
                    .FirstOrDefault(h => h.Year == year && h.Month == month && h.Day == day && h.Region == region && !h.IsDeleted && h.IsActive);
                return Task.FromResult<Holiday?>(item);
            }
        }

        /// <summary>
        /// Searches holidays by name (case-insensitive), optionally filtered by year.
        /// </summary>
        public Task<IReadOnlyList<Holiday>> SearchAsync(string name, int? year = null)
        {
            lock (_lock)
            {
                var q = _store.Values
                    .Where(h => !h.IsDeleted && h.IsActive)
                    .Where(h => h.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
                if (year.HasValue)
                    q = q.Where(h => h.Year == year.Value);
                var items = q.OrderBy(h => h.Year).ThenBy(h => h.Month).ThenBy(h => h.Day).ToList();
                return Task.FromResult<IReadOnlyList<Holiday>>(items);
            }
        }
    }
}
