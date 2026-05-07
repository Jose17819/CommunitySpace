using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class MesaDeBillar
    {
        public int IdMesaDeBillar { get; set; }
        public int IdZonaComun { get; set; }
        public string? EstadoMesa { get; set; }
        public string? NumeroDeMesa { get; set; }
        public string? TipoMesa { get; set; }
        public int CantidadDeBolas { get; set; }
        public bool TacosIncluidos { get; set; }

        [ForeignKey("IdZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
