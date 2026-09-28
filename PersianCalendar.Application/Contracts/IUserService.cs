using PersianCalendar.Domain;

namespace PersianCalendar.Application.Contracts
{
    public interface IUserService
    {
        Task<User?> GetCurrentAsync();
        Task<User> SaveAsync(User user);
    }
}
