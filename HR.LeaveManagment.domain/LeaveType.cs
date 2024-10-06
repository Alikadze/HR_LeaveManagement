using HR.LeaveManagment.domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }

    }
}
