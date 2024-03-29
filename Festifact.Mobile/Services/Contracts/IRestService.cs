﻿using Festifact.Mobile.Models;
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
        Task<List<Festival>> FilteredFestivalsAsync(string variable, string value);

        //tickets
        Task<Ticket> SaveTicketAsync(int id);

        //users
        Task<User> RefreshUserAsync(int id);
        Task SaveUserAsync(User user, bool isNewUser);
        Task<User> GetUserByEmailAsync(string email);

        //shows
        Task<List<Show>> RefreshShowsAsync();
        Task<List<Show>> RefreshFavouriteShowsAsync(int userId);
        Task AddFavouriteShowAsync(int userId, int showId);
        Task DeleteFavouriteShowAsync(int userId, int showId);

        //performers
        Task<List<Performer>> RefreshFavouritePerformersAsync(int userId);
        Task<List<Performer>> RefreshPerformersAsync();
        Task AddFavouritePerformerAsync(int userId, int performerId);
        Task DeleteFavouritePerformerAsync(int userId, int performerId);


    }
}
