using BibliotecaUPN.Web.Constantes;
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.servicios;
using BibliotecaUPN.Web.session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace BibliotecaUPN.Web.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private IAuthManager authManager;
        private IBibliotecaService bibliotecaService;
        public BibliotecaController(IAuthManager authManager, IBibliotecaService bibliotecaService) {
            this.authManager = authManager;
            this.bibliotecaService = bibliotecaService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            //var app = new AppContext(); 
            //Usuario user = (Usuario)Session["Usuario"];
            Usuario user = authManager.GetUserLogueado();
            var model = bibliotecaService.GetBibliotecas(user);
            //var model = app.Bibliotecas
            //    .Include(o => o.Libro.Autor)
            //    .Include(o=> o.Usuario)
            //    .Where(o => o.UsuarioId == user.Id)
            //    .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            //var app = new AppContext();
            //Usuario user = (Usuario)Session["Usuario"];
            Usuario user = authManager.GetUserLogueado();
            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            var biblioteca = new Biblioteca {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            //app.Bibliotecas.Add(biblioteca);
            //app.SaveChanges();
            bibliotecaService.AddBiblioteca(biblioteca);

            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            var app = new AppContext();
            Usuario user = (Usuario)Session["Usuario"];

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            //var libro = app.Bibliotecas
            //    .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
            //    .FirstOrDefault();
            var libro = bibliotecaService.GetBibliotecaByLibroidAndUserid(libroId,user);
            bibliotecaService.CambiarEstadoLeyendo(libro);
            //libro.Estado = ESTADO.LEYENDO;

            //app.SaveChanges();

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            var app = new AppContext();
            Usuario user = (Usuario)Session["Usuario"];

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            app.SaveChanges();

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }
    }
}