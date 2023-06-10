using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Extensions.Enums;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Type = Festifact.Api.Extensions.Enums.Type;

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

        public async Task<Performer> Insert(PerformerToAddDto performerToAddDto)
        {
            var result = await this.festifactDbContext.AddAsync(new Performer
            {
                Name = performerToAddDto.Name,
                Description = performerToAddDto.Description,
                ImageFilePath = performerToAddDto.ImageFilePath,
                CountryOfOrigin = performerToAddDto.CountryOfOrigin,
                Type = (Type)performerToAddDto.Type,
                Genre = (Genre)performerToAddDto.Genre
            });
            await this.festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
