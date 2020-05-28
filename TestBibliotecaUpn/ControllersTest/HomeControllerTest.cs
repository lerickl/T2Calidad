using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Models;
using BibliotecaUPN.Web.servicios;
using Moq;
using NUnit.Framework;
namespace BibliotecaUPN.Web.TestBibliotecaUpn.ControllersTest
{
    [TestFixture]
    class HomeControllerTest
    {
 
        [Test]
        public void MarcarComoTerminadoIsOk()
        {
          
            var IHomeServiceEMock = new Mock<IHomeServiceE>();

            IHomeServiceEMock.Setup(x => x.libros()).Returns(new List<Libro>());
           var controller = new HomeController(IHomeServiceEMock.Object);
            var result = controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);

        }

    }
}