using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IAdministradoresAplicacion
    {
        List<Administradores> Consultar();
        Administradores ConsultarId(int id);
        Administradores Guardar(Administradores entidad);
        Administradores Editar(Administradores entidad);
        void Eliminar(int id);
    }
}
