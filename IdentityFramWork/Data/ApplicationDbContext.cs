using IdentityFramWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace IdentityFramWork.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.Entity<IdentityUser>(option =>
            {
                option.ToTable(name:"User");
            });
            builder.Entity<IdentityRole>(option =>
            {
                option.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(option =>
            {
                option.ToTable(name: "UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(option =>
            {
                option.ToTable(name: "UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(option =>
            {
                option.ToTable(name: "UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(option =>
            {
                option.ToTable(name: "RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(option =>
            {
                option.ToTable(name: "UserTokens");
            });
        }
        public DbSet<IdentityFramWork.Models.MainPointVM>? MainPointVM { get; set; }
        public DbSet<IdentityFramWork.Models.Parts>? Parts { get; set; }
    }
}