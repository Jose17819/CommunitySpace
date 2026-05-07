using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class ResidenteApartamento
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public int ApartamentoId { get; set; }
        public bool EsPropietario { get; set; }

        [ForeignKey("ResidenteId")] public Residente? _Residente { get; set; }
        [ForeignKey("ApartamentoId")] public Apartamento? _Apartamento { get; set; }
    }
}
