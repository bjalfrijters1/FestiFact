﻿using Festifact.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services.Contracts
{
    public interface IFestivalService
    {
        Task<List<Festival>> GetFestivalsAsync();
        Task<Ticket> SaveTicketAsync(int id);

        Task<List<Festival>> GetFilteredFestivalsAsync(string variable, string value);

    }
}
