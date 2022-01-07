using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace Test.Module.Users.Application
{
    public class UserCreatorTest
    {
        private IUserRepository userRepository;
        private UserCreator userCreatorService;
        private IEventBus eventBus;

        public UserCreatorTest()
        {
            this.userRepository = new InMemoryUserRepository();
            this.userCreatorService = new UserCreator(this.userRepository, eventBus);
        }

        [Fact(Skip ="Test not to run")]
        public void NotToRunTest()
        { 
        }
        
        [Fact]
        public async Task AlreadyExistingEmailShouldThrowAnException()
        {
            await this.ExecuteCreateUser();

            await Assert.ThrowsAsync<UserAlreadyExistsException>(() => this.ExecuteCreateUser());
        }

        private async Task ExecuteCreateUser()
        {
            var request = new CreateUserRequest("1234", "amarimon", "amarimon@cloudactivereception.com", "Demo123456");

            await this.userCreatorService.Create(request);
        }

        [Fact]
        public async void AfterUserCreateItShouldBeInTheRepository()
        {
            await this.ExecuteCreateUser();

            Assert.NotNull(await this.userRepository.SearchAsyncByEmail(new UserEmail("amarimon@cloudactivereception.com")));
        }
    }
}
