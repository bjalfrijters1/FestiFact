using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Festifact.Mobile.Models;
using Festifact.Mobile.Services;
using Festifact.Mobile.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festifact.Mobile.ViewModels
{
    public class FestivalListViewModel : BaseViewModel
    {
        private readonly IFestivalService _festivalService;

        private string _filterText;
        public string FilterText { get => _filterText; set { _filterText = value; OnPropertyChanged(); } }

        private string _filterType;
        public string FilterType { get => _filterType; set { _filterType = value; OnPropertyChanged(); } }
        public ObservableCollection<Festival> Festivals { get; set; } = new();
 
        public ICommand SelectFestival { get; set; }
        public ICommand FilterCommand { get; set; }

        public FestivalListViewModel(IFestivalService service)
        {
            _festivalService = service;

            LoadMauiControls();
            _ = RefreshFestivalItems();
        }

        private void LoadMauiControls()
        {
            Title = "List of festival items";
            SelectFestival = new Command<Festival>(async (item) => await SelectionChanged(item));
            FilterCommand = new Command(async () => await Filter());
        }
        public async Task RefreshFestivalItems()
        {
            Festivals.Clear();
            var festivals = await _festivalService.GetFestivalsAsync();
            festivals.ForEach(festival => Festivals.Add(festival));
        }

        private async Task SelectionChanged(Festival festival)
        {
            if (festival == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Festival), festival }
            };

            try
            {
                await Shell.Current.GoToAsync(nameof(Views.FestivalPage), navigationParameter);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Filter()
        {
            Festivals.Clear();
            var festivals = await _festivalService.GetFilteredFestivalsAsync(FilterType, FilterText);
            festivals.ForEach(festival => Festivals.Add(festival));
            OnPropertyChanged();
        }
    }
}
