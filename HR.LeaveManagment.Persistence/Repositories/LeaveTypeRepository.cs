using HR.LeaveManagment.Application.Contracts.Persistence;
using HR.LeaveManagment.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrLeaveManagmentDbContext DbContext;
        public LeaveTypeRepository(HrLeaveManagmentDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}
