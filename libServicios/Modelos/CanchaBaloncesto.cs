using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class CanchaBaloncesto
    {
        public int IdCanchaBaloncesto { get; set; }
        public int IdZonaComun { get; set; }
        public int TiempoMaximoUso { get; set; }
        public string? EstadoTablero { get; set; }
        public bool RequiereFirma { get; set; }
        public bool EsTechada { get; set; }
        public int NumeroAros { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
