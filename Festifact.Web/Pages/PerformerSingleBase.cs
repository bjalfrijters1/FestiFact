using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class PerformerSingleBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IPerformerService _performerService { get; set; }

        public PerformerDto Performer { get; set; } = new();
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Performer = await _performerService.GetPerformer(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
