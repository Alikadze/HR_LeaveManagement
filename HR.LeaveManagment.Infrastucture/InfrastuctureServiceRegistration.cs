using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;
using HR.LeaveManagment.Infrastucture.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Infrastucture
{
    public static class InfrastuctureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastuctureServices(this IServiceCollection services,   IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            
            return services;
        }
    }
}
