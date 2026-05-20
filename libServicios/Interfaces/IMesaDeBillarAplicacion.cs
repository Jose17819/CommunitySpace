using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IMesaDeBillarAplicacion
    {

        List<MesaDeBillar> Consultar();
        MesaDeBillar ConsultarId(int id);
        MesaDeBillar Guardar(MesaDeBillar entidad);
        MesaDeBillar Editar(MesaDeBillar entidad);
        void Eliminar(int id);

    }
}
