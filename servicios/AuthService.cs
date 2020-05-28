using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.servicios
{
    public interface IAuthService
    {
        Usuario Login(string username, string password);

    }
    public class AuthService : IAuthService
    {
        AppContext app;
        public AuthService(AppContext app)
        {
            this.app = app;
        }
        public Usuario Login(string username, string password)
        {
            Usuario user = app.Usuarios.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {

                return user;

            };
            throw new NotImplementedException();

        }

    }
}