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
    public partial class frmCrearProducto : Form
    {
        #region Propiedades

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

        public int ProductoId { get; set; }

        #endregion

        public frmCrearProducto()
        {
            InitializeComponent();
            CargarControles();

            lblTitulo.Text = "Crear Producto";
            this.Text = "Crear Producto";
        }

        #region Metodos

        private void CargarControles()
        {
            var rubros = RubroRepository.Listado().OrderBy(r => r.Descripcion).ToList();
            rubros.Insert(0, new Rubro());
            ddlRubro.DisplayMember = "Descripcion";
            ddlRubro.ValueMember = "RubroId";
            ddlRubro.DataSource = rubros;

            var marcas = MarcaRepository.Listado().OrderBy(m => m.Descripcion).ToList();
            marcas.Insert(0, new Marca());
            ddlMarca.DisplayMember = "Descripcion";
            ddlMarca.ValueMember = "MarcaId";
            ddlMarca.DataSource = marcas;
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
                                                      txtPrecio,
                                                      txtCodigo
                                                  });
            if (valido)
            {
                var cod = CodigoProductoRepository.Obtener(c => c.Codigo == txtCodigo.Valor
                                                && !c.Eliminado
                                                && c.Producto.CuentaId == UsuarioActual.CuentaId);
                if (cod != null)
                {
                    errorProvider1.SetError(txtCodigo, "Ya existe un producto con el código ingresado");
                    errorProvider1.SetIconPadding(txtCodigo, 2);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    var prod = new Producto()
                           {
                               AceptaCantidadesDecimales = chxAceptaDecimales.Checked,
                               DisponibleEnDeposito = chxDisponibleEnDeposito.Checked,
                               Descripcion = txtDescripcion.Text,
                               MarcaId = Convert.ToInt32(ddlMarca.SelectedValue),
                               PrecioConIVA = txtPrecio.Valor.GetValueOrDefault(),
                               PrecioSinIVA = txtPrecioSinIva.Valor.GetValueOrDefault(),
                               RubroId = Convert.ToInt32(ddlRubro.SelectedValue),
                               StockReposicion = string.IsNullOrEmpty(txtStockReposicion.Valor)
                                                       ? (int?)null
                                                       : int.Parse(txtStockReposicion.Valor),
                               Identifier = Guid.NewGuid(),
                               CuentaId = UsuarioActual.CuentaId,
                               EsPromocion = false
                           };



                    ProductoRepository.Agregar(prod);
                    ProductoRepository.Commit();

                    var codigo = new CodigoProducto()
                                     {
                                         Codigo = txtCodigo.Valor,
                                         ProductoId = prod.ProductoId,
                                         Identifier = Guid.NewGuid()
                                     };
                    CodigoProductoRepository.Agregar(codigo);
                    CodigoProductoRepository.Commit();

                    ProductoId = prod.ProductoId;
                    ActualizacionPantallasHelper.ActualizarPantallaVentas();
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void txtPrecioSinIva_Cambio()
        {
            var precioSinIva = txtPrecioSinIva.Valor;
            var precioConIva = precioSinIva.GetValueOrDefault() * 1.21m;
            if (txtPrecio.Valor == null || Math.Abs(txtPrecio.Valor.GetValueOrDefault() - precioConIva) > 0.12m)
            {
                txtPrecio.Valor = precioConIva;
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
        }

        private void frmCrearProducto_Shown(object sender, EventArgs e)
        {
            txtDescripcion.Select();
        }
    }
}
