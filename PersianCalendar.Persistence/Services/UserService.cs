using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class UserService(HttpClient http) : IUserService
    {
        public Task<User?> GetCurrentAsync()
            => ApiHttp.GetOrDefault<User>(http, "api/users/me");

        public async Task<User> SaveAsync(User user)
        {
            if (user.Id == 0)
                return await ApiHttp.Post(http, "api/users", user);

            await ApiHttp.Put(http, $"api/users/{user.Id}", user);
            return user;
        }
    }
}
