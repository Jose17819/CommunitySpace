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
    public class CooworkingAplicacion : ICooworkingAplicacion
    {


        private IConexion? iConexion;



        public List<Cooworking> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Cooworking!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public Cooworking ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Cooworking!
                .Where(x => x.IdCooworking == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cooworking no encontrado");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }




        public Cooworking Guardar(Cooworking entidad)
        {
            if (entidad.IdCooworking != 0)
                throw new Exception("El cooworking ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Cooworking!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public Cooworking Editar(Cooworking entidad)
        {
            if (entidad.IdCooworking == 0)
                throw new Exception("El cooworking no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Cooworking!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Cooworking!
                .Where(x => x.IdCooworking == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cooworking no encontrado");
            this.iConexion.Cooworking!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




    }
}
