using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class ShowSingleBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IShowService _showService { get; set; }
        
        public ShowDto Show { get; set; }= new();
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Show = await _showService.GetShow(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        /*protected async Task EditFestival()
        {
            try
            {
                await _showService.PutShow(Show);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }*/
    }
}
