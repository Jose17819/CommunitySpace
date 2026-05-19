using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SancionesController : ControllerBase
    {
        private SancionesAplicacion iSancionesAplicacion;

        public SancionesController()
        {
            this.iSancionesAplicacion = new SancionesAplicacion();
        }

        [HttpGet]
        public List<Sanciones> Consultar()
        {
            return this.iSancionesAplicacion.Consultar();
        }

        [HttpGet]
        public Sanciones ConsultarId(int id)
        {
            return this.iSancionesAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public Sanciones Guardar(Sanciones entidad)
        {
            return this.iSancionesAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Sanciones Editar(Sanciones entidad)
        {
            return this.iSancionesAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iSancionesAplicacion.Eliminar(id);
        }
    }
}
