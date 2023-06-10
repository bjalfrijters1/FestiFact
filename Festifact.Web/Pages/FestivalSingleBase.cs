using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class FestivalSingleBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IFestivalService FestivalService { get; set; }

        public FestivalDto Festival { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Festival = await FestivalService.GetFestival(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task EditFestival()
        {
            try
            {
                await FestivalService.PutFestival(Festival);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
