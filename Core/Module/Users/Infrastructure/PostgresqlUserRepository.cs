using Core.Module.Users.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Module.Users.Infrastructure
{
    public class PostgresqlUserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public PostgresqlUserRepository(UserDbContext context) => this._context = context ??
                                                                      throw new ArgumentNullException(nameof(context));


        public async Task DeleteAsync(UserId id)
        {
            await this._context
                .Database
                .ExecuteSqlRawAsync("DELETE FROM users WHERE id=@p0", id.value)
                .ConfigureAwait(false);
        }

        public async Task SaveAsync(User user)
        {
            await this._context.users
                .AddAsync(user)
                .ConfigureAwait(false);
        }

        public async Task<User> SearchAsyncById(UserId id)
        {
            User? user = await this._context
           .users
           .Where(e => e.id == id)
           .Select(e => e)
           .SingleOrDefaultAsync()
           .ConfigureAwait(false);

            return user;
        }

        public async Task<User> SearchAsyncByEmail(UserEmail email)
        {
            User? user = await this._context
           .users
           .Where(e => e.email == email)
           .Select(e => e)
           .SingleOrDefaultAsync()
           .ConfigureAwait(false);

            return user;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
