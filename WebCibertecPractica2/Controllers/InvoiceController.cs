using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCibertecPractica2.Filters;
using WebCibertecPractica2.Model;
using WebCibertecPractica2.Repository;

namespace WebCibertecPractica2.Controllers
{
    public class InvoiceController : ChinookBaseController<Invoice>
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.InvoiceId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            if (!ModelState.IsValid) return View(invoice);
            _repository.Add(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            if (!ModelState.IsValid) return View(invoice);
            _repository.Update(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Delete(Invoice invoice)
        {
            _repository.Delete(invoice);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }
    }
}