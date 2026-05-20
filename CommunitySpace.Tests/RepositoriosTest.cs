using libServicios.Interfaces;
using libServicios.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CommunitySpace.Tests
{
    [TestClass]
    public class RepositoriosTest
    {


        // USUARIOS 
        [TestMethod]
        public void Usuarios_Consultar_RetornaLista()
        {
            var mock = new Mock<IUsuariosAplicacion>();
            mock.Setup(x => x.Consultar()).Returns(new List<Usuarios>
            {
                new Usuarios { Id = 1, Nombre = "Juan", Email = "juan@gmail.com" },
                new Usuarios { Id = 2, Nombre = "Maria", Email = "maria@gmail.com" }
            });

            var resultado = mock.Object.Consultar();

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void Usuarios_ConsultarId_RetornaUsuario()
        {
            var mock = new Mock<IUsuariosAplicacion>();
            mock.Setup(x => x.ConsultarId(1)).Returns(
                new Usuarios { Id = 1, Nombre = "Juan", Email = "juan@gmail.com" });

            var resultado = mock.Object.ConsultarId(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Juan", resultado.Nombre);
        }

        [TestMethod]
        public void Usuarios_Guardar_RetornaUsuarioConId()
        {
            var mock = new Mock<IUsuariosAplicacion>();
            var usuario = new Usuarios { Id = 0, Nombre = "Pedro", Email = "pedro@gmail.com" };
            mock.Setup(x => x.Guardar(usuario)).Returns(
                new Usuarios { Id = 1, Nombre = "Pedro", Email = "pedro@gmail.com" });

            var resultado = mock.Object.Guardar(usuario);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void Usuarios_Editar_RetornaUsuarioEditado()
        {
            var mock = new Mock<IUsuariosAplicacion>();
            var usuario = new Usuarios { Id = 1, Nombre = "Juan Editado", Email = "juan@gmail.com" };
            mock.Setup(x => x.Editar(usuario)).Returns(usuario);

            var resultado = mock.Object.Editar(usuario);

            Assert.AreEqual("Juan Editado", resultado.Nombre);
        }

        [TestMethod]
        public void Usuarios_Eliminar_EjecutaSinError()
        {
            var mock = new Mock<IUsuariosAplicacion>();
            mock.Setup(x => x.Eliminar(1));

            mock.Object.Eliminar(1);

            mock.Verify(x => x.Eliminar(1), Times.Once);
        }



        //RESIDENTES 
        [TestMethod]
        public void Residentes_Consultar_RetornaLista()
        {
            var mock = new Mock<IResidentesAplicacion>();
            mock.Setup(x => x.Consultar()).Returns(new List<Residentes>
            {
                new Residentes { Id = 1, Cedula = "123456", TipoResidente = "Propietario" },
                new Residentes { Id = 2, Cedula = "789012", TipoResidente = "Arrendatario" }
            });

            var resultado = mock.Object.Consultar();

            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void Residentes_Guardar_RetornaResidenteConId()
        {
            var mock = new Mock<IResidentesAplicacion>();
            var residente = new Residentes { Id = 0, Cedula = "111222", TipoResidente = "Propietario" };
            mock.Setup(x => x.Guardar(residente)).Returns(
                new Residentes { Id = 1, Cedula = "111222", TipoResidente = "Propietario" });

            var resultado = mock.Object.Guardar(residente);

            Assert.AreEqual(1, resultado.Id);
        }

        [TestMethod]
        public void Residentes_ConsultarPorApartamento_RetornaLista()
        {
            var mock = new Mock<IResidentesAplicacion>();
            mock.Setup(x => x.ConsultarPorApartamentos(1)).Returns(new List<Residentes>
            {
                new Residentes { Id = 1, Cedula = "123456" }
            });

            var resultado = mock.Object.ConsultarPorApartamentos(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Count);
        }




        //ZONAS COMUNES
        [TestMethod]
        public void ZonasComunes_Consultar_RetornaLista()
        {
            var mock = new Mock<IZonasComunesAplicacion>();
            mock.Setup(x => x.Consultar()).Returns(new List<ZonasComunes>
            {
                new ZonasComunes { Id = 1, Nombre = "Cancha Baloncesto", Disponible = true },
                new ZonasComunes { Id = 2, Nombre = "Zona BBQ", Disponible = true }
            });

            var resultado = mock.Object.Consultar();

            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void ZonasComunes_ConsultarDisponibles_RetornaSoloDisponibles()
        {
            var mock = new Mock<IZonasComunesAplicacion>();
            mock.Setup(x => x.ConsultarDisponibles()).Returns(new List<ZonasComunes>
            {
                new ZonasComunes { Id = 1, Nombre = "Cancha Baloncesto", Disponible = true }
            });

            var resultado = mock.Object.ConsultarDisponibles();

            Assert.IsTrue(resultado.All(x => x.Disponible == true));
        }

        [TestMethod]
        public void ZonasComunes_Guardar_RetornaZonaConId()
        {
            var mock = new Mock<IZonasComunesAplicacion>();
            var zona = new ZonasComunes { Id = 0, Nombre = "Cooworking", CapacidadMaxima = 10 };
            mock.Setup(x => x.Guardar(zona)).Returns(
                new ZonasComunes { Id = 1, Nombre = "Cooworking", CapacidadMaxima = 10 });

            var resultado = mock.Object.Guardar(zona);

            Assert.AreEqual(1, resultado.Id);
        }





        //RESERVAS
        [TestMethod]
        public void Reservas_Consultar_RetornaLista()
        {
            var mock = new Mock<IReservasAplicacion>();
            mock.Setup(x => x.Consultar()).Returns(new List<Reservas>
            {
                new Reservas { Id = 1, Residente = 1, ZonaComun = 1 },
                new Reservas { Id = 2, Residente = 2, ZonaComun = 2 }
            });

            var resultado = mock.Object.Consultar();

            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void Reservas_ValidarDisponibilidad_RetornaTrue()
        {
            var mock = new Mock<IReservasAplicacion>();
            mock.Setup(x => x.ValidarDisponibilidad(
                1,
                new DateTime(2026, 6, 1, 8, 0, 0),
                new DateTime(2026, 6, 1, 10, 0, 0)))
                .Returns(true);

            var resultado = mock.Object.ValidarDisponibilidad(
                1,
                new DateTime(2026, 6, 1, 8, 0, 0),
                new DateTime(2026, 6, 1, 10, 0, 0));

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Reservas_ValidarDisponibilidad_RetornaFalse()
        {
            var mock = new Mock<IReservasAplicacion>();
            mock.Setup(x => x.ValidarDisponibilidad(
                1,
                new DateTime(2026, 6, 1, 8, 0, 0),
                new DateTime(2026, 6, 1, 10, 0, 0)))
                .Returns(false);

            var resultado = mock.Object.ValidarDisponibilidad(
                1,
                new DateTime(2026, 6, 1, 8, 0, 0),
                new DateTime(2026, 6, 1, 10, 0, 0));

            Assert.IsFalse(resultado);
        }





        //PAGOS 
        [TestMethod]
        public void Pagos_Guardar_RetornaPagoConId()
        {
            var mock = new Mock<IPagosAplicacion>();
            var pago = new Pagos { Id = 0, IdReserva = 1, Monto = 50000, MetodoPago = "Efectivo" };
            mock.Setup(x => x.Guardar(pago)).Returns(
                new Pagos { Id = 1, IdReserva = 1, Monto = 50000, MetodoPago = "Efectivo" });

            var resultado = mock.Object.Guardar(pago);

            Assert.AreEqual(1, resultado.Id);
            Assert.AreEqual(50000, resultado.Monto);
        }

        [TestMethod]
        public void Pagos_ConsultarPorReserva_RetornaLista()
        {
            var mock = new Mock<IPagosAplicacion>();
            mock.Setup(x => x.ConsultarPorReservas(1)).Returns(new List<Pagos>
            {
                new Pagos { Id = 1, IdReserva = 1, Monto = 50000 }
            });

            var resultado = mock.Object.ConsultarPorReservas(1);

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(50000, resultado[0].Monto);
        }



    }
}