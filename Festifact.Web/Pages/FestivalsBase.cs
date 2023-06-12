using Festifact.Models.Dtos;
using Festifact.Models.Enums;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Type = Festifact.Models.Enums.Type;

namespace Festifact.Web.Pages
{
    public class FestivalsBase : ComponentBase
    {
        [Inject]
        public IFestivalService _festivalService { get; set; }
        public IEnumerable<FestivalDto> Festivals { get; set; }
        public string ErrorMessage { get; set; }
        public Type Type { get; set; }
        public Genre Genre { get; set; }

        protected FestivalToAddDto festivalToAddDto = new();

        protected override async Task OnInitializedAsync()
        {
            Festivals = await _festivalService.GetFestivals();
        }

        protected async Task AddFestival()
        {
            try
            {
                festivalToAddDto.OrganiserId = 1;
                var festivalDto = await _festivalService.PostFestival(festivalToAddDto);

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
