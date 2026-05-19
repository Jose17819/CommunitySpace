using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IPagosAplicacion
    {
        List<Pagos> Consultar();
        Pagos ConsultarId(int id);
        Pagos Guardar(Pagos entidad);
        List<Pagos> ConsultarPorReservas(int ReservasId);

    }
}
