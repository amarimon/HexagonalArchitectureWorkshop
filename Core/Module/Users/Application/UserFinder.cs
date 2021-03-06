using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Application
{
    public sealed class UserFinder
    {
        private IUserRepository repository { get; set; }
        private UserFinderService userFinderService { get; set; }

        public UserFinder(IUserRepository userRepository)
        {
            this.repository = userRepository;
            this.userFinderService = new UserFinderService(repository);
        }

        public async Task<User> Find(string userId)
        {
            User user = await this.userFinderService.Find(userId);

            return user;
        }
    }
}
