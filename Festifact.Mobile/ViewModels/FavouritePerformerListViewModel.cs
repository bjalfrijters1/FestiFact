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
    public class FavouritePerformerListViewModel : BaseViewModel
    {
        private readonly IPerformerService _showService;

        public ObservableCollection<Performer> Performers { get; set; } = new();

        public ICommand SelectPerformer { get; set; }

        public FavouritePerformerListViewModel(IPerformerService service)
        {
            _showService = service;

            Title = "Favourite shows";
            SelectPerformer = new Command<Performer>(async (item) => await SelectionChanged(item));

        }

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                _ = RefreshPerformerItems();
                OnPropertyChanged();
            }
        }

        public async Task RefreshPerformerItems()
        {
            Performers.Clear();
            var shows = await _showService.GetFavouritePerformersAsync(User.Id);
            shows.ForEach(show => Performers.Add(show));
        }

        private async Task SelectionChanged(Performer show)
        {
            if (show == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Performer), show }
            };

            try
            {
                await Shell.Current.GoToAsync(nameof(Views.PerformerPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
