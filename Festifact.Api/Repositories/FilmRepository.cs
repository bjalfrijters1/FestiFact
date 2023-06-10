using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
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

        public async Task<Film> Insert(FilmToAddDto filmToAdd)
        {
            var result = await this.festifactDbContext.AddAsync(new Film
            {
                Name = filmToAdd.Name,
                Description = filmToAdd.Description,
                Director = filmToAdd.Director,
                Year = filmToAdd.Year,
                CountryOfOrigin = filmToAdd.CountryOfOrigin,
                Actors = filmToAdd.Actors
            });

            await this.festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
