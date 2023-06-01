using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FestivalPage : ContentPage
{
	public FestivalPage(FestivalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}
}