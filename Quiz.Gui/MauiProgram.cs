using Microsoft.Extensions.Logging;
using Quiz.Gui.ViewModels;
using Syncfusion.Maui.Core.Hosting;

namespace Quiz.Gui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            

#if DEBUG
    		builder.Logging.AddDebug();
            builder.ConfigureSyncfusionCore();
#endif

            return builder.Build();
        }
    }
}
