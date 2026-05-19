using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ITarifasAplicacion
    {
        List<Tarifas> Consultar();
        Tarifas ConsultarId(int id);
        Tarifas Guardar(Tarifas entidad);
        Tarifas Editar(Tarifas entidad);
        void Eliminar(int id);
        List<Tarifas> ConsultarPorZona(int zonaComunId);
    }
}
