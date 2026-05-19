using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IResidentesAplicacion
    {
        List<Residentes> Consultar();
        Residentes ConsultarId(int id);
        Residentes Guardar(Residentes entidad);
        Residentes Editar(Residentes entidad);
        void Eliminar(int id);
        List<Residentes> ConsultarPorApartamentos(int ApartamentosId);


    }
}
