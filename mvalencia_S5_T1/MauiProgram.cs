using Microsoft.Extensions.Logging;
using mvalencia_S5_T1.Models;
using mvalencia_S5_T1.Utils;

namespace mvalencia_S5_T1
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

            return builder.Build();
        }
    }
}