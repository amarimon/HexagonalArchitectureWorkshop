using Core.Module.Users.Domain;
using System;
using System.Threading.Tasks;

namespace Core.Module.Users.Infrastructure
{
    public class PostgresqlUserRepository : IUserRepository
    {
        public PostgresqlUserRepository()
        { 
        
        }

        public Task DeleteAsync(UserId id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchAsyncById(UserId id)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchAsyncByEmail(UserEmail email)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
