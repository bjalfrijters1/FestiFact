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
        }
    }
}