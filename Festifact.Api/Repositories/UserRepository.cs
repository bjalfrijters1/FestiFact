using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FestifactDbContext _festifactDbContext;
        public UserRepository(FestifactDbContext festifactDbContext)
        {
            _festifactDbContext = festifactDbContext;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _festifactDbContext.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Insert(UserToAddDto user)
        {
            var result = await _festifactDbContext.AddAsync(new User
            {
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
            });
            await _festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
