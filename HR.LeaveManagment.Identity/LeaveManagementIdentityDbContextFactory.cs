﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Identity
{
    public class LeaveManagementIdentityDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementIdentityDbContext>
    {
        public LeaveManagementIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") // Make sure this matches your setup
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementIdentityDbContext>().EnableSensitiveDataLogging();
            var connectionString = configuration.GetConnectionString("LeaveManagementIdentityConnectionString");

            builder.UseSqlServer(connectionString);

            return new LeaveManagementIdentityDbContext(builder.Options);
        }
    }
}
