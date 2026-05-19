using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private FacturasAplicacion iFacturasAplicacion;

        public FacturasController()
        {
            this.iFacturasAplicacion = new FacturasAplicacion();
        }

        [HttpGet]
        public List<Facturas> Consultar()
        {
            return this.iFacturasAplicacion.Consultar();
        }

        [HttpGet]
        public Facturas ConsultarId(int id)
        {
            return this.iFacturasAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public Facturas Guardar(Facturas entidad)
        {
            return this.iFacturasAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Facturas Editar(Facturas entidad)
        {
            return this.iFacturasAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iFacturasAplicacion.Eliminar(id);
        }
    }
}
