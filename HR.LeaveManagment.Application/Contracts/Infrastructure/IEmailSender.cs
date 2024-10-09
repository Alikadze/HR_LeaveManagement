using HR.LeaveManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Contracts.Infrastructure
{
    public class IEmailSender
    {
        public Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();
        }

    }
}
