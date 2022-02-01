using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Domain
{
    public sealed class UserFinderService
    {
        private IUserRepository repository { get; set; }

        public UserFinderService(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public async Task<User> Find(string userId)
        {
            User user = await this.repository.SearchAsyncById(new UserId(userId));

            if (user == null)
                throw new UserDoesNotExistsException();

            return user;
        }
    }
}
