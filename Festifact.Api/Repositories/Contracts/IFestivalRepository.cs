using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFestivalRepository
    {
        Task<IEnumerable<Festival>> GetFestivals();
        Task<Festival> GetFestival(int id);
    }
}
