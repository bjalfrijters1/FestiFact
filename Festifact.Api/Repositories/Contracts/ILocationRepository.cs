using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(int id);
        Task<Location> Insert(LocationToAddDto locationToAddDto);
    }
}