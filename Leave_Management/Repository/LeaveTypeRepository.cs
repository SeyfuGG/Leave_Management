﻿using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        //Dependency Injection
        private readonly ApplicationDbContext _db;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

       public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

       public ICollection<LeaveType> FindAll()
        {
            var LeaveTypes = _db.LeaveTypes.ToList();
            
            return LeaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var LeaveType = _db.LeaveTypes.Find(id);
            //_db.LeaveTypes.FirstOrDefault();
            return LeaveType;

        }

        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            var exists = _db.LeaveTypes.Any(q=>q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }

        
    }
}
