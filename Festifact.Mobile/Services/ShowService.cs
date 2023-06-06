﻿using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class ShowService : IShowService
    {
        IRestService _restService;

        public ShowService(IRestService service)
        {
            _restService = service;
        }

        public Task<List<Show>> GetShowsAsync()
        {
            return _restService.RefreshShowsAsync();
        }
    }
}