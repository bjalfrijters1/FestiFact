using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<User> Insert(UserToAddDto user);
        Task<User> GetUserByEmail(string email);
    }
}
