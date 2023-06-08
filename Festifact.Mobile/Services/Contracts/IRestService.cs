using Festifact.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services.Contracts
{
    public interface IRestService
    {
        //festivals
        Task<List<Festival>> RefreshDataAsync();

        //tickets
        Task SaveTicketAsync(int id);

        //users
        Task<User> RefreshUserAsync(int id);
        Task SaveUserAsync(User user, bool isNewUser);
        Task<User> GetUserByEmailAsync(string email);

        //shows
        Task<List<Show>> RefreshShowsAsync();
        Task<List<Show>> RefreshFavouriteShowsAsync(int userId);


    }
}
