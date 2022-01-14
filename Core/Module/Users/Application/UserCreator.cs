using Core.Module.Shared.Domain;
using Core.Module.Users.Domain;
using System.Threading.Tasks;

namespace Core.Module.Users.Application
{
    public sealed class UserCreator
    {
        private IUserRepository repository { get; set; }
        private IEventBus eventBusPublisher { get; set; }

        public UserCreator(IUserRepository userRepository, IEventBus eventBus)
        {
            this.repository = userRepository;
            this.eventBusPublisher = eventBus;
        }

        public async Task Create(CreateUserRequest request)
        {
            if (await this.repository.SearchAsyncByEmail(new UserEmail(request.email)) != null)
                throw new UserAlreadyExistsException();

            User user = User.Create(new UserId(request.id), new UserName(request.userName), new UserEmail(request.email), new UserPassword(request.password));
            
            await this.repository.SaveAsync(user);
            //await this.eventBusPublisher.Publish(user.PullDomainEvents());
        }
    }
}
