using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.servicios;
using BibliotecaUPN.Web.session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BibliotecaUPN.Web.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService authService;
        private IAuthManager authManager;
        private ISessionService sessionService;
        public AuthController(IAuthService authService, IAuthManager authManager, ISessionService sessionService) {
            this.authService = authService;
            this.authManager = authManager;
            this.sessionService = sessionService;
        }
        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //var app = new AppContext();
            //var usuario = app.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
            var usuario= authService.Login(username, password);
            if (usuario != null)
            {
                //FormsAuthentication.SetAuthCookie(username, false);
                //Session["Usuario"] = usuario;
                authManager.Login(usuario);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout() {
            authManager.Logout();
            sessionService.LimpiarSesion();
            //FormsAuthentication.SignOut();
            //Session.Clear();
            return RedirectToAction("Login");
        }
    }
}