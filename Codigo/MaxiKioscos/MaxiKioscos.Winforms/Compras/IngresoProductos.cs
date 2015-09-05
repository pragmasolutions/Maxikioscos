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
using MaxiKioscos.Winforms.Facturas;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Interfaces;
using MaxiKioscos.Winforms.Productos;
using MaxiKioscos.Winforms.Productos.Modulos;
using MaxiKioscos.Winforms.Properties;

namespace MaxiKioscos.Winforms.Compras
{
    public partial class IngresoProductos : Form, IBuscadorParent
    {
        #region Repositorios

        private EFRepository<Usuario> _usuarioRepository;
        public EFRepository<Usuario> UsuarioRepository
        {
            get { return _usuarioRepository ?? (_usuarioRepository = new EFRepository<Usuario>()); }
        }

        private EFRepository<Factura> _facturaRepository;
        public EFRepository<Factura> FacturaRepository
        {
            get { return _facturaRepository ?? (_facturaRepository = new EFRepository<Factura>()); }
        }

        private EFRepository<Producto> _productoRepository;
        public EFRepository<Producto> ProductoRepository
        {
            get { return _productoRepository ?? (_productoRepository = new EFRepository<Producto>()); }
        }

        private EFRepository<ProveedorProducto> _proveedorProductoRepository;
        public EFRepository<ProveedorProducto> ProveedorProductoRepository
        {
            get {
                return _proveedorProductoRepository ??
                        (_proveedorProductoRepository = new EFRepository<ProveedorProducto>());
            }
        }

        private EFSimpleRepository<Cuenta> _cuentaRepository;
        public EFSimpleRepository<Cuenta> CuentaRepository
        {
            get { return _cuentaRepository ?? (_cuentaRepository = new EFSimpleRepository<Cuenta>()); }
        }

        private EFRepository<Compra> _compraRepository;
        public EFRepository<Compra> CompraRepository
        {
            get { return _compraRepository ?? (_compraRepository = new EFRepository<Compra>()); }
        }

        private EFRepository<StockTransaccion> _stockTransaccionRepository;
        public EFRepository<StockTransaccion> StockTransaccionRepository
        {
            get {
                return _stockTransaccionRepository ??
                        (_stockTransaccionRepository = new EFRepository<StockTransaccion>());
            }
        }

        private StockRepository _stockRepository;
        public StockRepository StockRepository
        {
            get { return _stockRepository ?? (_stockRepository = new StockRepository()); }
        }


        #endregion

        public decimal CostoFinal { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public decimal DGR { get; set; }

        private Timer _timerArrow;
        private bool _pressingArrow = false;
        private Keys _pressingOperation { get; set; }
        private string _ultimaBusqueda { get; set; }
        private ProductoCriterioBusqueda _ultimoCriterio  = ProductoCriterioBusqueda.Codigo;
        
        #region Factura

        public decimal ImporteTotal
        {
            get { return txtImporteTotal.Valor.GetValueOrDefault(); }
            set { txtImporteTotal.Valor = value; }
        }

        public decimal? DescuentoPorcentaje
        {
            get
            {
                return txtDescuentoPorcentaje.ValorDecimal.GetValueOrDefault();
            }
            set
            {
                txtDescuentoPorcentaje.ValorDecimal = value;
            }
        }


        public decimal? DescuentoEnPesos
        {
            get { return txtDescuentoImporte.Valor; }
            set { txtDescuentoImporte.Valor = value; }
        }

        public decimal? Descuento
        {
            get { return txtDescuento.Valor; }
            set { txtDescuento.Valor = value; }
        }

            
        public decimal ImporteFinal
            {
                get
                {
                    var costo = lblCosto.Text;
                    costo = costo.Replace("$", "");
                    return Convert.ToDecimal(costo);
                }
                set
                {
                    lblCosto.Text = String.Format("${0}", value.ToString("N2"));
                }
            }

        #endregion

        private Cuenta Cuenta { get; set; }
        private Usuario Usuario { get; set; }
        private Factura Factura { get; set; }

        public List<ProductoCompleto> ProductosDatasource { get; set; }
        public List<CompraProducto> ComprasProducto { get; set; }
        public bool IsAdmin { get; set; }
        
        public IngresoProductos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            IsAdmin = UsuarioActual.TieneRol("Administrador") || UsuarioActual.TieneRol("SuperAdministrador");
            
            ComprasProducto = new List<CompraProducto>();

            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            
            Usuario = UsuarioRepository.Obtener(u => u.UsuarioId == usuarioId,
                                                u => u.UsuarioProveedores,
                                                u => u.UsuarioProveedores.Select(p => p.Proveedor),
                                                u => u.Roles);
            Cuenta = CuentaRepository.Obtener(Usuario.CuentaId);

            StockRepository.Actualizar();

            var facturas = FacturaRepository.MaxiKioscosEntities.FacturaObtenerAbiertasPorUsuario(usuarioId, AppSettings.MaxiKioscoId).ToList();
            facturas.Insert(0, new FacturaCompleta());

            ddlFacturas.DataSource = facturas;
            ddlFacturas.ValueMember = "FacturaId";
            ddlFacturas.DisplayMember = "NombreCompleto";
            ddlFacturas.Focus();
        }

