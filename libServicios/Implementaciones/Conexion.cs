using libServicios.Interfaces;
using libServicios.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }



        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Administradores>? Administrador { get; set; }
        public DbSet<Apartamentos>? Apartamentos { get; set; }
        public DbSet<Residentes>? Residentes { get; set; }
        public DbSet<ResidentesApartamentos>? ResidentesApartamentos { get; set; }
        public DbSet<ZonasComunes>? ZonasComunes { get; set; }
        public DbSet<Tarifas>? Tarifas { get; set; }
        public DbSet<EstadoReservas>? EstadoReservas { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Sanciones>? Sanciones { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<MesaPingPong>? MesaPingPong { get; set; }
        public DbSet<SalonesComunales>? SalonesComunales { get; set; }
        public DbSet<ZonaBBQ>? ZonaBBQ { get; set; }
        public DbSet<MesaDeBillar>? MesaDeBillar { get; set; }
        public DbSet<Cooworking>? Cooworking { get; set; }
        public DbSet<CanchaSintetica>? CanchaSintetica { get; set; }
        public DbSet<CanchaBaloncesto>? CanchaBaloncesto { get; set; }
        public DbSet<CanchaMicro>? CanchaMicro { get; set; }


    }
}
