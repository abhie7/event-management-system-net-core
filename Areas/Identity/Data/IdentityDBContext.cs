using EventManagementSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventManagementSystem.Models;

namespace EventManagementSystem.Areas.Identity.Data;

public class IdentityDBContext : IdentityDbContext<AppUser>
{
    public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}
//
// public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
// {
//     public void Configure(EntityTypeBuilder<IdentityUser> builder)
//     {
//         builder.Property(x => x.Username).HasMaxLength(100).IsRequired();
//     }
// }
