using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId = "9e2bb68-33e4-4d2-b7b7-8574fva048cdb9"
                }
                //new IdentityUserRole<string>
                //{
                //    RoleId = "cacne43a6e-f72bb-4448-baaf-1ad1ccbbf",
                //    UserId = "9e623v-33e4-4d2-b7b7-8574fva048tcdb9"
                //}
            );
        }
    }
}
