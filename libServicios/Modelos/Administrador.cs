using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Administrador
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Cargo { get; set; }

        [ForeignKey("Usuario")] public Usuario? _Usuario { get; set; }
    }
}
