using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadoReservasController : ControllerBase
    {
        private EstadoReservasAplicacion iEstadoReservasAplicacion;

        public EstadoReservasController()
        {
            this.iEstadoReservasAplicacion = new EstadoReservasAplicacion();
        }

        [HttpGet]
        public List<EstadoReservas> Consultar()
        {
            return this.iEstadoReservasAplicacion.Consultar();
        }

        [HttpGet]
        public EstadoReservas ConsultarId(int id)
        {
            return this.iEstadoReservasAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public EstadoReservas Guardar(EstadoReservas entidad)
        {
            return this.iEstadoReservasAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public EstadoReservas Editar(EstadoReservas entidad)
        {
            return this.iEstadoReservasAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iEstadoReservasAplicacion.Eliminar(id);
        }
    }
}
