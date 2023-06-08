using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}