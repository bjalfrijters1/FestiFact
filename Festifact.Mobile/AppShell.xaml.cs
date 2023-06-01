namespace Festifact.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(Views.FestivalPage), typeof(Views.FestivalPage));
        }
    }
}