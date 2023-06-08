using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFavouriteShowRepository
    {
        Task<IEnumerable<FavouriteShow>> GetFavouriteShowsAsync(int userId);
        Task DeleteFavouriteShowAsync(int userId, int showId);
        Task<FavouriteShow> AddFavouriteShowAsync(FavouriteShowToAdd favouriteShowToAdd);
        Task<FavouriteShow> GetFavouriteShowAsync(int id);
    }
}
