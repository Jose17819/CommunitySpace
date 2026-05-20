using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CanchaBaloncestoController : ControllerBase
    {

        private CanchaBaloncestoAplicacion iCanchaBaloncestoAplicacion;


        public CanchaBaloncestoController()
        {
            this.iCanchaBaloncestoAplicacion = new CanchaBaloncestoAplicacion();
        }



        [HttpGet]
        public List<CanchaBaloncesto> Consultar()
        {
            return this.iCanchaBaloncestoAplicacion.Consultar();
        }



        [HttpGet]
        public CanchaBaloncesto ConsultarId(int id)
        {
            return this.iCanchaBaloncestoAplicacion.ConsultarId(id);
        }



        [HttpPost]
        public CanchaBaloncesto Guardar(CanchaBaloncesto entidad)
        {
            return this.iCanchaBaloncestoAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public CanchaBaloncesto Editar(CanchaBaloncesto entidad)
        {
            return this.iCanchaBaloncestoAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iCanchaBaloncestoAplicacion.Eliminar(id);
        }


    }
}