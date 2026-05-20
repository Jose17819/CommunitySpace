using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ICooworkingAplicacion
    {

        List<Cooworking> Consultar();
        Cooworking ConsultarId(int id);
        Cooworking Guardar(Cooworking entidad);
        Cooworking Editar(Cooworking entidad);
        void Eliminar(int id);

    }
}
