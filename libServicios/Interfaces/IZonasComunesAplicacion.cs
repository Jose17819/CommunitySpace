using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IZonasComunesAplicacion
    {
        List<ZonasComunes> Consultar();
        ZonasComunes ConsultarId(int id);
        ZonasComunes Guardar(ZonasComunes entidad);
        ZonasComunes Editar(ZonasComunes entidad);
        void Eliminar(int id);
        List<ZonasComunes> ConsultarDisponibles();

    }
}
