using Core.Module.Users.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Module.Users.Infrastructure
{
    public sealed class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }
    }
}
