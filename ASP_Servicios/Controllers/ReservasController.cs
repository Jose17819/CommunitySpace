using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservasController : ControllerBase
    {
        private ReservasAplicacion iReservasAplicacion;

        public ReservasController()
        {
            this.iReservasAplicacion = new ReservasAplicacion();
        }

        [HttpGet]
        public List<Reservas> Consultar()
        {
            return this.iReservasAplicacion.Consultar();
        }

        [HttpGet]
        public Reservas ConsultarId(int id)
        {
            return this.iReservasAplicacion.ConsultarId(id);
        }

        [HttpGet]
        public List<Reservas> ConsultarPorResidente(int residenteId)
        {
            return this.iReservasAplicacion.ConsultarPorResidentes(residenteId);
        }

        [HttpGet]
        public List<Reservas> ConsultarPorZona(int zonaComunId)
        {
            return this.iReservasAplicacion.ConsultarPorZona(zonaComunId);
        }

        [HttpGet]
        public bool ValidarDisponibilidad(int zonaComunId, DateTime fechaInicio, DateTime fechaFin)
        {
            return this.iReservasAplicacion.ValidarDisponibilidad(zonaComunId, fechaInicio, fechaFin);
        }

        [HttpPost]
        public Reservas Guardar(Reservas entidad)
        {
            return this.iReservasAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Reservas Editar(Reservas entidad)
        {
            return this.iReservasAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iReservasAplicacion.Eliminar(id);
        }
    }
}