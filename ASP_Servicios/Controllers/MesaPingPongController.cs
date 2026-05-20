using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MesaPingPongController : ControllerBase
    {

        private MesaPingPongAplicacion iMesaPingPongAplicacion;



        public MesaPingPongController()
        {
            this.iMesaPingPongAplicacion = new MesaPingPongAplicacion();
        }



        [HttpGet]
        public List<MesaPingPong> Consultar()
        {
            return this.iMesaPingPongAplicacion.Consultar();
        }



        [HttpGet]
        public MesaPingPong ConsultarId(int id)
        {
            return this.iMesaPingPongAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public MesaPingPong Guardar(MesaPingPong entidad)
        {
            return this.iMesaPingPongAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public MesaPingPong Editar(MesaPingPong entidad)
        {
            return this.iMesaPingPongAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iMesaPingPongAplicacion.Eliminar(id);
        }


    }
}
