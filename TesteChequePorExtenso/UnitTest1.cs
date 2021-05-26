using ChequePorExtenso.Controller;
using ChequePorExtenso.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteChequePorExtenso
{
    [TestClass]
    public class UnitTest1
    {

        ControladorUnidade controladorUnidade = new ControladorUnidade();
        ControladorDezena controladorDezena = new ControladorDezena();
        ControladorCentena controladorCentena = new ControladorCentena();
        ControladorCentavos controladorCentavos = new ControladorCentavos(new ControladorUnidade(), new ControladorDezena(), new Conversor());


        [TestMethod]
        public void RetornaInvalido()
        {
            Assert.AreEqual("Valor Invalido", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(0m));
        }

        [TestMethod]
        public void RetornaCincoCentavos()
        {
            Assert.AreEqual("Cinco centavos de real", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(0.5m));
        }
        [TestMethod]
        public void RetornaSeteReais()
        {
            Assert.AreEqual("Sete reais", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(7.00m));
        }

        [TestMethod]
        public void DoisReaisEVinteCinco()
        {
            Assert.AreEqual("Dois reais e vinte cinco centavos de real", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(2.25m));
        }

        [TestMethod]
        public void TrintaESete()
        {
            Assert.AreEqual("Trinta e sete reais", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(37.00m));
        }

        [TestMethod]
        public void SeiscentosETrintaESete()
        {
            Assert.AreEqual("Seiscentos e trinta e sete reais", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(637.00m));
        }

        [TestMethod]
        public void UmMilSeiscentosETrintaESete()
        {
            Assert.AreEqual("Um mil seiscentos e trinta e sete reais", new Conversor(controladorCentavos, controladorCentena, controladorUnidade, controladorDezena).Validar(1.637m));
        }

    }
}
