using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class PerformerListPage : ContentPage
{
	public PerformerListPage(PerformerListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}