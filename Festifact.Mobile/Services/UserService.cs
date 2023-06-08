using Festifact.Mobile.Models;
using Festifact.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services
{
    public class UserService : IUserService
    {
        IRestService _restService;

        public UserService(IRestService service)
        {
            _restService = service;
        }
        public Task EditUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _restService.RefreshUserAsync(id);
        }

        public Task SaveUserAsync(User user, bool isNewUser = false)
        {
            return _restService.SaveUserAsync(user, isNewUser);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _restService.GetUserByEmailAsync(email);
        }
    }
}
