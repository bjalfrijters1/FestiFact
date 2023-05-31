using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IOrganiserRepository
    {
        Task<IEnumerable<Organiser>> GetOrganisers();
        Task<Organiser> GetOrganiserById(int id);
    }
}
