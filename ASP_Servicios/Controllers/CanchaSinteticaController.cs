using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CanchaSinteticaController : ControllerBase
    {


        private CanchaSinteticaAplicacion iCanchaSinteticaAplicacion;


        public CanchaSinteticaController()
        {
            this.iCanchaSinteticaAplicacion = new CanchaSinteticaAplicacion();
        }



        [HttpGet]
        public List<CanchaSintetica> Consultar()
        {
            return this.iCanchaSinteticaAplicacion.Consultar();
        }



        [HttpGet]
        public CanchaSintetica ConsultarId(int id)
        {
            return this.iCanchaSinteticaAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public CanchaSintetica Guardar(CanchaSintetica entidad)
        {
            return this.iCanchaSinteticaAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public CanchaSintetica Editar(CanchaSintetica entidad)
        {
            return this.iCanchaSinteticaAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iCanchaSinteticaAplicacion.Eliminar(id);
        }



    }
}
