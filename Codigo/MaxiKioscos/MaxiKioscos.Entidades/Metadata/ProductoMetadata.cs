using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Maxikioscos.Comun.Extensions;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ProductoMetadata))]
    public partial class Producto : IEntity, ISynchronizableEntity, IValidatableObject
    {
        public string RubroString { get { return this.Rubro.Descripcion; } }

        public string MarcaString
        {
            get
            {
                if (this.Marca == null)
                    return string.Empty;
                return this.Marca.Descripcion;
            }
        }

        public string CodigosListado
        {
            get
            {
                if (CodigosProductos == null || CodigosProductos.Count == 0)
                    return string.Empty;
                var cods = CodigosProductos.Where(c => !c.Eliminado).ToList();
                if (cods.Count == 0)
                    return string.Empty;

                var codigos = cods.First().Codigo;
                if (cods.Count == 1)
                    return codigos;
                for (int i = 1; i < cods.Count; i++)
                {
                    codigos += String.Format(", {0}", cods.ElementAt(i).Codigo);
                }
                return codigos;
            }
        }
        
        public string ProveedoresListado
        {
            get
            {
                if (ProveedorProductos == null || !ProveedorProductos.Any())
                    return string.Empty;
                var proveedores = ProveedorProductos.First().Proveedor.Nombre;
                if (ProveedorProductos.Count == 1)
                    return proveedores;
                for (int i = 1; i < ProveedorProductos.Count(); i++)
                {
                    proveedores += String.Format(", {0}", ProveedorProductos.ElementAt(i).Proveedor.Nombre);
                }
                return proveedores;
            }
        }

        public string CostosListado
        {
            get
            {
                if (ProveedorProductos == null || !ProveedorProductos.Any())
                    return string.Empty;
                var proveedores = String.Format("${0}", ProveedorProductos.First().CostoConIVA.ToString("N2"));
                if (ProveedorProductos.Count == 1)
                    return proveedores;
                for (int i = 1; i < ProveedorProductos.Count(); i++)
                {
                    proveedores += String.Format(", ${0}", ProveedorProductos.ElementAt(i).CostoConIVA.ToString("N2"));
                }
                return proveedores;
            }
        }

        public string CostosResumen
        {
            get
            {
                if (ProveedorProductos == null || ProveedorProductos.Count == 0)
                    return string.Empty;

                var costos = ProveedorProductos.Where(c => !c.Eliminado).ToList();

                if (costos.Count == 0)
                    return string.Empty;

                var costosListado = new List<string>();

                foreach (var costo in costos)
                {
                    var proveedor = costo.ProveedorNombre.ToUpper();
                    if (proveedor.Count() > 4)
                    {
                        proveedor = proveedor.Substring(0, 4);
                    }
                    costosListado.Add(string.Format("({0}) {1:c2}", proveedor, costo.CostoConIVA));
                }

                return string.Join(", ", costosListado);
            }
        }

        public DateTime? FechaUltimaCompra
        {
            get
            {
                var ultimaCompra = this.ComprasProductos.OrderByDescending(cp => cp.Compra.Fecha).Select(cp =>cp.Compra).FirstOrDefault();
                return ultimaCompra != null ? (DateTime?) ultimaCompra.Fecha : null;
            }
        }

        public IEnumerable<ProveedorProducto> Costos
        {
            get { return this.ProveedorProductos.Where(pp => !pp.Eliminado); }
        }

        public decimal? UltimoCosto
        {
            get
            {
                if (!ProveedorProductos.Any())
                return null;

            var prod = ProveedorProductos.FirstOrDefault(pp => pp.FechaUltimaModificacion == ProveedorProductos.Max(p => p.FechaUltimaModificacion));
            return prod.CostoConIVA;
            }
        }

        public DateTime? UltimaModificacionCosto
        {
            get
            {
                if (!ProveedorProductos.Any())
                    return null;

                return ProveedorProductos.Max(pp => pp.FechaUltimoCambioCosto);
            }
        }

        public DateTime? UltimaCompraCosto
        {
            get
            {
                if (!ComprasProductos.Any())
                    return null;

                var prod = ComprasProductos.FirstOrDefault(pp => pp.FechaUltimaModificacion == ComprasProductos.Max(p => p.FechaUltimaModificacion));
                return prod.FechaUltimaModificacion;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (this.ProveedorProductos.HasDuplicates(new ProveedorProductoComparer()))
            {
                errors.Add(new ValidationResult("No puede haber dos costos para un mismo proveedor"));
            }

            return errors;
        }

        public List<PromocionMaxikiosco> PromocionMaxikioscos { get; set; }

        public decimal? Ganancia
        {
            get
            {
                ProveedorProducto pp = ProveedorProductos.Any(x => x.FechaUltimoCambioCosto != null)
                            ? ProveedorProductos.OrderByDescending(x => x.FechaUltimoCambioCosto).FirstOrDefault()
                            : ProveedorProductos.OrderByDescending(x => x.FechaUltimaModificacion).FirstOrDefault();
                if (pp == null)
                {
                    return null;
                }
                return ((this.PrecioConIVA - pp.CostoConIVA) / pp.CostoConIVA) * 100;
            }
        }

        public decimal GetStockPorMaxikiosco(int maxikioscoId)
        {
            var transacciones = this.Stocks.Where(x => !x.Eliminado && x.MaxiKioscoId == maxikioscoId)
                    .SelectMany(x => x.StockTransacciones)
                    .Where(x => !x.Eliminado);

            return transacciones.Select(x => x.Cantidad).DefaultIfEmpty(0).Sum();
        }
    }

    public class ProductoMetadata
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        [Required(ErrorMessage = "Debe ingresar un rubro")]
        public int RubroId { get; set; }

        [Display(Name = "Marca")]
        [UIHint("Marca")]
        [Required(ErrorMessage = "Debe ingresar una marca")]
        public int? MarcaId { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio con IVA")]
        [Required(ErrorMessage = "Debe ingresar un precio")]
        [DataType(DataType.Currency)]
        public decimal PrecioConIVA { get; set; }

        [Display(Name = "Precio sin IVA")]
        [Required(ErrorMessage = "Debe ingresar un precio")]
        [DataType(DataType.Currency)]
        public decimal PrecioSinIVA { get; set; }

        [Display(Name = "Stock reposicion")]
        public int? StockReposicion { get; set; }

        [DisplayName("Acepta Stock decimal")]
        public bool AceptaCantidadesDecimales { get; set; }

        [DisplayName("Disponible en Depósito")]
        public bool DisponibleEnDeposito { get; set; }

        [DisplayName("Factor de Agrupamiento")]
        public int? FactorAgrupamiento { get; set; }
    }

    public class ProveedorProductoComparer : IEqualityComparer<ProveedorProducto>
    {
        public bool Equals(ProveedorProducto x, ProveedorProducto y)
        {
            return x.ProveedorId == y.ProveedorId;
        }

        public int GetHashCode(ProveedorProducto obj)
        {
            return obj.ProveedorId.GetHashCode();
        }
    }
}

