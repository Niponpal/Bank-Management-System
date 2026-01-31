using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BankManagementSystem.Auth_IdentityModel.IdentityModel;

namespace CatMS.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(new User
        {
            Id = 1,
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        }, new User
        {
            Id = 2,
            Email = "administrator@localhost.com",
            NormalizedEmail = "ADMINISTRATOR@LOCALHOST.COM",
            UserName = "administrator@localhost.com",
            NormalizedUserName = "ADMINISTRATOR@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        },
         new User
         {
             Id = 3,
             Email = "customer@localhost.com",
             NormalizedEmail = "CUSTOMER@LOCALHOST.COM",
             UserName = "customer@localhost.com",
             NormalizedUserName = "CUSTOMER@LOCALHOST.COM",
             PasswordHash = hasher.HashPassword(null, "P@ssword1"),
             EmailConfirmed = true,
             SecurityStamp = Guid.NewGuid().ToString()
         }

        );
    }
}
