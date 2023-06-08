using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FavouriteShowPage : ContentPage
{
	public FavouriteShowPage(FavouriteShowViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}