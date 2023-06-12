using Festifact.Models.Dtos;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Festifact.Web.Pages
{
    public class FestivalSingleBase : ComponentBase
    {
        [Parameter]
        public int? Id { get; set; }

        [Inject]
        public IFestivalService FestivalService { get; set; }

        [Inject]
        public IShowService ShowService { get; set; }

        public string Banner { get; set; } = null;
        public FestivalDto Festival { get; set; } = new();
        public IEnumerable<FestivalPerformanceDto> FestivalPerformances { get; set; }
        public int amountOfShows { get; set; }
        public int amountOfPerformers { get; set; }
        public StatisticsDto Statistics { get; set; } = new();
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Festival = await FestivalService.GetFestival((int)Id);
                if(Festival.Banner == null)
                {
                    Banner = $"images/coolio.png";
                } else
                {
                    Banner = $"images/{Festival.Banner}";
                }
                await GetStatistics();
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

        protected async Task GetStatistics()
        {
            Statistics = await FestivalService.GetStatistics((int)Id);
            FestivalPerformances = await FestivalService.GetFestivalPerformances((int)Id);
            List<int> showIds = FestivalPerformances.Select(x => x.ShowId).Distinct().ToList();
            amountOfShows = FestivalPerformances.Select(x => x.ShowId).Distinct().Count();
            
            List<int> performerIds = new List<int>();
            foreach(int id in showIds)
            {
               if(!performerIds.Contains(id))
                {
                    performerIds.Add(id);
                }
            }
            amountOfPerformers = performerIds.Count();

        }
    }
}
