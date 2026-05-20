using Microsoft.VisualStudio.TestTools.UnitTesting;
using preServicios_lib.Comunicaciones;
using libServicios.Modelos;

namespace CommunitySpace.Tests
{
    [TestClass]
    public class ComunicacionesTest
    {
        private readonly Comunicaciones comunicaciones = new Comunicaciones();

        
        private readonly string UrlBase = "http://localhost:5124";



        // Se consulta la lista de usuarios
        [TestMethod]
        public async Task ConsultarUsuarios_DeberiaRetornarLista()
        {
            
            var resultado = await comunicaciones.Ejecutar<List<Usuarios>>(
                new Dictionary<string, object>
                {
                    { "Url", $"{UrlBase}/Usuarios/Consultar" }
                });

            
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Count > 0);
        }





        // Se valida que se guarde un usuario
        [TestMethod]
        public async Task GuardarUsuario_DeberiaRetornarUsuarioConId()
        {
            
            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Usuario Test",
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




        // Se valida que se edite usuario
        [TestMethod]
        public async Task ModificarUsuario_DeberiaActualizarInformacion()
        {
            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Usuario Inicial",
                Apellido = "Prueba",
                Email = $"editar{DateTime.Now.Ticks}@gmail.com",
                Contraseña = "123456",
                Telefono = "3001234567"
            };

            var usuarioCreado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Guardar" },
            { "Entidad", usuario }
                });


            usuarioCreado.Nombre = "Usuario Modificado";


            var resultado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Editar" },
            { "Entidad", usuarioCreado },
            { "EsEditar", true }
                });


            Assert.IsNotNull(resultado);
            Assert.AreEqual("Usuario Modificado", resultado.Nombre);
        }




        // Se valida que se elimine un usuario
        [TestMethod]
        public async Task BorrarUsuario_DeberiaEliminarRegistro()
        {
            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Usuario Eliminar",
                Apellido = "Prueba",
                Email = $"eliminar{DateTime.Now.Ticks}@gmail.com",
                Contraseña = "123456",
                Telefono = "3001234567"
            };


            var usuarioCreado = await comunicaciones.Ejecutar<Usuarios>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Guardar" },
            { "Entidad", usuario }
                });


            await comunicaciones.Ejecutar<object>(
                new Dictionary<string, object>
                {
            { "Url", $"{UrlBase}/Usuarios/Eliminar?id={usuarioCreado.Id}" },
            { "EsEliminar", true }
                });


            Assert.IsTrue(true);
        }



    }
}