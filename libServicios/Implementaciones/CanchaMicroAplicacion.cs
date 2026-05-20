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
    public class CanchaMicroAplicacion : ICanchaMicroAplicacion
    {

        private IConexion? iConexion;



        public List<CanchaMicro> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.CanchaMicro!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public CanchaMicro ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaMicro!
                .Where(x => x.IdCanchaMicro == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha micro no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }




        public CanchaMicro Guardar(CanchaMicro entidad)
        {
            if (entidad.IdCanchaMicro != 0)
                throw new Exception("La cancha ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaMicro!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public CanchaMicro Editar(CanchaMicro entidad)
        {
            if (entidad.IdCanchaMicro == 0)
                throw new Exception("La cancha no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaMicro!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaMicro!
                .Where(x => x.IdCanchaMicro == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha micro no encontrada");
            this.iConexion.CanchaMicro!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




    }
}
