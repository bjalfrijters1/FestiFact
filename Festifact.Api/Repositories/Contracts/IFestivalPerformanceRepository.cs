using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IFestivalPerformanceRepository
    {
        Task<FestivalPerformance> GetFestivalPerformance(int id);
        Task<IEnumerable<FestivalPerformance>> GetAllFestivalPerformances();
        Task<FestivalPerformance> Insert(FestivalPerformanceToAddDto fpToAddDto);
    }
}
