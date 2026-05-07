using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Residente
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public int Usuario { get; set; }
        public string? TipoResidente { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Usuario")] public Usuario? _Usuario { get; set; }

        [NotMapped] public List<ResidenteApartamento>? ResidenteApartamentos { get; set; }
        [NotMapped] public List<Reserva>? Reservas { get; set; }
        [NotMapped] public List<Sancion>? Sanciones { get; set; }
        [NotMapped] public List<Factura>? Facturas { get; set; }
    }


}
