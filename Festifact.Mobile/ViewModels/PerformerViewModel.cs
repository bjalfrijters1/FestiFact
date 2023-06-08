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
    [QueryProperty(nameof(Performer), "Performer")]
    public class PerformerViewModel : BaseViewModel
    {
        public ICommand AddToFavouriteCommand { get; set; }

        private readonly IPerformerService _performerService;
        private readonly UserViewModel _userViewModel;

        public PerformerViewModel(IPerformerService performerService, UserViewModel userViewModel)
        {
            _performerService = performerService;
            //_performerListViewModel = performerListViewModel;

            AddToFavouriteCommand = new Command(async () => await FavouritePerformer());
            _userViewModel = userViewModel;
        }

        private Performer _performer;

        public Performer Performer
        {
            get => _performer;
            set
            {
                _performer = value;
                Title = _performer.Name;
                OnPropertyChanged();
            }
        }

        private async Task FavouritePerformer()
        {
            await _performerService.AddFavouritePerformerAsync(_userViewModel.User.Id, Performer.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
