using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.servicios;
using BibliotecaUPN.Web.session;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.TestBibliotecaUpn.ControllersTest
{
    [TestFixture]
    class AuthControllerTest
    {
        [Test]
        public void GetLoginIsOk()
        {
            var AuthServiceMock = new Mock<IAuthService>();
            var AuthManagerMock = new Mock<IAuthManager>();
            var SessionServiceMock = new Mock<ISessionService>();
            var controller = new AuthController(AuthServiceMock.Object, AuthManagerMock.Object, SessionServiceMock.Object);
            var result = controller.Login();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LoginIsError()
        {
            var user = new Usuario();

            var auth = new Mock<IAuthService>();
            var SessionMock = new Mock<ISessionService>();
            auth.Setup(o => o.Login("admin", "admin"));
            var controller = new AuthController(auth.Object, null, null);

            var redirect = controller.Login("admin", "admin");
            Assert.IsInstanceOf<ViewResult>(redirect);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(redirect);



        }
        [Test]
        public void PostLoginIsOK()
        {
            var admin = new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "namedmin" };


            var authMock = new Mock<IAuthService>();
            var SessionMock = new Mock<ISessionService>();
            var authManagerMock = new Mock<IAuthManager>();
            authMock.Setup(x => x.Login("admin", "admin")).Returns(admin);
            var controllerUsuario = new AuthController(authMock.Object, authManagerMock.Object, SessionMock.Object);

            var result = controllerUsuario.Login("admin", "admin");
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.IsNotInstanceOf<ViewResult>(result);
        }
        [Test]
        public void LogOutisOk()
        {
            var SessionMock = new Mock<ISessionService>();
            var authMock = new Mock<IAuthService>();
            var authManagerMock = new Mock<IAuthManager>();
            var controllerUsuario = new AuthController(authMock.Object, authManagerMock.Object, SessionMock.Object);
            var result = controllerUsuario.Logout();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
    }
}