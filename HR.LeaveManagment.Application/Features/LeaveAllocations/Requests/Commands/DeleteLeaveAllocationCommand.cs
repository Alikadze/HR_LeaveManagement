using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands
{
    internal class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
