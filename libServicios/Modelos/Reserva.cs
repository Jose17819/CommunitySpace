using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }
        public int Residente { get; set; }
        public int ZonaComun { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool TieneCosto { get; set; }
        public int EstadoReserva { get; set; }

        [ForeignKey("Residente")] public Residente? _Residente { get; set; }
        [ForeignKey("ZonaComun")] public ZonaComun? _ZonaComun { get; set; }
        [ForeignKey("EstadoReserva")] public EstadoReserva? _EstadoReserva { get; set; }

        [NotMapped] public List<Pago>? Pagos { get; set; }
        [NotMapped] public List<Sancion>? Sanciones { get; set; }
    }
}
