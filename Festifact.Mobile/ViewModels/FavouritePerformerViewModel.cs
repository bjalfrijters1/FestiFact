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
    public class FavouritePerformerViewModel : BaseViewModel
    {
        public ICommand RemoveCommand { get; set; }

        private readonly IPerformerService _performerService;
        private readonly UserViewModel _userViewModel;

        public FavouritePerformerViewModel(IPerformerService performerService, UserViewModel userViewModel)
        {
            _performerService = performerService;
            RemoveCommand = new Command(async () => await RemoveFromFavourites());

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
        
        public async Task RemoveFromFavourites()
        {
            await this._performerService.DeleteFavouritePerformerAsync(_userViewModel.User.Id, Performer.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
