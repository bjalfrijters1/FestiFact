using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}