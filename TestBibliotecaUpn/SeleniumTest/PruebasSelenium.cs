using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.TestBibliotecaUpn.SeleniumTest
{
    [TestFixture]
    class PruebasSelenium
    {
        string Ruta = "http://localhost:58972/";
        ChromeOptions opciones = new ChromeOptions();

        [Test]
        public void LoginIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            var page = navegador.FindElementById("HomeIndex");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ViewLibrosIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("2").Click();
            var page = navegador.FindElementById("DetalleLibro");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ComentarLibrosIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("2").Click();
         

            navegador.FindElementById("idcomentario").SendKeys("libro comentado");
            navegador.FindElementById("idpuntaje").SendKeys("5");
            navegador.FindElementById("buttonComentario").Click();
            var page = navegador.FindElementById("DetalleLibro");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void AgregarABibliotecaIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementByName("2").Click();
            var page = navegador.FindElementById("HomeIndex");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonBibliotecaIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("temaLink").Click();

            var page = navegador.FindElementById("Biblioteca");
            Assert.IsNotNull(page);
            navegador.Close();
        }
        [Test]
        public void ButtonHomeIsOk()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = Ruta;
            navegador.FindElementByName("Username").SendKeys("admin");
            navegador.FindElementByName("Password").SendKeys("admin");
            navegador.FindElementById("BotonLogin").Click();
            navegador.FindElementById("ButtonHome").Click();

            var page = navegador.FindElementById("HomeIndex");
            Assert.IsNotNull(page);
            navegador.Close();
        }
    }
}