using HR.LeaveManagment.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
    }
}
