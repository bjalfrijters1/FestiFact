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
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseMapServiceToken("JwTVmFcwBGnEoPT2vjOu~EhnGqxFTMaUzNkj1EduPTA~AtmflFPQjxpCYfo6VQr9xEWE1igce4Ejb-RLzKaM_IOzNLamQfWrSh3dWSsWw0g_");
                });

            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            builder.Services.AddSingleton<IRestService, RestService>();
            builder.Services.AddSingleton<IFestivalService, FestivalService>();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IShowService, ShowService>();
            builder.Services.AddSingleton<IPerformerService, PerformerService>();
            builder.Services.AddSingleton<IMailService,MailService>();

            builder.Services.AddSingleton<FestivalListPage>();
            builder.Services.AddSingleton<FestivalListViewModel>();
            builder.Services.AddSingleton<FestivalPage>();
            builder.Services.AddSingleton<FestivalViewModel>();
            builder.Services.AddSingleton<UserPage>();
            builder.Services.AddSingleton<UserViewModel>();
            builder.Services.AddSingleton<ShowListPage>();
            builder.Services.AddSingleton<ShowListViewModel>();
            builder.Services.AddSingleton<ShowPage>();
            builder.Services.AddSingleton<ShowViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<FavouriteShowListPage>();
            builder.Services.AddSingleton<FavouriteShowListViewModel>();
            builder.Services.AddSingleton<FavouritePerformerListPage>();
            builder.Services.AddSingleton<FavouritePerformerListViewModel>();
            builder.Services.AddSingleton<PerformerPage>();
            builder.Services.AddSingleton<PerformerViewModel>();
            builder.Services.AddSingleton<PerformerListPage>();
            builder.Services.AddSingleton<PerformerListViewModel>();
            builder.Services.AddSingleton<FavouritePerformer>();
            builder.Services.AddSingleton<FavouritePerformerViewModel>();
            builder.Services.AddSingleton<FavouriteShowPage>();
            builder.Services.AddSingleton<FavouriteShowViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}