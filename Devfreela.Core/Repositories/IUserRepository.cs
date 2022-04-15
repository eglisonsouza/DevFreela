using Devfreela.Core.Entities;

namespace Devfreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> GetByEmailAndPasswordAsync(string email, string password);

    }
}
