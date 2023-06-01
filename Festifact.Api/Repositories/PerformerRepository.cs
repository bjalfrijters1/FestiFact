using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public PerformerRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Performer> GetPerformer(int id)
        {
            var performer = await this.festifactDbContext.Performers.FindAsync(id);
            return performer;
        }

        public async Task<IEnumerable<Performer>> GetPerformers()
        {
            var performers = await this.festifactDbContext.Performers.ToListAsync();
            return performers;
        }
    }
}
