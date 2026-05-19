using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Tarifas
    {
        public int Id { get; set; }
        public int ZonaComun { get; set; }
        public decimal PrecioPorHora { get; set; }
        public bool Activa { get; set; }

        [ForeignKey("ZonaComun")] public ZonasComunes? _ZonasComunes { get; set; }

    }
}
