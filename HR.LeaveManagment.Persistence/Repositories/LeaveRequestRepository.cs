using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest> , ILeaveRequestRepository
    {
        private readonly HrLeaveManagmentDbContext DbContext;
        public LeaveRequestRepository(HrLeaveManagmentDbContext dbContext) : base(dbContext) 
        {
            DbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            DbContext.Entry(leaveRequest).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await DbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = DbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return leaveRequest;
        }
    }
}
