using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class SalonComunal
    {
        public int IdSalonesComunales { get; set; }
        public int IdZonaComun { get; set; }
        public string? CapacidadPersonas { get; set; }
        public string? NumeroDeSalon { get; set; }
        public bool TieneCocina { get; set; }
        public bool TieneVideoBeam { get; set; }
        public bool TieneSonido { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
