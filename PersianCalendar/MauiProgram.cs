using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PersianCalendar.Persistence.Configurations;

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

            using var settingsFile = FileSystem.OpenAppPackageFileAsync("appsettings.json").GetAwaiter().GetResult();
            var settingsCopy = new MemoryStream();
            settingsFile.CopyTo(settingsCopy);
            settingsCopy.Position = 0;
            builder.Configuration.AddJsonStream(settingsCopy);

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.ConfigurePersistenceServices(builder.Configuration);

            return builder.Build();
        }
    }
}
