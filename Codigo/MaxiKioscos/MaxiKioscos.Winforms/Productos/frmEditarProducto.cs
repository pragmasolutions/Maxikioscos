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
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.Productos.Modulos;
using Util;

namespace MaxiKioscos.Winforms.Productos
{
    public partial class frmEditarProducto : Form
    {
        #region Repositorios

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

        private EFRepository<Marca> _marcaRepository;

        public EFRepository<Marca> MarcaRepository
        {
            get { return _marcaRepository ?? (_marcaRepository = new EFRepository<Marca>()); }
        }

        private EFRepository<Rubro> _rubroRepository;

        public EFRepository<Rubro> RubroRepository
        {
            get { return _rubroRepository ?? (_rubroRepository = new EFRepository<Rubro>()); }
        }

        #endregion

        #region propiedades

        public Producto Producto { get; set; }

        public List<CodigoProducto> Codigos { get; set; }

        public int ProductoId { get; set; }
        #endregion

        public frmEditarProducto(int productoId)
        {
            InitializeComponent();
            ProductoId = productoId;
        }

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            Producto = ProductoRepository.Obtener(p => p.ProductoId == ProductoId, p => p.ProveedorProductos,
                                                  p => p.ProveedorProductos.Select(pp => pp.Proveedor),
                                                  p => p.Marca, p => p.Rubro, p => p.CodigosProductos);
            ActualizarGrillaCodigos();
            CargarControles();
            CargarProducto();

            lblTitulo.Text = "Editar Producto";
            this.Text = "Editar Producto";
        }

        #region Metodos

        private void CargarControles()
        {
            var rubros = RubroRepository.Listado().OrderBy(r => r.Descripcion).ToList();
            
            //verifico que el producto tenga un rubro eliminado y lo agrego a la lista
            if (rubros.All(r => r.RubroId != Producto.RubroId))
                rubros.Insert(0, Producto.Rubro);
            rubros.Insert(0, new Rubro());
            ddlRubro.DisplayMember = "Descripcion";
            ddlRubro.ValueMember = "RubroId";
            ddlRubro.DataSource = rubros;

            var marcas = MarcaRepository.Listado().OrderBy(m => m.Descripcion).ToList();
            
            //verifico que el producto tenga una marca eliminada y la agrego a la lista
            if (marcas.All(r => r.MarcaId != Producto.MarcaId))
                marcas.Insert(0, Producto.Marca);
            marcas.Insert(0, new Marca());
            ddlMarca.DisplayMember = "Descripcion";
            ddlMarca.ValueMember = "MarcaId";
            ddlMarca.DataSource = marcas;
        }

        private void CargarProducto()
        {
            txtDescripcion.Text = Producto.Descripcion;
            txtPrecio.Valor = Producto.PrecioConIVA;
            txtPrecioSinIva.Valor = Producto.PrecioSinIVA;
            txtStockReposicion.Valor = Producto.StockReposicion == null
                                           ? (string) null
                                           : Producto.StockReposicion.ToString();
            ddlMarca.SelectedValue = Producto.MarcaId;
            ddlRubro.SelectedValue  = Producto.RubroId;
            chxAceptaDecimales.Checked = Producto.AceptaCantidadesDecimales;
            chxDisponibleEnDeposito.Checked = Producto.DisponibleEnDeposito;

            if (Producto.FactorAgrupamiento != null)
            {
                txtFactorAgrupamiento.Valor = Producto.FactorAgrupamiento.GetValueOrDefault().ToString();
            }

            var costo = Producto.UltimoCosto;
            txtUltimoCosto.Disabled = true;
            txtUltimoCosto.Valor = costo;

            if (costo != null)
            {
                if (txtUltimoCosto.Valor != null)
                {
                    txtPorcentajeGanancia.Valor = txtPrecio.Valor == null
                                                    ? (int?)null
                                                    : ((txtPrecio.Valor - txtUltimoCosto.Valor) / txtUltimoCosto.Valor) * 100m;
                }
            }

            if (Producto.CodigosProductos.Any(c => !c.Eliminado))
            {
                CargarCodigos();
            }
        }

        private void CargarCodigos()
        {
            Codigos = Producto.CodigosProductos.Where(c => !c.Eliminado).ToList();
            dgvCodigos.DataSource = Codigos.ToArray();
        }

