using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IEstadoReservasAplicacion
    {
        List<EstadoReservas> Consultar();
        EstadoReservas ConsultarId(int id);
        EstadoReservas Guardar(EstadoReservas entidad);
        EstadoReservas Editar(EstadoReservas entidad);
        void Eliminar(int id);
    }
}
