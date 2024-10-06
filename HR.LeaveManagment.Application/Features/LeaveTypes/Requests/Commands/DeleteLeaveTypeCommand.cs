using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands
{
    internal class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
