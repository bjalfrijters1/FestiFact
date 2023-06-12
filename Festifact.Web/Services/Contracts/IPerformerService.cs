using Festifact.Models.Dtos;

namespace Festifact.Web.Services.Contracts
{
    public interface IPerformerService
    {
        Task<IEnumerable<PerformerDto>> GetPerformers();
        Task<PerformerDto> GetPerformer(int id);
        Task<PerformerDto> PostPerformer(PerformerToAddDto performerToAddDto);
    }
}
