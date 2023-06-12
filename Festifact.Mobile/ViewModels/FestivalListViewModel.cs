using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Festifact.Mobile.Models;
using Festifact.Mobile.Services;
using Festifact.Mobile.Services.Contracts;
using Festifact.Models.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Mobile.ViewModels
{
    public class FestivalListViewModel : BaseViewModel
    {
        private readonly IFestivalService _festivalService;

        private string _filterText;
        public string FilterText { get => _filterText; set { _filterText = value; OnPropertyChanged(); } }

        private string _filterType;
        public string FilterType { get => _filterType; set { _filterType = value; OnPropertyChanged(); } }
        private ObservableCollection<Festival> _festivals { get; set; } = new ObservableCollection<Festival>();

        public ObservableCollection<Festival> Festivals
        {
            get { return _festivals; }
            set
            {
                _festivals = value;
                OnPropertyChanged(nameof(Festivals));
            }
        }
 
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
            if(!Festivals.Any())
            {
                _ = RefreshFestivalItems();
            }

            if (FilterType.Equals("Genre"))
            {
                Genre result;
                bool exists = Enum.TryParse<Genre>(FilterText, out result);
                
                if (exists)
                {
                    List<Festival> FilteredFestivals = Festivals.ToList();
                    Festivals.Clear();
                    FilteredFestivals.Where(f => f.Genre == result)
                        .ToList()
                        .ForEach(festival => Festivals.Add(festival));
                    if (!Festivals.Any())
                        _ = RefreshFestivalItems();
                }

            }
            if (FilterType.Equals("Type"))
            {
                Type result;
                bool exists = Enum.TryParse<Type>(FilterText, out result);

                if (exists)
                {
                    List<Festival> FilteredFestivals = Festivals.ToList();
                    Festivals.Clear();
                    FilteredFestivals.Where(f => f.Type == result)
                        .ToList()
                        .ForEach(festival => Festivals.Add(festival));
                    if (!Festivals.Any())
                        _ = RefreshFestivalItems();
                }
            }
            else
            {
                Location lkLocation = await GetCurrentLocationAsync();
                List<Festival> FilteredFestivals = Festivals.ToList();
                Festivals.Clear();
                    
                foreach (var festival in FilteredFestivals)
                {
                    festival.FestivalLocation = await GetFestivalLocationAsync(festival);
                    festival.Distance = Location.CalculateDistance(festival.FestivalLocation, lkLocation, 0);

                }
                _ = FilteredFestivals.OrderBy(f => f.Distance);
                FilteredFestivals.ForEach(festival => Festivals.Add(festival));

            }
        }

        private async Task<Location> GetFestivalLocationAsync(Festival festival)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(festival.Address);
                return locations?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if(location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(30)
                    });

                    return location;
                }

                return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
