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
using MaxiKioscos.Winforms.Productos;
using MaxiKioscos.Winforms.Productos.Modulos;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Telerik.WinControls.UI;

namespace MaxiKioscos.Winforms.Ventas
{
    
    public partial class Ventas : Form
    {
        #region Repositorios

        private VentaRepository _repository;
        public VentaRepository Repository
        {
            get { return _repository ?? (_repository = new VentaRepository()); }
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
        public List<ProductoHorario> ProductosDatasource { get; set; }

        private Timer _timerArrow;
        private bool _pressingArrow = false;
        private Keys _pressingOperation { get; set; }
        private string _ultimaBusqueda { get; set; }
        private int? _nroVenta;
        private static List<Timer> _timers;

        public Ventas()
        {
            InitializeComponent();
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[5].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            StockRepository.Actualizar();
            ForzarSincronizacion = true;
            ReiniciarVenta();
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
            ProductosDatasource = ProductoRepository.ListadoProductoHorario(AppSettings.MaxiKioscoId)
                                    .Where(x => !x.EsPromocion || (x.EsPromocion && x.StockActual > 0)).ToList();
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

        private void ReiniciarVenta()
        {
            txtFecha.Texto = DateTime.Now.ToShortDateString();
            SetNroFactura();

            if (ForzarSincronizacion)
            {
                ProductosDatasource = ProductoRepository.ListadoProductoHorario(AppSettings.MaxiKioscoId)
                    .Where(x => !x.EsPromocion || (x.EsPromocion && x.StockActual > 0)).ToList();
            }
            ForzarSincronizacion = false;
        }

        private void SetNroFactura()
        {
            if (_nroVenta == null)
            {
                _repository = new VentaRepository();
                _nroVenta = Repository.GenerarNroVenta(AppSettings.MaxiKioscoId);
            }
            else
                _nroVenta++;
            txtNroVenta.Texto = _nroVenta.ToString();
            
            txtCodigo.Focus();
        }

        #region Botonera
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            Aceptar(true, false);
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
                CalcularTotal();
                

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
                CalcularTotal();
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
            dgvListado.SelectedRows[0].Cells["Total"].Value = cantidad*Convert.ToDecimal(dgvListado.SelectedRows[0].Cells["Unitario"].Value.ToString().Replace("$", ""));
            dgvListado.SelectedRows[0].Cells["TotalFormateado"].Value = StringPrice(cantidad * Convert.ToDecimal(dgvListado.SelectedRows[0].Cells["Unitario"].Value.ToString().Replace("$", "")));
            CalcularTotal();
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

        private void Aceptar(bool sobrescribir, bool imprimir)
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
                if (dgvListado.Rows.Count > 0)
                {
                    var lineas = new List<VentaProducto>();
                    decimal total = 0;
                    decimal costoTotal = 0;
                    for (int i = 0; i <= dgvListado.Rows.Count - 1; i++)
                    {
                        var linea = new VentaProducto();

                        linea.Cantidad = decimal.Parse(dgvListado.Rows[i].Cells["Cantidad"].Value.ToString());
                        linea.Eliminado = false;
                        linea.Identifier = Guid.NewGuid();
                        linea.Precio = Convert.ToDecimal(dgvListado.Rows[i].Cells["Unitario"].Value.ToString().Replace("$", ""));
                        linea.ProductoId = (int)dgvListado.Rows[i].Cells["productoId"].Value;
                        linea.Costo = dgvListado.Rows[i].Cells["Costo"].Value == null
                                                ? 0
                                                : Convert.ToDecimal(dgvListado.Rows[i].Cells["Costo"].Value.ToString().Replace("$", ""));

                        var recargo = dgvListado.Rows[i].Cells["Recargo"].Value;
                        linea.EsPromocion = bool.Parse(dgvListado.Rows[i].Cells["EsPromocion"].Value.ToString());
                        linea.AdicionalPorExcepcion = recargo == null
                                                                ? (decimal?)null :
                                                                Convert.ToDecimal(recargo.ToString().Replace("$", "")) * linea.Cantidad;
                        linea.Desincronizado = true;


                        total += Convert.ToDecimal(linea.Cantidad) * linea.Precio.GetValueOrDefault();
                        costoTotal += Convert.ToDecimal(linea.Cantidad) * linea.Costo;
                        lineas.Add(linea);
                    }


                    ConfirmacionAbierta = true;
                    var frmConfirmar = new frmConfirmarVenta(total);
                    if (frmConfirmar.ShowDialog() == DialogResult.OK)
                    {
                        ConfirmacionAbierta = false;
                        var venta = new Venta
                        {
                            ImporteTotal = total,
                            CostoTotal = costoTotal,
                            Identifier = Guid.NewGuid(),
                            Eliminado = false,
                            CierreCajaId = UsuarioActual.CierreCajaIdActual,
                            FechaVenta = DateTime.Now,
                            VentaProductos = lineas,
                            Facturada = imprimir
                        };
                        venta.CierreCajaId = UsuarioActual.CierreCajaIdActual;
                        var stockRepository = new StockRepository();
                        var stockTransaccionRepository = new EFRepository<StockTransaccion>();

                        var seAgregoStock = false;
                        var seAgregoTransaccion = false;

                        //Agrego primero a la coleccion las lineas secundarias correspondientes a promociones
                        var secundarias = new List<VentaProducto>();
                        foreach (var linea in lineas.Where(l => l.EsPromocion))
                        {
                            var productos = ProductoPromocionRepository.Listado().Where(p => p.PadreId == linea.ProductoId && !p.Eliminado).ToList();
                            secundarias.AddRange(productos.Select(p => new VentaProducto()
                                                                       {
                                                                           Cantidad = p.Unidades * linea.Cantidad,
                                                                           ProductoId = p.HijoId
                                                                       }));
                        }

                        lineas.AddRange(secundarias);

                        foreach (var line in lineas)
                        {
                            var stockSt = new StockTransaccion
                            {
                                Cantidad = line.Cantidad * (-1),
                                StockTransaccionTipoId = 1,
                                Identifier = Guid.NewGuid(),
                                Desincronizado = true
                            };

                            var stock = stockRepository.ObtenerByProducto(line.ProductoId, AppSettings.MaxiKioscoId);
                            if (stock != null)
                            {
                                stockSt.StockId = stock.StockId;
                                stock.StockActual = stock.StockActual - Convert.ToDecimal(line.Cantidad);
                                stockTransaccionRepository.Agregar(stockSt);
                                stockRepository.Modificar(stock);
                                seAgregoTransaccion = true;
                                seAgregoStock = true;
                            }
                            else
                            {
                                stock = new Stock()
                                {
                                    Identifier = Guid.NewGuid(),
                                    MaxiKioscoId = AppSettings.MaxiKioscoId,
                                    ProductoId = line.ProductoId,
                                    StockActual = -line.Cantidad,
                                    OperacionCreacion = "Venta en DESKTOP",
                                    FechaCreacion = DateTime.Now,
                                    StockTransacciones = new List<StockTransaccion> { stockSt }
                                };
                                stockRepository.Agregar(stock);
                                seAgregoStock = true;
                            }
                        }

                        if (seAgregoStock)
                            stockRepository.Commit();
                        if (seAgregoTransaccion)
                            stockTransaccionRepository.Commit();

                        Repository.Agregar(venta);
                        try
                        {
                            Repository.Commit();
                            Limpiar();
                        }
                        catch (Exception)
                        {
                            Mensajes.Guardar(false, "Ha ocurrido un error al registrar la venta. Por favor intente nuevamente");
                        }
                        ReiniciarVenta();
                    }
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

        private void BuscarArticulo(ProductoHorario prod)
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
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Total"].Value = prod.Precio;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["TotalFormateado"].Value = StringPrice(prod.Precio);
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Costo"].Value = prod.Costo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["Recargo"].Value = prod.Recargo;
                dgvListado.Rows[dgvListado.Rows.Count - 1].Cells["EsPromocion"].Value = prod.EsPromocion;
                CalcularTotal();
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

        private void CalcularTotal()
        {
            decimal total = 0;
            for (int i = 0; i <= dgvListado.Rows.Count - 1; i++)
            {
                total += Convert.ToDecimal(dgvListado.Rows[i].Cells["Total"].Value.ToString().Replace("$", ""));
            }
            lblTotal.Text = String.Format("${0}", total.ToString("N2"));
        }

        private void Limpiar()
        {
            while (dgvListado.Rows.Count > 0)
            {
                dgvListado.Rows.RemoveAt(0);
            }
            lblTotal.Text = "$0";
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
                }
            }
        }

        #endregion

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        SuprimirFila();
                        break;
                }
            }
            txtCodigo.Focus();
        }

        private void dgvListado_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var icon = @"\Resources\delete_icon.ico";
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 4);
                e.Handled = true;
            }
        }

        private void Ventas_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void BuscarPorCodigo(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                PopupAbierto = true;
                var productos = ProductosDatasource.Where(p => ObtenerProductosVendidosIds().All(c => c != p.ProductoId)
                    && (!p.EsPromocion || (p.EsPromocion && p.StockActual > 0))).ToList();
                var frm = new frmBuscador(txtCodigo.Text, productos, true, criterio);

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
                var frm = new frmBuscador(txtCodigo.Text, ProductosDatasource.Where(x => !x.EsPromocion || (x.EsPromocion && x.StockActual > 0)).ToList(), true, criterio);
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
                var buscador = this.OwnedForms.First() as frmBuscador;
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
                        var buscador = this.OwnedForms.First() as frmBuscador;
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
                var buscador = this.OwnedForms.First() as frmBuscador;
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
                var buscador = this.OwnedForms.First() as frmBuscador;

                
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
                    
                    if (prod.EsPromocion)
                    {
                        if (prod.StockActual == 0)
                        {
                            MessageBox.Show("Esta promoción no se encuentra disponible para la cantidad solicitada");
                            SuprimirUltimaFila();
                        }
                        else
                        {
                            ActualizarStockPromociones(prod.ProductoId, 1);
                            prod.StockActual--;
                        }
                    }
                    else
                    {
                        prod.StockActual--;
                    }
                    ScrollearHastaElFinal();
                }
                buscador.Close();
                txtCodigo.Clear();
                txtCodigo.Focus();
                SeleccionarUltimaFila();
            }
            else
            {
                Aceptar(false, false);
            }
        }

        private void ScrollearHastaElFinal()
        {
            if (dgvListado.RowCount != 0)
            {
                dgvListado.FirstDisplayedScrollingRowIndex = dgvListado.RowCount - 1;
            }
        }

        private void BuscadorSubir()
        {
 	        if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscador;
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
                var buscador = this.OwnedForms.First() as frmBuscador;
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

        
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Aceptar(true, true);
        }
    }
}
