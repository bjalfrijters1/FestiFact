namespace Festifact.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(Views.FestivalPage), typeof(Views.FestivalPage));
            Routing.RegisterRoute(nameof(Views.UserPage), typeof(Views.UserPage));
            Routing.RegisterRoute(nameof(Views.ShowPage), typeof(Views.ShowPage));
            Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(Views.FavouriteShowListPage), typeof(Views.FavouriteShowListPage));
            Routing.RegisterRoute(nameof(Views.FavouritePerformerListPage), typeof(Views.FavouritePerformerListPage));
            Routing.RegisterRoute(nameof(Views.PerformerPage), typeof(Views.PerformerPage));
            Routing.RegisterRoute(nameof(Views.FavouritePerformer), typeof(Views.FavouritePerformer));
            Routing.RegisterRoute(nameof(Views.FavouriteShowPage), typeof(Views.FavouriteShowPage));

        }
    }
}