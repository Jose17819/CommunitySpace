using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{

    public interface IMesaPingPongAplicacion
    {

        List<MesaPingPong> Consultar();
        MesaPingPong ConsultarId(int id);
        MesaPingPong Guardar(MesaPingPong entidad);
        MesaPingPong Editar(MesaPingPong entidad);
        void Eliminar(int id);


    }

}
