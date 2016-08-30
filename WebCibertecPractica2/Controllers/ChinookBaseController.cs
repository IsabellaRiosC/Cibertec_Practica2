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
    //[Authorize]
    [ExceptionControl]
    public class ChinookBaseController<T> : Controller
         where T : class
    {
        // GET: ChinookBase
        protected IRepository<T> _repository;
        public ChinookBaseController()
        {
            _repository = new BaseRepository<T>();
        }
    }
}