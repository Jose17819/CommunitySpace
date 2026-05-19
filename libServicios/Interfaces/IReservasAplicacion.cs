using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IReservasAplicacion
    {
        List<Reservas> Consultar();
        Reservas ConsultarId(int id);
        Reservas Guardar(Reservas entidad);
        Reservas Editar(Reservas entidad);
        void Eliminar(int id);
        List<Reservas> ConsultarPorResidentes(int ResidentesId);
        List<Reservas> ConsultarPorZona(int ZonasComunesId);
        bool ValidarDisponibilidad(int ZonasComunesId, DateTime fechaInicio, DateTime fechaFin);


    }
}
