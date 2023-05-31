
using Festifact.Mobile.Services.Contracts;
using Festifact.Mobile.ViewModels;

namespace Festifact.Mobile.Views;

public partial class FestivalListPage : ContentPage
{
	public FestivalListPage(FestivalListViewModel festivalListViewModel)
	{
		InitializeComponent();
		BindingContext = festivalListViewModel;
	}

}