using HR.LeaveManagment.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
    {
        //GetLeaveRequestWithDetails
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
