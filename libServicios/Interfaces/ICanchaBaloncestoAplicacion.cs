using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface ICanchaBaloncestoAplicacion
    {
        List<CanchaBaloncesto> Consultar();
        CanchaBaloncesto ConsultarId(int id);
        CanchaBaloncesto Guardar(CanchaBaloncesto entidad);
        CanchaBaloncesto Editar(CanchaBaloncesto entidad);
        void Eliminar(int id);


    }
}
