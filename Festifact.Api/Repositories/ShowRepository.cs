using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public ShowRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Show> GetShow(int id)
        {
            var show = await this.festifactDbContext.Shows.FindAsync(id);
            return show;
        }

        public async Task<IEnumerable<Show>> GetShows()
        {
            var shows = await this.festifactDbContext.Shows.ToListAsync();
            return shows;
        }

        public async Task<Show> Insert(ShowToAddDto showToAddDto)
        {
            var result = await this.festifactDbContext.AddAsync(new Show
            {
                LocationId = showToAddDto.LocationId,
                PerformerId = showToAddDto.PerformerId,
                FilmId = showToAddDto.FilmId,
                Name = showToAddDto.Name,
                Description = showToAddDto.Description,
                ImageFilePath = showToAddDto.ImageFilePath,
                StartDateTime = (DateTime)showToAddDto.StartDateTime,
                EndDateTime = (DateTime)showToAddDto.EndDateTime,
            });
            await this.festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
