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
    [QueryProperty(nameof(Festival), "Festival")]
    public class FestivalViewModel : BaseViewModel
    {
        public ICommand FavouritesCommand { get; set; }
        public ICommand OrderCommand { get; set; }

        private readonly IFestivalService _festivalService;
        private readonly FestivalListViewModel _festivalListViewModel;

        public FestivalViewModel(IFestivalService festivalService, FestivalListViewModel festivalListViewModel)
        {
            _festivalService = festivalService;
            _festivalListViewModel = festivalListViewModel;
            

            FavouritesCommand = new Command(async () => await FavouriteFestival());
            OrderCommand = new Command(async () => await OrderTicket());
        }

        private Festival _festival;

        public Festival Festival
        {
            get => _festival;
            set
            {

                _festival = value;
                Title = _festival.Name;
                OnPropertyChanged();
            }
        }

        private async Task FavouriteFestival()
        {
           
            await Shell.Current.GoToAsync("..");
        }

        private async Task OrderTicket()
        {
            //add command to add a ticket to tickets.
            await _festivalService.SaveTicketAsync(Festival.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
