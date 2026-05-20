using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ZonaBBQController : ControllerBase
    {

        private ZonaBBQAplicacion iZonaBBQAplicacion;


        public ZonaBBQController()
        {
            this.iZonaBBQAplicacion = new ZonaBBQAplicacion();
        }



        [HttpGet]
        public List<ZonaBBQ> Consultar()
        {
            return this.iZonaBBQAplicacion.Consultar();
        }



        [HttpGet]
        public ZonaBBQ ConsultarId(int id)
        {
            return this.iZonaBBQAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public ZonaBBQ Guardar(ZonaBBQ entidad)
        {
            return this.iZonaBBQAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public ZonaBBQ Editar(ZonaBBQ entidad)
        {
            return this.iZonaBBQAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iZonaBBQAplicacion.Eliminar(id);
        }



    }
}
