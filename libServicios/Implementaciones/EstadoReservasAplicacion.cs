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
    public class EstadoReservasAplicacion : IEstadoReservasAplicacion
    {
        private IConexion? iConexion;

        public List<EstadoReservas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.EstadoReservas!.ToList();
        }

        public EstadoReservas ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.EstadoReservas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Estado de reserva no encontrado");
            return entidad;
        }

        public EstadoReservas Guardar(EstadoReservas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El estado de reserva ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.EstadoReservas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public EstadoReservas Editar(EstadoReservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El estado de reserva no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.EstadoReservas!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.EstadoReservas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Estado de reserva no encontrado");
            this.iConexion.EstadoReservas!.Remove(entidad);
            this.iConexion.SaveChanges();
        }
    }
}
