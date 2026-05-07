using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Tarifa
    {
        public int Id { get; set; }
        public int ZonaComunId { get; set; }
        public decimal PrecioPorHora { get; set; }
        public bool Activa { get; set; }

        [ForeignKey("ZonaComun")] public ZonaComun? _ZonaComun { get; set; }
    }
}