        private void ddlFacturas_ComboSelectedIndexChanged(object sender, EventArgs e)
        {
            var valor = ddlFacturas.Valor;
            if (valor != 0)
            {
                Factura = FacturaRepository.Obtener(f => f.FacturaId == valor, f => f.Proveedor);
                ProveedorId = Factura.ProveedorId;
                ImporteTotal = Factura.ImporteTotal;
                txtImporteTotal_Cambio();

                if (IsAdmin)
                {
                    txtDescuentoImporte.Disabled = false;
                    txtDescuentoPorcentaje.Disabled = true;
                    chxIVA.Enabled = true;
                    chxDGR.Enabled = true;
                }
                else
                {
                    txtDescuentoImporte.Disabled = true;
                    txtDescuentoPorcentaje.Disabled = true;
                    chxIVA.Enabled = false;
                    chxDGR.Enabled = false;
                }

                var dgr = Factura.Proveedor.PercepcionDGR.GetValueOrDefault();
                lblDGR.Text = String.Format("DGR ({0}%)", dgr.ToString("N2"));

                
                
                CargarCombo();
                txtCodigo.Enabled = true;
                btnBuscar.Enabled = true;
                btnBottomBuscar.Enabled = true;
                btnBottomNuevoProducto.Enabled = true;

                ddlTipoComprobante.Disabled = false;
                if (!string.IsNullOrEmpty(Factura.Proveedor.TipoComprobante))
                {
                    ddlTipoComprobante.Texto = Factura.Proveedor.TipoComprobante;
                }
                

                ComprasProducto = new List<CompraProducto>();
                RefrescarGrilla();
                txtCodigo.Focus();
            }
            else
            {
                ProveedorId = 0;
                txtCodigo.Enabled = false;
                btnBottomBuscar.Enabled = false;
                btnBuscar.Enabled = false;
                btnBottomNuevoProducto.Enabled = false;
                lblDGR.Text = "DGR (0,00%)";
                txtDGR.Valor = 0;
                txtDescuentoImporte.Disabled = true;
                txtDescuentoPorcentaje.Disabled = true;
                ddlTipoComprobante.Disabled = true;

                chxIVA.Enabled = false;
                chxDGR.Enabled = false;
                txtImporteTotal.Valor = 0;
            }

            radDescuentoImporte.Checked = true;
            txtIVA.Valor = 0;
            txtTotalCompra.Valor = 0;
            txtDescuento.Valor = 0;
            txtTotalConDescuento.Valor = 0;
            txtDGR.Disabled = true;
            txtIVA.Disabled = true;
            txtDGR.Valor = 0;
            txtIVA.Valor = 0;
            chxDGR.Checked = false;
            chxIVA.Checked = false;

        }
        
        public void FocusOnCodeTextbox()
        {
            txtCodigo.Focus();
        }

