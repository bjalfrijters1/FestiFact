using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class FestivalPerformanceRepository : IFestivalPerformanceRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public FestivalPerformanceRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<FestivalPerformance> GetFestivalPerformance(int id)
        {
            var festivalPerformance = await this.festifactDbContext.FestivalPerformances.FindAsync(id);
            return festivalPerformance;
        }

        public async Task<IEnumerable<FestivalPerformance>> GetAllFestivalPerformances()
        {
            var festivalPerformances = await this.festifactDbContext.FestivalPerformances.ToListAsync();
            return festivalPerformances;
        }

        public async Task<FestivalPerformance> Insert(FestivalPerformanceToAddDto fpToAddDto)
        {
            var result = await this.festifactDbContext.FestivalPerformances.AddAsync(new FestivalPerformance
            {
                FestivalId = fpToAddDto.FestivalId,
                ShowId = fpToAddDto.ShowId,
            });
            await this.festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
