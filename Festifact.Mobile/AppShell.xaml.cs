namespace Festifact.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
            Routing.RegisterRoute(nameof(Views.FestivalListPage), typeof(Views.FestivalListPage));
        }
    }
}