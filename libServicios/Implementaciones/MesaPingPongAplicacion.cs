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
    public class MesaPingPongAplicacion : IMesaPingPongAplicacion
    {


        private IConexion? iConexion;



        public List<MesaPingPong> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.MesaPingPong!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public MesaPingPong ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.MesaPingPong!
                .Where(x => x.IdMesaPingPong == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Mesa de ping pong no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }



        public MesaPingPong Guardar(MesaPingPong entidad)
        {
            if (entidad.IdMesaPingPong != 0)
                throw new Exception("La mesa ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.MesaPingPong!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public MesaPingPong Editar(MesaPingPong entidad)
        {
            if (entidad.IdMesaPingPong == 0)
                throw new Exception("La mesa no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.MesaPingPong!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.MesaPingPong!
                .Where(x => x.IdMesaPingPong == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Mesa de ping pong no encontrada");
            this.iConexion.MesaPingPong!.Remove(entidad);
            this.iConexion.SaveChanges();
        }



    }
}
