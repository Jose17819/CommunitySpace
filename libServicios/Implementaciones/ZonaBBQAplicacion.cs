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
    public class ZonaBBQAplicacion : IZonaBBQAplicacion
    {


        private IConexion? iConexion;



        public List<ZonaBBQ> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.ZonaBBQ!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public ZonaBBQ ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ZonaBBQ!
                .Where(x => x.IdZonaBBQ == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Zona BBQ no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }



        public ZonaBBQ Guardar(ZonaBBQ entidad)
        {
            if (entidad.IdZonaBBQ != 0)
                throw new Exception("La zona BBQ ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ZonaBBQ!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public ZonaBBQ Editar(ZonaBBQ entidad)
        {
            if (entidad.IdZonaBBQ == 0)
                throw new Exception("La zona BBQ no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ZonaBBQ!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ZonaBBQ!
                .Where(x => x.IdZonaBBQ == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Zona BBQ no encontrada");
            this.iConexion.ZonaBBQ!.Remove(entidad);
            this.iConexion.SaveChanges();
        }


    }

}
