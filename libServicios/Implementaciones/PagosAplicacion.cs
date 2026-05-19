using libServicios.Interfaces;
using libServicios.Modelos;
using libServicios.Nucleos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libServicios.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {


        private IConexion? iConexion;



        public List<Pagos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Pagos!.ToList();
        }



        public Pagos ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Pagos!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Pagos no encontrado");
            entidad._Reservas = this.iConexion.Reservas!
                .Where(x => x.Id == entidad.IdReserva).FirstOrDefault();
            return entidad;
        }



        public Pagos Guardar(Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El Pagos ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Pagos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public List<Pagos> ConsultarPorReservas(int ReservasId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Pagos!
                .Where(x => x.IdReserva == ReservasId).ToList();
        }


    }
}
