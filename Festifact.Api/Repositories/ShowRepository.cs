using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
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
    }
}
