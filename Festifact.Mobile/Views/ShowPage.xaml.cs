using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class ShowPage : ContentPage
{
	public ShowPage(ShowViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}