using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FavouriteShowListPage : ContentPage
{
	public FavouriteShowListPage(FavouriteShowListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}