        private void NuevoProducto()
        {
            var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
            if (user != 0)
            {
                using (var frm = new frmCrearProducto())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var prod = ProductoRepository.MaxiKioscosEntities
                                .ProductoListadoCompleto(AppSettings.MaxiKioscoId, null, frm.ProductoId).
                                FirstOrDefault();
                        using (var frmCosto = new IngresarCosto(prod.Descripcion))
                        {
                            if (frmCosto.ShowDialog() == DialogResult.OK)
                            {
                                //Modifico el costo de proveedor para ese producto
                                var proveedorProd = new ProveedorProducto()
                                {
                                    CostoConIVA = frmCosto.Costo.GetValueOrDefault(),
                                    ProductoId = prod.ProductoId,
                                    ProveedorId = ProveedorId,
                                    Identifier = Guid.NewGuid(),
                                    FechaUltimoCambioCosto = DateTime.Now
                                };
                                ProveedorProductoRepository.Agregar(proveedorProd);
                                ProveedorProductoRepository.Commit();
                                prod.CostoConIVA = frmCosto.Costo;
                                
                                AgregarProducto(prod);
                            }
                            ProductosDatasource.Add(prod);
                        }
                        
                    }
                }
            }
            txtCodigo.Text = string.Empty;
            txtCodigo.Focus();
        }
        
        private void FrmOnTeclaApretada(Keys key)
        {
            var texto = txtCodigo.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(key);
            }
            else
            {
                TratarTextoDistintoVacio(key);
            }
        }

        private void TratarTextoDistintoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.Down:
                        ActivarArrowTimer(Keys.Down);
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        ActivarArrowTimer(Keys.Down);
                        BuscadorSubir();
                        break;
                    case Keys.Enter:
                        Agregar();
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                }
            }
        }

        private void ActivarArrowTimer(Keys key)
        {
            if (!_pressingArrow)
            {
                _timerArrow = new Timer();
                _timerArrow.Interval = 500;
                _timerArrow.Tick += TimerArrowOnTick;
                _timerArrow.Start();
                _pressingOperation = key;
            }
        }

        private void TimerArrowOnTick(object sender, EventArgs eventArgs)
        {
            if (_pressingArrow)
            {
                if (_pressingOperation == Keys.Down)
                    BuscadorBajar();
                else
                    BuscadorSubir();
                _timerArrow.Interval = 50;
            }
            else
            {
                _timerArrow.Stop();
            }
        }

        private void TratarTextoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.F5, Keys.F6, Keys.Delete, Keys.Escape, Keys.Enter, Keys.Down, Keys.Up};
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.F5:
                        txtCodigo.Text = _ultimaBusqueda;
                        _ultimoCriterio = ProductoCriterioBusqueda.Marca;
                        AbrirBuscador(_ultimoCriterio);
                        txtCodigo.Select(0, txtCodigo.Text.Length);
                        break;
                    case Keys.F6:
                        txtCodigo.Text = _ultimaBusqueda;
                        _ultimoCriterio = ProductoCriterioBusqueda.Descripcion;
                        AbrirBuscador(_ultimoCriterio);
                        txtCodigo.Select(0, txtCodigo.Text.Length);
                        break;
                    case Keys.Delete:
                        SuprimirFila();
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                    case Keys.Enter:
                        Agregar();
                        break;
                    case Keys.Down:
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        BuscadorSubir();
                        break;
                }
            }
        }

        private void BuscadorSubir()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Subir();
            }
            else
            {
                Subir();
            }
        }

        private void BuscadorBajar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Bajar();
            }
            else
            {
                Bajar();
            }
        }

        public List<ProductoHorario> Productos { get; set; }

        private void AbrirBuscador(ProductoCriterioBusqueda? criterio, string text = null)
        {
            var texto = string.IsNullOrEmpty(text) ? txtCodigo.Text : text;
            if (!this.OwnedForms.Any())
            {
                var productos = ProductosDatasource.Where(p => ComprasProducto.All(c => c.ProductoId != p.ProductoId)).ToList();
                var frm = new BuscadorCompleto(texto, productos, criterio.GetValueOrDefault());
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;
                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Closing += FrmOnClosing;
                frm.Show();
                frm.Texto = texto;
                txtCodigo.Focus();
                txtCodigo.Select(texto.Length, 0);
            }
            else
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Texto = texto;
                if (criterio != null)
                {
                    buscador.EstablecerCriterio(criterio.GetValueOrDefault());
                }
                buscador.AplicarFiltros();
            }
        }

        private void FrmOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            var frm = sender as BuscadorCompleto;
            if (!frm.CerradoDesdeTextbox && frm.ProductoSeleccionado != null)
            {
                AgregarProductoAColeccion(frm.ProductoSeleccionado);
                txtCodigo.Clear();
                txtCodigo.Focus();
                CalcularTotales();
            }
        }


        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            CerrarBuscador();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            _pressingArrow = true;
            
            Keys key = e.KeyCode;
            var texto = txtCodigo.Text;
            if ((key >= Keys.A && key <= Keys.Z) || (key >= Keys.D0 && key <= Keys.D9) || (key >= Keys.NumPad0 && key <= Keys.NumPad9) || key == Keys.Divide || key == Keys.Multiply || key == Keys.Add)
                texto += key.ToString();
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(e.KeyCode);
            }
            else
            {
                TratarTextoDistintoVacio(e.KeyCode);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            switch (txtCodigo.Text)
            {
                case "+":
                    NuevoProducto();
                    break;
                case "/":
                    CambiarPropiedadesProducto();
                    break;
                case "*":
                    CambiarUnidades();
                    break;
                case "":
                    break;
                default:
                    AbrirBuscador(null, txtCodigo.Text);
                    SeleccionarUltimaFila();
                    txtCodigo.Focus();
                    break;
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            _pressingArrow = false;
        }

        private void SuprimirFila()
        {
            if (dvgCompraProducto.SelectedRows.Count > 0)
            {
                var indice = dvgCompraProducto.SelectedRows[0].Index;
                ComprasProducto.RemoveAt(indice);

                if (indice > 0)
                {
                    RefrescarGrilla(indice);
                }
                else
                {
                    RefrescarGrilla();
                }

                if (ComprasProducto.Count == 0)
                {
                    btnBottomUnidades.Enabled = false;
                    btnBottomAlterarProducto.Enabled = false;
                }
                CalcularTotales();
                txtCodigo.Focus();
            }
        }

        private void Agregar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                var producto = buscador.ObtenerProducto();

                _ultimaBusqueda = buscador.RecordarBusqueda
                                            ? txtCodigo.Text
                                            : null;
                AgregarProductoAColeccion(producto);
                buscador.Close();
                _ultimoCriterio = ProductoCriterioBusqueda.Codigo;
                txtCodigo.Clear();
                txtCodigo.Focus();
                CalcularTotales();
                SeleccionarUltimaFila();
                ScrollearHastaElFinal();
            }
        }

        private void ScrollearHastaElFinal()
        {
            int rowCount = dvgCompraProducto.Rows.Count;
            if (rowCount > 0)
                dvgCompraProducto.FirstDisplayedScrollingRowIndex = dvgCompraProducto.RowCount - 1;
        }

        private void AgregarProductoAColeccion(ProductoCompleto producto)
        {
            var original = ProductosDatasource.FirstOrDefault(p => p.ProductoId == producto.ProductoId);
            if (original.CostoConIVA == null)
            {
                using (var frmCosto = new IngresarPrecioCosto(original.Descripcion, original.PrecioConIVA, 0, Factura.ProveedorNombre))
                {
                    if (frmCosto.ShowDialog() == DialogResult.OK)
                    {
                        //Modifico el costo de proveedor para ese producto
                        var proveedorProd = new ProveedorProducto()
                        {
                            CostoConIVA = frmCosto.Costo.GetValueOrDefault(),
                            ProductoId = original.ProductoId,
                            ProveedorId = ProveedorId,
                            Identifier = Guid.NewGuid(),
                            FechaUltimoCambioCosto = DateTime.Now
                        };
                        ProveedorProductoRepository.Agregar(proveedorProd);
                        ProveedorProductoRepository.Commit();
                        original.CostoConIVA = frmCosto.Costo;
                        original.PrecioConIVA = frmCosto.Precio;

                        AgregarProducto(original);
                    }
                }
            }
            else
            {
                AgregarProducto(original);
            }
        }

        private void CalcularTotales(string campoCambio = null)
        {
            var compras = ComprasProducto.Sum(producto => producto.Cantidad * producto.CostoActualizado.GetValueOrDefault());
            txtTotalCompra.Valor = compras;

            //Calculo el descuento

            txtDescuento.Valor = -(radDescuentoImporte.Checked
                                ? txtDescuentoImporte.Valor.GetValueOrDefault()
                                : compras == 0 ? 0 : (Convert.ToDecimal(DescuentoPorcentaje) * compras) / 100);

            
            txtTotalConDescuento.Valor = txtTotalCompra.Valor + txtDescuento.Valor.GetValueOrDefault();

            decimal dgr;
            dgr = chxDGR.Checked
                      ? txtDGR.Valor.GetValueOrDefault()
                      : (Convert.ToDecimal(Factura.Proveedor.PercepcionDGR)*txtTotalConDescuento.Valor.GetValueOrDefault()) / 100;

            if (campoCambio != "dgr")
                txtDGR.Valor = dgr;
            

            decimal iva;
            if (chxIVA.Checked)
            {
                iva = txtIVA.Valor.GetValueOrDefault();
            }
            else
            {
                var total = txtTotalConDescuento.Valor.GetValueOrDefault();
                if (total >= Cuenta.AplicarPercepcionIVADesde && Factura.Proveedor.AplicaPercepcionIVA)
                {
                    lblIVA.Text = String.Format("IVA ({0}%)", Cuenta.PorcentajePercepcionIVA.GetValueOrDefault().ToString("N2"));
                    iva = (total * Cuenta.PorcentajePercepcionIVA.GetValueOrDefault()) / 100;
                }
                else
                {
                    iva = 0;
                    lblIVA.Text = "IVA (0,00%)";
                }
            }

            if (campoCambio != "iva")
                txtIVA.Valor = iva;

            ImporteFinal = txtTotalConDescuento.Valor.GetValueOrDefault() + dgr + iva;

        }

        private void CerrarBuscador()
        {
            if (this.OwnedForms.Any())
            {
                this.OwnedForms.First().Close();
                txtCodigo.Text = string.Empty;
                _ultimoCriterio = ProductoCriterioBusqueda.Codigo;
            }
        }

        private void Buscar(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                var productos = ProductosDatasource.Where(p => ComprasProducto.All(c => c.ProductoId != p.ProductoId)).ToList();
                var frm = new Productos.BuscadorCompleto(txtCodigo.Text, productos, criterio);

                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;


                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Closing += FrmOnClosing;
                frm.Show();

                SeleccionarUltimaFila();
                txtCodigo.Focus();
            }
        }

        private void AgregarProducto(ProductoCompleto original)
        {
            ComprasProducto.Add(new CompraProducto()
            {
                Cantidad = 1,
                CostoActualizado = original.CostoConIVA,
                CostoActual = original.CostoConIVA.GetValueOrDefault(),
                PrecioActualizado = original.PrecioConIVA,
                ProductoId = original.ProductoId,
                StockAnterior = original.Stock,
                StockActual = original.Stock + 1,
                PrimerCodigoProducto = original.Codigo,
                ProductoDescripcion = original.Descripcion,
                ProductoMarca = original.Marca
            });
            RefrescarGrilla();
            SeleccionarUltimaFila();
            btnBottomUnidades.Enabled = true;
            btnBottomAlterarProducto.Enabled = true;
        }

        private void Bajar()
        {
            if (dvgCompraProducto.RowCount > 0)
            {
                if (dvgCompraProducto.SelectedRows.Count > 0)
                {
                    int rowCount = dvgCompraProducto.Rows.Count;
                    int index = dvgCompraProducto.SelectedCells[0].OwningRow.Index;

                    if (index != (rowCount - 1)) // include the header row
                    {
                        dvgCompraProducto.ClearSelection();
                        dvgCompraProducto.Rows[index + 1].Selected = true;
                    }
                }
            }
        }

        private void Subir()
        {
            if (dvgCompraProducto.RowCount > 0)
            {
                if (dvgCompraProducto.SelectedRows.Count > 0)
                {
                    int index = dvgCompraProducto.SelectedCells[0].OwningRow.Index;

                    if (index != 0) // include the header row
                    {
                        dvgCompraProducto.ClearSelection();
                        dvgCompraProducto.Rows[index - 1].Selected = true;
                    }
                }
            }
        }

        private void CambiarPropiedadesProducto()
        {
            if (dvgCompraProducto.SelectedRows.Count > 0)
            {
                //obtengo las unidades actuales
                DataGridViewRow row = dvgCompraProducto.SelectedRows[0];
                var item = dvgCompraProducto.SelectedRows[0].DataBoundItem as CompraProducto;
                
                using (var frm = new IngresarPrecioCosto(item.ProductoDescripcion, 
                                                        item.PrecioActualizado.GetValueOrDefault(), 
                                                        item.CostoActualizado, 
                                                        Factura.ProveedorNombre))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ActualizarPropiedadesProducto(frm.Precio, frm.Costo, item.CostoActualizado);
                    }
                    txtCodigo.Text = string.Empty;
                }
            }
        }

        private void ActualizarPropiedadesProducto(decimal precio, decimal? costo, decimal? costoAnterior)
        {
            DataGridViewRow row = dvgCompraProducto.SelectedRows[0];
            var item = dvgCompraProducto.SelectedRows[0].DataBoundItem as CompraProducto;
            var selectedIndex = row.Index;
            
            var cambio = false;
            //Modifico el precio
            var prod = ProductoRepository.Obtener(p => p.ProductoId == item.ProductoId);
            var compra = ComprasProducto.FirstOrDefault(c => c.ProductoId == item.ProductoId);

            if (prod.PrecioConIVA != precio)
            {
                
                prod.PrecioConIVA = precio;
                prod.PrecioSinIVA = precio / 1.21m;
                compra.PrecioActualizado = precio;
                
                ProductoRepository.Modificar(prod);
                ProductoRepository.Commit();
                cambio = true;
            }
            

            if (costo != costoAnterior && costo != null)
            {
                compra.CostoActualizado = costo;
                var factura = FacturaRepository.Obtener(f => f.FacturaId == ddlFacturas.Valor);
                if (costoAnterior != null)
                {
                    var proveedorProducto = ProveedorProductoRepository.Obtener(p => p.ProductoId == item.ProductoId
                                                                                     && p.ProveedorId == factura.ProveedorId);
                    if (proveedorProducto.CostoConIVA != costo.GetValueOrDefault())
                        proveedorProducto.FechaUltimoCambioCosto = DateTime.Now;
                    proveedorProducto.CostoConIVA = costo.GetValueOrDefault();
                    proveedorProducto.CostoSinIVA = proveedorProducto.CostoConIVA / 1.21m;
                    
                    ProveedorProductoRepository.Modificar(proveedorProducto);
                }
                else
                {
                    var proveedorProducto = new ProveedorProducto
                                                {
                                                    CostoConIVA = costo.GetValueOrDefault(),
                                                    CostoSinIVA = costo.GetValueOrDefault() / 1.21m,
                                                    ProductoId = item.ProductoId,
                                                    ProveedorId = factura.ProveedorId,
                                                    FechaUltimoCambioCosto = DateTime.Now
                                                };
                    ProveedorProductoRepository.Agregar(proveedorProducto);
                }
                ProveedorProductoRepository.Commit();
                ActualizacionPantallasHelper.ActualizarPantallaVentas();

                cambio = true;
            }

            if (cambio)
            {
                RefrescarGrilla();
            }

            //Por alguna razon se pierde la seleccion, asi que selecciono la misma fila otra vez
            dvgCompraProducto.ClearSelection();
            dvgCompraProducto.Rows[selectedIndex].Selected = true;
            dvgCompraProducto.FirstDisplayedScrollingRowIndex = selectedIndex;
        }

        private void CambiarUnidades()
        {
            if (dvgCompraProducto.SelectedRows.Count > 0)
            {
                var item = (CompraProducto)dvgCompraProducto.SelectedRows[0].DataBoundItem;
                //obtengo las unidades actuales
                DataGridViewRow row = dvgCompraProducto.SelectedRows[0];
                var selectedIndex = row.Index;
                var unidades = item.Cantidad;
                var productoId = item.ProductoId;
                var original = ProductoRepository.MaxiKioscosEntities.ProductoListadoCompleto(AppSettings.MaxiKioscoId,
                                                                                              ProveedorId, null).ToList().FirstOrDefault(p => p.ProductoId == productoId);
                var prod = item.ProductoDescripcion;
                using (var frm = new IngresarUnidades(prod, unidades, original.AceptaCantidadesDecimales, false))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {   
                        var linea = ComprasProducto.FirstOrDefault(c => c.ProductoId == productoId);
                        linea.Cantidad = frm.Unidades;
                        linea.StockActual = linea.StockAnterior + linea.Cantidad;
                        RefrescarGrilla();
                        CalcularTotales();
                    }
                    txtCodigo.Text = string.Empty;
                }
                dvgCompraProducto.ClearSelection();
                dvgCompraProducto.Rows[selectedIndex].Selected = true;
                dvgCompraProducto.FirstDisplayedScrollingRowIndex = selectedIndex;
            }
        }

        private void SeleccionarUltimaFila()
        {
            int rowCount = dvgCompraProducto.Rows.Count;
            dvgCompraProducto.ClearSelection();
            if (rowCount > 0)
                dvgCompraProducto.Rows[rowCount - 1].Selected = true;
        }

        private void RefrescarGrilla(int? indiceSeleccion = null)
        {
            dvgCompraProducto.DataSource = ComprasProducto.ToArray();
            dvgCompraProducto.Refresh();
            dvgCompraProducto.Parent.Refresh();
            ActualizarPrecioFinal();
            CargarCombo();

            if (indiceSeleccion != null)
            {
                dvgCompraProducto.ClearSelection();
                var index = indiceSeleccion < dvgCompraProducto.Rows.Count
                                ? indiceSeleccion.GetValueOrDefault()
                                : indiceSeleccion.GetValueOrDefault() - 1;
                dvgCompraProducto.Rows[index].Selected = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ComprasProducto.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto");
            }
            else
            {
                //Comparo el total con el maximo margen configurado
                var margenImporte = Cuenta.MargenImporteFactura;
                if (Math.Abs(ImporteFinal - Factura.ImporteTotal) > (margenImporte ?? 10))
                {
                    MessageBox.Show(String.Format(
                            "No se puede cargar la factura. El importe total (${0}) difiere del importe de la factura (${1}) en un valor mayor al máximo margen de factura establecido (${2})",
                            ImporteFinal.ToString("N2"),
                            Factura.ImporteTotal.ToString("N2"), 
                            (margenImporte ?? 10).ToString("N2")));
                }
                else
                {
                    //Inserto la Compra
                    var comprasProducto = ComprasProducto.Select(c => new CompraProducto()
                                                    {
                                                        Cantidad = c.Cantidad,
                                                        CostoActual = c.CostoActual,
                                                        CostoActualizado = c.CostoActualizado,
                                                        PrecioActual = c.PrecioActual,
                                                        PrecioActualizado = c.PrecioActualizado,
                                                        ProductoId = c.ProductoId,
                                                        Eliminado = false,
                                                        Desincronizado = true,
                                                        Identifier = Guid.NewGuid(),
                                                        FechaUltimaModificacion = DateTime.Now
                                                    }).ToList();
                    var compra = new Compra()
                                     {
                                         CuentaId = Usuario.CuentaId,
                                         FacturaId = Factura.FacturaId,
                                         Fecha = DateTime.Now,
                                         MaxiKioscoId = AppSettings.MaxiKioscoId,
                                         Numero = Factura.AutoNumero,
                                         ComprasProductos = comprasProducto,
                                         Eliminado = false,
                                         Desincronizado = true,
                                         Identifier = Guid.NewGuid(),
                                         FechaUltimaModificacion = DateTime.Now,
                                         ImporteFactura = txtImporteTotal.Valor.GetValueOrDefault(),
                                         Descuento = txtDescuento.Valor.GetValueOrDefault(),
                                         ImporteFinal = ImporteFinal,
                                         PercepcionDGR = txtDGR.Valor.GetValueOrDefault(),
                                         PercepcionIVA = txtIVA.Valor.GetValueOrDefault(),
                                         TotalCompra = txtTotalCompra.Valor.GetValueOrDefault(),
                                         TipoComprobante = ddlTipoComprobante.Texto
                                     };
                    
                    
                    foreach (var prod in comprasProducto)
                    {
                        //Actualizo el stock
                        var stock = StockRepository.Obtener(s => s.ProductoId == prod.ProductoId
                                                                 && s.MaxiKioscoId == AppSettings.MaxiKioscoId);

                        var transaccion = new StockTransaccion
                                              {
                                                  Cantidad = prod.Cantidad, 
                                                  StockTransaccionTipoId = 2,
                                                  Identifier = Guid.NewGuid(),
                                                  FechaUltimaModificacion = DateTime.Now,
                                                  Desincronizado = true
                                              };
                        if (stock == null)
                        {
                            stock = new Stock()
                                                    {
                                                        MaxiKioscoId = AppSettings.MaxiKioscoId,
                                                        ProductoId = prod.ProductoId,
                                                        StockActual = transaccion.Cantidad,
                                                        Eliminado = false,
                                                        Desincronizado = true,
                                                        Identifier = Guid.NewGuid(),
                                                        FechaUltimaModificacion = DateTime.Now,
                                                        FechaCreacion = DateTime.Now,
                                                        OperacionCreacion = "Compra desde desktop"
                                                    };
                            StockRepository.Agregar(stock);
                            StockRepository.Commit();
                        }
                        transaccion.StockId = stock.StockId;
                        StockTransaccionRepository.Agregar(transaccion);

                        //Modifico el precio
                        var producto = ProductoRepository.Obtener(prod.ProductoId);
                        producto.PrecioConIVA = prod.PrecioActualizado.GetValueOrDefault();
                        producto.PrecioSinIVA = prod.PrecioActualizado.GetValueOrDefault() == 0 ? 0 : prod.PrecioActual / 1.21m;

                        ProductoRepository.Modificar(producto);
                    }
                    StockTransaccionRepository.Commit();

                    FacturaRepository.Modificar(Factura);
                    FacturaRepository.Commit();


                    CompraRepository.Agregar(compra);
                    CompraRepository.Commit();

                    StockRepository.Actualizar(AppSettings.MaxiKioscoIdentifier);

                    MessageBox.Show(Resources.CompraExitosa);
                    this.Close();
                }
            }
        }

        #region grilla

        private void dvgCompraProducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 32 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var icon = @"\Resources\delete_icon.ico";
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 4);
                e.Handled = true;
            }
        }

        private void dvgCompraProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 32 && e.RowIndex >= 0)
            {
                ComprasProducto.RemoveAt(e.RowIndex);
                RefrescarGrilla();
                if (ComprasProducto.Count == 0)
                {
                    btnBottomUnidades.Enabled = false;
                    btnBottomAlterarProducto.Enabled = false;
                }
                txtCodigo.Focus();
                CalcularTotales();
            }
            txtCodigo.Focus();
        }

        #endregion

        private void btnBottomUnidades_Click(object sender, EventArgs e)
        {
            CambiarUnidades();
        }

        private void btnBottomAlterarProducto_Click(object sender, EventArgs e)
        {
            CambiarPropiedadesProducto();
        }

        private void ActualizarPrecioFinal()
        {
            CostoFinal = ComprasProducto.Sum(producto => producto.Cantidad * producto.CostoActualizado.GetValueOrDefault());
            lblCosto.Text = String.Format("$ {0}", CostoFinal.ToString("N2"));
        }
        
        #region Facturas

        private void txtDescuentoPorcentaje_Cambio()
        {
            if (DescuentoPorcentaje == 0)
            {
                DescuentoEnPesos = null;
            }
            else
            {
                var descuento = Convert.ToDecimal(DescuentoPorcentaje);
                var importeCompras = ComprasProducto.Sum(producto => producto.Cantidad*producto.CostoActualizado.GetValueOrDefault());
                var incremento = (descuento * importeCompras) / 100;
                //ImporteFinal = ImporteTotal - incremento;
                DescuentoEnPesos = incremento;
                Descuento = -incremento;
                CalcularTotalConDescuento();
                CalcularTotales();
            }
        }
        
        private void CalcularTotalConDescuento()
        {
            txtTotalConDescuento.Valor = txtTotalCompra.Valor - DescuentoEnPesos;
        }

        private void txtDescuentoImporte_Cambio()
        {

            if (DescuentoEnPesos == null)
            {
                //ImporteFinal = ImporteTotal;
                DescuentoPorcentaje = null;
            }
            else
            {
                //ImporteFinal = ImporteTotal - DescuentoEnPesos.GetValueOrDefault();
                var importeCompras = ComprasProducto.Sum(producto => producto.Cantidad * producto.CostoActualizado.GetValueOrDefault());

                var descuento = (importeCompras == 0) 
                                        ? 0
                                        : ((DescuentoEnPesos * 100) / importeCompras).GetValueOrDefault();
                DescuentoPorcentaje = descuento;
                CalcularTotalConDescuento();
                CalcularTotales();
            }
        }

        
        private void txtImporteTotal_Cambio()
        {
            if (txtImporteTotal.Valor == null)
            {
                txtDescuentoImporte.Disabled = true;
                txtDescuentoPorcentaje.Disabled = true;
                txtDescuentoImporte.Valor = null;
                txtDescuentoPorcentaje.Valor = null;
            }
            else
            {
                txtDescuentoImporte.Disabled = false;
                txtDescuentoPorcentaje.Disabled = false;

                if (DescuentoEnPesos != null)
                {
                    var descuento = Convert.ToDecimal(DescuentoPorcentaje);
                    var incremento = (descuento * ImporteTotal) / 100;
                    ImporteFinal = ImporteTotal - incremento;
                    DescuentoEnPesos = incremento;
                }
                else
                {
                    ImporteFinal = ImporteTotal;
                }
            }
        }

        private void btnBottomNuevoProducto_Click(object sender, EventArgs e)
        {
            NuevoProducto();
        }

        #endregion

        #region AutoCompleteCombo
        private void CargarCombo()
        {
            ProductosDatasource = ProductoRepository.MaxiKioscosEntities.ProductoListadoCompleto(AppSettings.MaxiKioscoId,
                                                                                ProveedorId, null).ToList();
            var idsGrilla = new List<int>();
            for (int i = 0; i < dvgCompraProducto.Rows.Count; i++)
            {
                var productoId = ((CompraProducto) dvgCompraProducto.Rows[i].DataBoundItem).ProductoId;
                idsGrilla.Add(productoId);
            }
            ProductosDatasource = ProductosDatasource.Where(ph => !idsGrilla.Contains(ph.ProductoId)).ToList();
            
        }
        

        #endregion

        private void IngresoProductos_Shown(object sender, EventArgs e)
        {
            dtpFecha.Select();
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Cerrado)
            {
                MessageBox.Show("Debe abrir una caja primero");
                return;
            }

            using (var frm = new frmEditarFactura())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var facturas = FacturaRepository.MaxiKioscosEntities.FacturaObtenerAbiertasPorUsuario(UsuarioId, AppSettings.MaxiKioscoId).ToList();
                    facturas.Insert(0, new FacturaCompleta());
                    ddlFacturas.DataSource = facturas;
                    ddlFacturas.Valor = frm.Factura.FacturaId;
                    txtCodigo.Focus();
                }
            }
            
        }

        private void radDescuentoImporte_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlFacturas.Valor != 0)
            {
                txtDescuentoImporte.Disabled = false;
                txtDescuentoPorcentaje.Disabled = true;
                CalcularTotales();
            }
        }

        private void radDescuentoPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlFacturas.Valor != 0)
            {
                txtDescuentoImporte.Disabled = true;
                txtDescuentoPorcentaje.Disabled = false;
                CalcularTotales();
            }
        }

        private void chxDGR_CheckedChanged(object sender, EventArgs e)
        {
            if (chxDGR.Checked)
            {
                txtDGR.Disabled = false;
            }
            else
            {
                txtDGR.Disabled = true;
                txtDGR.Valor = Factura.Proveedor.PercepcionDGR;
            }
            CalcularTotales();
        }

        private void txtDGR_Cambio()
        {
            CalcularTotales("dgr");
        }

        private void chxIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (chxIVA.Checked)
            {
                txtIVA.Disabled = false;
            }
            else
            {
                txtIVA.Disabled = true;
                var total = txtTotalConDescuento.Valor.GetValueOrDefault();
                if (total >= Cuenta.AplicarPercepcionIVADesde && Factura.Proveedor.AplicaPercepcionIVA)
                {
                    lblIVA.Text = String.Format("IVA ({0}%)", Cuenta.PorcentajePercepcionIVA.GetValueOrDefault().ToString("N2"));
                    txtIVA.Valor = (total * Cuenta.PorcentajePercepcionIVA.GetValueOrDefault()) / 100;
                }
                else
                {
                    txtIVA.Valor = 0;
                    lblIVA.Text = "IVA (0,00%)";
                }
                
            }
            CalcularTotales();
        }

        private void txtIVA_Cambio()
        {
            CalcularTotales("iva");
        }

        private void dvgCompraProducto_Click(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _ultimaBusqueda;
            Buscar(ProductoCriterioBusqueda.Descripcion);
            txtCodigo.Select(0, txtCodigo.Text.Length);
        }

        private void btnBuscarPorMarca_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _ultimaBusqueda;
            Buscar(ProductoCriterioBusqueda.Marca);
            txtCodigo.Select(0, txtCodigo.Text.Length);
        }

        private void IngresoProductos_Load(object sender, EventArgs e)
        {
            if (IsAdmin)
            {
                btnMostrarTodos.Visible = false;
                radDescuentoImporte.Enabled = true;
                radDescuentoPorcentaje.Enabled = true;
            }
            CargarTipoComprobantes();
        }

        private void CargarTipoComprobantes()
        {
            ddlTipoComprobante.DataSource = new List<string> {"X", "A"};
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            var userId = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "Administrador", "SuperAdministrador" });
            if (userId > 0)
            {
                IsAdmin = true;
                btnMostrarTodos.Visible = false;
                var facturas = FacturaRepository.MaxiKioscosEntities.FacturaObtenerAbiertasPorUsuario(userId, AppSettings.MaxiKioscoId).ToList();
                facturas.Insert(0, new FacturaCompleta());

                ddlFacturas.DataSource = facturas;
                ddlFacturas.Focus();

                radDescuentoImporte.Enabled = true;
                radDescuentoPorcentaje.Enabled = true;

                if (ddlFacturas.Valor != 0)
                {
                    chxIVA.Enabled = true;
                    chxDGR.Enabled = true;
                }

                ComprasProducto = new List<CompraProducto>();
                dvgCompraProducto.DataSource = ComprasProducto;
            }
        }
    }
}
