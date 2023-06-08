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
    public class PerformerListViewModel : BaseViewModel
    {
        private readonly IPerformerService _performerService;

        public ObservableCollection<Performer> Performers { get; set; } = new();

        public ICommand SelectPerformer { get; set; }

        public PerformerListViewModel(IPerformerService service)
        {
            _performerService = service;

            Title = "List of performer items";
            SelectPerformer = new Command<Performer>(async (item) => await SelectionChanged(item));
            _ = RefreshPerformerItems();
        }

        public async Task RefreshPerformerItems()
        {
            Performers.Clear();
            var performers = await _performerService.GetPerformersAsync();
            performers.ForEach(performer => Performers.Add(performer));
        }

        private async Task SelectionChanged(Performer performer)
        {
            if (performer == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Performer), performer }
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
