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
    public class ResidentesApartamentosAplicacion : IResidentesApartamentosAplicacion
    {
        private IConexion? iConexion;

        public List<ResidentesApartamentos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.ResidentesApartamentos!.ToList();
            foreach (var item in lista)
            {
                item._Residentes = this.iConexion.Residentes!
                    .Where(x => x.Id == item.ResidenteId).FirstOrDefault();
                item._Apartamentos = this.iConexion.Apartamentos!
                    .Where(x => x.Id == item.ApartamentoId).FirstOrDefault();
            }
            return lista;
        }

        public ResidentesApartamentos ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ResidentesApartamentos!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("ResidenteApartamento no encontrado");
            entidad._Residentes = this.iConexion.Residentes!
                .Where(x => x.Id == entidad.ResidenteId).FirstOrDefault();
            entidad._Apartamentos = this.iConexion.Apartamentos!
                .Where(x => x.Id == entidad.ApartamentoId).FirstOrDefault();
            return entidad;
        }

        public ResidentesApartamentos Guardar(ResidentesApartamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El registro ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ResidentesApartamentos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public ResidentesApartamentos Editar(ResidentesApartamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El registro no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.ResidentesApartamentos!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.ResidentesApartamentos!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Registro no encontrado");
            this.iConexion.ResidentesApartamentos!.Remove(entidad);
            this.iConexion.SaveChanges();
        }

        public List<ResidentesApartamentos> ConsultarPorApartamento(int apartamentoId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.ResidentesApartamentos!
                .Where(x => x.ApartamentoId == apartamentoId).ToList();
        }
    }
}
