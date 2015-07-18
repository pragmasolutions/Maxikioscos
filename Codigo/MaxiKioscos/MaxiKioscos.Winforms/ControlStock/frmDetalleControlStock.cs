using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.DataStruct;

namespace MaxiKioscos.Winforms.ControlStock
{
    public partial class frmDetalleControlStock : Form
        
    {
        private ControlStockRepository _controlStockRepository;
        public ControlStockRepository ControlStockRepository
        {
            get { return _controlStockRepository ?? (_controlStockRepository = new ControlStockRepository()); }
        }

        
        public frmDetalleControlStock(int controlStockId)
        {
            InitializeComponent();
            CargarControl(controlStockId);
        }

        #region Metodos
        private void CargarControl(int controlStockId)
        {

            var control = ControlStockRepository.Obtener(cs => cs.ControlStockId == controlStockId, 
                                            cs => cs.Rubro, cs => cs.Proveedor,
                                            cs => cs.ControlStockDetalles, cs => cs.ControlStockDetalles.Select(csd => csd.Stock),
                                            cs => cs.ControlStockDetalles.Select(csd => csd.Stock.Producto),
                                            cs => cs.ControlStockDetalles.Select(csd => csd.Stock.Producto.CodigosProductos),
                                            cs => cs.ControlStockDetalles.Select(csd => csd.MotivoCorreccion));
            txtEstado.Texto = control.Estado;
            txtFecha.Texto = control.FechaCreacion.ToShortDateString();
            txtFechaCorreccion.Texto = control.FechaCorreccion == null ? string.Empty : control.FechaCorreccion.GetValueOrDefault().ToShortDateString();
            txtProveedor.Texto = control.ProveedorNombre;
            txtRubro.Texto = control.RubroDescripcion;

            CargarDetalles(control);
        }

        private void CargarDetalles(Entidades.ControlStock control)
        {
            var lista = control.ControlStockDetalles.Select(c => new ControlStockDetalleGridStruct
                                                                     {
                                                                         ControlStockDetalleId = c.ControlStockDetalleId,
                                                                         Cantidad = c.Cantidad,
                                                                         Codigo = c.Stock.Producto.CodigosListado,
                                                                         Correccion = c.Correccion,
                                                                         Motivo = c.MotivoCorreccionNombre,
                                                                         Producto = c.ProductoNombre
                                                                     }).OrderBy(p => p.Producto).ToList();
            dgvDetalles.DataSource = lista;
        }
        #endregion
    }
}
