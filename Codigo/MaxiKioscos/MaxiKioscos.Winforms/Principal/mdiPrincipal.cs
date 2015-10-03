using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.CierreCajas;
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Winforms.Compras;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.ControlStock;
using MaxiKioscos.Winforms.CorreccionesStock;
using MaxiKioscos.Winforms.Excepciones;
using MaxiKioscos.Winforms.Exportacion;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.IoC;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.Membership;
using MaxiKioscos.Winforms.Productos;
using MaxiKioscos.Winforms.Properties;
using MaxiKioscos.Winforms.Proveedores;
using MaxiKioscos.Winforms.ReportarError;
using MaxiKioscos.Winforms.Reportes;
using MaxiKioscos.Winforms.Sincronizacion;
using MaxiKioscos.Winforms.SincronizationService;
using MaxiKioscos.Winforms.UserControls;
using MaxiKioscos.Winforms.Usuarios;
using MaxiKioscos.Winforms.Ventas;
using MaxiKioscos.Winforms.Marcas;
using MaxiKioscos.Winforms.Rubros;
using MaxiKioscos.Winforms.Facturas;
using System.IO;
using Maxikioscos.Comun.Helpers;
using MaxiKioscos.Winforms.Costos;
using MaxiKioscos.Winforms.RetirosPersonales;

namespace MaxiKioscos.Winforms.Principal
{
    public partial class mdiPrincipal : Form
    {
        private EFRepository<CierreCaja> _cierreCajaRepository;
        public EFRepository<CierreCaja> CierreCajaRepository
        {
            get { return _cierreCajaRepository ?? (_cierreCajaRepository = new EFRepository<CierreCaja>()); }
        }

        private DatabaseRepository _databaseRepository;
        public DatabaseRepository DatabaseRepository
        {
            get { return _databaseRepository ?? (_databaseRepository = new DatabaseRepository()); }
        }

        private EFRepository<Entidades.MaxiKiosco> _maxikioscoRepository;
        public EFRepository<Entidades.MaxiKiosco> MaxikioscoRepository
        {
            get { return _maxikioscoRepository ?? (_maxikioscoRepository = new EFRepository<Entidades.MaxiKiosco>()); }
        }

        private readonly ISincronizacionManager _sincronizacionManager;

        private static Timer _connectionTimer { get; set; }

        private static Timer ExportTimer { get; set; }

        public mdiPrincipal()
        {
            InitializeComponent();

            _sincronizacionManager = CompositionRoot.Resolve<ISincronizacionManager>();
            _sincronizacionManager.SyncExitosa += ActualizarUltimaSyncExitosa;

            CheckearNuevoKiosco();
            ActualizarEsquema();

            IniciarTimerExportacion();
        }

        private void IniciarTimerExportacion()
        {
            ExportTimer = new Timer();
            ExportTimer.Interval = 15*60*1000;
            ExportTimer.Tick += ExportTimer_Tick;
            ExportTimer.Start();
        }

        void ExportTimer_Tick(object sender, EventArgs e)
        {
            _sincronizacionManager.ExportarDatosDesincronizados();
        }

        private void ActualizarUltimaSyncExitosa()
        {
            var date = DateTime.Now;
            var kiosco = MaxikioscoRepository.Obtener(m => m.Identifier == AppSettings.MaxiKioscoIdentifier);
            kiosco.UltimaSincronizacionExitosa = date;
            MaxikioscoRepository.Modificar(kiosco);
            MaxikioscoRepository.Commit();

            RefrescarTssSync(date);
        }

        private void RefrescarTssSync(DateTime? date)
        {
            tssUltimaSyncExitosa.Text = date == null
                                            ? string.Empty
                                            : String.Format("  |    Ultima Sincronización exitosa: {0} {1}",
                                                        date.GetValueOrDefault().ToShortDateString(),
                                                        date.GetValueOrDefault().ToShortTimeString());
        }

        

        private bool ActualizarEsquema()
        {
            if (AppSettings.MaxiKioscoIdentifier != Guid.Empty)
            {
                var scriptsPath = Path.Combine(AppSettings.ApplicationPath, "SqlScripts");
                var seActualizo = DatabaseRepository.ActualizarEsquema(AppSettings.MaxiKioscoIdentifier, scriptsPath);
                return seActualizo;
            }
            return false;
        }

