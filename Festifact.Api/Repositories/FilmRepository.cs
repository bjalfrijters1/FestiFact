using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public FilmRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Film> GetFilm(int id)
        {
            var film = await this.festifactDbContext.Films.FindAsync(id);
            return film;
        }

        public async Task<IEnumerable<Film>> GetFilms()
        {
            var films = await this.festifactDbContext.Films.ToListAsync();
            return films;
        }
    }
}
