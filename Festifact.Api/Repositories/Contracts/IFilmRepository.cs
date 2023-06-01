using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetFilms();
        Task<Film> GetFilm(int id);
    }
}