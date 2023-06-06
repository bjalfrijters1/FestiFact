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
    public class ShowListViewModel : BaseViewModel
    {
        private readonly IShowService _showService;

        public ObservableCollection<Show> Shows { get; set; } = new();

        public ICommand SelectShow { get; set; }

        public ShowListViewModel(IShowService service)
        {
            _showService = service;

            Title = "List of show items";
            SelectShow = new Command<Show>(async (item) => await SelectionChanged(item));
            _ = RefreshShowItems();
        }

        public async Task RefreshShowItems()
        {
            Shows.Clear();
            var shows = await _showService.GetShowsAsync();
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
                await Shell.Current.GoToAsync(nameof(Views.ShowPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
