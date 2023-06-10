using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetFilms();
        Task<Film> GetFilm(int id);
        Task<Film> Insert(FilmToAddDto filmToAdd);
    }
}