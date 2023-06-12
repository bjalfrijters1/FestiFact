using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class LocationsBase : ComponentBase
    {

        [Inject]
        public ILocationService _locationService { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }

        protected LocationToAddDto LocationToAddDto = new();

        protected override async Task OnInitializedAsync()
        {
            Locations = await _locationService.GetLocations();
        }

        protected async Task AddLocation()
        {
            try
            {
                var locationDto = await _locationService.PostLocation(LocationToAddDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

    }
}
