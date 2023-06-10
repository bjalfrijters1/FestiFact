using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public LocationRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Location> GetLocation(int id)
        {
            var location = await this.festifactDbContext.Locations.FindAsync(id);
            return location;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            var locations = await this.festifactDbContext.Locations.ToListAsync();
            return locations;
        }

        public async Task<Location> Insert(LocationToAddDto locationToAddDto)
        {
            var result = await festifactDbContext.AddAsync(new Location
            {
                Name = locationToAddDto.Name,
                Capacity = locationToAddDto.Capacity
            });
            await festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
