using libServicios.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Administradores>? Administrador { get; set; }
        DbSet<Apartamentos>? Apartamentos { get; set; }
        DbSet<Residentes>? Residentes { get; set; }
        DbSet<ResidentesApartamentos>? ResidentesApartamentos { get; set; }
        DbSet<ZonasComunes>? ZonasComunes { get; set; }
        DbSet<Tarifas>? Tarifas { get; set; }
        DbSet<EstadoReservas>? EstadoReservas { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<Sanciones>? Sanciones { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<MesaPingPong>? MesaPingPong { get; set; }
        DbSet<SalonesComunales>? SalonesComunales { get; set; }
        DbSet<ZonaBBQ>? ZonaBBQ { get; set; }
        DbSet<MesaDeBillar>? MesaDeBillar { get; set; }
        DbSet<Cooworking>? Cooworking { get; set; }
        DbSet<CanchaSintetica>? CanchaSintetica { get; set; }
        DbSet<CanchaBaloncesto>? CanchaBaloncesto { get; set; }
        DbSet<CanchaMicro>? CanchaMicro { get; set; }


        int SaveChanges();

    }
}
