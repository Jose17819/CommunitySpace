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
    public class SancionesAplicacion : ISancionesAplicacion
    {
        private IConexion? iConexion;

        public List<Sanciones> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Sanciones!.ToList();
            foreach (var item in lista)
            {
                item._Residentes = this.iConexion.Residentes!
                    .Where(x => x.Id == item.ResidenteId).FirstOrDefault();
                item._Reservas = this.iConexion.Reservas!
                    .Where(x => x.Id == item.ReservaId).FirstOrDefault();
            }
            return lista;
        }

        public Sanciones ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Sanciones!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Sancion no encontrada");
            entidad._Residentes = this.iConexion.Residentes!
                .Where(x => x.Id == entidad.ResidenteId).FirstOrDefault();
            entidad._Reservas = this.iConexion.Reservas!
                .Where(x => x.Id == entidad.ReservaId).FirstOrDefault();
            return entidad;
        }

        public Sanciones Guardar(Sanciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("La sancion ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Sanciones!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Sanciones Editar(Sanciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La sancion no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Sanciones!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Sanciones!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Sancion no encontrada");
            this.iConexion.Sanciones!.Remove(entidad);
            this.iConexion.SaveChanges();
        }

        public List<Sanciones> ConsultarPorResidente(int residenteId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Sanciones!
                .Where(x => x.ResidenteId == residenteId).ToList();
        }
    }
}
