using libServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IResidentesApartamentosAplicacion
    {
        List<ResidentesApartamentos> Consultar();
        ResidentesApartamentos ConsultarId(int id);
        ResidentesApartamentos Guardar(ResidentesApartamentos entidad);
        ResidentesApartamentos Editar(ResidentesApartamentos entidad);
        void Eliminar(int id);
        List<ResidentesApartamentos> ConsultarPorApartamento(int apartamentoId);
    }
}
