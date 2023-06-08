using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class PerformerPage : ContentPage
{
	public PerformerPage(PerformerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}