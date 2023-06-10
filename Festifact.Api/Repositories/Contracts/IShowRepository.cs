using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IShowRepository
    {
        Task<IEnumerable<Show>> GetShows();
        Task<Show> GetShow(int id);
        Task<Show> Insert(ShowToAddDto showToAddDto);
    }
}
