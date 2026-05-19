using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IFacturasAplicacion
    {
        List<Facturas> Consultar();
        Facturas ConsultarId(int id);
        Facturas Guardar(Facturas entidad);
        Facturas Editar(Facturas entidad);
        void Eliminar(int id);
        List<Facturas> ConsultarPorResidente(int residenteId);
    }
}
