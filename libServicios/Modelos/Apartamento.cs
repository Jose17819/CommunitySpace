using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string? NumeroApartamento { get; set; }
        public int Piso { get; set; }
        public string? Torre { get; set; }
        public bool TieneParqueadero { get; set; }

        [NotMapped] public List<ResidenteApartamento>? ResidenteApartamentos { get; set; }
    }

}
