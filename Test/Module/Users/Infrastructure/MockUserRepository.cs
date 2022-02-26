using Core.Module.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Module.Users.Infrastructure
{
    public class StubUserRepository : IUserRepository
    {
        private List<User> usersInRepository;

        public StubUserRepository()
        {
            usersInRepository = new List<User>();
            usersInRepository.Add(new User(new UserId("1"), new UserName("testUser"), new UserEmail("email@email.com"), new UserPassword("testPassword")));
            usersInRepository.Add(new User(new UserId("2"), new UserName("testUser2"), new UserEmail("email2@email.com"), new UserPassword("testPassword2")));
        }

        public Task DeleteAsync(UserId id)
        {
            return Task.Run(() => {
                this.usersInRepository.Remove(this.usersInRepository.Single(s => s.userId == id));
            });
        }

        public Task SaveAsync(User user)
        {
            return Task.Run(() => { this.usersInRepository.Add(user); });
        }

        public Task<User> SearchAsyncById(UserId id)
        {
            return (Task<User>)Task.Run(() => {
                return this.usersInRepository.FirstOrDefault(user => user.userId.value == id.value);
            });
        }

        public Task<User> SearchAsyncByEmail(UserEmail email)
        {
            return (Task<User>)Task.Run(() => {
                User user = this.usersInRepository.FirstOrDefault(user => 
                        user.userEmail.value.ToUpper().Equals(email.value.ToUpper(), StringComparison.InvariantCultureIgnoreCase)
                    );

                return user;
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
