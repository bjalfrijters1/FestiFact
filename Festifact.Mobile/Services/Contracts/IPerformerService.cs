using Festifact.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services.Contracts
{
    public interface IPerformerService
    {
        Task<List<Performer>> GetPerformersAsync();
        Task<List<Performer>> GetFavouritePerformersAsync(int userId);
        Task AddFavouritePerformerAsync(int userId, int performerId);
        Task DeleteFavouritePerformerAsync(int userId, int performerId);
    }
}
