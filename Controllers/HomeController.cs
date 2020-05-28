using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        private IHomeServiceE homserv;
        public HomeController(IHomeServiceE homserv) {
            this.homserv = homserv;
         }
        [HttpGet]
        public ActionResult Index()
        {
            //var app = new AppContext();
            //var model = app.Libros.Include(o => o.Autor).ToList();
            var model= homserv.libros();
            return View(model);
        }       

    }
}