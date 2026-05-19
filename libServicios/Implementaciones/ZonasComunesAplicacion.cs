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
    public class ZonasComunesAplicacion : IZonasComunesAplicacion
    {


        private IConexion? iConexion;


        public List<ZonasComunes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.ZonasComunes!.ToList();
        }



        public ZonasComunes ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ZonasComunes!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Zona común no encontrada");
            return entidad;
        }



        public ZonasComunes Guardar(ZonasComunes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("La zona común ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ZonasComunes!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public ZonasComunes Editar(ZonasComunes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La zona común no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ZonasComunes!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ZonasComunes!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Zona común no encontrada");
            this.iConexion.ZonasComunes!.Remove(entidad);
            this.iConexion.SaveChanges();
        }



        public List<ZonasComunes> ConsultarDisponibles()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.ZonasComunes!
                .Where(x => x.Disponible == true).ToList();
        }



    }
}
