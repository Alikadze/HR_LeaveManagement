using HR.LeaveManagment.Application.DTOs.Common;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
