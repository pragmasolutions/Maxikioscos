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

namespace MaxiKioscos.Winforms.Productos
{
    public partial class frmDetalleEliminarProducto : Form
        
    {
        private EFRepository<Producto> _productoRepository;
        public EFRepository<Producto> ProductoRepository
        {
            get { return _productoRepository ?? (_productoRepository = new EFRepository<Producto>()); }
        }

        private EFRepository<CodigoProducto> _codigoProductoRepository;
        public EFRepository<CodigoProducto> CodigoProductoRepository
        {
            get { return _codigoProductoRepository ?? (_codigoProductoRepository = new EFRepository<CodigoProducto>()); }
        }

        #region propiedades
        
        public string Descripcion
        {
            get { return txtDescripcion.Texto; }
            set { txtDescripcion.Texto = value; }
        }

        public string Marca
        {
            get { return txtMarca.Texto; }
            set { txtMarca.Texto = value; }
        }

        public string Rubro
        {
            get { return txtRubro.Texto; }
            set { txtRubro.Texto = value; }
        }

        public string Precio
        {
            get { return txtPrecio.Texto; }
            set { txtPrecio.Texto=value;}
        }
    
        
        public string AceptaCantidadesDecimales
        {
            get { return txtAceptaCantidadesDecimales.Texto; }
            set { txtAceptaCantidadesDecimales.Texto = value; }
        }

        public string DisponibleEnDeposito
        {
            get { return txtDisponibleEnDeposito.Texto; }
            set { txtDisponibleEnDeposito.Texto = value; }
        }

        public string StockReposicion
        {
            get { return txtStockReposicion.Texto; }
            set { txtStockReposicion.Texto = value; }
        }

        public string Codigos
        {
            get { return txtCodigos.Texto; }
            set { txtCodigos.Texto = value; }
        }

        public Producto Producto { get; set; }

        public string Operacion { get; set; }

        #endregion

        public frmDetalleEliminarProducto(int productoId, string operacion)
        {
            InitializeComponent();
            CargarProducto(productoId);

            Operacion = operacion;
            if (operacion == "Eliminar")
            {
                lblTitulo.Text = "Eliminar Producto";
                this.Text = "Eliminar Producto";
                btnCancelar.Visible = true;
                btnAceptar.Text = "Aceptar";
            }
            else
            {
                lblTitulo.Text = "Detalle de Producto";
                this.Text = "Detalle de Producto";
                btnCancelar.Visible = false;
                btnAceptar.Location = new Point(391, 417);
                this.Select();
            }
        }

        #region Metodos
        private void CargarProducto(int prodcutoId)
        {

            Producto = ProductoRepository.Obtener(p => p.ProductoId == prodcutoId, p => p.ProveedorProductos, 
                p => p.ProveedorProductos.Select(pp => pp.Proveedor),
                p => p.Marca, p => p.Rubro, p => p.CodigosProductos);

            Descripcion = Producto.Descripcion;
            Precio = "$" + Producto.PrecioConIVA.ToString("N2");
            Rubro = Producto.Rubro.Descripcion;
            Marca = Producto.Marca == null ? string.Empty : Producto.Marca.Descripcion;
            Codigos = Producto.CodigosListado;
            AceptaCantidadesDecimales = Producto.AceptaCantidadesDecimales ? "SI" : "NO";
            DisponibleEnDeposito = Producto.DisponibleEnDeposito ? "SI" : "NO";
            StockReposicion = Producto.StockReposicion == null
                            ? string.Empty
                            : Producto.StockReposicion.GetValueOrDefault().ToString("N2");
            if (Producto.ProveedorProductos.Count > 0) 
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            dgvProveedores.Columns[2].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvProveedores.DataSource = Producto.ProveedorProductos.ToList();
        }
        #endregion


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Eliminar")
            {
                var codigos = CodigoProductoRepository.Listado()
                    .Where(c => c.ProductoId == Producto.ProductoId && !c.Eliminado).ToList();
                if (codigos.Any())
                {
                    foreach (var codigoProducto in codigos)
                    {
                        CodigoProductoRepository.Eliminar(codigoProducto);
                    }
                    CodigoProductoRepository.Commit();
                }
                
                ProductoRepository.Eliminar(Producto.ProductoId);
                ProductoRepository.Commit();
            }
        }

        private void frmDetalleEliminarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }

        private void btnAceptar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }

        
    }
}
