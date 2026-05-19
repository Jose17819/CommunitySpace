using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {

        private UsuariosAplicacion iUsuariosAplicacion;



        public UsuariosController()
        {
            this.iUsuariosAplicacion = new UsuariosAplicacion();
        }



        [HttpGet]
        public List<Usuarios> Consultar()
        {
            return this.iUsuariosAplicacion.Consultar();
        }



        [HttpGet]
        public Usuarios ConsultarId(int id)
        {
            return this.iUsuariosAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public Usuarios Guardar(Usuarios entidad)
        {
            return this.iUsuariosAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public Usuarios Editar(Usuarios entidad)
        {
            return this.iUsuariosAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iUsuariosAplicacion.Eliminar(id);
        }


    }
}