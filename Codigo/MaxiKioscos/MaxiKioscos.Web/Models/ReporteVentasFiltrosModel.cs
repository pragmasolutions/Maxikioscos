using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaxiKioscos.Reportes.Enumeraciones;

namespace MaxiKioscos.Web.Models
{
    public class ReporteVentasFiltrosModel : ReporteRangoFechaBase
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [Display(Name = "Mostrar totales generales")]
        public bool MostrarTotalGeneral { get; set; }
    }

    public class ReporteVentasProveedorFiltrosModel : ReporteVentasFiltrosModel
    {
        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }
    }

    public class ReporteTransferenciasPorProductosFiltrosModel : ReporteRangoFechaBase
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Maxikiosco Origen")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoOrigenId { get; set; }

        [Display(Name = "Maxikiosco Destino")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoDestinoId { get; set; }

        [Display(Name = "Mostrar totales generales")]
        public bool MostrarTotalGeneral { get; set; }
    }

    public class ReporteStockValorizadoFiltrosModel : ReporteModelBase
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [Display(Name = "Mostrar totales generales")]
        public bool MostrarTotalGeneral { get; set; }
    }


    public class ReporteVentasCierreCajaFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        [Required(ErrorMessage = "Debe seleccionar un maxikiosco")]
        public int? MaxikioscoId { get; set; }

        [Display(Name = "Cierre de Caja")]
        [Required(ErrorMessage = "Debe seleccionar un cierre de caja")]
        public int CierreCajaId { get; set; }

        public ReporteVentasCierreCajaFiltrosModel()
        {
            this.Fecha = DateTime.UtcNow;
        }
    }

    public class GanaciaAdicionalExcepcionRubroFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }
    }

    public class RetirosPersonalesPorTicketFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Usuario")]
        [UIHint("Usuario")]
        public int? UsuarioId { get; set; }
    }

    public class ReporteCierresDeCajaFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [Display(Name = "Usuario")]
        [UIHint("Usuario")]
        public int? UsuarioId { get; set; }
    }

    public class ReporteRetirosPersonalesFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }
        
        [Display(Name = "Usuario")]
        [UIHint("Usuario")]
        public int? UsuarioId { get; set; }
    }

    public class ReporteDineroSobranteFaltanteFiltrosModel : ReporteModelBase
    {
        public ReporteDineroSobranteFaltanteFiltrosModel()
        {
            var now = DateTime.UtcNow;
            Desde = new DateTime(now.Year, now.Month, 1);
            Hasta = now;
        }

        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }
    }

    public class ReporteStockFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }
    }

    public class ReporteDescuentoProveedoresFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }
    }

    public class ReporteComprasPorProveedorFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }
    }

    public class ReporteSugerenciaComprasFiltrosModel : ReporteModelBase
    {
        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        [Required(ErrorMessage = "Debe ingresar un maxikiosco")]
        public int? MaxiKioscoId { get; set; }

        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        [Required(ErrorMessage = "Debe ingresar un proveedor")]
        public int? ProveedorId { get; set; }

        [Display(Name = "Días")]
        [Required(ErrorMessage = "Debe ingresar una duración en días")]
        [Range(1, int.MaxValue, ErrorMessage = "La duración en días debe ser mayor a cero")]
        public int? Dias { get; set; }
    }

    


    public class ReporteReposicionFiltrosModel : ReporteModelBase
    {
        [Display(Name = "Producto")]
        [UIHint("Producto")]
        public int? ProductoId { get; set; }

        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }
    }

    public class ReporteModelBase
    {
        public ReporteTipoEnum ReporteTipo { get; set; }
    }

    public class ReporteGastoPorCategoriaFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("Maxikiosco")]
        public int? MaxikioscoId { get; set; }

        [Display(Name = "Categoria")]
        [UIHint("Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Sub Categoria")]
        [UIHint("SubCategoria")]
        public int? SubCategoriaId { get; set; }

        [Display(Name = "Mostrar totales generales")]
        public bool MostrarTotalGeneral { get; set; }

    }

    public class ReporteGastoPorCategoriaTotalGeneralFiltrosModel : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }
    }

    public class ReporteRangoFechaBase : ReporteModelBase
    {
        [DataType(DataType.Date)]
        public DateTime? Desde { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Hasta { get; set; }

        public DateTime? HastaDiaSiguiente
        {
            get
            {
                DateTime? hasta = Hasta == null
                ? (DateTime?)null
                : this.Hasta.GetValueOrDefault().AddDays(1);

                return hasta;
            }
        }
    }
}