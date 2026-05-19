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
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion? iConexion;

        public List<Facturas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var lista = this.iConexion.Facturas!.ToList();
            foreach (var item in lista)
            {
                item._Pagos = this.iConexion.Pagos!
                    .Where(x => x.Id == item.PagoId).FirstOrDefault();
                item._Residentes = this.iConexion.Residentes!
                    .Where(x => x.Id == item.ResidenteId).FirstOrDefault();
            }
            return lista;
        }

        public Facturas ConsultarId(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Facturas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Factura no encontrada");
            entidad._Pagos = this.iConexion.Pagos!
                .Where(x => x.Id == entidad.PagoId).FirstOrDefault();
            entidad._Residentes = this.iConexion.Residentes!
                .Where(x => x.Id == entidad.ResidenteId).FirstOrDefault();
            return entidad;
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("La factura ya existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Facturas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Facturas Editar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("La factura no existe");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            this.iConexion.Facturas!.Update(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public void Eliminar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            var entidad = this.iConexion.Facturas!
                .Where(x => x.Id == id).FirstOrDefault();
            if (entidad == null)
                throw new Exception("Factura no encontrada");
            this.iConexion.Facturas!.Remove(entidad);
            this.iConexion.SaveChanges();
        }

        public List<Facturas> ConsultarPorResidente(int residenteId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.Obtener("string_conexion");
            return this.iConexion.Facturas!
                .Where(x => x.ResidenteId == residenteId).ToList();
        }
    }
}
