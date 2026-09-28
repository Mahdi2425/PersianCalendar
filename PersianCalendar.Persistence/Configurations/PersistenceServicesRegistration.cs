using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersianCalendar.Application.Contracts;
using PersianCalendar.Persistence.Services;

namespace PersianCalendar.Persistence.Configurations
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var baseUrl = configuration["Api:BaseUrl"]
                ?? throw new InvalidOperationException("Api:BaseUrl is missing from appsettings.json.");

            void ConfigureClient(HttpClient client)
            {
                client.BaseAddress = new Uri(baseUrl.EndsWith('/') ? baseUrl : baseUrl + "/");
                client.Timeout = TimeSpan.FromSeconds(30);
            }

            services.AddHttpClient<ICalendarService, CalendarService>(ConfigureClient);
            services.AddHttpClient<IEventService, EventService>(ConfigureClient);
            services.AddHttpClient<ICategoryService, CategoryService>(ConfigureClient);
            services.AddHttpClient<IHolidayService, HolidayService>(ConfigureClient);
            services.AddHttpClient<IReminderService, ReminderService>(ConfigureClient);
            services.AddHttpClient<IUserService, UserService>(ConfigureClient);
            services.AddSingleton<IPersianDateService, PersianDateService>();

            return services;
        }
    }
}
