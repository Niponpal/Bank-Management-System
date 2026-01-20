using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CatMS.Auth_IdentityModel.IdentityModel;

namespace CatMS.Data.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(new UserRole
        {
            RoleId = 1,
            UserId = 1,
        }, new UserRole
        {
            RoleId = 2,
            UserId = 2,
        });
    }
}
