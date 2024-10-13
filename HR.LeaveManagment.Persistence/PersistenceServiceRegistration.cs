using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrLeaveManagmentDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveManagementConnectionString")
                )
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
