using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Domain
{
    public sealed class UserSearchService
    {
        private IUserRepository repository { get; set; }

        public UserSearchService(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public async Task<User> Search(string userId)
        {
            User user = await this.repository.SearchAsyncById(new UserId(userId));

            return user;
        }
    }
}
