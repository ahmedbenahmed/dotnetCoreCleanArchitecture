using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cleanArch.Mvc.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string SUPER_ADMIN_ROLE_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            const string ADMIN_ROLE_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf7";
            const string USER_ROLE_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf8";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = SUPER_ADMIN_ROLE_ID,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            const string SUPER_ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf9";
            var superAdminUser = new IdentityUser
            {
                Id = SUPER_ADMIN_ID,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@example.com",
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "SuperAdminPassword123!");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = SUPER_ADMIN_ROLE_ID,
                    UserId = SUPER_ADMIN_ID
                },
                 new IdentityUserRole<string>
                 {
                     RoleId = ADMIN_ROLE_ID,
                     UserId = SUPER_ADMIN_ID
                 }
            );
        }
    }
}