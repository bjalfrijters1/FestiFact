using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using Festifact.Mobile.ViewModels;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Testing
{
    public class MobileTests
    {
        /*
         * To successfully run this test, comment the function "LoadMauiControls()" in the constructor of FestivalListViewModel(), 
         * since this tests ViewModel and we don't actually use the MAUI app here, we need to disable the controls in order to test the unit
         * 
         */
        [Fact]
        public async Task ShouldPopulateFestivals()
        {
            var festivals = new List<Festival>();
            var festival = new Festival();
            festivals.Add(festival);

            var festivalService = Substitute.For<IFestivalService>();
            festivalService.GetFestivalsAsync().Returns(festivals);

            var festivalListVM = new FestivalListViewModel(festivalService);
            //await festivalListVM.RefreshFestivalItems();

            Assert.True(festivalListVM.Festivals?.Count > 0);
        }

        /*
         * To successfully run this test, comment the function "LoadMauiControls()" in the constructor of FestivalListViewModel(), 
         * since this tests ViewModel and we don't actually use the MAUI app here, we need to disable the controls in order to test the unit
         * 
         */
        [Fact]
        public async Task ShouldPopulateShows()
        {
            var shows = new List<Show>();
            var show = new Show();
            shows.Add(show);

            var showService = Substitute.For<IShowService>();
            showService.GetShowsAsync().Returns(shows);

            var showListVM = new ShowListViewModel(showService);

            Assert.True(showListVM.Shows?.Count > 0);
        }
    }
}
