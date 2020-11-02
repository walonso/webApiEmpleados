using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursosHumanos2.Repositorio;
using RecursosHumanos2.Repositorio.Entidades;

namespace UnitTestProjectMSTest
{
    [TestClass]
    public class RepositorioTests
    {
        [TestMethod]
        public void Obtener()
        {
            var empleadoMemoria = new Memoria<Entidad>();
            Empleado emp = new Empleado
            {
                Id = 1
            };
            var g = empleadoMemoria.Obtener(emp);
            Assert.IsNotNull(g);

        }

        [TestMethod]
        public void Insertar()
        {
            var empleadoMemoria = new Memoria<Empleado>();
            var cuentaMemoria = new Memoria<Cuenta>();
            Empleado emp = new Empleado
            {
                Id = 1,
                Nombre = "test",
                Cargo="Ing."
            };
            empleadoMemoria.Insertar(emp);
            var cuentaMemoria2 = new Memoria<Cuenta>();

            var g = empleadoMemoria.Obtener(emp);
            Assert.IsNotNull(g);

        }
    }
}
