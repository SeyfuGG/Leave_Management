using Leave_Management.Data;
using Leave_Management.Repository;
using System.Collections.Generic;

namespace Leave_Management.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {

        ICollection<LeaveType> GetEmployeeByLeaveType(int id);

    }
}
