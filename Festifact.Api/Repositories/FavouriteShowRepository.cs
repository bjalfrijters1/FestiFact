using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class FavouriteShowRepository : IFavouriteShowRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public FavouriteShowRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task DeleteFavouriteShowAsync(int userId, int showId)
        {
            await this.festifactDbContext.FavouriteShows.
                Where(show => show.UserId == userId && show.ShowId == showId).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<FavouriteShow>> GetFavouriteShowsAsync(int userId)
        {
            var favouriteShows = await this.festifactDbContext.FavouriteShows
                .Where(favouriteShow => favouriteShow.UserId == userId).ToListAsync();
            return favouriteShows;
        }

        public async Task<FavouriteShow> AddFavouriteShowAsync(FavouriteShowToAdd favouriteShowToAdd)
        {
            var result = await this.festifactDbContext.AddAsync(new FavouriteShow
            {
                UserId = favouriteShowToAdd.UserId,
                ShowId = favouriteShowToAdd.ShowId
            });
            await festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FavouriteShow> GetFavouriteShowAsync(int id)
        {
            var favouriteShow = await festifactDbContext.FavouriteShows.FindAsync(id);
            return favouriteShow;
        }
    }
}
