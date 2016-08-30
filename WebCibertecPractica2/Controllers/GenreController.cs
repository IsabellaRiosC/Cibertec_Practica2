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
    public class GenreController : ChinookBaseController<Genre>
    {
        // GET: Genre
        public ActionResult Index()
        {

            return View(_repository.PaginatedList((x => x.GenreId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            _repository.Add(genre);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);

            _repository.Update(genre);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }

        [HttpPost]
        public ActionResult Delete(Genre genre)
        {
            _repository.Delete(genre);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }

    }
}