using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Sancion
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public int? ReservaId { get; set; }
        public string? Motivo { get; set; }
        public decimal Valor { get; set; }
        public bool Pagada { get; set; }
        public DateTime FechaSancion { get; set; }

        [ForeignKey("ResidenteId")] public Residente? _Residente { get; set; }
        [ForeignKey("ReservaId")] public Reserva? _Reserva { get; set; }
    }
}
