﻿using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Controllers
{

    [Authorize (Roles = "Administrator")]  
    // check if the user has access to leavetype controller 
        public class LeaveTypesController : Controller

    {
        // Start Dependency Injection
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //END Dependency Injection
        
        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var Model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);
            return View(Model);
        } 

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            { 
            return NotFound();
            }
            var leavetype =_repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        { 
            try
            {
                //TODO: Add insert Logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                var isSuccess = _repo.Create(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("","Something went wrong......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong......");
                return View(model);
            }
        }

        // GET: LeaveTypesController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);

            return View(model);
        }

        // POST: LeaveTypesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
               // leaveType.DateCreated = DateTime.Now;
                var isSuccess = _repo.Update(leaveType);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));

            }
            catch 
            {
                ModelState.AddModelError("", "Something went wrong......");
                return View(model);
            }
        }

        // GET: LeaveTypesController1/Delete/5
        public ActionResult Delete(int id)
        {
            var leaveType = _repo.FindById(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(leaveType);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));


        }

        // POST: LeaveTypesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                var leaveType = _repo.FindById(id);
                if (leaveType == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(leaveType);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
