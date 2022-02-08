using Core.Module.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Module.Users.Infrastructure
{
    public sealed class UserMapConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityBuilder)
        {
            if (entityBuilder == null)
            {
                throw new ArgumentNullException(nameof(entityBuilder));
            }

            entityBuilder.ToTable("users");

            entityBuilder.Property(b => b.id)
                .HasConversion(
                    v => v.value,
                    v => new UserId(v.ToString()))
                .IsRequired();


            //entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.userName)
                .HasConversion(
                    v => v.value,
                    v => new UserName(v))
                .HasColumnName("username");

            entityBuilder.Property(x => x.email)
                .HasConversion(
                    v => v.value,
                    v => new UserEmail(v))
                .HasColumnName("mail");

            entityBuilder.Property(x => x.password)
                 .HasConversion(
                    v => v.value,
                    v => new UserPassword(v))
                .HasColumnName("password");

        /*builder.Property(credit => credit.Currency)
            .HasConversion(
                value => value.Code,
                value => new Currency(value))
            .IsRequired();

        builder.Property(b => b.ExternalUserId)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        builder.HasMany(x => x.CreditsCollection)
            .WithOne(b => b.Account!)
            .HasForeignKey(b => b.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.DebitsCollection)
            .WithOne(b => b.Account!)
            .HasForeignKey(b => b.AccountId)
            .OnDelete(DeleteBehavior.Cascade);*/
    }
    }
}
