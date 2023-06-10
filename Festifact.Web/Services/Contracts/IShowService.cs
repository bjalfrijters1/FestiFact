using Festifact.Models.Dtos;

namespace Festifact.Web.Services.Contracts
{
    public interface IShowService
    {
        Task<IEnumerable<ShowDto>> GetShows();
        Task<ShowDto> GetShow(int id);
        Task<ShowDto> PostShow(ShowToAddDto showToAddDto);
    }
}
