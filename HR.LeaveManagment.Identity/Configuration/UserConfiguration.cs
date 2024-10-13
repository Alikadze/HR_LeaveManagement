using HR.LeaveManagment.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagment.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                Email = "admin1@localhost.com",
                NormalizedEmail = "ADMIN1@LOCALHOST.COM",
                FirstName = "System1",
                LastName = "Admin1",
                UserName = "admin1@localhost.com",
                NormalizedUserName = "ADMIN1@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            };

            var regularUser = new ApplicationUser
            {
                Id = "9e2bb68-33e4-4d2-b7b7-8574fva048cdb9",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            };

            var employeeUser = new ApplicationUser
            {
                Id = "9e623v-33e4-4d2-b7b7-8574fva048tcdb9",
                Email = "employ@localhost.com",
                NormalizedEmail = "EMPLOY@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Employ",
                UserName = "employ@localhost.com",
                NormalizedUserName = "EMPLOYEE@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            };

            builder.HasData(adminUser, regularUser, employeeUser);
        }
    }
}