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
    public class ResidentesAplicacion : IResidentesAplicacion
    {


        private IConexion? iConexion;


        public List<Residentes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Residentes!.ToList();
            foreach (var item in lista)
                item._Usuarios = this.iConexion.Usuarios!
                    .Where(x => x.Id == item.Usuario).FirstOrDefault();
            return lista;
        }



        public Residentes ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Residentes!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Residentes no encontrado");
            entidad._Usuarios = this.iConexion.Usuarios!
                .Where(x => x.Id == entidad.Usuario).FirstOrDefault();
            return entidad;
        }



        public Residentes Guardar(Residentes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El Residentes ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Residentes!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public Residentes Editar(Residentes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Residentes no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Residentes!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }



        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Residentes!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Residentes no encontrado");
            this.iConexion.Residentes!.Remove(entidad);
            this.iConexion.SaveChanges();
        }



        public List<Residentes> ConsultarPorApartamentos(int ApartamentosId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var idsResidentess = this.iConexion.ResidentesApartamentos!
                .Where(x => x.ApartamentoId == ApartamentosId)
                .Select(x => x.ResidenteId).ToList();
            var lista = this.iConexion.Residentes!
                .Where(x => idsResidentess.Contains(x.Id)).ToList();
            return lista;
        }



    }
}
