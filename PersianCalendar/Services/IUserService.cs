using System;
using System.Threading.Tasks;
using PersianCalendar.Models;

namespace PersianCalendar.Services
{
    public interface IUserService
    {
        Task<User?> GetCurrentAsync();
        Task<User> SaveAsync(User user);
    }
}
