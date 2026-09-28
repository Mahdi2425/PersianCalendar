using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    /// <summary>
    /// In-memory implementation of IUserService.
    /// Stores a single current user profile.
    /// Will be replaced by a backed (SQLite/EF) implementation later.
    /// </summary>
    public class UserService : BaseService, IUserService
    {
        private readonly Dictionary<Guid, User> _store = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns the first non-deleted, active user (current user).
        /// </summary>
        public Task<User?> GetCurrentAsync()
        {
            lock (_lock)
            {
                var item = _store.Values
                    .FirstOrDefault(u => !u.IsDeleted && u.IsActive);
                return Task.FromResult<User?>(item);
            }
        }

        /// <summary>
        /// Creates or updates a user profile and returns the stored instance.
        /// </summary>
        public Task<User> SaveAsync(User user)
        {
            lock (_lock)
            {
                Touch(user);
                _store[user.Id] = user;
                return Task.FromResult<User>(user);
            }
        }
    }
}
