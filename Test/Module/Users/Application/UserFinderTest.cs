using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace Test.Module.Users.Application
{
    public class UserFinderTest
    {
        private IUserRepository userRepository;
        private UserFinder userFinderService;
        private UserCreator userCreatorService;
        private IEventBus eventBus;

        public UserFinderTest()
        {
            this.userRepository = new InMemoryUserRepository();
            this.userFinderService = new UserFinder(this.userRepository);
            this.userCreatorService = new UserCreator(this.userRepository, eventBus);
        }

       
        [Fact]
        public async Task NotExistingUserShouldThrowAnException()
        {
            await Assert.ThrowsAsync<UserDoesNotExistsException>(() => this.userFinderService.Find("1"));
        }

        private async Task ExecuteCreateUser()
        {
            var request = new CreateUserRequest("1234", "amarimon", "amarimon@cloudactivereception.com", "@password");

            await this.userCreatorService.Create(request);
        }

        [Fact]
        public async void ShoulFindExistingUser()
        {
            await this.ExecuteCreateUser();

            User existingUser = User.Create(new UserId("1234"), new UserName("amarimon"), new UserEmail("amarimon@cloudactivereception.com"), new UserPassword("@password"));

            User user = await this.userFinderService.Find(existingUser.id.value.ToString());

            //Assert.NotNull(user); <- NO!!!!!
            Assert.Equal(user, existingUser);
        }
    }
}
