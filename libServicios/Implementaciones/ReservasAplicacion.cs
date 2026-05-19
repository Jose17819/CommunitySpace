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
    public class ReservasAplicacion : IReservasAplicacion
    {


        private IConexion? iConexion;


        public List<Reservas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Reservas!.ToList();
            foreach (var item in lista)
            {
                item._Residentes = this.iConexion.Residentes!
                    .Where(x => x.Id == item.Residente).FirstOrDefault();
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.ZonaComun).FirstOrDefault();
                item._EstadoReservas = this.iConexion.EstadoReservas!
                    .Where(x => x.Id == item.EstadoReserva).FirstOrDefault();
            }
            return lista;
        }



        public Reservas ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Reservas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Reservas no encontrada");
            entidad._Residentes = this.iConexion.Residentes!
                .Where(x => x.Id == entidad.Residente).FirstOrDefault();
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.ZonaComun).FirstOrDefault();
            entidad._EstadoReservas = this.iConexion.EstadoReservas!
                .Where(x => x.Id == entidad.EstadoReserva).FirstOrDefault();
            return entidad;
        }



        public Reservas Guardar(Reservas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("La Reservas ya existe");
            if (!ValidarDisponibilidad(entidad.ZonaComun, entidad.FechaInicio, entidad.FechaFin))
                throw new Exception("La zona no está disponible en ese horario");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Reservas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public Reservas Editar(Reservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La Reservas no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Reservas!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Reservas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Reservas no encontrada");
            this.iConexion.Reservas!.Remove(entidad);
            this.iConexion.SaveChanges();
        }



        public List<Reservas> ConsultarPorResidentes(int ResidentesId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Reservas!
                .Where(x => x.Residente == ResidentesId).ToList();
        }


        public List<Reservas> ConsultarPorZona(int ZonasComunesId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Reservas!
                .Where(x => x.ZonaComun == ZonasComunesId).ToList();
        }



        public bool ValidarDisponibilidad(int ZonasComunesId, DateTime fechaInicio, DateTime fechaFin)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var conflicto = this.iConexion.Reservas!
                .Where(x => x.ZonaComun == ZonasComunesId &&
                            x.FechaInicio < fechaFin &&
                            x.FechaFin > fechaInicio)
                .FirstOrDefault();
            return conflicto == null;
        }


    }
}