        #endregion


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtDescripcion,
                                                      ddlMarca,
                                                      ddlRubro,
                                                      txtPrecio
                                                  });
            if (valido)
            {
                Producto.AceptaCantidadesDecimales = chxAceptaDecimales.Checked;
                Producto.DisponibleEnDeposito = chxDisponibleEnDeposito.Checked;
                Producto.Descripcion = txtDescripcion.Text;
                Producto.MarcaId = (int)ddlMarca.SelectedValue;
                Producto.PrecioConIVA = txtPrecio.Valor.GetValueOrDefault();
                Producto.PrecioSinIVA = txtPrecioSinIva.Valor.GetValueOrDefault();
                Producto.RubroId = (int)ddlRubro.SelectedValue;
                Producto.FactorAgrupamiento = txtFactorAgrupamiento.ValorEntero;
                Producto.StockReposicion = string.IsNullOrEmpty(txtStockReposicion.Valor)
                                               ? (int?) null
                                               : int.Parse(txtStockReposicion.Valor);
                ProductoRepository.Modificar(Producto);
                ProductoRepository.Commit();
                ActualizacionPantallasHelper.ActualizarPantallaVentas();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void btnCrearCodigo_Click(object sender, EventArgs e)
        {
            var codProd = new CodigoProducto {ProductoId = Producto.ProductoId};
            if (new CrearCodigo(codProd).ShowDialog() == DialogResult.OK)
            {
                ActualizarGrillaCodigos();
            }
        }

        private void ActualizarGrillaCodigos()
        {
            _codigoProductoRepository = new EFRepository<CodigoProducto>();
            Codigos = CodigoProductoRepository.Listado().Where(c => c.ProductoId == Producto.ProductoId).ToList();
            dgvCodigos.DataSource = Codigos.ToArray();
        }

        private void dgvCodigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8) && e.RowIndex >= 0)
            {
                var codigoId = Convert.ToInt32(dgvCodigos.Rows[e.RowIndex].Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 7:
                        EditarCodigo(codigoId);
                        break;
                    case 8:
                        EliminarCodigo(codigoId);
                        break;
                }
            }
        }

        private void EliminarCodigo(int codigoId)
        {
            if (dgvCodigos.RowCount > 1)
            {
                var codigo = Codigos.FirstOrDefault(c => c.CodigoProductoId == codigoId);
                CodigoProductoRepository.Eliminar(codigo);
                CodigoProductoRepository.Commit();
                ActualizarGrillaCodigos();
            }
            else
            {
                MessageBox.Show("Error: Debe haber al menos un código para el producto");
            }
        }

        private void EditarCodigo(int codigoId)
        {
            var codigo = Codigos.FirstOrDefault(c => c.CodigoProductoId == codigoId);
            if (new CrearCodigo(codigo).ShowDialog() == DialogResult.OK)
            {
                ActualizarGrillaCodigos();
            }
        }

        private void dgvCodigos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;

                switch (e.ColumnIndex)
                {
                    case 7:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 8:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 4;
                        break;
                }
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }
        }


        private void txtPrecioSinIva_Cambio()
        {
            var precioSinIva = txtPrecioSinIva.Valor;
            var precioConIva = precioSinIva.GetValueOrDefault() * 1.21m;
            if (txtPrecio.Valor == null || Math.Abs(txtPrecio.Valor.GetValueOrDefault() - precioConIva) > 0.12m)
            {
                txtPrecio.Valor = precioConIva;

                if (txtUltimoCosto.Valor != null)
                {
                    var nuevoPorcentaje = ((txtPrecio.Valor - txtUltimoCosto.Valor) / txtUltimoCosto.Valor) * 100m;
                    if (txtPorcentajeGanancia.Valor == null || Math.Abs(nuevoPorcentaje.GetValueOrDefault() - txtPorcentajeGanancia.Valor.GetValueOrDefault()) > 1.2m)
                    {
                        txtPorcentajeGanancia.Valor = txtPrecio.Valor == null ? (int?)null : nuevoPorcentaje;
                    }

                }
            }
        }

       
        private void txtPrecio_Cambio()
        {
            var precioConIva = txtPrecio.Valor;
            var precioSinIva = precioConIva.GetValueOrDefault() / 1.21m;
            if (txtPrecioSinIva.Valor == null || Math.Abs(txtPrecioSinIva.Valor.GetValueOrDefault() - precioSinIva) > 0.12m)
            {
                txtPrecioSinIva.Valor = precioSinIva;
            }

            if (txtUltimoCosto.Valor != null)
            {
                var nuevoPorcentaje = ((txtPrecio.Valor - txtUltimoCosto.Valor)/txtUltimoCosto.Valor)*100m;
                if (txtPorcentajeGanancia.Valor == null || Math.Abs(nuevoPorcentaje.GetValueOrDefault() - txtPorcentajeGanancia.Valor.GetValueOrDefault()) > 1.2m)
                {
                    txtPorcentajeGanancia.Valor = txtPrecio.Valor == null ? (int?)null : nuevoPorcentaje;
                }
                
            }
        }

        private void txtPorcentajeGanancia_Cambio()
        {
            if (txtUltimoCosto.Valor != null)
            {
                if (txtPorcentajeGanancia.Valor == null)
                {
                    txtPrecio.Valor = null;
                }
                else
                {
                    var nuevoPrecio = (txtPorcentajeGanancia.Valor * txtUltimoCosto.Valor) / 100 + txtUltimoCosto.Valor;
                    if (txtPrecio.Valor == null || Math.Abs(nuevoPrecio.GetValueOrDefault() - txtPrecio.Valor.GetValueOrDefault()) > 0.12m)
                    {
                        txtPrecio.Valor = nuevoPrecio;
                    }
                }
            }
            txtPrecio_Cambio();
        }

        private void frmEditarProducto_Shown(object sender, EventArgs e)
        {
            txtDescripcion.Select();
        }
    }
}
