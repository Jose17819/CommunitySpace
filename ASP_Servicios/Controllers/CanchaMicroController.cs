using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CanchaMicroController : ControllerBase
    {

        private CanchaMicroAplicacion iCanchaMicroAplicacion;



        public CanchaMicroController()
        {
            this.iCanchaMicroAplicacion = new CanchaMicroAplicacion();
        }



        [HttpGet]
        public List<CanchaMicro> Consultar()
        {
            return this.iCanchaMicroAplicacion.Consultar();
        }



        [HttpGet]
        public CanchaMicro ConsultarId(int id)
        {
            return this.iCanchaMicroAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public CanchaMicro Guardar(CanchaMicro entidad)
        {
            return this.iCanchaMicroAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public CanchaMicro Editar(CanchaMicro entidad)
        {
            return this.iCanchaMicroAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iCanchaMicroAplicacion.Eliminar(id);
        }


    }
}
