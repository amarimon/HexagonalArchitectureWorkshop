using Core.Module.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Module.Users.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> usersInRepository;

        public InMemoryUserRepository()
        {
            usersInRepository = new List<User>();
        }

        public Task DeleteAsync(UserId id)
        {
            return Task.Run(() => {
                this.usersInRepository.Remove(this.usersInRepository.Single(s => s.id == id));
            });
        }

        public Task SaveAsync(User user)
        {
            return Task.Run(() => { this.usersInRepository.Add(user); });
        }

        public Task<User> SearchAsyncById(UserId id)
        {
            return (Task<User>)Task.Run(() => {
                return this.usersInRepository.FirstOrDefault(user => user.id == id);
            });
        }

        public Task<User> SearchAsyncByEmail(UserEmail email)
        {
            return (Task<User>)Task.Run(() => {
                User user = this.usersInRepository.FirstOrDefault(user => 
                        user.email.value.ToUpper().Equals(email.value.ToUpper(), StringComparison.InvariantCultureIgnoreCase)
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
