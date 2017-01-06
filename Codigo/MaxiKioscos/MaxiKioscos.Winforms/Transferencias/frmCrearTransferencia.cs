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
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Productos.Modulos;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using log4net;
using Maxikioscos.Comun.Helpers;
using MaxiKioscos.Winforms.Principal;
using MaxiKioscos.Winforms.Transferencias.Modulos;
using MaxiKioscos.Winforms.UserControls;
using Telerik.WinControls.UI;
using ProductoCriterioBusqueda = MaxiKioscos.Winforms.Productos.ProductoCriterioBusqueda;

namespace MaxiKioscos.Winforms.Transferencias
{
    
    public partial class frmCrearTransferencia : Form
    {
        #region Repositorios

        private EFRepository<Transferencia> _repository;
        public EFRepository<Transferencia> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Transferencia>()); }
        }

        private ProductoRepository _productoRepository;
        public ProductoRepository ProductoRepository
        {
            get { return _productoRepository ?? (_productoRepository = new ProductoRepository()); }
        }

        private EFRepository<ProductoPromocion> _productoPromocionRepository;
        public EFRepository<ProductoPromocion> ProductoPromocionRepository
        {
            get { return _productoPromocionRepository ?? (_productoPromocionRepository = new EFRepository<ProductoPromocion>()); }
        }

        public EFRepository<ExcepcionRubro>  ExcepcionRubroRepository
        {
            get { return new EFRepository<ExcepcionRubro>(); }
        }

        private EFRepository<TransferenciaProducto> _ransferenciaProductoRepository;
        public EFRepository<TransferenciaProducto> TransferenciaProductoRepository
        {
            get { return _ransferenciaProductoRepository ?? (_ransferenciaProductoRepository = new EFRepository<TransferenciaProducto>()); }
        }
        

        public EFRepository<Entidades.MaxiKiosco> MaxikioscoRepository
        {
            get { return new EFRepository<Entidades.MaxiKiosco>(); }
        }

        private StockRepository _stockRepository;
        public StockRepository StockRepository
        {
            get { return _stockRepository ?? (_stockRepository = new StockRepository()); }
        }

        #endregion

        public bool ForzarSincronizacion { get; set; }
        public bool MensajeErrorAbierto { get; set; }
        public bool PopupAbierto { get; set; }
        public bool ConfirmacionAbierta { get; set; }
        public List<ProductoTransferenciaDesktop> ProductosDatasource { get; set; }

        private Timer _timerArrow;
        private bool _pressingArrow = false;
        private Keys _pressingOperation { get; set; }
        private string _ultimaBusqueda { get; set; }
        private string _autoNumero;
        private static List<Timer> _timers;

        private string _operacion { get; set; }

        private Entidades.MaxiKiosco _origen;
        private Entidades.MaxiKiosco Origen
        {
            get
            {
                if (_origen == null)
                {
                    _origen = MaxikioscoRepository.Obtener(x => x.Identifier == UsuarioActual.Cuenta.MaxiKioscoIdentifierPredeterminadoTransferencias);
                }
                return _origen;
            }
        }

        private Transferencia Transferencia { get; set; } 

        public frmCrearTransferencia()
        {
            InitializeComponent();
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[5].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            _operacion = "Crear";
        }

        public frmCrearTransferencia(int transferenciaId)
        {
            InitializeComponent();
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[5].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            _operacion = "Editar";
            this.Text = "Editar Transferencia";
            Transferencia = Repository.Obtener(x => x.TransferenciaId == transferenciaId,
                                                    t => t.Origen,
                                                    t => t.Destino,
                                                    t => t.TransferenciaProductos,
                                                    t => t.TransferenciaProductos.Select(tp => tp.Producto),
                                                    t => t.TransferenciaProductos.Select(tp => tp.Producto).Select(p => p.CodigosProductos));
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            StockRepository.Actualizar();
            ForzarSincronizacion = true;
            CargarTransferencia();
            this.WindowState = FormWindowState.Maximized;

            CheckearExcepcionesPorRubro();
        }

        private void CheckearExcepcionesPorRubro()
        {
            _timers = new List<Timer>();
            var excepciones = ExcepcionRubroRepository.Listado().Where(er => er.MaxiKioscoId == AppSettings.MaxiKioscoId).ToList();
            foreach (var excepcionRubro in excepciones)
            {
                SetearTimer(excepcionRubro.Desde);
                SetearTimer(excepcionRubro.Hasta);
            }
        }

        private void SetearTimer(TimeSpan timeSpan)
        {
            var diferencia = DiferenciaHorariaEnElDia();
            var timer = new Timer();
            if (diferencia < timeSpan)
            {
                var intervalo = timeSpan - diferencia;
                timer.Interval = Convert.ToInt32(intervalo.TotalMilliseconds);
            }
            else
            {
                timer.Interval = DiferenciaHorariaEnElDiaMasUno(timeSpan);
            }
            timer.Tick += TimerOnTick;
            _timers.Add(timer);
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            var timer = (Timer) sender;
            timer.Stop();
            ProductosDatasource = ProductoRepository.ListadoProductoTransferenciaDesktop(AppSettings.MaxiKioscoId);
        }

        private TimeSpan DiferenciaHorariaEnElDia()
        {
            var now = DateTime.Now;
            var aLasDoce = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            var diferencia = now - aLasDoce;
            return diferencia;
        }

        private int DiferenciaHorariaEnElDiaMasUno(TimeSpan timespan)
        {
            var diaSiguiente = DateTime.Now.AddDays(1);
            var aLasDoceDelDiaSiguiente = new DateTime(diaSiguiente.Year, diaSiguiente.Month, diaSiguiente.Day, 0, 0, 0);
            var diferencia = aLasDoceDelDiaSiguiente - DateTime.Now;
            var result = Convert.ToInt32(diferencia.TotalMilliseconds + timespan.TotalMilliseconds);
            return result;
        }

        private void CargarTransferencia()
        {
            if (Transferencia == null)
            {
                txtFecha.Texto = DateTime.Now.ToShortDateString();
                txtOrigen.Texto = Origen.Nombre;
                SetNroFactura();
            }
            else
            {
                txtFecha.Texto = Transferencia.FechaCreacion.ToShortDateString();
                txtOrigen.Texto = Transferencia.Origen.Nombre;
                txtAutoNumero.Texto = Transferencia.AutoNumero;

                CargarGrillaProductos();
            }
            
            ProductosDatasource = ProductoRepository.ListadoProductoTransferenciaDesktop(AppSettings.MaxiKioscoId);
        }

        private void CargarGrillaProductos()
        {
            foreach (var prod in Transferencia.TransferenciaProductos.Where(x => !x.Eliminado).ToList())
            {
                var item = new ProductoTransferenciaDesktop
                {
                    Codigo = prod.Producto.CodigosListado,
                    Costo = prod.Costo,
                    Descripcion = prod.Producto.Descripcion,
                    Precio = prod.PrecioVenta,
                    ProductoId = prod.ProductoId,
                    StockActual = prod.StockDestino
                };
                dgvListado.Rows.Add();
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["productoId"].Value = item.ProductoId;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Cantidad"].Value = prod.Cantidad;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Codigo"].Value = item.Codigo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Descripcion"].Value = item.Descripcion;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Unitario"].Value = item.Precio;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["PrecioUnitarioFormateado"].Value = item.PrecioUnitarioFormateado;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Costo"].Value = item.Costo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["StockActual"].Value = item.StockActualFormateado;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["TransferenciaProductoId"].Value = prod.TransferenciaProductoId;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Identifier"].Value = prod.Identifier;
            }
        }

        private void SetNroFactura()
        {
            if (string.IsNullOrEmpty(_autoNumero))
            {
                GenerarNumeroTransferencia();
            }
            txtAutoNumero.Texto = _autoNumero;
            txtCodigo.Focus();
        }

        private void GenerarNumeroTransferencia()
        {
            _repository = new EFRepository<Transferencia>();
            var prefijo = String.Format("{0}_", AppSettings.Maxikiosco.Abreviacion.ToUpper());
            var ultima = _repository.Listado().Where(x => x.AutoNumero.StartsWith(prefijo)).OrderByDescending(x => x.TransferenciaId).FirstOrDefault();
            var numero = ultima == null
                ? 1
                : Convert.ToInt32(ultima.AutoNumero.Replace(prefijo, "")) + 1;
            _autoNumero = String.Format("{0}{1}", prefijo, ultima == null ? 1 : numero);
        }

        #region Botonera
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            Aceptar(true);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _ultimaBusqueda;
            BuscarPorCodigo(ProductoCriterioBusqueda.Descripcion);
            txtCodigo.Select(0, txtCodigo.Text.Length);
        }

        private void btnSuprimirFila_Click(object sender, EventArgs e)
        {
            SuprimirFila();
        }

        private void btnBuscarPorCodigo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _ultimaBusqueda;
            BuscarPorCodigo(ProductoCriterioBusqueda.Descripcion);
            txtCodigo.Select(0, txtCodigo.Text.Length);
        }

        private void btnModificarCantidad_Click(object sender, EventArgs e)
        {
            ModificarCantidad();
        }

        #endregion
        
        #region Metodos Privados
        private void SuprimirFila()
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var indice = dgvListado.SelectedRows[0].Index;

                //Modifico el stock
                var unidades = Convert.ToDecimal(dgvListado.SelectedRows[0].Cells["Cantidad"].Value.ToString());
                var productoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["productoId"].Value.ToString());
                var prod = ProductosDatasource.First(p => p.ProductoId == productoId);
                prod.StockActual += unidades;

                dgvListado.Rows.RemoveAt(indice);
                

                if (indice > 0)
                {
                    dgvListado.ClearSelection();
                    dgvListado.Rows[indice - 1].Selected = true;
                }
                HabilitarBotones();
                txtCodigo.Focus();
            }
        }

        private void SuprimirUltimaFila()
        {
            if (dgvListado.Rows.Count > 0)
            {
                var indice = dgvListado.Rows.Count - 1;
                dgvListado.Rows.RemoveAt(indice);
                if (indice > 0)
                {
                    dgvListado.ClearSelection();
                    dgvListado.Rows[indice - 1].Selected = true;
                }
            }
        }


        private void ModificarCantidad()
        {
            if (dgvListado.SelectedRows.Count > 0 && (txtCodigo.Text == "*" || string.IsNullOrEmpty(txtCodigo.Text)))
            {
                PopupAbierto = true;
                var selectedIndex = dgvListado.SelectedRows[0].Index;

                var unidades = Convert.ToDecimal(dgvListado.SelectedRows[0].Cells["Cantidad"].Value.ToString());
                var productoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["productoId"].Value.ToString());
                var original = ProductoRepository.Obtener(productoId);

                using (var frm = new IngresarUnidades(dgvListado.SelectedRows[0].Cells["descripcion"].Value.ToString(), unidades, original.AceptaCantidadesDecimales, true))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var prod = ProductosDatasource.First(p => p.ProductoId == productoId);
                        var diferenciaStock = frm.Unidades - unidades;
                        if (original.EsPromocion && prod.StockActual - diferenciaStock < 0)
                        {
                            MessageBox.Show("Esta promoción no se encuentra disponible para la cantidad solicitada");
                        }
                        else
                        {
                            SetCantidad(frm.Unidades);
                            //Modifico el stock

                            prod.StockActual -= diferenciaStock;

                            if (original.EsPromocion)
                            {
                                ActualizarStockPromociones(original.ProductoId, Convert.ToInt32(diferenciaStock));
                            }
                        }
                    }
                }
                dgvListado.ClearSelection();
                dgvListado.Rows[selectedIndex].Selected = true;
            }
            txtCodigo.Text = "";
            txtCodigo.Focus();
        }

        private void ActualizarStockPromociones(int productoId, int cantidad)
        {
            var promociones = ProductoPromocionRepository.Listado().Where(p => p.PadreId == productoId).ToList();
            foreach (var promo in promociones)
            {
                var prod = ProductosDatasource.First(p => p.ProductoId == promo.HijoId);
                prod.StockActual -= promo.Unidades * cantidad;
            }
        }

        private void SetCantidad(decimal cantidad)
        {
            dgvListado.SelectedRows[0].Cells["Cantidad"].Value = cantidad;
        }

        private string StringPrice(decimal number)
        {
            string precio = (number % 1) == 0
                            ? number.ToString()
                                    .Replace(",0000000", "")
                                    .Replace(",000000", "")
                                    .Replace(",00000", "")
                                    .Replace(",0000", "")
                                    .Replace(".00", "")
                                    .Replace(",00", "")
                            : number.ToString("N2");
            return String.Format("${0}", precio);
        }

        private void Aceptar(bool sobrescribir = false)
        {
            if (PopupAbierto && !sobrescribir)
                PopupAbierto = false;
            else if (MensajeErrorAbierto && !sobrescribir)
                MensajeErrorAbierto = false;
            else if (ConfirmacionAbierta && !sobrescribir)
            {
                ConfirmacionAbierta = false;
            }   
            else
            {
                try
                {
                    if (dgvListado.Rows.Count > 0)
                    {
                        ConfirmacionAbierta = true;
                        var frmConfirmar = new ConfirmationForm("Está seguro que desea guardar la transferencia?", "Si", "No");
                        if (frmConfirmar.ShowDialog() == DialogResult.OK)
                        {
                            var lineas = new List<TransferenciaProducto>();
                            for (int i = 0; i <= dgvListado.Rows.Count - 1; i++)
                            {
                                var linea = new TransferenciaProducto();

                                linea.Cantidad = int.Parse(dgvListado.Rows[i].Cells["Cantidad"].Value.ToString());
                                linea.Eliminado = false;
                                linea.PrecioVenta = Convert.ToDecimal(dgvListado.Rows[i].Cells["Unitario"].Value.ToString().Replace("$", ""));
                                linea.ProductoId = (int)dgvListado.Rows[i].Cells["productoId"].Value;
                                linea.Costo = dgvListado.Rows[i].Cells["Costo"].Value == null
                                                        ? 0
                                                        : Convert.ToDecimal(dgvListado.Rows[i].Cells["Costo"].Value.ToString().Replace("$", ""));
                                linea.FechaUltimaModificacion = DateTime.Now;
                                linea.Orden = i + 1;
                                linea.Desincronizado = true;
                                linea.StockDestino = Convert.ToDecimal(dgvListado.Rows[i].Cells["StockActual"].Value.ToString());
                                var identifier = Guid.Parse(dgvListado.Rows[i].Cells["Identifier"].Value.ToString());
                                linea.Identifier = _operacion == "Crear"
                                                        ? Guid.NewGuid()
                                                        : (identifier == Guid.Empty ? Guid.NewGuid() : identifier);
                                linea.TransferenciaProductoId = Convert.ToInt32(dgvListado.Rows[i].Cells["TransferenciaProductoId"].Value.ToString());
                                lineas.Add(linea);
                            }

                            if (_operacion == "Crear")
                            {
                                var transferencia = new Transferencia
                                {
                                    FechaCreacion = DateTime.Now,
                                    Identifier = Guid.NewGuid(),
                                    Eliminado = false,
                                    TransferenciaProductos = lineas,
                                    AutoNumero = _autoNumero,
                                    Desincronizado = true,
                                    DestinoId = AppSettings.MaxiKioscoId,
                                    FechaAprobacion = null,
                                    OrigenId = Origen.MaxiKioscoId,
                                    UsuarioId = UsuarioActual.UsuarioId
                                };

                                Repository.Agregar(transferencia);
                            }
                            else
                            {
                                //Transferencia.TransferenciaProductos = lineas;
                                var trans = Repository.Obtener(t => t.TransferenciaId == Transferencia.TransferenciaId,
                                                        t => t.TransferenciaProductos);
                                var originales = trans.TransferenciaProductos.Where(tp => !tp.Eliminado);

                                var paraEliminar = originales.Select(o => o.TransferenciaProductoId).ToList();

                                var i = 1;
                                foreach (var tp in lineas)
                                {
                                    tp.Orden = i;
                                    if (tp.TransferenciaProductoId == 0)
                                    {
                                        tp.TransferenciaId = Transferencia.TransferenciaId;
                                        TransferenciaProductoRepository.Agregar(tp);
                                    }
                                    else
                                    {
                                        var original = originales.FirstOrDefault(o => tp.TransferenciaProductoId == o.TransferenciaProductoId);
                                        if (original != null)
                                        {
                                            original.Cantidad = tp.Cantidad;
                                            original.PrecioVenta = tp.PrecioVenta;
                                            original.ProductoId = tp.ProductoId;
                                            original.StockDestino = tp.StockDestino;
                                            original.StockOrigen = tp.StockOrigen;
                                            TransferenciaProductoRepository.Modificar(original);
                                            paraEliminar.Remove(original.TransferenciaProductoId);
                                        }
                                    }
                                    i++;
                                }

                                foreach (var id in paraEliminar)
                                {
                                    TransferenciaProductoRepository.Eliminar(id);
                                }

                                trans.OrigenId = Transferencia.OrigenId;
                                trans.DestinoId = Transferencia.DestinoId;


                                trans.FechaUltimaModificacion = DateTime.Now;
                                trans.Desincronizado = true;
                            }
                            Repository.Commit();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger("errors").Error(ExceptionHelper.GetInnerException(ex).Message);
                    throw;
                }
            }
        }
        
        private void Cancelar()
        {
            this.Close();
        }
        

        private void SeleccionarUltimaFila()
        {
            int rowCount = dgvListado.Rows.Count;

            if (rowCount == 0)
                return;

            dgvListado.ClearSelection();
            dgvListado.Rows[rowCount - 1].Selected = true;
        }

        private void BuscarArticulo(ProductoTransferenciaDesktop prod)
        {
            //char guion = "-";
            if (prod != null)
            {
                dgvListado.Rows.Add();
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["productoId"].Value = prod.ProductoId;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Cantidad"].Value = 1;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Codigo"].Value = prod.Codigo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Descripcion"].Value = prod.Descripcion;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Unitario"].Value = prod.Precio;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["PrecioUnitarioFormateado"].Value = prod.PrecioUnitarioFormateado;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Costo"].Value = prod.Costo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["StockActual"].Value = prod.StockActualFormateado;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["TransferenciaProductoId"].Value = 0;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Identifier"].Value = Guid.Empty;
            }
            txtCodigo.Text = string.Empty;
            HabilitarBotones();
            //txtCodigo.Focus();
        }

        private void HabilitarBotones()
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                btnBottomUnidades.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnBottomUnidades.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void Limpiar()
        {
            while (dgvListado.Rows.Count > 0)
            {
                dgvListado.Rows.RemoveAt(0);
            }
            txtCodigo.Text = string.Empty;
            txtCodigo.Focus();
        }

        private void Bajar()
        {
            if (dgvListado.RowCount > 0)
            {
                if (dgvListado.SelectedRows.Count > 0)
                {
                    int rowCount = dgvListado.Rows.Count;
                    int index = dgvListado.SelectedCells[0].OwningRow.Index;

                    if (index != (rowCount - 1)) // include the header row
                    {
                        dgvListado.ClearSelection();
                        dgvListado.Rows[index + 1].Selected = true;
                    }

                    dgvListado.FirstDisplayedScrollingRowIndex = dgvListado.SelectedRows[0].Index;
                }
            }
        }

        private void Subir()
        {
            if (dgvListado.RowCount > 0)
            {
                if (dgvListado.SelectedRows.Count > 0)
                {
                    int index = dgvListado.SelectedCells[0].OwningRow.Index;

                    if (index != 0) // include the header row
                    {
                        dgvListado.ClearSelection();
                        dgvListado.Rows[index - 1].Selected = true;
                    }

                    dgvListado.FirstDisplayedScrollingRowIndex = dgvListado.SelectedRows[0].Index;
                }
            }
        }

        #endregion

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                SuprimirFila();
            }
            txtCodigo.Focus();
        }

        private void dgvListado_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var icon = @"\Resources\delete_icon.ico";
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 4);
                e.Handled = true;
            }
        }

        private void frmTransferencias_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void BuscarPorCodigo(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                PopupAbierto = true;
                var productos = ProductosDatasource.Where(p => ObtenerProductosVendidosIds().All(c => c != p.ProductoId)).ToList();
                var frm = new frmBuscadorTransferencia(txtCodigo.Text, productos, true, criterio);

                frm.Cambio += BuscarArticulo;
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.MensajeError += FrmOnMensajeError;
                frm.GotFocus += PopupGotFocused;
                frm.LostFocus += PopupLostFocus;
                frm.Owner = this;


                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();

                SeleccionarUltimaFila();
                txtCodigo.Focus();
            }
        }

        private void FrmOnMensajeError()
        {
            MensajeErrorAbierto = true;
        }

        private void PopupLostFocus(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void PopupGotFocused(object sender, EventArgs e)
        {
            dgvListado.Focus();
        }

        private void CerrarBuscador()
        {
            if (this.OwnedForms.Any())
            {
                this.OwnedForms.First().Close();
            }
            txtCodigo.Text = string.Empty;
        }

        private void AbrirBuscador(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                PopupAbierto = true;
                //var productos = ProductosDatasource.Where(p => ObtenerProductosVendidosIds().All(c => c != p.ProductoId)).ToList();
                var frm = new frmBuscadorTransferencia(txtCodigo.Text, ProductosDatasource.ToList(), true, criterio);
                frm.Cambio += BuscarArticulo;
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.MensajeError += FrmOnMensajeError;
                frm.Owner = this;
                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();
                frm.AplicarFiltros(txtCodigo.Text);
                txtCodigo.Focus();
                txtCodigo.Select(txtCodigo.Text.Length, 0);
            }
            else
            {
                var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;
                buscador.AplicarFiltros(txtCodigo.Text);
            }
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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            _pressingArrow = true;
            Keys key = e.KeyCode;
            var texto = txtCodigo.Text;
            if ((key >= Keys.A && key <= Keys.Z) || (key >= Keys.D0 && key <= Keys.D9) || (key >= Keys.NumPad0 && key <= Keys.NumPad9) || key == Keys.Multiply)
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
                case "":
                    break;
                case "*":
                    ModificarCantidad();
                    break;
                default:
                    if (this.OwnedForms.Any())
                    {
                        var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;
                        buscador.AplicarFiltros(txtCodigo.Text);

                        SeleccionarUltimaFila();
                        txtCodigo.Focus();
                    }
                    break;
            }
            
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            _pressingArrow = false;
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
                        ActivarArrowTimer(Keys.Up);
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
            else if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;
                buscador.AplicarFiltros(txtCodigo.Text);

                SeleccionarUltimaFila();
                txtCodigo.Focus();
            }
        }

        private void TratarTextoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.F5, Keys.F6, Keys.Delete, Keys.Escape, Keys.Enter, Keys.Down, Keys.Up };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.F5:
                        txtCodigo.Text = _ultimaBusqueda;
                        AbrirBuscador(ProductoCriterioBusqueda.Marca);
                        txtCodigo.Select(0, txtCodigo.Text.Length);
                        break;
                    case Keys.F6:
                        txtCodigo.Text = _ultimaBusqueda;
                        AbrirBuscador(ProductoCriterioBusqueda.Descripcion);
                        txtCodigo.Select(0, txtCodigo.Text.Length);
                        break;
                    case Keys.Delete:
                        SuprimirFila();
                        break;
                    case Keys.Divide:
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                    case Keys.Enter:
                        Agregar();
                        break;
                    case Keys.Down:
                        ActivarArrowTimer(Keys.Down);
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        ActivarArrowTimer(Keys.Up);
                        BuscadorSubir();
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

        private void Agregar()
        {
            if (this.OwnedForms.Any() || !string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (!this.OwnedForms.Any())
                {
                    AbrirBuscador(ProductoCriterioBusqueda.Codigo);
                }
                var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;

                
                _ultimaBusqueda = buscador.RecordarBusqueda 
                                            ? txtCodigo.Text
                                            : null;
                buscador.Aceptar(txtCodigo.Text);

                if (txtCodigo.Focused)
                {
                    PopupAbierto = false;
                }

                if (buscador.ProductoSeleccionado != null)
                {

                    var prod = ProductosDatasource.FirstOrDefault(p => p.ProductoId == buscador.ProductoSeleccionado.ProductoId);
                    
                    prod.StockActual--;
                    ScrollearHastaElFinal();
                }
                buscador.Close();
                txtCodigo.Clear();
                txtCodigo.Focus();
                SeleccionarUltimaFila();
                ScrollearHastaElFinal();
            }
            else
            {
                Aceptar();
            }
        }

        private void ScrollearHastaElFinal()
        {
            int rowCount = dgvListado.Rows.Count;
            if (rowCount > 0)
                dgvListado.FirstDisplayedScrollingRowIndex = dgvListado.RowCount - 1;
        }

        private void BuscadorSubir()
        {
 	        if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;
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
                var buscador = this.OwnedForms.First() as frmBuscadorTransferencia;
                buscador.Bajar();
            }
            else
            {
                Bajar();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            CerrarBuscador();
        }

        private IEnumerable<int> ObtenerProductosVendidosIds()
        {
            var list = new List<int>();
            
            for (var i = 0; i <= dgvListado.Rows.Count - 1; i++)
            {
                var productoId = (int)dgvListado.Rows[i].Cells["productoId"].Value;
                list.Add(productoId);
            }
            return list;
        }

        private void dgvListado_Click(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void btnBuscarPorMarca_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _ultimaBusqueda;
            BuscarPorCodigo(ProductoCriterioBusqueda.Marca);
            txtCodigo.Select(0, txtCodigo.Text.Length);
        }
       
    }
}
