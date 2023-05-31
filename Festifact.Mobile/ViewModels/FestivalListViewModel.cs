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
    public class FestivalListViewModel : BaseViewModel
    {
        private readonly IFestivalService _festivalService;

        public ObservableCollection<Festival> Festivals { get; set; } = new();
      
        public ICommand SelectFestival { get; set; }

        public FestivalListViewModel(IFestivalService service)
        {
            _festivalService = service;

            Title = "List of festival items";
            SelectFestival = new Command<Festival>(async (item) => await SelectionChanged(item));
            _ = RefreshFestivalItems();
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
                { nameof(festival), festival }
            };

            try
            {
                await Shell.Current.GoToAsync(nameof(Views.FestivalPage), navigationParameter);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
