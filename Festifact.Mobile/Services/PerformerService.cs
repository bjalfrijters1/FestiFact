using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class PerformerService : IPerformerService
    {
        IRestService _restService;

        public PerformerService(IRestService service)
        {
            _restService = service;
        }

        public Task AddFavouritePerformerAsync(int userId, int performerId)
        {
            return _restService.AddFavouritePerformerAsync(userId, performerId);
        }

        public Task<List<Performer>> GetFavouritePerformersAsync(int userId)
        {
            return _restService.RefreshFavouritePerformersAsync(userId);
        }

        public Task<List<Performer>> GetPerformersAsync()
        {
            return _restService.RefreshPerformersAsync();
        }

    }
}
