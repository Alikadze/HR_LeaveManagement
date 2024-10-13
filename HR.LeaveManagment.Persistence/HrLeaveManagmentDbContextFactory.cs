using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.LeaveManagment.Persistence
{
    public class HrLeaveManagmentDbContextFactory : IDesignTimeDbContextFactory<HrLeaveManagmentDbContext>
    {
        public HrLeaveManagmentDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<HrLeaveManagmentDbContext>().EnableSensitiveDataLogging();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new HrLeaveManagmentDbContext(builder.Options);
        }
    }
}
