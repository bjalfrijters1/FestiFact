using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFavouritePerformerRepository
    {
        Task<IEnumerable<FavouritePerformer>> GetFavouritePerformersAsync(int userId);
        Task DeleteFavouritePerformerAsync(int userId, int performerId);
        Task<FavouritePerformer> AddFavouritePerformerAsync(FavouritePerformerToAddDto favouritePerformerToAddDto);
        Task<FavouritePerformer> GetFavouritePerformerAsync(int id);
    }
}
