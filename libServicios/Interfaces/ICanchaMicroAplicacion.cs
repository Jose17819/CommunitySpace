using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ICanchaMicroAplicacion
    {

        List<CanchaMicro> Consultar();
        CanchaMicro ConsultarId(int id);
        CanchaMicro Guardar(CanchaMicro entidad);
        CanchaMicro Editar(CanchaMicro entidad);
        void Eliminar(int id);


    }
}
