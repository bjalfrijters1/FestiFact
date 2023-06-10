using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Festifact.Web.Pages
{
    public class ShowsBase : ComponentBase
    {

        [Inject]
        public IShowService _showService { get; set; }
        public IEnumerable<ShowDto> Shows { get; set; }

        protected ShowToAddDto ShowToAddDto = new();

        protected override async Task OnInitializedAsync()
        {
            Shows = await _showService.GetShows();
        }

        protected async Task AddShow()
        {
            try
            {
                var showDto = await _showService.PostShow(ShowToAddDto);
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

    }
}
