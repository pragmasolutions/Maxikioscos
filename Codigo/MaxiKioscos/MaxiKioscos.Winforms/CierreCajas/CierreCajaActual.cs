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
using MaxiKioscos.Winforms.Facturas;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.OperacionesCaja;
using MaxiKioscos.Winforms.Ventas;
using Microsoft.Reporting.WinForms;

namespace MaxiKioscos.Winforms.CierreCajas
{
    public partial class CierreCajaActual : Form
    {
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

        #endregion

        public CierreCajaActual()
        {
            InitializeComponent();

            this.Text = String.Format("Caja - {0}", DateTime.Now.ToShortDateString());

            dvgRefuerzos.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvFacturas.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvFacturas.Columns[1].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            ActualizarPantalla();
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
                        var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() {"SuperAdministrador", "Administrador"});
                        if (user != 0)
                        {
                            EditarOperacion(operacionCajaId, UsuarioActual.UsuarioId, tipo);
                        }
                        break;
                    case 14:
                        user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() {"SuperAdministrador", "Administrador"});
                        if (user != 0)
                        {
                            EliminarOperacion(operacionCajaId, UsuarioActual.UsuarioId);
                        }
                        break;
                }
            }
        }
        
        private void EditarOperacion(int operacionCajaId, int usuarioId, string tipo)
        {
            using (var form = new OperacionCajaEditar(operacionCajaId, usuarioId, tipo))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (tipo == "Refuerzo")
                    {
                        OperacionCajaRepository = new EFSimpleRepository<OperacionCaja>();
                        CierreCajaRepository = new EFRepository<CierreCaja>();
                        ActualizarPantalla();
                    }
                    else
                    {
                        MessageBox.Show("La extracción se ha registrado correctamente");
                    }
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
            ActualizarGrillaRefuerzos();
            ActualizarGrillaVentas();
            ActualizarGrillaFacturas();
            ActualizarDineroActual();
        }

        private void ActualizarDineroActual()
        {
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

        private void ActualizarGrillaRefuerzos()
        {
            dvgRefuerzos.DataSource = OperacionCajaRepository.Listado(o => o.MotivoOperacionCaja)
                            .Where(o => o.MotivoOperacionCaja.Descripcion == "Refuerzo"
                            && o.CierreCajaId == UsuarioActual.CierreCajaIdActual
                            && !o.Eliminado).ToList();
        }


        private void btnCrearOperacion_Click(object sender, EventArgs e)
        {
            var tipo = ((Control) sender).Name == "btnCrearExtraccion" ? "Extracción" : "Refuerzo";
            if (UsuarioActual.TieneRol("Administrador") || UsuarioActual.TieneRol("SuperAdministrador"))
                EditarOperacion(0, UsuarioActual.UsuarioId, tipo);
            else
            {
                using (var loginForm = new frmLogin(new List<string>() { "SuperAdministrador", "Administrador" }))
                {
                    var loginResult = loginForm.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        EditarOperacion(0, UsuarioActual.UsuarioTemporalId, tipo);
                    }
                }
            }
            dvgRefuerzos.Focus();
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

        private void dgvVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var grilla = ((DataGridView)sender);
                var ventaId = Convert.ToInt32(grilla.SelectedRows[0].Cells[0].Value);
                new frmDetalleVenta(ventaId).ShowDialog();
            }
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
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

        private void dvgRefuerzos_KeyDown(object sender, KeyEventArgs e)
        {
            if (dvgRefuerzos.SelectedRows.Count > 0)
            {
                var grilla = ((DataGridView)sender);
                var tipo = grilla.Name == "dvgExtracciones" ? "Extracción" : "Refuerzo";
                var operacionCajaId = Convert.ToInt32(grilla.SelectedRows[0].Cells[0].Value);
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new OperacionCajaDetalle(operacionCajaId).ShowDialog();
                        break;
                    case Keys.M:
                        var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EditarOperacion(operacionCajaId, UsuarioActual.UsuarioId, tipo);
                        }
                        break;
                    case Keys.Delete:
                        user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EliminarOperacion(operacionCajaId, UsuarioActual.UsuarioId);
                        }
                        break;
                }
            }
        }

        private void CierreCajaActual_Activated(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }
    }
}
