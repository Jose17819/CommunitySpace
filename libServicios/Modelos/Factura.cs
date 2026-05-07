using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public string? NumeroFactura { get; set; }
        public int PagoId { get; set; }
        public int ResidenteId { get; set; }
        public decimal Total { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaEmision { get; set; }

        [ForeignKey("PagoId")] public Pago? _Pago { get; set; }
        [ForeignKey("ResidenteId")] public Residente? _Residente { get; set; }
    }
}
