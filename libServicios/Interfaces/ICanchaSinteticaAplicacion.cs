using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ICanchaSinteticaAplicacion
    {

        List<CanchaSintetica> Consultar();
        CanchaSintetica ConsultarId(int id);
        CanchaSintetica Guardar(CanchaSintetica entidad);
        CanchaSintetica Editar(CanchaSintetica entidad);
        void Eliminar(int id);


    }
}
