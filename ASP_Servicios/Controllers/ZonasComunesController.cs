using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ZonasComunesController : ControllerBase
    {

        private ZonasComunesAplicacion iZonasComunesAplicacion;



        public ZonasComunesController()
        {
            this.iZonasComunesAplicacion = new ZonasComunesAplicacion();
        }



        [HttpGet]
        public List<ZonasComunes> Consultar()
        {
            return this.iZonasComunesAplicacion.Consultar();
        }



        [HttpGet]
        public ZonasComunes ConsultarId(int id)
        {
            return this.iZonasComunesAplicacion.ConsultarId(id);
        }



        [HttpGet]
        public List<ZonasComunes> ConsultarDisponibles()
        {
            return this.iZonasComunesAplicacion.ConsultarDisponibles();
        }



        [HttpPost]
        public ZonasComunes Guardar(ZonasComunes entidad)
        {
            return this.iZonasComunesAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public ZonasComunes Editar(ZonasComunes entidad)
        {
            return this.iZonasComunesAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iZonasComunesAplicacion.Eliminar(id);
        }


    }
}