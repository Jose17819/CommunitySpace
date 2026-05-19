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
    public class AdministradoresAplicacion : IAdministradoresAplicacion
    {
        private IConexion? iConexion;

        public List<Administradores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Administradores!.ToList();
            foreach (var item in lista)
                item._Usuarios = this.iConexion.Usuarios!
                    .Where(x => x.Id == item.Usuario).FirstOrDefault();
            return lista;
        }

        public Administradores ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Administradores!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Administrador no encontrado");
            entidad._Usuarios = this.iConexion.Usuarios!
                .Where(x => x.Id == entidad.Usuario).FirstOrDefault();
            return entidad;
        }

        public Administradores Guardar(Administradores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El administrador ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Administradores!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Administradores Editar(Administradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El administrador no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Administradores!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Administradores!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Administrador no encontrado");
            this.iConexion.Administradores!.Remove(entidad);
            this.iConexion.SaveChanges();
        }
    }
}
