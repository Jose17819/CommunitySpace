using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class AdministradoresController : ControllerBase
    {
        private AdministradoresAplicacion iAdministradoresAplicacion;

        public AdministradoresController()
        {
            this.iAdministradoresAplicacion = new AdministradoresAplicacion();
        }

        [HttpGet]
        public List<Administradores> Consultar()
        {
            return this.iAdministradoresAplicacion.Consultar();
        }

        [HttpGet]
        public Administradores ConsultarId(int id)
        {
            return this.iAdministradoresAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public Administradores Guardar(Administradores entidad)
        {
            return this.iAdministradoresAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Administradores Editar(Administradores entidad)
        {
            return this.iAdministradoresAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iAdministradoresAplicacion.Eliminar(id);
        }
    }
}
