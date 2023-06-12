using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class PerformersBase : ComponentBase
    {

        [Inject]
        public IPerformerService _performerService { get; set; }
        public IEnumerable<PerformerDto> Performers { get; set; }

        protected PerformerToAddDto PerformerToAddDto = new();

        protected override async Task OnInitializedAsync()
        {
            Performers = await _performerService.GetPerformers();
        }

        protected async Task AddPerformer()
        {
            try
            {
                var performerDto = await _performerService.PostPerformer(PerformerToAddDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

    }
}
