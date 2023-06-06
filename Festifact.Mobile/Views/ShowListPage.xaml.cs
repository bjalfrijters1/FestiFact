using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class ShowListPage : ContentPage
{
	public ShowListPage(ShowListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}