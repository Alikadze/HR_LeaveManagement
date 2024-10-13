using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
