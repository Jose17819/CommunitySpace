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
    public class SalonesComunalesAplicacion : ISalonesComunalesAplicacion
    {


        private IConexion? iConexion;




        public List<SalonesComunales> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.SalonesComunales!.ToList();
            foreach (var item in lista)
                item._ZonasComunes = this.iConexion.ZonasComunes!
                    .Where(x => x.Id == item.IdZonaComun).FirstOrDefault();
            return lista;
        }



        public SalonesComunales ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.SalonesComunales!
                .Where(x => x.IdSalonesComunales == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Salón comunal no encontrado");
            entidad._ZonasComunes = this.iConexion.ZonasComunes!
                .Where(x => x.Id == entidad.IdZonaComun).FirstOrDefault();
            return entidad;
        }



        public SalonesComunales Guardar(SalonesComunales entidad)
        {
            if (entidad.IdSalonesComunales != 0)
                throw new Exception("El salón ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.SalonesComunales!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }




        public SalonesComunales Editar(SalonesComunales entidad)
        {
            if (entidad.IdSalonesComunales == 0)
                throw new Exception("El salón no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.SalonesComunales!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.SalonesComunales!
                .Where(x => x.IdSalonesComunales == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Salón comunal no encontrado");
            this.iConexion.SalonesComunales!.Remove(entidad);
            this.iConexion.SaveChanges();
        }



    }
}
