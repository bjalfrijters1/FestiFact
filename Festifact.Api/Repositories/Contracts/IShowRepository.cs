using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IShowRepository
    {
        Task<IEnumerable<Show>> GetShows();
        Task<Show> GetShow(int id);
    }
}
