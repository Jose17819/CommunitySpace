using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Pagos
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public string? MetodoPago { get; set; }
        public decimal Monto { get; set; }
        public string? EstadoPago { get; set; }
        public DateTime FechaPago { get; set; }

        [ForeignKey("IdReserva")] public Reservas? _Reservas { get; set; }

        [NotMapped] public List<Facturas>? Facturas { get; set; }


    }
}
