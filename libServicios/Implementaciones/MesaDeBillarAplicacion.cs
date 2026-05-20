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
    public class MesaDeBillarAplicacion : IMesaDeBillarAplicacion
    {


        private IConexion? iConexion;



        public List<MesaDeBillar> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.MesaDeBillar!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public MesaDeBillar ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.MesaDeBillar!
                .Where(x => x.IdMesaDeBillar == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Mesa de billar no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }




        public MesaDeBillar Guardar(MesaDeBillar entidad)
        {
            if (entidad.IdMesaDeBillar != 0)
                throw new Exception("La mesa ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.MesaDeBillar!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public MesaDeBillar Editar(MesaDeBillar entidad)
        {
            if (entidad.IdMesaDeBillar == 0)
                throw new Exception("La mesa no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.MesaDeBillar!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.MesaDeBillar!
                .Where(x => x.IdMesaDeBillar == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Mesa de billar no encontrada");
            this.iConexion.MesaDeBillar!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




    }
}
