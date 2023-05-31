using Festifact.Mobile.Services;
using Festifact.Mobile.Services.Contracts;
using Festifact.Mobile.ViewModels;
using Festifact.Mobile.Views;
using Microsoft.Extensions.Logging;

namespace Festifact.Mobile
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

            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            builder.Services.AddSingleton<IRestService, RestService>();
            builder.Services.AddSingleton<IFestivalService, FestivalService>();

            builder.Services.AddSingleton<FestivalListPage>();
            builder.Services.AddSingleton<FestivalListViewModel>();
            builder.Services.AddSingleton<FestivalPage>();
            builder.Services.AddSingleton<FestivalViewModel>();



#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}