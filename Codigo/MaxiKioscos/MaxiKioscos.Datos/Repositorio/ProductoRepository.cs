using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class ProductoRepository: EFRepository<Producto>,IProductoRepository
    {
        public ProductoRepository(){}

        public ProductoRepository(DbContext context) : base(context) { }

        public Producto Obtener(int productoId)
        {
            return DbContext
                .Set<Producto>()
                .Select(u => u)
                .FirstOrDefault(u => u.ProductoId==productoId);
        }

        public ProductoPorCodigo ProductoPorCodigo(string codigo, int maxiKioscoId)
        {
            return MaxiKioscosEntities.ProductoPorCodigo(codigo, maxiKioscoId).FirstOrDefault();
        }

        public ProductoHorario ObtenerPorCodigo(string codigo, int maxiKioscoId)
        {
            return MaxiKioscosEntities.ObtenerProductoPorCodigo(codigo, maxiKioscoId).FirstOrDefault();
                
        }

        public List<ProductoHorario> ListadoProductoHorario(int maxiKioscoId)
        {
            return MaxiKioscosEntities.ObtenerProductoPorCodigo("0", maxiKioscoId).ToList();

        }

        public List<ProductoHorario> ListadoProductoHorarioCombo(int maxiKioscoId)
        {
            return MaxiKioscosEntities.ObtenerProductoPorCodigo("0", maxiKioscoId).Select(p => new ProductoHorario() 
            { ProductoId = p.ProductoId, Descripcion = (p.Codigo + " - " + p.Marca +" - " + p.Descripcion), Codigo = p.Codigo,Precio = p.Precio}).ToList();

        }

        public List<Producto> Listado(string descripcion, int marcaId, int rubroId)
        {
            return DbContext
                .Set<Producto>()
                .Select(p => p)
                .Where(p =>(descripcion==null || p.Descripcion.Contains(descripcion)) &&
                    (marcaId==0 || p.MarcaId==marcaId) &&
                    (rubroId==0 || p.RubroId==rubroId)).ToList();
        }

       public static void EliminarODeshabilitar(int productoId)
        {
            throw new NotImplementedException();
        }

        public static bool Guardar(Producto producto)
        {
            throw new NotImplementedException();
            return true;
        }

        public ProductoCompleto Obtener(int productoId,int maxikioscoId,int proveedorId)
        {
            return this.MaxiKioscosEntities.ProductoListadoCompleto(maxikioscoId, proveedorId, productoId).FirstOrDefault();
        }


        public ProductoParaTransferencia ObtenerParaTransferencia(int productoId, int origenId, int destinoId)
        {
            return this.MaxiKioscosEntities.ProductoParaTransferencia(origenId, destinoId, productoId).FirstOrDefault();
        }

        public List<ProductoStock> ObtenerStock(int productoId)
        {
            return this.MaxiKioscosEntities.ProductoStock(productoId).ToList();
        }

        public List<PromocionCompleta> PromocionesListado(int? rubroId, string descripcion, decimal? precio,
                                    int? stockReposicion, int? conStockMenorA, string codigo)
        {
            return this.MaxiKioscosEntities.PromocionesListado(rubroId, descripcion, precio, stockReposicion,
                    conStockMenorA, codigo).ToList();
        }

        public List<ProductoTransferenciaDesktop> ListadoProductoTransferenciaDesktop(int maxikioscoId)
        {
            return this.MaxiKioscosEntities.ProductoObtenerParaTransferenciaDesktop("0", maxikioscoId).ToList();
        }
    }
}
