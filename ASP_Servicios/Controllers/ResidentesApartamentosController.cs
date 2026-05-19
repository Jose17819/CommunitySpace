using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResidentesApartamentosController : ControllerBase
    {
        private ResidentesApartamentosAplicacion iResidentesApartamentosAplicacion;

        public ResidentesApartamentosController()
        {
            this.iResidentesApartamentosAplicacion = new ResidentesApartamentosAplicacion();
        }

        [HttpGet]
        public List<ResidentesApartamentos> Consultar()
        {
            return this.iResidentesApartamentosAplicacion.Consultar();
        }

        [HttpGet]
        public ResidentesApartamentos ConsultarId(int id)
        {
            return this.iResidentesApartamentosAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public ResidentesApartamentos Guardar(ResidentesApartamentos entidad)
        {
            return this.iResidentesApartamentosAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public ResidentesApartamentos Editar(ResidentesApartamentos entidad)
        {
            return this.iResidentesApartamentosAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iResidentesApartamentosAplicacion.Eliminar(id);
        }
    }
}
