using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        //Dependency Injection
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        //End dependency Injection
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var LeaveHistories = _db.LeaveHistories.ToList();

            return LeaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var LeaveHistories = _db.LeaveHistories.Find(id);
            //_db.LeaveTypes.FirstOrDefault();
            return LeaveHistories;
        }

        public bool IsExists(int id)
        {
            var exists = _db.LeaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
