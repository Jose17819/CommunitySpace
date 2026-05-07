using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class MesaPingPong
    {
        public int IdMesaPingPong { get; set; }
        public int IdZonaComun { get; set; }
        public string? NumeroDeMesa { get; set; }
        public string? EstadoMesa { get; set; }
        public bool PaletasIncluidas { get; set; }
        public bool RedesIncluidas { get; set; }
        public string? Ubicacion { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
