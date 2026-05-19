using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        private PagosAplicacion iPagosAplicacion;

        public PagosController()
        {
            this.iPagosAplicacion = new PagosAplicacion();
        }

        [HttpGet]
        public List<Pagos> Consultar()
        {
            return this.iPagosAplicacion.Consultar();
        }

        [HttpGet]
        public Pagos ConsultarId(int id)
        {
            return this.iPagosAplicacion.ConsultarId(id);
        }

        [HttpGet]
        public List<Pagos> ConsultarPorReserva(int reservaId)
        {
            return this.iPagosAplicacion.ConsultarPorReservas(reservaId);
        }

        [HttpPost]
        public Pagos Guardar(Pagos entidad)
        {
            return this.iPagosAplicacion.Guardar(entidad);
        }
    }
}