using PersianCalendar.Application.Contracts;
using PersianCalendar.Domain;
using PersianCalendar.Persistence.Api;

namespace PersianCalendar.Persistence.Services
{
    public class CategoryService(HttpClient http) : ICategoryService
    {
        public Task<IReadOnlyList<EventCategory>> GetAllAsync()
            => ApiHttp.GetList<EventCategory>(http, "api/categories");

        public Task<EventCategory?> GetByIdAsync(int id)
            => ApiHttp.GetOrDefault<EventCategory>(http, $"api/categories/{id}");

        public Task<EventCategory> CreateAsync(EventCategory category)
            => ApiHttp.Post(http, "api/categories", category);

        public Task UpdateAsync(EventCategory category)
            => ApiHttp.Put(http, $"api/categories/{category.Id}", category);

        public Task DeleteAsync(int id)
            => ApiHttp.Delete(http, $"api/categories/{id}");
    }
}
