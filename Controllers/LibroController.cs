using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            var app = new AppContext();
            var model = app.Libros.Include(o => o.Autor)
                .Include(o => o.Comentarios.Select(x => x.Usuario))
                .Where(o => o.Id == id)
                .FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComentario(Comentario comentario)
        {
            // TO-DO validar que el usuario haya terminado de leer el libro para comentar.
            // caso contrario no dejar comentar.

            var app = new AppContext();
            Usuario user = (Usuario)Session["Usuario"];
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.Comentarios.Add(comentario);            

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }
    }
}