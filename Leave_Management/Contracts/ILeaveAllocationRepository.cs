using Leave_Management.Data;
using System.Collections.Generic;

namespace Leave_Management.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
       // ICollection<LeaveAllocation> GetEmployeeByLeaveType(int id);
    }
}
