using libServicios.Implementaciones;
using libServicios.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResidentesController : ControllerBase
    {

        private ResidentesAplicacion iResidentesAplicacion;



        public ResidentesController()
        {
            this.iResidentesAplicacion = new ResidentesAplicacion();
        }



        [HttpGet]
        public List<Residentes> Consultar()
        {
            return this.iResidentesAplicacion.Consultar();
        }



        [HttpGet]
        public Residentes ConsultarId(int id)
        {
            return this.iResidentesAplicacion.ConsultarId(id);
        }



        [HttpGet]
        public List<Residentes> ConsultarPorApartamento(int apartamentoId)
        {
            return this.iResidentesAplicacion.ConsultarPorApartamentos(apartamentoId);
        }



        [HttpPost]
        public Residentes Guardar(Residentes entidad)
        {
            return this.iResidentesAplicacion.Guardar(entidad);
        }



        [HttpPut]
        public Residentes Editar(Residentes entidad)
        {
            return this.iResidentesAplicacion.Editar(entidad);
        }



        [HttpDelete]
        public void Eliminar(int id)
        {
            this.iResidentesAplicacion.Eliminar(id);
        }


    }
}