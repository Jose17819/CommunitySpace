using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CooworkingController : ControllerBase
    {


        private CooworkingAplicacion iCooworkingAplicacion;


        public CooworkingController()
        {
            this.iCooworkingAplicacion = new CooworkingAplicacion();
        }



        [HttpGet]
        public List<Cooworking> Consultar()
        {
            return this.iCooworkingAplicacion.Consultar();
        }



        [HttpGet]
        public Cooworking ConsultarId(int id)
        {
            return this.iCooworkingAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public Cooworking Guardar(Cooworking entidad)
        {
            return this.iCooworkingAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public Cooworking Editar(Cooworking entidad)
        {
            return this.iCooworkingAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iCooworkingAplicacion.Eliminar(id);
        }



    }
}
