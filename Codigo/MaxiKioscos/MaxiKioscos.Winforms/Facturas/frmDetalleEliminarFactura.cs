using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;

namespace MaxiKioscos.Winforms.Facturas
{
    public partial class frmDetalleEliminarFactura : Form
        
    {
        private EFRepository<Factura> _facturaRepository;
        public EFRepository<Factura> FacturaRepository
        {
            get
            {
                if (_facturaRepository == null)
                    _facturaRepository = new EFRepository<Factura>();
                return _facturaRepository;
            }
        }

        private EFRepository<Compra> _compraRepository;
        public EFRepository<Compra> CompraRepository
        {
            get
            {
                if (_compraRepository == null)
                    _compraRepository = new EFRepository<Compra>();
                return _compraRepository;
            }
        }
        
        #region propiedades

        public string AutoNumerico
        {
            get { return ucAutonumerico.Texto; }
            set { ucAutonumerico.Texto = value; }
        }

        public string FacturaNro
        {
            get { return txtFacturaNro.Texto; }
            set { txtFacturaNro.Texto = value; }
        }

        public string ImporteTotal
        {
            get { return txtImporteTotal.Texto; }
            set { txtImporteTotal.Texto = value; }
        }

        public string Fecha
        {
            get { return txtFecha.Texto; }
            set { txtFecha.Texto = value; }
        }
        
        public string ProveedorFactura
        {
            get { return txtProveedor.Texto; }
            set { txtProveedor.Texto = value; }
        }

        public Factura Factura { get; set; }

        public string Operacion { get; set; }

        #endregion

        public frmDetalleEliminarFactura(int facturaId, string operacion)
        {
            InitializeComponent();
            CargarFactura(facturaId);

            Operacion = operacion;
            if (operacion == "Eliminar")
            {
                lblTitulo.Text = "Eliminar Factura";
                this.Text = "Eliminar Factura";
                btnCancelar.Visible = true;
                btnAceptar.Text = "Aceptar";
            }
            else
            {
                lblTitulo.Text = "Detalle de Factura";
                this.Text = "Detalle de Factura";
                btnCancelar.Visible = false;
                btnAceptar.Location = new Point(391, 417);
            }
        }

        #region Metodos
        private void CargarFactura(int facturaId)
        {

            Factura = FacturaRepository.Obtener(f => f.FacturaId == facturaId, f => f.Proveedor, 
                f => f.Compras, f => f.Compras.Select(c => c.ComprasProductos),
                f => f.Compras.Select(c => c.ComprasProductos.Select(cp => cp.Producto)));

            FacturaNro = Factura.FacturaNro;
            AutoNumerico = Factura.AutoNumero;
            ImporteTotal = "$" + Factura.ImporteTotal.ToString("N2");
            Fecha = Factura.Fecha.ToString();

            ProveedorFactura = Factura.ProveedorNombre;
            if (Factura.Compras.Count > 0) 
            {
                var compraId = Factura.Compras.FirstOrDefault().CompraId;
                CargarProductos(compraId);
            }
            

        }

        private void CargarProductos(int compraId)
        {
            
            var compra = CompraRepository.Obtener(c => c.CompraId == compraId,
                                                    c => c.ComprasProductos,
                                                    c => c.ComprasProductos.Select(cp => cp.Producto));
            //var venta = Repository.Obtener(v => v.VentaId == ventaId,
            //                              v => v.VentaProductos,
            //                              v => v.VentaProductos.Select(vp => vp.Producto));

            txtFecha.Texto = String.Format("{0} {1}",
                                            compra.Fecha.ToShortDateString(),
                                            compra.Fecha.ToShortTimeString());

            txtImporteTotal.Texto = String.Format("${0:f2}", compra.Total);

            dgvCompraProductos.DataSource = compra.ComprasProductos.ToList();
        }
        #endregion


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Eliminar")
            {
                //verifico si ya tiene productos asociados
                if (Factura.Compras.Count > 0)
                {
                    MessageBox.Show("No puede eliminarse esta factura porque ya tiene productos asociados");
                    this.DialogResult = DialogResult.None;
                }
            }
        }
    }
}
