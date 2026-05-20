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
    public class CanchaBaloncestoAplicacion : ICanchaBaloncestoAplicacion
    {

        private IConexion? iConexion;



        public List<CanchaBaloncesto> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.CanchaBaloncesto!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }




        public CanchaBaloncesto ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaBaloncesto!
                .Where(x => x.IdCanchaBaloncesto == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha de baloncesto no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }




        public CanchaBaloncesto Guardar(CanchaBaloncesto entidad)
        {
            if (entidad.IdCanchaBaloncesto != 0)
                throw new Exception("La cancha ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaBaloncesto!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public CanchaBaloncesto Editar(CanchaBaloncesto entidad)
        {
            if (entidad.IdCanchaBaloncesto == 0)
                throw new Exception("La cancha no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaBaloncesto!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }





        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaBaloncesto!
                .Where(x => x.IdCanchaBaloncesto == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha de baloncesto no encontrada");
            this.iConexion.CanchaBaloncesto!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




    }


}
