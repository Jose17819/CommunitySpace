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
    public class TarifasAplicacion : ITarifasAplicacion
    {
        private IConexion? iConexion;

        public List<Tarifas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Tarifas!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.ZonaComun).FirstOrDefault();
            return lista;
        }

        public Tarifas ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Tarifas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Tarifa no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.ZonaComun).FirstOrDefault();
            return entidad;
        }

        public Tarifas Guardar(Tarifas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("La tarifa ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Tarifas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Tarifas Editar(Tarifas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La tarifa no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Tarifas!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Tarifas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Tarifa no encontrada");
            this.iConexion.Tarifas!.Remove(entidad);
            this.iConexion.SaveChanges();
        }

        public List<Tarifas> ConsultarPorZona(int zonaComunId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Tarifas!
                .Where(x => x.ZonaComun == zonaComunId).ToList();
        }
    }
}
