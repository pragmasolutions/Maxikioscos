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
using MaxiKioscos.Winforms.Gastos;
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Facturas;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.OperacionesCaja;
using MaxiKioscos.Winforms.Principal;
using MaxiKioscos.Winforms.RetirosPersonales;
using MaxiKioscos.Winforms.Ventas;
using Microsoft.Reporting.WinForms;

namespace MaxiKioscos.Winforms.CierreCajas
{
    public partial class CierreCajaDetalleCompleto : Form
    {
        public mdiPrincipal Parent { get; set; }

        #region Repositorios

        private EFSimpleRepository<OperacionCaja> _operacionCajaRepository;
        public EFSimpleRepository<OperacionCaja> OperacionCajaRepository
        {
            get
            {
                if (_operacionCajaRepository == null)
                    _operacionCajaRepository = new EFSimpleRepository<OperacionCaja>();
                return _operacionCajaRepository;
            }
            set { _operacionCajaRepository = value; }
        }

        private EFRepository<CierreCaja> _cierreCajaRepository;
        public EFRepository<CierreCaja> CierreCajaRepository
        {
            get
            {
                if (_cierreCajaRepository == null)
                    _cierreCajaRepository = new EFRepository<CierreCaja>();
                return _cierreCajaRepository;
            }
            set { _cierreCajaRepository = value; }
        }

        private EFRepository<Venta> _ventaRepository;
        public EFRepository<Venta> VentaRepository
        {
            get
            {
                if (_ventaRepository == null)
                    _ventaRepository = new EFRepository<Venta>();
                return _ventaRepository;
            }
            set { _ventaRepository = value; }
        }

        private EFRepository<Factura> _facturaRepository;
        public EFRepository<Factura> FacturaRepository
        {
            get
            {
                if (_facturaRepository == null)
                    _facturaRepository = new EFRepository<Factura>();
                return _facturaRepository;
            }
            set
            {
                _facturaRepository = value;
            }
        }

        private EFRepository<Costo> _costoRepository;
        public EFRepository<Costo> CostoRepository
        {
            get
            {
                if (_costoRepository == null)
                    _costoRepository = new EFRepository<Costo>();
                return _costoRepository;
            }
            set
            {
                _costoRepository = value;
            }
        }

        private EFRepository<RetiroPersonal> _retiroPersonalRepository;
        public EFRepository<RetiroPersonal> RetiroPersonalRepository
        {
            get
            {
                if (_retiroPersonalRepository == null)
                    _retiroPersonalRepository = new EFRepository<RetiroPersonal>();
                return _retiroPersonalRepository;
            }
            set
            {
                _retiroPersonalRepository = value;
            }
        }

        #endregion

        public CierreCajaDetalleCompleto(mdiPrincipal parent)
        {
            InitializeComponent();
            Parent = parent;

            this.Text = String.Format("Caja - {0}", DateTime.Now.ToShortDateString());

            dvgExtracciones.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dvgRefuerzos.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvFacturas.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvFacturas.Columns[1].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            dvgExtracciones.Columns[2].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            dvgRefuerzos.Columns[2].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            dgvCostos.AutoGenerateColumns = false;
            dgvCostos.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvRetirosPersonales.AutoGenerateColumns = false;
            dgvRetirosPersonales.Columns[2].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
        }

        
        private void dvgExtraccionesRefuerzos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 12 || e.ColumnIndex == 13 || e.ColumnIndex == 14) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                
                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;

