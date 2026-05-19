using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Nucleos
{
    public class Configuraciones
    {
        public static string Obtener(string clave)
        {
            return "server=localhost;database=db_reservas;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
