using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartamentosController : ControllerBase
    {
        private ApartamentosAplicacion iApartamentosAplicacion;

        public ApartamentosController()
        {
            this.iApartamentosAplicacion = new ApartamentosAplicacion();
        }

        [HttpGet]
        public List<Apartamentos> Consultar()
        {
            return this.iApartamentosAplicacion.Consultar();
        }

        [HttpGet]
        public Apartamentos ConsultarId(int id)
        {
            return this.iApartamentosAplicacion.ConsultarId(id);
        }

        [HttpPost]
        public Apartamentos Guardar(Apartamentos entidad)
        {
            return this.iApartamentosAplicacion.Guardar(entidad);
        }

        [HttpPut]
        public Apartamentos Editar(Apartamentos entidad)
        {
            return this.iApartamentosAplicacion.Editar(entidad);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iApartamentosAplicacion.Eliminar(id);
        }
    }
}
