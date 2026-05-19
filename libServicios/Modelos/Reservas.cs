using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Reservas
    {
        public int Id { get; set; }
        public int Residente { get; set; }
        public int ZonaComun { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool TieneCosto { get; set; }
        public int EstadoReserva { get; set; }

        [ForeignKey("Residente")] public Residentes? _Residentes { get; set; }
        [ForeignKey("ZonaComun")] public ZonasComunes? _ZonasComunes { get; set; }
        [ForeignKey("EstadoReserva")] public EstadoReservas? _EstadoReservas { get; set; }

        [NotMapped] public List<Pagos>? Pagos { get; set; }
        [NotMapped] public List<Sanciones>? Sanciones { get; set; }


    }
}
