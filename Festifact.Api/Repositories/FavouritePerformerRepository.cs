using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class FavouritePerformerRepository : IFavouritePerformerRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public FavouritePerformerRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }
        public async Task DeleteFavouritePerformerAsync(int userId, int showId)
        {
            await this.festifactDbContext.FavouritePerformers.
                Where(show => show.UserId == userId && show.PerformerId == showId).ExecuteDeleteAsync();
        }

        public async Task<FavouritePerformer> AddFavouritePerformerAsync(FavouritePerformerToAddDto favouritePerformerToAddDto)
        {
            var result = await this.festifactDbContext.AddAsync(new FavouritePerformer
            {
                UserId = favouritePerformerToAddDto.UserId,
                PerformerId = favouritePerformerToAddDto.PerformerId
            });
            await festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FavouritePerformer> GetFavouritePerformerAsync(int id)
        {
            var favouritePerformer = await festifactDbContext.FavouritePerformers.FindAsync(id);
            return favouritePerformer;
        }

        public async Task<IEnumerable<FavouritePerformer>> GetFavouritePerformersAsync(int userId)
        {
            var favouritePerformers = await this.festifactDbContext.FavouritePerformers
                .Where(favouritePerformer => favouritePerformer.UserId == userId).ToListAsync();
            return favouritePerformers;
        }
    }
}
