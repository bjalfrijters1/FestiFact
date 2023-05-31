using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class OrganiserRepository : IOrganiserRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public OrganiserRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<IEnumerable<Organiser>> GetOrganisers()
        {
            var organisers = await this.festifactDbContext.Organisers.ToListAsync();
            return organisers;
        }

        public async Task<Organiser> GetOrganiserById(int id)
        {
            var organiser = await this.festifactDbContext.Organisers.FindAsync(id);
            return organiser;
        }
    }
}