                switch (e.ColumnIndex)
                {
                    case 12:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 13:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 14:
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

        private void dvgExtraccionesRefuerzos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 12 || e.ColumnIndex == 13 || e.ColumnIndex == 14) && e.RowIndex >= 0)
            {
                var grilla = ((DataGridView)sender);
                var tipo = grilla.Name == "dvgExtracciones" ? "Extracción" : "Refuerzo";
                var operacionCajaId = Convert.ToInt32(grilla.Rows[e.RowIndex].Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 12:
                        new OperacionCajaDetalle(operacionCajaId).ShowDialog();
                        break;
                    case 13:
                        EditarOperacion(operacionCajaId, UsuarioActual.UsuarioId, tipo);
                        break;
                    case 14:
                        EliminarOperacion(operacionCajaId, UsuarioActual.UsuarioId);
                        break;
                }
            }
        }
        
        private void EditarOperacion(int operacionCajaId, int usuarioId, string tipo)
        {
            using (var form = new OperacionCajaEditar(operacionCajaId, usuarioId, tipo))
            {
                form.CajaActual = lblDineroEnCaja.Text;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OperacionCajaRepository = new EFSimpleRepository<OperacionCaja>();
                    CierreCajaRepository = new EFRepository<CierreCaja>();
                    ActualizarPantalla();
                }
            }
        }

        private void EliminarOperacion(int operacionCajaId, int usuarioId)
        {
            using (var form = new OperacionCajaEliminar(operacionCajaId, usuarioId))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OperacionCajaRepository = new EFSimpleRepository<OperacionCaja>();
                    CierreCajaRepository = new EFRepository<CierreCaja>();
                    ActualizarPantalla();
                }
            }
        }

        private void ActualizarPantalla()
        {
            ActualizarGrillaExtracciones();
            ActualizarGrillaRefuerzos();
            ActualizarGrillaVentas();
            ActualizarGrillaFacturas();
            ActualizarGrillaCostos();
            ActualizarGrillaRetirosPersonales();
            ActualizarDineroActual();
        }

        private void ActualizarDineroActual()
        {
            var dineroActual = CierreCajaRepository.MaxiKioscosEntities.CierreCajaCantidadDineroActual(UsuarioActual.CierreCajaIdActual).FirstOrDefault();
            lblDineroEnCaja.Text = String.Format("${0}", dineroActual.GetValueOrDefault().ToString("N2"));

            var cajaInicial = CierreCajaRepository.Obtener(UsuarioActual.CierreCajaIdActual);
            lblCajaInicial.Text = String.Format("${0}", cajaInicial.CajaInicial.ToString("N2"));
        }

        private void ActualizarGrillaFacturas()
        {
            var facturas = FacturaRepository.Listado(f => f.Proveedor).Where(
                                f => f.CierreCajaId == UsuarioActual.CierreCajaIdActual).ToList();
            dgvFacturas.DataSource = facturas.ToList();
        }

        private void ActualizarGrillaVentas()
        {
            var ventas = VentaRepository.Listado(v => v.VentaProductos,
                                                 v => v.VentaProductos.Select(vp => vp.Producto))
                                            .Where(v => v.CierreCajaId == UsuarioActual.CierreCajaIdActual)
                                            .OrderByDescending(v => v.FechaVenta).Take(10).ToList();

            var ventasFormateadas = ventas.Select(v => new VentaGridStruct
                                        {
                                            VentaId = v.VentaId,
                                            Fecha = String.Format("{0} {1}",
                                                                    v.FechaVenta.ToShortDateString(),
                                                                    v.FechaVenta.ToShortTimeString()),
                                            ImporteTotal = "$" + v.ImporteTotal.ToString("N2"),
                                            PrimerProducto = v.VentaProductos.First().Producto.Descripcion
                                        }).ToList();
            dgvVentas.DataSource = ventasFormateadas;
        }

        private void ActualizarGrillaExtracciones()
        {
            dvgExtracciones.DataSource = OperacionCajaRepository.Listado(o => o.MotivoOperacionCaja)
                            .Where(o => o.MotivoOperacionCaja.Descripcion == "Extracción"
                            && o.CierreCajaId == UsuarioActual.CierreCajaIdActual
                            && !o.Eliminado).ToList();
        }

        private void ActualizarGrillaRefuerzos()
        {
            dvgRefuerzos.DataSource = OperacionCajaRepository.Listado(o => o.MotivoOperacionCaja)
                            .Where(o => o.MotivoOperacionCaja.Descripcion == "Refuerzo"
                            && o.CierreCajaId == UsuarioActual.CierreCajaIdActual
                            && !o.Eliminado).ToList();
        }

        private void ActualizarGrillaCostos()
        {
            var datasource = CostoRepository.Listado(c => c.CierreCaja, c => c.CategoriaCosto)
                .Where(c => c.CierreCajaId == UsuarioActual.CierreCajaIdActual)
                .OrderByDescending(c => c.Fecha).ToList();
            var costos = datasource.Select(c => new CostoGridStruct
            {
                Estado = c.Aprobado ? "Aprobado" : "No Aprobado",
                CajaCerrada = c.CierreCaja.FechaFin != null,
                CategoriaCosto = c.CategoriaCosto.Descripcion,
                CostoId = c.CostoId,
                Fecha = c.Fecha,
                Importe = c.Monto,
                NroComprobante = c.NroComprobante
            }).ToList();

            dgvCostos.DataSource = costos.ToList();
        }

        private void ActualizarGrillaRetirosPersonales()
        {
            var datasource = RetiroPersonalRepository.Listado(c => c.CierreCaja)
                    .Where(c => c.CierreCajaId == UsuarioActual.CierreCajaIdActual)
                    .OrderByDescending(c => c.FechaRetiroPersonal).ToList();

            var retiros = datasource.Select(rp => new RetiroPersonalGridStruct
            {
                RetiroPersonalId = rp.RetiroPersonalId,
                Fecha = rp.FechaRetiroPersonal,
                Importe = rp.ImporteTotal
            }).ToList();

            dgvRetirosPersonales.DataSource = retiros.ToList();
        }

        private void dgvCostos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                switch (e.ColumnIndex)
                {
                    case 7:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 8:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 9:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 4;
                        break;
                }
                var ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }

            if ((e.ColumnIndex == 11 || e.ColumnIndex == 12) && e.RowIndex >= 0)
            {
                var item = dgvCostos.Rows[e.RowIndex].DataBoundItem as CostoGridStruct;

                if (item.Estado == "Aprobado" || item.CajaCerrada)
                {
                    var buttonCell = (DataGridViewDisableButtonCell)dgvCostos.Rows[e.RowIndex].Cells[8];
                    buttonCell.Enabled = false;

                    var buttonCell2 = (DataGridViewDisableButtonCell)dgvCostos.Rows[e.RowIndex].Cells[9];
                    buttonCell2.Enabled = false;
                }
            }


        }

        private void dgvCostos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                var costo = dgvCostos.Rows[e.RowIndex].DataBoundItem as CostoGridStruct;
                switch (e.ColumnIndex)
                {
                    case 7:
                        new frmDetalleEliminarGasto(costo.CostoId, "Detalle").ShowDialog();
                        break;
                    case 8:
                        CostoEditar(costo);
                        break;
                    case 9:
                        CostoEliminar(costo);
                        break;
                }
            }

        }

        private void CostoEliminar(CostoGridStruct costo)
        {
            if (!costo.CajaCerrada && costo.Estado != "Aprobado")
            {
                if (new frmDetalleEliminarGasto(costo.CostoId, "Eliminar").ShowDialog() == DialogResult.OK)
                {
                    //borro la factura
                    CostoRepository.Eliminar(costo.CostoId);
                    CostoRepository.Commit();
                    ActualizarPantalla();
                }
            }
        }

        private void CostoEditar(CostoGridStruct costo)
        {
            if (!costo.CajaCerrada && costo.Estado != "Aprobado")
            {
                if (new frmEditarGasto(costo.CostoId).ShowDialog() == DialogResult.OK)
                {
                    CostoRepository = new EFRepository<Costo>();
                    ActualizarPantalla();
                }
            }
        }

        private void dgvCostos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCostos.SelectedRows[0];
            var costoId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleEliminarGasto(costoId, "Detalle").ShowDialog();
        }

        private void dgvRetirosPersonales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var ico = new Icon(AppSettings.ApplicationPath + @"\Resources\details_icon.ico");
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                e.Handled = true;
            }

        }

        private void dgvRetirosPersonales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var retiroPersonal = dgvRetirosPersonales.Rows[e.RowIndex].DataBoundItem as RetiroPersonalGridStruct;
                new frmDetalleRetiroPersonal(retiroPersonal.RetiroPersonalId).ShowDialog();
            }

        }

        private void dgvRetirosPersonales_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRetirosPersonales.SelectedRows[0];
            var costoId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleRetiroPersonal(costoId).ShowDialog();
        }


        private void btnCrearOperacion_Click(object sender, EventArgs e)
        {
            var tipo = ((Control) sender).Name == "btnCrearExtraccion" ? "Extracción" : "Refuerzo";
            if (UsuarioActual.TieneRol("Administrador") || UsuarioActual.TieneRol("SuperAdministrador"))
                EditarOperacion(0, UsuarioActual.UsuarioId, tipo);
            else
            {
                using (var loginForm = new frmLogin(new List<string>() {"Administrador", "SuperAdministrador" }))
                {
                    var loginResult = loginForm.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        EditarOperacion(0, UsuarioActual.UsuarioTemporalId, tipo);
                    }
                }
            }
            if (tipo == "Refuerzo")
                dvgRefuerzos.Focus();
            else
                dvgExtracciones.Focus();
        }

        private void dgvVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var icon = @"\Resources\details_icon.ico";
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                e.Handled = true;
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var grilla = ((DataGridView)sender);
                var ventaId = Convert.ToInt32(grilla.Rows[e.RowIndex].Cells[0].Value);
                new frmDetalleVenta(ventaId).ShowDialog();
            }
        }

        private void dgvFacturas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 18 || e.ColumnIndex == 19 || e.ColumnIndex == 20) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;

                switch (e.ColumnIndex)
                {
                    case 18:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 19:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 20:
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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 18 || e.ColumnIndex == 19 || e.ColumnIndex == 20) && e.RowIndex >= 0)
            {
                var facturaId = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 18:
                        new frmDetalleEliminarFactura(facturaId, "Detalle").ShowDialog();
                        break;
                    case 19:
                        if (new frmEditarFactura(facturaId).ShowDialog() == DialogResult.OK)
                        {
                            FacturaRepository = new EFRepository<Factura>();
                            ActualizarGrillaFacturas();
                        }
                        break;
                    case 20:
                        if (new frmDetalleEliminarFactura(facturaId, "Eliminar").ShowDialog() == DialogResult.OK)
                        {
                            //borro la factura
                            FacturaRepository.Eliminar(facturaId);
                            FacturaRepository.Commit();

                            ActualizarGrillaFacturas();
                        }
                        break;
                }
            }
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (new frmEditarFactura().ShowDialog() == DialogResult.OK)
            {
                FacturaRepository = new EFRepository<Factura>();
                ActualizarGrillaFacturas();
            }
            dgvFacturas.Focus();
        }

        private void btnActualizarFacturas_Click(object sender, EventArgs e)
        {
            _facturaRepository=new EFRepository<Factura>();
            ActualizarGrillaFacturas();
            _operacionCajaRepository = new EFSimpleRepository<OperacionCaja>();
            ActualizarGrillaExtracciones();
             _operacionCajaRepository=new EFSimpleRepository<OperacionCaja>();
            ActualizarGrillaRefuerzos();
            _cierreCajaRepository=new EFRepository<CierreCaja>();
            ActualizarDineroActual();
            _ventaRepository=new EFRepository<Venta>();
            ActualizarGrillaVentas();
        }

        private void CierreCajaDetalleCompleto_Load(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }

        private void dgvVentas_KeyDown(object sender, KeyEventArgs e)
        {
            var grilla = ((DataGridView)sender);
            if (grilla.SelectedRows.Count > 0)
            {
                if (e.KeyCode == Keys.D)
                {
                    var ventaId = Convert.ToInt32(grilla.SelectedRows[0].Cells[0].Value);
                    new frmDetalleVenta(ventaId).ShowDialog();
                }
            }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            var grilla = ((DataGridView)sender);
            if (grilla.SelectedRows.Count > 0)
            {
                var facturaId = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value);
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new frmDetalleEliminarFactura(facturaId, "Detalle").ShowDialog();
                        break;
                    case Keys.M:
                        if (new frmEditarFactura(facturaId).ShowDialog() == DialogResult.OK)
                        {
                            FacturaRepository = new EFRepository<Factura>();
                            ActualizarGrillaFacturas();
                        }
                        break;
                    case Keys.Delete:
                        if (new frmDetalleEliminarFactura(facturaId, "Eliminar").ShowDialog() == DialogResult.OK)
                        {
                            //borro la factura
                            FacturaRepository.Eliminar(facturaId);
                            FacturaRepository.Commit();

                            ActualizarGrillaFacturas();
                        }
                        break;
                }
            }
        }

        private void dvgExtracciones_KeyDown(object sender, KeyEventArgs e)
        {
            var grilla = ((DataGridView)sender);
            if (grilla.SelectedRows.Count > 0)
            {
                var tipo = grilla.Name == "dvgExtracciones" ? "Extracción" : "Refuerzo";
                var operacionCajaId = Convert.ToInt32(grilla.SelectedRows[0].Cells[0].Value);
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new OperacionCajaDetalle(operacionCajaId).ShowDialog();
                        break;
                    case Keys.M:
                        EditarOperacion(operacionCajaId, UsuarioActual.UsuarioId, tipo);
                        break;
                    case Keys.Delete:
                        EliminarOperacion(operacionCajaId, UsuarioActual.UsuarioId);
                        break;
                }
            }
        }

        private void CierreCajaDetalleCompleto_Activated(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }

        private void btnAgregarRetiroPersonal_Click(object sender, EventArgs e)
        {
            var pantalla = new frmNuevoRetiroPersonal();
            bool copia = false;
            foreach (var frm in Parent.MdiChildren)
            {
                if (pantalla.Name == frm.Name)
                {
                    frm.Close();
                }
            }

            pantalla.Closed += ApplicationTab_Closed;
            pantalla.Load += PantallaOnLoad;
            pantalla.MdiParent = Parent;
            pantalla.Show();
        }


        private void ApplicationTab_Closed(object sender, EventArgs e)
        {
            var vantana = sender as Form;
            vantana.Closed -= ApplicationTab_Closed;

            ActualizarPantalla();
        }

        private void PantallaOnLoad(object sender, EventArgs eventArgs)
        {
            ((Form)sender).WindowState = FormWindowState.Maximized;
        }

        private void btnCrearCosto_Click(object sender, EventArgs e)
        {
            if (new frmEditarGasto().ShowDialog() == DialogResult.OK)
            {
                ActualizarPantalla();
            }
        }
    }
}
