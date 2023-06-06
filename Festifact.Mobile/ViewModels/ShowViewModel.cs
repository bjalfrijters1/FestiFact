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
        //public ICommand FavouritesCommand { get; set; }
        //public ICommand OrderCommand { get; set; }

        private readonly IShowService _showService;
        private readonly ShowListViewModel _showListViewModel;

        public ShowViewModel(IShowService showService, ShowListViewModel showListViewModel)
        {
            _showService = showService;
            _showListViewModel = showListViewModel;

            //FavouritesCommand = new Command(async () => await FavouriteShow());
            //OrderCommand = new Command(async () => await OrderTicket());
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

        /*private async Task FavouriteShow()
        {

            await Shell.Current.GoToAsync("..");
        }*/

        /*private async Task OrderTicket()
        {
            //add command to add a ticket to tickets.
            await _showService.SaveTicketAsync(Show.Id);
            await Shell.Current.GoToAsync("..");
        }*/
    }
}
