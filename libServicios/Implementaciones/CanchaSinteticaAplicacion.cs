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
    public class CanchaSinteticaAplicacion : ICanchaSinteticaAplicacion
    {


        private IConexion? iConexion;



        public List<CanchaSintetica> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.CanchaSintetica!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }



        public CanchaSintetica ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaSintetica!
                .Where(x => x.IdCanchaSintetica == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha sintética no encontrada");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }




        public CanchaSintetica Guardar(CanchaSintetica entidad)
        {
            if (entidad.IdCanchaSintetica != 0)
                throw new Exception("La cancha ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaSintetica!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public CanchaSintetica Editar(CanchaSintetica entidad)
        {
            if (entidad.IdCanchaSintetica == 0)
                throw new Exception("La cancha no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.CanchaSintetica!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.CanchaSintetica!
                .Where(x => x.IdCanchaSintetica == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Cancha sintética no encontrada");
            this.iConexion.CanchaSintetica!.Remove(entidad);
            this.iConexion.SaveChanges();
        }




    }
}
