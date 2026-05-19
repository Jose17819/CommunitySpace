using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IUsuariosAplicacion
    {
        List<Usuarios> Consultar();
        Usuarios ConsultarId(int id);
        Usuarios Guardar(Usuarios entidad);
        Usuarios Editar(Usuarios entidad);
        void Eliminar(int id);

    }
}
