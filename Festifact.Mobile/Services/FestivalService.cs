using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class FestivalService : IFestivalService
    {
        IRestService _restService;

        public FestivalService(IRestService service)
        {
            _restService = service;
        }

        public Task<List<Festival>> GetFestivalsAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task<List<Festival>> GetFilteredFestivalsAsync(string variable, string value)
        {
            return _restService.FilteredFestivalsAsync(variable, value);
        }

        public Task<Ticket> SaveTicketAsync(int id)
        {
            return _restService.SaveTicketAsync(id);
        }
    }
}
