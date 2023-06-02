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
        Task<List<Festival>> RefreshDataAsync();
        Task SaveTicketAsync(int id);
    }
}
