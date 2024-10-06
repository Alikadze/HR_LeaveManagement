using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto
    {
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        int LeaveTypeId { get; }
        string RequestComments { get; }

    }
}
