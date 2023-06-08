using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FavouritePerformerListPage : ContentPage
{
	public FavouritePerformerListPage(FavouritePerformerListViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}