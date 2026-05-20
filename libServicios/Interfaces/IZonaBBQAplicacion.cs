using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IZonaBBQAplicacion
    {

        List<ZonaBBQ> Consultar();
        ZonaBBQ ConsultarId(int id);
        ZonaBBQ Guardar(ZonaBBQ entidad);
        ZonaBBQ Editar(ZonaBBQ entidad);
        void Eliminar(int id);


    }
}
