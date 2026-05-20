using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SalonesComunalesController : ControllerBase
    {

        private SalonesComunalesAplicacion iSalonesComunalesAplicacion;


        public SalonesComunalesController()
        {
            this.iSalonesComunalesAplicacion = new SalonesComunalesAplicacion();
        }



        [HttpGet]
        public List<SalonesComunales> Consultar()
        {
            return this.iSalonesComunalesAplicacion.Consultar();
        }



        [HttpGet]
        public SalonesComunales ConsultarId(int id)
        {
            return this.iSalonesComunalesAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public SalonesComunales Guardar(SalonesComunales entidad)
        {
            return this.iSalonesComunalesAplicacion.Guardar(entidad);
        }




        [HttpPut]
        public SalonesComunales Editar(SalonesComunales entidad)
        {
            return this.iSalonesComunalesAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iSalonesComunalesAplicacion.Eliminar(id);
        }



    }
}
