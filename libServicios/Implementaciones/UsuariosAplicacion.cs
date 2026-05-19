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
    public class UsuariosAplicacion : IUsuariosAplicacion
    {


        private IConexion? iConexion;


        public List<Usuarios> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Usuarios!.ToList();
        }



        public Usuarios ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Usuarios!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Usuarios no encontrado");
            return entidad;
        }



        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El Usuarios ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Usuarios!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public Usuarios Editar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Usuarios no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Usuarios!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Usuarios!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Usuarios no encontrado");
            this.iConexion.Usuarios!.Remove(entidad);
            this.iConexion.SaveChanges();
        }


    }
}
