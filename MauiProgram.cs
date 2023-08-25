using MauiSampleApp.Services.Navigation;
using MauiSampleApp.ViewModels;
using MauiSampleApp.Views;
using Microsoft.Extensions.Logging;

namespace MauiSampleApp
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

            #region ViewModels registration

            builder.Services.AddTransient<LoginViewModel>();

            #endregion

            #region Views registration

            builder.Services.AddTransient<LoginPage>();

            #endregion

            #region Service registration

            builder.Services.AddSingleton<INavigationService, NavigationService>();

            #endregion
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}