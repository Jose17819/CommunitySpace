using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{

    [Table("ResidenteApartamentos")]
    public class ResidentesApartamentos
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public int ApartamentoId { get; set; }
        public bool EsPropietario { get; set; }

        [ForeignKey("ResidenteId")] public Residentes? _Residentes { get; set; }
        [ForeignKey("ApartamentoId")] public Apartamentos? _Apartamentos { get; set; }


    }
}
