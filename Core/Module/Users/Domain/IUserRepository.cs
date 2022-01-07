using Core.Module.Shared.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Domain
{
    public interface IUserRepository : IRepository
    {
        public Task SaveAsync(User user);
        public Task<User> SearchAsyncById(UserId id);
        public Task<User> SearchAsyncByEmail(UserEmail email);
        public Task DeleteAsync(UserId id);
    }
}
