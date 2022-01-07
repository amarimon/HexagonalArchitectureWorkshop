using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Application
{
    public sealed class UserFinder
    {
        private IUserRepository repository { get; set; }

        public UserFinder(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public async Task Find(string userId)
        {
            await this.repository.SearchAsyncById(new UserId(userId));
        }
    }
}
