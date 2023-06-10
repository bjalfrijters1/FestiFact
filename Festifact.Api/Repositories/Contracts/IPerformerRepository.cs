using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IPerformerRepository
    {
        Task<IEnumerable<Performer>> GetPerformers();
        Task<Performer> GetPerformer(int id);
        Task<Performer> Insert(PerformerToAddDto performerToAddDto);
    }
}