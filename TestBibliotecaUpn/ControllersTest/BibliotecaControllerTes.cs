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
    class BibliotecaControllerTes
    {
        [Test]
        public void GetIndexBibliotecaIsOk()
        {
            var authManagerMock = new Mock<IAuthManager>();
            var bibliotecaServiceMock = new Mock<IBibliotecaService>();
            var controller = new BibliotecaController(authManagerMock.Object, bibliotecaServiceMock.Object);
            var result = controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);



        }

        [Test]
        public void GetAddBibliotecaIsOk()
        {
            var authManagerMock = new Mock<IAuthManager>();
            var bibliotecaServiceMock = new Mock<IBibliotecaService>();
            authManagerMock.Setup(x => x.GetUserLogueado()).Returns(new Usuario());
            var controller = new BibliotecaController(authManagerMock.Object, bibliotecaServiceMock.Object);
            var result = controller.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void PostAddBibliotecaIsOk()
        {
            var authManagerMock = new Mock<IAuthManager>();
            var bibliotecaServiceMock = new Mock<IBibliotecaService>();
            authManagerMock.Setup(x => x.GetUserLogueado()).Returns(new Usuario());
            var controller = new BibliotecaController(authManagerMock.Object, bibliotecaServiceMock.Object);
            var result = controller.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void MarcarComoLeyendoIsOkx()
        {
            var authManagerMock = new Mock<IAuthManager>();
            var bibliotecaServiceMock = new Mock<IBibliotecaService>();
            authManagerMock.Setup(x => x.GetUserLogueado()).Returns(new Usuario());
            bibliotecaServiceMock.Setup(x => x.GetBibliotecaByLibroidAndUserid(1, new Usuario())).Returns(new Biblioteca());
            bibliotecaServiceMock.Setup(x => x.CambiarEstadoLeyendo(new Biblioteca()));
           
            var controller = new BibliotecaController(authManagerMock.Object, bibliotecaServiceMock.Object);
            var result = controller.MarcarComoLeyendo(1);
       
            //var libro = bibliotecaService.GetBibliotecaByLibroidAndUserid(libroId, user);
            //bibliotecaService.CambiarEstadoLeyendo(libro);


            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void MarcarComoTerminadoIsOk()
        {
            var authManagerMock = new Mock<IAuthManager>();
            var bibliotecaServiceMock = new Mock<IBibliotecaService>();
            authManagerMock.Setup(x => x.GetUserLogueado()).Returns(new Usuario());
            bibliotecaServiceMock.Setup(x => x.GetBibliotecaByLibroidAndUserid(1, new Usuario())).Returns(new Biblioteca());
            var controller = new BibliotecaController(authManagerMock.Object, bibliotecaServiceMock.Object);
            var result = controller.MarcarComoTerminado(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
    }
}