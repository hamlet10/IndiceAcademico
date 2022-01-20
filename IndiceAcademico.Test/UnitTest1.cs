using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestIndice
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AsignacionLetra()
        {
            //ASSERT
            char obtenido = IndiceAcademico.CalculoIndice.AsignarLetra(40);
            char esperado = 'F';
            Assert.AreEqual(esperado,obtenido);
        }

        [TestMethod]
        public void IndiceTest()
        {
            double[] calificaciones = {100,100,100,100 };
            double promedio = IndiceAcademico.CalculoIndice.CalcularIndice(calificaciones);
            double esp = 100;
            //ASSERT
            Assert.AreEqual(esp, promedio);
        }

    }
}

