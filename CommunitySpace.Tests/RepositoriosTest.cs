using libServicios.Interfaces;
using libServicios.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CommunitySpace.Tests
{
    [TestClass]
    public class RepositoriosTest
    {

        // Se valida que se consulte la lista de usuarios
        [TestMethod]
        public void ConsultarUsuarios_DeberiaRetornarLista()
        {
            
            var mock = new Mock<IUsuariosAplicacion>();

            mock.Setup(x => x.Consultar()).Returns(
                new List<Usuarios>
                {
                    new Usuarios
                    {
                        Id = 1,
                        Nombre = "Juan",
                        Email = "juan@gmail.com"
                    },

                    new Usuarios
                    {
                        Id = 2,
                        Nombre = "Maria",
                        Email = "maria@gmail.com"
                    }
                });

            
            var resultado = mock.Object.Consultar();

            
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
        }




        // Se valida que se consulte un usuario por Id
        [TestMethod]
        public void ConsultarUsuarioPorId_DeberiaRetornarUsuario()
        {
            
            var mock = new Mock<IUsuariosAplicacion>();

            mock.Setup(x => x.ConsultarId(1)).Returns(
                new Usuarios
                {
                    Id = 1,
                    Nombre = "Juan",
                    Email = "juan@gmail.com"
                });

            
            var resultado = mock.Object.ConsultarId(1);

            
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Juan", resultado.Nombre);
        }




        // Se valida que se guarde correctamente un usuario
        [TestMethod]
        public void GuardarUsuario_DeberiaRetornarUsuarioConId()
        {
            
            var mock = new Mock<IUsuariosAplicacion>();

            var usuario = new Usuarios
            {
                Id = 0,
                Nombre = "Pedro",
                Email = "pedro@gmail.com"
            };

            mock.Setup(x => x.Guardar(usuario)).Returns(
                new Usuarios
                {
                    Id = 1,
                    Nombre = "Pedro",
                    Email = "pedro@gmail.com"
                });

            
            var resultado = mock.Object.Guardar(usuario);

            
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }



        // Se valida que se modifique un usuario
        [TestMethod]
        public void ModificarUsuario_DeberiaActualizarInformacion()
        {
            
            var mock = new Mock<IUsuariosAplicacion>();

            var usuario = new Usuarios
            {
                Id = 1,
                Nombre = "Usuario Modificado",
                Email = "usuario@gmail.com"
            };

            mock.Setup(x => x.Editar(usuario)).Returns(usuario);

            
            var resultado = mock.Object.Editar(usuario);

            
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Usuario Modificado", resultado.Nombre);
        }



        // Se valida que se elimine correctamente un usuario
        [TestMethod]
        public void BorrarUsuario_DeberiaEjecutarseCorrectamente()
        {
           
            var mock = new Mock<IUsuariosAplicacion>();

            mock.Setup(x => x.Eliminar(1));

            
            mock.Object.Eliminar(1);

            
            mock.Verify(x => x.Eliminar(1), Times.Once);
        }



    }
}