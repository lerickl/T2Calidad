using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.servicios
{
    public interface IHomeServiceE
    {
         IEnumerable<Libro> libros();
    }
    public class HomeService: IHomeServiceE
    {
        AppContext app;
        public HomeService(AppContext app)
        {
            this.app = app;
        }

        public  IEnumerable<Libro> libros()
        {
  

            var model = app.Libros.Include(o => o.Autor).ToList();
            return model;

        }



    }

   
}