using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Type = Festifact.Api.Extensions.Enums.Type;
using Microsoft.EntityFrameworkCore;
using Festifact.Api.Extensions.Enums;

namespace Festifact.Api.Repositories
{
    public class FestivalRepository : IFestivalRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public FestivalRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Festival> GetFestival(int id)
        {
            var festival = await this.festifactDbContext.Festivals.FindAsync(id);
            return festival;
        }

        public async Task<IEnumerable<Festival>> GetFestivals()
        {
            var festivals = await this.festifactDbContext.Festivals.ToListAsync();
            return festivals;
        }

        public async Task<Festival> Insert(FestivalToAddDto festivalToAddDto)
        {
            var result = await festifactDbContext.AddAsync(new Festival
            {
                OrganiserId = festivalToAddDto.OrganiserId,
                Name = festivalToAddDto.Name,
                Description = festivalToAddDto.Description,
                Banner = festivalToAddDto.Banner,
                Type = (Type)festivalToAddDto.Type,
                Genre = (Genre)festivalToAddDto.Genre,
                AgeCategory = festivalToAddDto.AgeCategory,
                StartDate = festivalToAddDto.StartDate,
                EndDate = festivalToAddDto.EndDate,
                MaxTickets = festivalToAddDto.MaxTickets,
                TicketsRemaining = festivalToAddDto.TicketsRemaining
            });
            await festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }

        /* public async Task<Festival> Update(FestivalDto festival)
         {
             //var result = await this.festifactDbContext.Update(festival);

             await festifactDbContext.SaveChangesAsync();
             return result.Entity;
         }*/
    }
}
