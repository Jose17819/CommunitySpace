using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ISancionesAplicacion
    {
        List<Sanciones> Consultar();
        Sanciones ConsultarId(int id);
        Sanciones Guardar(Sanciones entidad);
        Sanciones Editar(Sanciones entidad);
        void Eliminar(int id);
        List<Sanciones> ConsultarPorResidente(int residenteId);
    }
}
