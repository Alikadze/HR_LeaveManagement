using HR.LeaveManagment.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        //GetLeaveAllocationWithDetails
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();

    }
}
