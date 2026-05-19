using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Cooworking
    {

        [Key]
        public int IdCooworking { get; set; }
        public int IdZonaComun { get; set; }
        public int CantPuestosDeTrabajo { get; set; }
        public bool TieneInternet { get; set; }
        public bool TieneAireAcondicionado { get; set; }
        public bool TieneImpresora { get; set; }
        public bool TieneLockers { get; set; }

        [ForeignKey("IdZonaComun")] public ZonasComunes? _ZonasComunes { get; set; }

    }
}
