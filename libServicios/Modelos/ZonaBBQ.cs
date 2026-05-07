using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class ZonaBBQ
    {
        public int IdZonaBBQ { get; set; }
        public int IdZonaComun { get; set; }
        public string? NumeroParrillas { get; set; }
        public string? CapacidadSillas { get; set; }
        public int CantidadDeUtensilios { get; set; }
        public bool CarbonIncluido { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
