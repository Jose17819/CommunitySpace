using Microsoft.VisualStudio.TestTools.UnitTesting;
using preServicios_lib.Comunicaciones;
using libServicios.Modelos;

namespace CommunitySpace.Tests
{
    [TestClass]
    public class ComunicacionesTest
    {
        private Comunicaciones comunicaciones = new Comunicaciones();
        private string UrlBase = "http://localhost:5124";

        [TestMethod]
        public async Task Comunicaciones_Consultar_UsuariosRetornaLista()
        {
            var resultado = await comunicaciones.Ejecutar<List<Usuarios>>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/Usuarios/Consultar" }
                });

            Assert.IsNotNull(resultado);
        }


        [TestMethod]
        public async Task Comunicaciones_Consultar_ZonasComunesRetornaLista()
        {
            var resultado = await comunicaciones.Ejecutar<List<ZonasComunes>>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/ZonasComunes/Consultar" }
                });

            Assert.IsNotNull(resultado);
        }


        [TestMethod]
        public async Task Comunicaciones_Guardar_UsuarioRetornaConId()
        {
            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Test",
                Apellido = "Prueba",
                Email = $"test{DateTime.Now.Ticks}@gmail.com",
                Contraseña = "123456",
                Telefono = "3001234567"
            };

            var resultado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/Usuarios/Guardar" },
                    { "Entidad", usuario }
                });

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Id > 0);
        }



        [TestMethod]
        public async Task Comunicaciones_Guardar_ZonaComunRetornaConId()
        {
            var zona = new ZonasComunes
            {
                Id = 0,
                Nombre = "Zona Test",
                Descripcion = "Zona de prueba",
                CapacidadMaxima = 10,
                Disponible = true
            };

            var resultado = await comunicaciones.Ejecutar<ZonasComunes>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/ZonasComunes/Guardar" },
                    { "Entidad", zona }
                });

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Id > 0);
        }



        [TestMethod]
        public async Task Comunicaciones_Editar_UsuarioRetornaEditado()
        {
            
            var usuarioNuevo = new Usuarios
            {
                Id = 0,
                Nombre = "Para Editar",
                Apellido = "Test",
                Email = $"editar{DateTime.Now.Ticks}@gmail.com",
                Contraseña = "123456",
                Telefono = "3001234567"
            };

            var creado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Guardar" },
            { "Entidad", usuarioNuevo }
                });

            
            creado.Nombre = "Nombre Editado";

            var resultado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Editar" },
            { "Entidad", creado },
            { "EsEditar", true }
                });

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Nombre Editado", resultado.Nombre);
        }

        [TestMethod]
        public async Task Comunicaciones_Eliminar_EjecutaSinError()
        {
            
            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Eliminar",
                Apellido = "Test",
                Email = $"eliminar{DateTime.Now.Ticks}@gmail.com",
                Contraseña = "123456",
                Telefono = "3001234567"
            };

            var creado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/Usuarios/Guardar" },
                    { "Entidad", usuario }
                });

            
            await comunicaciones.Ejecutar<object>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/Usuarios/Eliminar?id={creado.Id}" },
                    { "EsEliminar", true }
                });

            Assert.IsTrue(true);
        }


    }
}