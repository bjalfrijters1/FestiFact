using CommunityToolkit.Mvvm.ComponentModel;
using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festifact.Mobile.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public class FavouriteShowListViewModel : BaseViewModel
    {
        private readonly IShowService _showService;

        public ObservableCollection<Show> Shows { get; set; } = new();

        public ICommand SelectShow { get; set; }

        public FavouriteShowListViewModel(IShowService service)
        {
            _showService = service;

            Title = "Favourite shows";
            SelectShow = new Command<Show>(async (item) => await SelectionChanged(item));
            
        }

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                _ = RefreshShowItems();
                OnPropertyChanged();
            }
        }

        public async Task RefreshShowItems()
        {
            Shows.Clear();
            var shows = await _showService.GetFavouriteShowsAsync(User.Id);
            shows.ForEach(show => Shows.Add(show));
        }

        private async Task SelectionChanged(Show show)
        {
            if (show == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Show), show }
            };

            try
            {
                await Shell.Current.GoToAsync(nameof(Views.FavouriteShowPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
