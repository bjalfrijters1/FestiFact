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
        //public ICommand FavouritesCommand { get; set; }
        //public ICommand OrderCommand { get; set; }

        private readonly IPerformerService _performerService;
        //private readonly PerformerListViewModel _performerListViewModel;

        public PerformerViewModel(IPerformerService performerService)
        {
            _performerService = performerService;
            //_performerListViewModel = performerListViewModel;

            //FavouritesCommand = new Command(async () => await FavouritePerformer());
            //OrderCommand = new Command(async () => await OrderTicket());
        }

        private Performer _performer;

        public Performer Performer
        {
            get => _performer;
            set
            {
                _performer = value;
                Title = "Cool story bro";
                OnPropertyChanged();
            }
        }

        /*private async Task FavouritePerformer()
        {

            await Shell.Current.GoToAsync("..");
        }*/

        /*private async Task OrderTicket()
        {
            //add command to add a ticket to tickets.
            await _performerService.SaveTicketAsync(Performer.Id);
            await Shell.Current.GoToAsync("..");
        }*/
    }
}
