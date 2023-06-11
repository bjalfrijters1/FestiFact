using Festifact.Models.Dtos;

namespace Festifact.Web.Services.Contracts
{
    public interface IFestivalService
    {
        Task<IEnumerable<FestivalDto>> GetFestivals();
        Task<FestivalDto> GetFestival(int id);
        Task<FestivalDto> PostFestival(FestivalToAddDto festivalToAddDto);
        Task<FestivalDto> PutFestival(FestivalDto festival);
        Task<StatisticsDto> GetStatistics(int id);

        Task<IEnumerable<FestivalPerformanceDto>> GetFestivalPerformances(int id);

    }
}
