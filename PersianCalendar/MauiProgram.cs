using Microsoft.Extensions.Logging;
using PersianCalendar.Services;

namespace PersianCalendar
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // ---- Domain services (interfaces + implementations) ----
            builder.Services.AddScoped<ICalendarService, CalendarService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IHolidayService, HolidayService>();
            builder.Services.AddScoped<IReminderService, ReminderService>();
            builder.Services.AddScoped<IPersianDateService, PersianDateService>();
            builder.Services.AddScoped<IUserService, UserService>();

            return builder.Build();
        }
    }
}