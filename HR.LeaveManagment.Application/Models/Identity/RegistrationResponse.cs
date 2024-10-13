using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Models.Identity
{
    public class RegistrationResponse
    {
        public string UserId { get; set; }
        public string[] Errors { get; set; }

    }
}
