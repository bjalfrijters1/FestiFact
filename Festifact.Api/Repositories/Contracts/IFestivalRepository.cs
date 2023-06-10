using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFestivalRepository
    {
        Task<IEnumerable<Festival>> GetFestivals();
        Task<Festival> GetFestival(int id);
        Task<Festival> Insert(FestivalToAddDto festivalToAddDto);
        Task<Festival> Update(FestivalDto festivalDto);
    }
}
