using Festifact.Api.Entities;

namespace Festifact.Api.Repositories.Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int id);
    }
}