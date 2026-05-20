using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class MesaDeBillarController : ControllerBase
    {


        private MesaDeBillarAplicacion iMesaDeBillarAplicacion;



        public MesaDeBillarController()
        {
            this.iMesaDeBillarAplicacion = new MesaDeBillarAplicacion();
        }



        [HttpGet]
        public List<MesaDeBillar> Consultar()
        {
            return this.iMesaDeBillarAplicacion.Consultar();
        }



        [HttpGet]
        public MesaDeBillar ConsultarId(int id)
        {
            return this.iMesaDeBillarAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public MesaDeBillar Guardar(MesaDeBillar entidad)
        {
            return this.iMesaDeBillarAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public MesaDeBillar Editar(MesaDeBillar entidad)
        {
            return this.iMesaDeBillarAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iMesaDeBillarAplicacion.Eliminar(id);
        }



    }
}
