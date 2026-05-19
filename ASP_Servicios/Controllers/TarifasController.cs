using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarifasController : ControllerBase
    {
        private TarifasAplicacion iTarifasAplicacion;

        public TarifasController()
        {
            this.iTarifasAplicacion = new TarifasAplicacion();
        }

        [HttpGet]
        public List<Tarifas> Consultar()
        {
            return this.iTarifasAplicacion.Consultar();
        }

        [HttpGet]
        public Tarifas ConsultarId(int id)
        {
            return this.iTarifasAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public Tarifas Guardar(Tarifas entidad)
        {
            return this.iTarifasAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Tarifas Editar(Tarifas entidad)
        {
            return this.iTarifasAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iTarifasAplicacion.Eliminar(id);
        }
    }
}
