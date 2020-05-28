using BibliotecaUPN.Web.Constantes;
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.servicios
{
    public interface IBibliotecaService {
        IEnumerable<Biblioteca> GetBibliotecas(Usuario user);
        void AddBiblioteca(Biblioteca biblioteca);
        Biblioteca GetBibliotecaByLibroidAndUserid(int libroid, Usuario user );
        void CambiarEstadoLeyendo(Biblioteca biblioteca);
    }
    public class BibliotecasService : IBibliotecaService
    {
        AppContext app;
        public BibliotecasService(AppContext app) {
            this.app=app;
        }

        public void AddBiblioteca(Biblioteca biblioteca)
        {
            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();
        }

        public void CambiarEstadoLeyendo(Biblioteca biblioteca)
        {
            var xd = app.Bibliotecas.Where(x => x.Id == biblioteca.Id).FirstOrDefault();

            bool v= xd.Estado == ESTADO.LEYENDO;
            app.SaveChanges();

        }

        public Biblioteca GetBibliotecaByLibroidAndUserid(int libroid,Usuario user )
        {
            var libro = app.Bibliotecas
                 .Where(o => o.LibroId == libroid && o.UsuarioId == user.Id)
                 .FirstOrDefault();
            
          
            return libro;
        }

        public IEnumerable<Biblioteca> GetBibliotecas(Usuario user)
        {
            var model = app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == user.Id)
                .ToList();
            return model;
        }
    }
}