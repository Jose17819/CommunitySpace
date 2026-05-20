using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ISalonesComunalesAplicacion
    {

        List<SalonesComunales> Consultar();
        SalonesComunales ConsultarId(int id);
        SalonesComunales Guardar(SalonesComunales entidad);
        SalonesComunales Editar(SalonesComunales entidad);
        void Eliminar(int id);


    }
}
