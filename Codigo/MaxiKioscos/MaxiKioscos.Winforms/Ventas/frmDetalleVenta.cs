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

namespace MaxiKioscos.Winforms.Ventas
{
    public partial class frmDetalleVenta : Form
    {
        private EFSimpleRepository<Venta> _repository;
        public EFSimpleRepository<Venta> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<Venta>()); }
        }

        public frmDetalleVenta(int ventaId)
        {
            InitializeComponent();
            var venta = Repository.Obtener(v => v.VentaId == ventaId,
                                           v => v.VentaProductos,
                                           v => v.VentaProductos.Select(vp => vp.Producto),
                                           v => v.VentaProductos.Select(vp => vp.Producto.CodigosProductos));
                                                 
            txtFecha.Texto = String.Format("{0} {1}", 
                                            venta.FechaVenta.ToShortDateString(),
                                            venta.FechaVenta.ToShortTimeString());
            txtImporteTotal.Texto = String.Format("${0:f2}", venta.ImporteTotal);
            dgvVentaProductos.DataSource = venta.VentaProductos.ToList();
            dgvVentaProductos.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            btnAceptar.Focus();
        }

        private void frmDetalleVenta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }
    }
}
