using Festifact.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task SaveUserAsync(User user, bool isNewUser);
        Task EditUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
