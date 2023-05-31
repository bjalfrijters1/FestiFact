﻿using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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
    }
}
