using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Administradores
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string? Cargo { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuarios { get; set; }
    }
}
