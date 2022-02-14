using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Module.Users.Infrastructure
{
    [Trait("Category", "Unit")]
    [Trait("Class", nameof(PostgresqlUserRepository))]
    [Trait("Method", nameof(PostgresqlUserRepository))]
    public class PostgresqlUserRepositoryTest : IDisposable
    {
        private IUserRepository userRepository;
        private UserDbContext userDbContext;

        public PostgresqlUserRepositoryTest()
        {
            var connectionString = "host=localhost;port=5432;database=local_test;username=sysdba;password=MasterCloud";

            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            userDbContext = new UserDbContext(optionsBuilder.Options);

            this.userRepository = new PostgresqlUserRepository(userDbContext);
        }

        private async Task ExecuteCreateUser()
        {
            var request = new CreateUserRequest("1234", "amarimon", "amarimon@cloudactivereception.com", "@password");

            User user = User.Create(new UserId(request.id), new UserName(request.userName), new UserEmail(request.email), new UserPassword(request.password));

            await this.userRepository.SaveAsync(user);
        }

        [Fact]
        public async void AfterUserCreateItShouldBeInTheRepository()
        {
            userDbContext.Database.BeginTransaction();

            await this.ExecuteCreateUser();

            Assert.NotNull(await this.userRepository.SearchAsyncByEmail(new UserEmail("amarimon@cloudactivereception.com")));
        }


        public void Dispose()
        {
            //Implementem la interfície IDisposable, pq quan es cridi el dispose faci neteja.
            //Per exemple, si utilitzessim una db, i un test fallés, podrien quedar dades.
            //En aquest cas ho posem a mode d'exemple per veure una possiblitat.
            userDbContext.Database.RollbackTransaction();
        }
    }
}
