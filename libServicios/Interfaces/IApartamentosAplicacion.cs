using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IApartamentosAplicacion
    {
        List<Apartamentos> Consultar();
        Apartamentos ConsultarId(int id);
        Apartamentos Guardar(Apartamentos entidad);
        Apartamentos Editar(Apartamentos entidad);
        void Eliminar(int id);
    }
}
