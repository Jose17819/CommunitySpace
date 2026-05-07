using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class CanchaMicro
    {
        public int IdCanchaMicro { get; set; }
        public int IdZonaComun { get; set; }
        public int TiempoMaximoUso { get; set; }
        public int CapacidadJugadores { get; set; }
        public string? EstadoCancha { get; set; }
        public bool RequiereFirma { get; set; }
        public bool TieneIluminacion { get; set; }
        public bool TieneVestuario { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
