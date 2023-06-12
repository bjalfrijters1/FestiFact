using Festifact.Models.Dtos;

namespace Festifact.Web.Services.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetLocations();
        Task<LocationDto> GetLocation(int id);
        Task<LocationDto> PostLocation(LocationToAddDto locationToAddDto);
    }
}
