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
        private readonly IFestivalService _festivalService;
        private readonly FestivalListViewModel _festivalListViewModel;

        public FestivalViewModel(IFestivalService festivalService, FestivalListViewModel festivalListViewModel)
        {
            _festivalService = festivalService;
            _festivalListViewModel = festivalListViewModel;
        }

        private Festival _festival;

        public Festival Festival
        {
            get => _festival;
            set
            {
                _festival = value;
            }
        }
    }
}
