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
    public class ApartamentosAplicacion : IApartamentosAplicacion
    {
        private IConexion? iConexion;

        public List<Apartamentos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Apartamentos!.ToList();
        }

        public Apartamentos ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Apartamentos!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Apartamento no encontrado");
            return entidad;
        }

        public Apartamentos Guardar(Apartamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El apartamento ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Apartamentos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Apartamentos Editar(Apartamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El apartamento no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Apartamentos!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Apartamentos!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Apartamento no encontrado");
            this.iConexion.Apartamentos!.Remove(entidad);
            this.iConexion.SaveChanges();
        }
    }
}
