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
    public class InvoiceLineController : ChinookBaseController<InvoiceLine>
    {
        // GET: InvoiceLine
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.InvoiceLineId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvoiceLine invoiceline)
        {
            if (!ModelState.IsValid) return View(invoiceline);
            _repository.Add(invoiceline);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var invoiceline = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceline == null) return RedirectToAction("Index");
            return View(invoiceline);
        }

        [HttpPost]
        public ActionResult Edit(InvoiceLine invoiceline)
        {
            if (!ModelState.IsValid) return View(invoiceline);
            _repository.Update(invoiceline);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var invoiceline = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceline == null) return RedirectToAction("Index");
            return View(invoiceline);
        }

        [HttpPost]
        public ActionResult Delete(InvoiceLine invoiceline)
        {
            _repository.Delete(invoiceline);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var invoiceline = _repository.GetById(x => x.InvoiceLineId == id);
            if (invoiceline == null) return RedirectToAction("Index");
            return View(invoiceline);
        }
    }
}