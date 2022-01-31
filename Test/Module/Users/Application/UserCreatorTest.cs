using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Module.Users.Application
{
    [Trait("Category", "Unit")]
    [Trait("Class", nameof(UserCreator))]
    [Trait("Method", nameof(UserCreator))]
    public class UserCreatorTest : IDisposable
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
            var request = new CreateUserRequest("1234", "amarimon", "amarimon@cloudactivereception.com", "@password");

            await this.userCreatorService.Create(request);
        }

        [Fact]
        public async void AfterUserCreateItShouldBeInTheRepository()
        {
            await this.ExecuteCreateUser();

            Assert.NotNull(await this.userRepository.SearchAsyncByEmail(new UserEmail("amarimon@cloudactivereception.com")));
        }


        [Theory]
        [ClassData(typeof(CreateInvalidUserRequestGenerator))]
        public async Task InvalidUserShouldThrowAnException(CreateUserRequest request)
        {
            //Ull, any
            await Assert.ThrowsAnyAsync<DomainException>(() => this.userCreatorService.Create(request));
            //await Assert.ThrowsAsync<InvalidEmailException>(() => this.userCreatorService.Create(request));
        }


        public void Dispose()
        {
            //Implementem la interfície IDisposable, pq quan es cridi el dispose faci neteja.
            //Per exemple, si utilitzessim una db, i un test fallés, podrien quedar dades.
            //En aquest cas ho posem a mode d'exemple per veure una possiblitat.
        }
    }
}
