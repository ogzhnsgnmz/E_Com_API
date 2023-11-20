using ECom.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECom.Persistence.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        #region SeedData

        var role1 = new AppRole() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" };
        var role2 = new AppRole() { Id = 2, Name = "User", NormalizedName = "USER" };

        builder.HasData(role1, role2);

        #endregion
    }
}