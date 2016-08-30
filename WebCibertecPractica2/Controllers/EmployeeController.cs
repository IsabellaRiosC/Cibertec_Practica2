﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCibertecPractica2.Filters;
using WebCibertecPractica2.Model;
using WebCibertecPractica2.Repository;

namespace WebCibertecPractica2.Controllers
{
    public class EmployeeController : ChinookBaseController<Employee>
    {
        // GET: Employee
        public ActionResult Index()
        {

            return View(_repository.PaginatedList((x => x.EmployeeId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);

            _repository.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            _repository.Delete(employee);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }
    }
}