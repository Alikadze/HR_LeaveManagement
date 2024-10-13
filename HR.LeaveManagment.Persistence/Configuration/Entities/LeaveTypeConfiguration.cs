using HR.LeaveManagment.domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Persistence.Configuration.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Sick"
                }
            );
        }
    }
}
