using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Residentes
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public int Usuario { get; set; }
        public string? TipoResidente { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuarios { get; set; }

        [NotMapped] public List<ResidentesApartamentos>? ResidentesApartamentos { get; set; }
        [NotMapped] public List<Reservas>? Reservas { get; set; }
        [NotMapped] public List<Sanciones>? Sanciones { get; set; }
        [NotMapped] public List<Facturas>? Facturas { get; set; }


    }


}
