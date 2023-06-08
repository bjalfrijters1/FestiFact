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
    public class ShowViewModel : BaseViewModel
    {
        public ICommand AddToFavouriteCommand { get; set; }

        private readonly IShowService _showService;
        private readonly ShowListViewModel _showListViewModel;
        private readonly UserViewModel _userViewModel;

        public ShowViewModel(IShowService showService, ShowListViewModel showListViewModel, UserViewModel userViewModel)
        {
            _showService = showService;
            _showListViewModel = showListViewModel;

            AddToFavouriteCommand = new Command(async () => await AddFavouriteShow());
            _userViewModel = userViewModel;
        }

        private Show _show;

        public Show Show
        {
            get => _show;
            set
            {
                _show = value;
                Title = "Cool story bro";
                OnPropertyChanged();
            }
        }

        private async Task AddFavouriteShow()
        {
            await _showService.AddFavouriteShowAsync(_userViewModel.User.Id, Show.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
