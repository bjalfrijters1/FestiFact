using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IPerformerRepository
    {
        Task<IEnumerable<Performer>> GetPerformers();
        Task<Performer> GetPerformer(int id);
    }
}