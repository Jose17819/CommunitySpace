using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class ZonasComunes
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int CapacidadMaxima { get; set; }
        public bool Disponible { get; set; }

        [NotMapped] public List<Tarifas>? Tarifas { get; set; }
        [NotMapped] public List<Reservas>? Reservas { get; set; }
        [NotMapped] public MesaPingPong? MesaPingPong { get; set; }
        [NotMapped] public SalonesComunales? SalonesComunales { get; set; }
        [NotMapped] public ZonaBBQ? ZonaBBQ { get; set; }
        [NotMapped] public MesaDeBillar? MesaDeBillar { get; set; }
        [NotMapped] public Cooworking? Cooworking { get; set; }
        [NotMapped] public CanchaSintetica? CanchaSintetica { get; set; }
        [NotMapped] public CanchaBaloncesto? CanchaBaloncesto { get; set; }
        [NotMapped] public CanchaMicro? CanchaMicro { get; set; }


    }
}