        private void CheckearNuevoKiosco()
        {
            if (AppSettings.MaxiKioscoIdentifier != Guid.Empty)
                return;
            _sincronizacionManager.InicializarKiosco();
        }

        private void LogIn()
        {
            using (var form = new frmLogin())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    ToggleLoginItems();
                    SetContextoCierreCaja();
                    ControlarCierreCaja();

                    ToggleExcepcionesHabilitado();
                    ToggleAccionesRelacionadasACierreDeCaja();
                    ToggleAccionesRelacionadasASesion();

                    this.Text = this.Tag.ToString();

                    if (result == DialogResult.OK)
                    {
                        ToggleEstadoOnline();
                    }
                    

                    CheckUltimaCajaCerrada();
                }
                else
                {
                    ToggleLoginItems();
                    this.Text = this.Tag.ToString();
                }
                ToggleForzarSincronizacionEstado();
            }
        }

        private void ToggleEstadoOnline()
        {
            if (AppSettings.MaxiKioscoEstaOnline)
            {
                _sincronizacionManager.SincronizarEnSegundoPlano(this, bgWorker, tssProgreso);
                tsmReportarError.Visible = true;
            }
            else
            {
                tsmReportarError.Visible = false;
            }
        }

        private void CheckUltimaCajaCerrada()
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto)
            {
                var ultimaCaja = CierreCajaRepository.Obtener(c => c.CierreCajaId == UsuarioActual.CierreCajaIdActual,
                                                              c => c.Usuario);

                if (ultimaCaja.UsuarioId != UsuarioActual.UsuarioId)
                {
                    var confirmation = new ConfirmationForm(string.Format(Resources.MensajeCerrarCajaAnterior, ultimaCaja.Usuario.NombreCompleto),
                                                            Resources.TextoAceptar, Resources.TextoCancelar);

                    if (confirmation.ShowDialog() == DialogResult.OK)
                    {
                        CerrarCaja(cancel: Logoff, controlarMargenes: false, cerrarSesion: false);
                    }
                    else
                    {
                        //Cerrar session
                        Logoff();
                    }
                }
            }
        }

        private void SetContextoCierreCaja()
        {
            _cierreCajaRepository = new EFRepository<CierreCaja>();
            var caja = CierreCajaRepository.MaxiKioscosEntities.CierreCajaObtenerUltima(AppSettings.MaxiKioscoId).FirstOrDefault();

            if (caja == null)
            {
                EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
            }
            else
            {
                if (caja.FechaFin == null)
                {
                    UsuarioActual.CierreCajaIdActual = caja.CierreCajaId;
                    EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Abierto;
                }
                else
                {
                    EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
                }
            }
        }

        private void mdiPrincipal_Load(object sender, EventArgs e)
        {
            AppSettings.MainForm = this;
            _connectionTimer = new Timer();
            _connectionTimer.Interval = 120000;
            _connectionTimer.Tick += _connectionTimer_Tick;
            _connectionTimer.Start();

            if (AppSettings.Maxikiosco != null)
            {
                RefrescarTssSync(AppSettings.Maxikiosco.UltimaSincronizacionExitosa);
            }
            LogIn();

        }

        void _connectionTimer_Tick(object sender, EventArgs e)
        {
            _sincronizacionManager.PingServer();
            ToggleForzarSincronizacionEstado();
        }

        private void AbrirTab(Form pantalla)
        {
            bool copia = false;
            foreach (var frm in this.MdiChildren)
            {
                if (pantalla.Name == frm.Name)
                {
                    copia = true;
                    frm.Focus();
                }
            }
            if (!copia)
            {
                pantalla.Closed += ApplicationTab_Closed;
                pantalla.Load += PantallaOnLoad;
                pantalla.MdiParent = this;
                pantalla.Show();
            }
            else
            {
                pantalla.Dispose();
            }
        }

        private void PantallaOnLoad(object sender, EventArgs eventArgs)
        {
            ((Form)sender).WindowState = FormWindowState.Maximized;
        }


        #region Cierre de Caja

        private void tsmiAbrirCaja_Click(object sender, EventArgs e)
        {
            //Verifico que no hayan cierres de caja abiertos y que haya una caja inicial
            var cajaFinalAnterior = CierreCajaRepository.MaxiKioscosEntities.CierreCajaUltimaCajaFinal(AppSettings.MaxiKioscoId).FirstOrDefault();
            if (cajaFinalAnterior == null)
            {
                //No hay cierre de caja: ingreso una caja inicial por ser la primera vez
                var frm = new CajaInicial();
                if (frm.ShowDialog() == DialogResult.OK && AppSettings.MaxiKioscoEstaOnline)
                {
                    _sincronizacionManager.SincronizarEnSegundoPlano(this, bgWorker, tssProgreso);
                }
            }
            else
            {
                var cierre = new CierreCaja
                                 {
                                     CajaInicial = cajaFinalAnterior.GetValueOrDefault(),
                                     FechaInicio = DateTime.Now,
                                     Identifier = Guid.NewGuid(),
                                     MaxiKioskoId = AppSettings.MaxiKioscoId,
                                     UsuarioId = UsuarioActual.UsuarioId
                                 };
                CierreCajaRepository.Agregar(cierre);
                CierreCajaRepository.Commit();
                EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Abierto;
                UsuarioActual.CierreCajaIdActual = cierre.CierreCajaId;
                MessageBox.Show("La caja se ha abierto correctamente");
                ToggleExcepcionesHabilitado();
                if (AppSettings.MaxiKioscoEstaOnline)
                {
                    _sincronizacionManager.SincronizarEnSegundoPlano(this, bgWorker, tssProgreso);
                }

            }
            ToggleAccionesRelacionadasACierreDeCaja();
            ControlarCierreCaja();
        }

        public void ControlarCierreCaja()
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto)
            {
                tsmiAbrirCaja.Enabled = false;
                tsmiCerrarCaja.Enabled = true;
                tsmiDetalleCompleto.Enabled = true;
            }
            else
            {
                tsmiAbrirCaja.Enabled = true;
                tsmiCerrarCaja.Enabled = false;
                tsmiDetalleCompleto.Enabled = false;
            }
        }

        private void ToggleExcepcionesHabilitado()
        {
            var cantidadCierresDeCaja = this.CierreCajaRepository
                                    .Listado()
                                    .Count(cc => cc.MaxiKiosco.CuentaId == UsuarioActual.CuentaId
                                     && cc.MaxiKioskoId == AppSettings.MaxiKioscoId);

            tsmExcepciones.Enabled = cantidadCierresDeCaja > 1;
        }

        private void ToggleForzarSincronizacionEstado()
        {
            if (_sincronizacionManager.IsConnected)
            {
                tssConeccionForzarSincronizacion.Text = "Forzar Sincronización: Conectado";
            }
            else
            {
                tssConeccionForzarSincronizacion.Text = "Forzar Sincronización: Desconectado";
            }
        }

        private void ToggleAccionesRelacionadasACierreDeCaja()
        {
            tsbCaja.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
            tsbVentas.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
            tsmiCerrarCaja.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
            tsmiDetalleCompleto.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
            comprasToolStripMenuItem.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
        }

        private void ToggleAccionesRelacionadasASesion()
        {
            tsmCambiarContraseña.Enabled = UsuarioActual.Usuario != null;
            tsmIniciarSesion.Enabled = UsuarioActual.Usuario == null;
            tsmCerrarSesion.Enabled = UsuarioActual.Usuario != null;
            tsbArticulos.Enabled = UsuarioActual.EstaAutenticado;
            tsbControlStock.Enabled = UsuarioActual.EstaAutenticado;
        }

        private void tsmiCerrarCaja_Click(object sender, EventArgs e)
        {
            CerrarCaja();
        }

        private void CerrarCaja(Action cancel = null, bool controlarMargenes = true, bool cerrarSesion = true)
        {
            using (var form = new CerrarCaja(controlarMargenes))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CerrarTodosLosTabs();
                    EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
                    ControlarCierreCaja();
                    ToggleAccionesRelacionadasACierreDeCaja();

                    if (cerrarSesion)
                    {
                        CerrarSesion();
                    }

                    AbrirTab(new CierreCajaDetalle(form.CierreCajaId));
                }
                else
                {
                    if (cancel != null)
                    {
                        cancel();
                    }
                }
            }
        }

        private void ApplicationTab_Closed(object sender, EventArgs e)
        {
            var vantana = sender as Form;
            vantana.Closed -= ApplicationTab_Closed;
        }

        private void tsbCaja_Click(object sender, EventArgs e)
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto)
                AbrirTab(new CierreCajaActual());
            else
                MessageBox.Show("Debe abrir una caja primero.");
        }

        private void gestionDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmProveedores());
        }

        #endregion

        private void tsmGestionDeMercaderias_Click(object sender, EventArgs e)
        {
            IngresoProductos ventanaIngresoDeProductos;

            if (UsuarioActual.TieneRol("Administrador") || UsuarioActual.TieneRol("Encargado") || UsuarioActual.TieneRol("SuperAdministrador"))
            {
                ventanaIngresoDeProductos = new IngresoProductos(UsuarioActual.UsuarioId);
                AbrirTab(ventanaIngresoDeProductos);
            }
            else
            {
                using (var loginForm = new frmLogin(new List<string>() { "Encargado", "Administrador", "SuperAdministrador" }))
                {
                    var loginResult = loginForm.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        ventanaIngresoDeProductos = new IngresoProductos(UsuarioActual.UsuarioTemporalId);
                        AbrirTab(ventanaIngresoDeProductos);
                    }
                }
            }

        }

        private void tsbVentas_Click(object sender, EventArgs e)
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto)
            {
                var ventanaVentas = new Ventas.Ventas();
                AbrirTab(ventanaVentas);
            }
            else
                MessageBox.Show("Debe abrir una caja primero.");
        }

        private void tsmGestionDeMarcas_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmGestionMarcas());
        }

        private void tsmGestionDeRubros_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmGestionRubros());
        }

        private void tsmExcepciones_Click(object sender, EventArgs e)
        {
            var ventanaExcepciones = new frmGestionExcepciones();
            AbrirTab(ventanaExcepciones);
        }

        private void gesiónDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaGestionDeFacturas = new FrmGestionFacturas();
            AbrirTab(ventanaGestionDeFacturas);
        }

        private void tsbArticulos_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmProductos());
        }

        private void tsmiDetalleCompleto_Click(object sender, EventArgs e)
        {
            var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador" });
            if (user != 0)
            {
                var ventanaDetalleCompleto = new CierreCajaDetalleCompleto();
                AbrirTab(ventanaDetalleCompleto);
            }
        }

        private void gestionDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador" });
            if (user != 0)
            {
                AbrirTab(new frmGestionCorreccionStock());
            }
        }

        #region Sincronizacion
        
        private void actualizarDesdeArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sincronizacionManager.ActualizarKioscoDesdeArchivo(openFileDialogSincronizacion);
        }

        private void exportarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmExportar().ShowDialog();
        }

        #endregion

        private void tsmGestionDeArticulos_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmProductos());
        }

        private void tsmCambiarContraseña_Click(object sender, EventArgs e)
        {
            var dialog = new frmCambiarPassword();
            dialog.ShowDialog();
        }

        private void tsmSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto)
            {
                var confirmation = new ConfirmationForm(Resources.CerrarSesionConfirmacionCajaAbirta,
                                                        Resources.TextoAceptar, Resources.TextoCancelar);

                if (confirmation.ShowDialog() == DialogResult.OK)
                {
                    var cerrarCajaForm = new CerrarCaja(controlarMargenes: true);
                    if (cerrarCajaForm.ShowDialog() == DialogResult.OK)
                    {
                        CerrarTodosLosTabs();
                        EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
                        ControlarCierreCaja();
                        ToggleAccionesRelacionadasACierreDeCaja();


                        MembershipProvider.Logoff();
                        ToggleLoginItems();

                        AbrirTab(new CierreCajaDetalle(cerrarCajaForm.CierreCajaId));
                    }
                }
            }
            else
            {
                Logoff();
            }
            this.Text = this.Tag.ToString();
        }

        private void Logoff()
        {
            MembershipProvider.Logoff();
            ToggleLoginItems();
            CerrarTodosLosTabs();
        }

        private void CerrarTodosLosTabs()
        {
            foreach (var frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void ToggleLoginItems()
        {
            //Items laterales
            tsbCaja.Enabled = UsuarioActual.EstaAutenticado;
            tsbArticulos.Enabled = UsuarioActual.EstaAutenticado;
            tsbVentas.Enabled = UsuarioActual.EstaAutenticado;
            tsbControlStock.Enabled = UsuarioActual.EstaAutenticado;

            //Items menu superior
            ToggleHabilitarMenuItems(menuStrip.Items);

            //toggle iniciar secion/cerrar sesion
            tsmiAbrirCaja.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Cerrado;
            tsmiCerrarCaja.Enabled = EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Abierto;
            tsmIniciarSesion.Enabled = !UsuarioActual.EstaAutenticado;
            tsmCerrarSesion.Enabled = UsuarioActual.EstaAutenticado;
            tssUsuario.Text = UsuarioActual.Usuario != null
                                  ? String.Format("   |   Usuario: {0}", UsuarioActual.Usuario.NombreUsuario)
                                  : string.Empty;
        }

        private void ToggleHabilitarMenuItems(ToolStripItemCollection items)
        {
            foreach (object item in items)
            {
                var subItem = item as ToolStripMenuItem;
                if (subItem != null)
                {
                    if (subItem.HasDropDownItems)
                    {
                        subItem.Enabled = IsItemEnabled(subItem);
                        ToggleHabilitarMenuItems(subItem.DropDownItems);
                    }
                    else
                    {
                        subItem.Enabled = IsItemEnabled(subItem);
                    }
                }
            }
        }

        private bool IsItemEnabled(ToolStripMenuItem item)
        {
            return (item.Tag != null && item.Tag.ToString() == "Anonimo") ||
                                          UsuarioActual.EstaAutenticado;
        }

        private void tsmIniciarSesion_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void tsmConfiguracion_Click(object sender, EventArgs e)
        {
            new frmConfiguracion().ShowDialog();
        }

        private void reconectarForzarSincronizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_sincronizacionManager.IsConnected)
            {
                _sincronizacionManager.PingServer();
            }
            else
            {
                MessageBox.Show(Resources.ForzarSincronizacionConeccionEstablecida);
            }

            ToggleForzarSincronizacionEstado();
        }

        private void tsmReportarError_Click(object sender, EventArgs e)
        {
            new frmReportarError().ShowDialog();
        }

        private void tsmControlStock_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmControlStock());
        }

        private void tsbControlStock_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmControlStock());
        }

        private void mdiPrincipal_Resize(object sender, EventArgs e)
        {
            //Cierro el popup de busqueda de ventas cuando minimizo la aplicacion
            if (WindowState == FormWindowState.Minimized)
            {
                foreach (var frm in this.MdiChildren)
                {
                    if (frm.Name == "Ventas" && frm.OwnedForms.Any())
                        frm.OwnedForms.First().Close();
                }
            }
        }

        private void tsbReposicionStock_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmReponerStock());
        }

        private void sincronizacionSecuencialStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
            if (user != 0)
            {
                var confirmation = new ConfirmationForm(Resources.SincronizacionConfimacion,
                                     Resources.TextoAceptar, Resources.TextoCancelar);

                if (confirmation.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _sincronizacionManager.SincronizacionSecuencial();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.SincronizacionError, Resources.SincronizacionTitulo);
                    }
                }
            }
        }

        private void tsmSegundoPlano_Click(object sender, EventArgs e)
        {
            _sincronizacionManager.SincronizarEnSegundoPlano(this, bgWorker, tssProgreso);
        }

        private void tsbAcercaDe_Click(object sender, EventArgs e)
        {
            var about = new abxAcercaDe();
            about.Show();
        }

        private void tsmCostos_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmCostos());
        }

        private void tsmRetiroPersonal_Click(object sender, EventArgs e)
        {
            AbrirTab(new frmRetirosPersonales(this));
        }
    }
}
