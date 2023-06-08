using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FavouritePerformer : ContentPage
{
	public FavouritePerformer(FavouritePerformerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}