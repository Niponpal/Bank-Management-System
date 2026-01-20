using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BankManagementSystem.Auth_IdentityModel.IdentityModel;

namespace CatMS.Data.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = 1,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR",
            Description = "Default role assigned to all employees."

        }, new Role
        {
            Id = 2,
            Name = "Admin",
            NormalizedName = "Admin",
            Description = "Default role assigned to all employees."
        }, new Role
        {
            Id = 3,
            Name = "Customer",
            NormalizedName = "Buyer",
            Description = "Default role assigned to all customers."
        }

        );
    }
}

