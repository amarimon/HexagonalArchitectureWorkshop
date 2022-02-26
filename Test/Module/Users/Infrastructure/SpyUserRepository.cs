using Core.Module.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Module.Users.Infrastructure
{
    public class SpyUserRepository : IUserRepository
    {
        private List<User> usersInRepository;
        private bool saveAsyncIsCalled = false;

        public SpyUserRepository()
        {
            usersInRepository = new List<User>();
        }

        public Task DeleteAsync(UserId id)
        {
            return Task.Run(() => {});
        }

        public Task SaveAsync(User user)
        {
            return Task.Run(() => { this.saveAsyncIsCalled = true; });
        }

        public Task<User> SearchAsyncById(UserId id)
        {
            return (Task<User>)Task.Run(() => {
            });
        }

        public Task<User> SearchAsyncByEmail(UserEmail email)
        {
            return (Task<User>)Task.Run(() => {
                return null;
            });
        }

        public void Dispose()
        {
            if (this.usersInRepository != null)
            {
                this.usersInRepository.Clear();
                this.usersInRepository = null;
            }
        }
    }
}
