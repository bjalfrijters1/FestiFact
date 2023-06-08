using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festifact.Mobile.ViewModels
{
    [QueryProperty(nameof(Show), "Show")]
    public class FavouriteShowViewModel : BaseViewModel
    {
        public ICommand RemoveCommand { get; set; }

        private readonly IShowService _showService;
        private readonly ShowListViewModel _showListViewModel;
        private readonly UserViewModel _userViewModel;

        public FavouriteShowViewModel(IShowService showService, ShowListViewModel showListViewModel, UserViewModel userViewModel)
        {
            _showService = showService;
            _showListViewModel = showListViewModel;

            RemoveCommand = new Command(async () => await RemoveFavouriteShow());
            _userViewModel = userViewModel;
        }

        private async Task RemoveFavouriteShow()
        {
            await _showService.DeleteFavouriteShowAsync(_userViewModel.User.Id, Show.Id);
            await Shell.Current.GoToAsync("..");
        }

        private Show _show;

        public Show Show
        {
            get => _show;
            set
            {
                _show = value;
                Title = "Favourite shows";
                OnPropertyChanged();
            }
        }
    }
}
