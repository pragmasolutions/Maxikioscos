namespace MaxiKioscos.Winforms.Principal
{
    partial class mdiPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCambiarContraseña = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReportarError = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbrirCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarCaja = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExcepciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetalleCompleto = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGestionDeArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGestionDeMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGestionDeRubros = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gestionDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControlStock = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGestionDeMercaderias = new System.Windows.Forms.ToolStripMenuItem();
            this.gesiónDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGestionProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGastos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRetiroPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbReposicionStock = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSugerenciaCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSegundoPlano = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exportarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconectarForzarSincronizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssConeccionForzarSincronizacion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUltimaSyncExitosa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProgreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogSincronizacion = new System.Windows.Forms.OpenFileDialog();
            this.tsbCaja = new System.Windows.Forms.ToolStripButton();
            this.tsbArticulos = new System.Windows.Forms.ToolStripButton();
            this.tsbVentas = new System.Windows.Forms.ToolStripButton();
            this.tspAccesosDirectos = new System.Windows.Forms.ToolStrip();
            this.tsbControlStock = new System.Windows.Forms.ToolStripButton();
            this.tsbTransferencias = new System.Windows.Forms.ToolStripButton();
            this.mdiTabStrip2 = new MdiTabStrip.MdiTabStrip();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.printer = new AxEPSON_Impresora_Fiscal.AxPrinterFiscal();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tspAccesosDirectos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdiTabStrip2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSistema,
            this.tsmCaja,
            this.articulosToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.tsmGastos,
            this.tsmRetiroPersonal,
            this.reportesToolStripMenuItem,
            this.sincronizaciónToolStripMenuItem,
            this.afipToolStripMenuItem,
            this.tsbAcercaDe});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1124, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmSistema
            // 
            this.tsmSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIniciarSesion,
            this.tsmCerrarSesion,
            this.toolStripSeparator1,
            this.tsmConfiguracion,
            this.tsmCambiarContraseña,
            this.toolStripSeparator2,
            this.tsmReportarError,
            this.tsmSalir});
            this.tsmSistema.Name = "tsmSistema";
            this.tsmSistema.Size = new System.Drawing.Size(73, 24);
            this.tsmSistema.Tag = "Anonimo";
            this.tsmSistema.Text = "Sistema";
            // 
            // tsmIniciarSesion
            // 
            this.tsmIniciarSesion.Name = "tsmIniciarSesion";
            this.tsmIniciarSesion.Size = new System.Drawing.Size(216, 26);
            this.tsmIniciarSesion.Tag = "Anonimo";
            this.tsmIniciarSesion.Text = "Iniciar Sesión";
            this.tsmIniciarSesion.Click += new System.EventHandler(this.tsmIniciarSesion_Click);
            // 
            // tsmCerrarSesion
            // 
            this.tsmCerrarSesion.Name = "tsmCerrarSesion";
            this.tsmCerrarSesion.Size = new System.Drawing.Size(216, 26);
            this.tsmCerrarSesion.Text = "Cerrar Sesión";
            this.tsmCerrarSesion.Click += new System.EventHandler(this.tsmCerrarSesion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // tsmConfiguracion
            // 
            this.tsmConfiguracion.Name = "tsmConfiguracion";
            this.tsmConfiguracion.Size = new System.Drawing.Size(216, 26);
            this.tsmConfiguracion.Text = "Configuracion";
            this.tsmConfiguracion.Click += new System.EventHandler(this.tsmConfiguracion_Click);
            // 
            // tsmCambiarContraseña
            // 
            this.tsmCambiarContraseña.Name = "tsmCambiarContraseña";
            this.tsmCambiarContraseña.Size = new System.Drawing.Size(216, 26);
            this.tsmCambiarContraseña.Text = "Cambiar contraseña";
            this.tsmCambiarContraseña.Click += new System.EventHandler(this.tsmCambiarContraseña_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // tsmReportarError
            // 
            this.tsmReportarError.Name = "tsmReportarError";
            this.tsmReportarError.Size = new System.Drawing.Size(216, 26);
            this.tsmReportarError.Text = "Reportar error";
            this.tsmReportarError.Visible = false;
            this.tsmReportarError.Click += new System.EventHandler(this.tsmReportarError_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(216, 26);
            this.tsmSalir.Tag = "Anonimo";
            this.tsmSalir.Text = "Salir";
            this.tsmSalir.Click += new System.EventHandler(this.tsmSalir_Click);
            // 
            // tsmCaja
            // 
            this.tsmCaja.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbrirCaja,
            this.tsmiCerrarCaja,
            this.toolStripSeparator6,
            this.tsmExcepciones,
            this.tsmiDetalleCompleto});
            this.tsmCaja.Name = "tsmCaja";
            this.tsmCaja.Size = new System.Drawing.Size(50, 24);
            this.tsmCaja.Text = "Caja";
            // 
            // tsmiAbrirCaja
            // 
            this.tsmiAbrirCaja.Name = "tsmiAbrirCaja";
            this.tsmiAbrirCaja.Size = new System.Drawing.Size(202, 26);
            this.tsmiAbrirCaja.Text = "Abrir Caja";
            this.tsmiAbrirCaja.Click += new System.EventHandler(this.tsmiAbrirCaja_Click);
            // 
            // tsmiCerrarCaja
            // 
            this.tsmiCerrarCaja.Name = "tsmiCerrarCaja";
            this.tsmiCerrarCaja.Size = new System.Drawing.Size(202, 26);
            this.tsmiCerrarCaja.Text = "Cerrar Caja";
            this.tsmiCerrarCaja.Click += new System.EventHandler(this.tsmiCerrarCaja_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmExcepciones
            // 
            this.tsmExcepciones.Name = "tsmExcepciones";
            this.tsmExcepciones.Size = new System.Drawing.Size(202, 26);
            this.tsmExcepciones.Text = "Excepciones";
            this.tsmExcepciones.Visible = false;
            this.tsmExcepciones.Click += new System.EventHandler(this.tsmExcepciones_Click);
            // 
            // tsmiDetalleCompleto
            // 
            this.tsmiDetalleCompleto.Name = "tsmiDetalleCompleto";
            this.tsmiDetalleCompleto.Size = new System.Drawing.Size(202, 26);
            this.tsmiDetalleCompleto.Text = "Detalle Completo";
            this.tsmiDetalleCompleto.Click += new System.EventHandler(this.tsmiDetalleCompleto_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGestionDeArticulos,
            this.toolStripSeparator5,
            this.tsmGestionDeMarcas,
            this.tsmGestionDeRubros,
            this.toolStripSeparator4,
            this.gestionDeToolStripMenuItem,
            this.tsmControlStock});
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.articulosToolStripMenuItem.Text = "Articulos";
            // 
            // tsmGestionDeArticulos
            // 
            this.tsmGestionDeArticulos.Name = "tsmGestionDeArticulos";
            this.tsmGestionDeArticulos.Size = new System.Drawing.Size(224, 26);
            this.tsmGestionDeArticulos.Text = "Gestión de Articulos";
            this.tsmGestionDeArticulos.Click += new System.EventHandler(this.tsmGestionDeArticulos_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmGestionDeMarcas
            // 
            this.tsmGestionDeMarcas.Name = "tsmGestionDeMarcas";
            this.tsmGestionDeMarcas.Size = new System.Drawing.Size(224, 26);
            this.tsmGestionDeMarcas.Text = "Gestión de Marcas";
            this.tsmGestionDeMarcas.Click += new System.EventHandler(this.tsmGestionDeMarcas_Click);
            // 
            // tsmGestionDeRubros
            // 
            this.tsmGestionDeRubros.Name = "tsmGestionDeRubros";
            this.tsmGestionDeRubros.Size = new System.Drawing.Size(224, 26);
            this.tsmGestionDeRubros.Text = "Gestión de Rubros";
            this.tsmGestionDeRubros.Click += new System.EventHandler(this.tsmGestionDeRubros_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // gestionDeToolStripMenuItem
            // 
            this.gestionDeToolStripMenuItem.Name = "gestionDeToolStripMenuItem";
            this.gestionDeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionDeToolStripMenuItem.Text = "Retiro de Mercadería";
            this.gestionDeToolStripMenuItem.Click += new System.EventHandler(this.gestionDeToolStripMenuItem_Click);
            // 
            // tsmControlStock
            // 
            this.tsmControlStock.Name = "tsmControlStock";
            this.tsmControlStock.Size = new System.Drawing.Size(224, 26);
            this.tsmControlStock.Text = "Control de Stock";
            this.tsmControlStock.Click += new System.EventHandler(this.tsmControlStock_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGestionDeMercaderias,
            this.gesiónDeFacturasToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // tsmGestionDeMercaderias
            // 
            this.tsmGestionDeMercaderias.Name = "tsmGestionDeMercaderias";
            this.tsmGestionDeMercaderias.Size = new System.Drawing.Size(233, 26);
            this.tsmGestionDeMercaderias.Text = "Ingreso de Mercadería";
            this.tsmGestionDeMercaderias.Click += new System.EventHandler(this.tsmGestionDeMercaderias_Click);
            // 
            // gesiónDeFacturasToolStripMenuItem
            // 
            this.gesiónDeFacturasToolStripMenuItem.Name = "gesiónDeFacturasToolStripMenuItem";
            this.gesiónDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.gesiónDeFacturasToolStripMenuItem.Text = "Gestión de Facturas";
            this.gesiónDeFacturasToolStripMenuItem.Click += new System.EventHandler(this.gesiónDeFacturasToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGestionProveedores});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // tsmiGestionProveedores
            // 
            this.tsmiGestionProveedores.Name = "tsmiGestionProveedores";
            this.tsmiGestionProveedores.Size = new System.Drawing.Size(241, 26);
            this.tsmiGestionProveedores.Text = "Gestión de Proveedores";
            this.tsmiGestionProveedores.Click += new System.EventHandler(this.gestionDeProveedoresToolStripMenuItem_Click);
            // 
            // tsmGastos
            // 
            this.tsmGastos.Name = "tsmGastos";
            this.tsmGastos.Size = new System.Drawing.Size(65, 24);
            this.tsmGastos.Text = "Gastos";
            this.tsmGastos.Click += new System.EventHandler(this.tsmCostos_Click);
            // 
            // tsmRetiroPersonal
            // 
            this.tsmRetiroPersonal.Name = "tsmRetiroPersonal";
            this.tsmRetiroPersonal.Size = new System.Drawing.Size(120, 24);
            this.tsmRetiroPersonal.Text = "Retiro Personal";
            this.tsmRetiroPersonal.Click += new System.EventHandler(this.tsmRetiroPersonal_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReposicionStock,
            this.txtSugerenciaCompras});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tsbReposicionStock
            // 
            this.tsbReposicionStock.Name = "tsbReposicionStock";
            this.tsbReposicionStock.Size = new System.Drawing.Size(241, 26);
            this.tsbReposicionStock.Text = "Reposición de Stock";
            this.tsbReposicionStock.Click += new System.EventHandler(this.tsbReposicionStock_Click);
            // 
            // txtSugerenciaCompras
            // 
            this.txtSugerenciaCompras.Name = "txtSugerenciaCompras";
            this.txtSugerenciaCompras.Size = new System.Drawing.Size(241, 26);
            this.txtSugerenciaCompras.Text = "Sugerencia de Compras";
            this.txtSugerenciaCompras.Click += new System.EventHandler(this.txtSugerenciaCompras_Click);
            // 
            // sincronizaciónToolStripMenuItem
            // 
            this.sincronizaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSegundoPlano,
            this.toolStripSeparator7,
            this.exportarDatosToolStripMenuItem,
            this.reconectarForzarSincronizaciónToolStripMenuItem});
            this.sincronizaciónToolStripMenuItem.Name = "sincronizaciónToolStripMenuItem";
            this.sincronizaciónToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.sincronizaciónToolStripMenuItem.Text = "Sincronización";
            // 
            // tsmSegundoPlano
            // 
            this.tsmSegundoPlano.Name = "tsmSegundoPlano";
            this.tsmSegundoPlano.Size = new System.Drawing.Size(303, 26);
            this.tsmSegundoPlano.Text = "Sincronizar desde Web";
            this.tsmSegundoPlano.Click += new System.EventHandler(this.tsmSegundoPlano_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(300, 6);
            // 
            // exportarDatosToolStripMenuItem
            // 
            this.exportarDatosToolStripMenuItem.Name = "exportarDatosToolStripMenuItem";
            this.exportarDatosToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.exportarDatosToolStripMenuItem.Text = "Exportar datos...";
            // 
            // reconectarForzarSincronizaciónToolStripMenuItem
            // 
            this.reconectarForzarSincronizaciónToolStripMenuItem.Name = "reconectarForzarSincronizaciónToolStripMenuItem";
            this.reconectarForzarSincronizaciónToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.reconectarForzarSincronizaciónToolStripMenuItem.Text = "Reconectar Forzar Sincronización";
            this.reconectarForzarSincronizaciónToolStripMenuItem.Click += new System.EventHandler(this.reconectarForzarSincronizaciónToolStripMenuItem_Click);
            // 
            // afipToolStripMenuItem
            // 
            this.afipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cierreZToolStripMenuItem,
            this.cierreXToolStripMenuItem});
            this.afipToolStripMenuItem.Name = "afipToolStripMenuItem";
            this.afipToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.afipToolStripMenuItem.Text = "Afip";
            // 
            // cierreZToolStripMenuItem
            // 
            this.cierreZToolStripMenuItem.Name = "cierreZToolStripMenuItem";
            this.cierreZToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cierreZToolStripMenuItem.Text = "Cierre Z";
            this.cierreZToolStripMenuItem.Click += new System.EventHandler(this.tsmCierreZ_Click);
            // 
            // cierreXToolStripMenuItem
            // 
            this.cierreXToolStripMenuItem.Name = "cierreXToolStripMenuItem";
            this.cierreXToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.cierreXToolStripMenuItem.Text = "Cierre X";
            this.cierreXToolStripMenuItem.Click += new System.EventHandler(this.cierreXToolStripMenuItem_Click);
            // 
            // tsbAcercaDe
            // 
            this.tsbAcercaDe.Name = "tsbAcercaDe";
            this.tsbAcercaDe.Size = new System.Drawing.Size(96, 24);
            this.tsbAcercaDe.Text = "Acerca de...";
            this.tsbAcercaDe.Click += new System.EventHandler(this.tsbAcercaDe_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado,
            this.tssConeccionForzarSincronizacion,
            this.tssUsuario,
            this.tssUltimaSyncExitosa,
            this.tssProgreso});
            this.statusStrip.Location = new System.Drawing.Point(0, 541);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1124, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tssEstado
            // 
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(0, 20);
            // 
            // tssConeccionForzarSincronizacion
            // 
            this.tssConeccionForzarSincronizacion.Name = "tssConeccionForzarSincronizacion";
            this.tssConeccionForzarSincronizacion.Size = new System.Drawing.Size(0, 20);
            this.tssConeccionForzarSincronizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tssUsuario
            // 
            this.tssUsuario.Name = "tssUsuario";
            this.tssUsuario.Size = new System.Drawing.Size(59, 20);
            this.tssUsuario.Text = "Usuario";
            // 
            // tssUltimaSyncExitosa
            // 
            this.tssUltimaSyncExitosa.Name = "tssUltimaSyncExitosa";
            this.tssUltimaSyncExitosa.Size = new System.Drawing.Size(0, 20);
            // 
            // tssProgreso
            // 
            this.tssProgreso.Name = "tssProgreso";
            this.tssProgreso.Size = new System.Drawing.Size(1045, 20);
            this.tssProgreso.Spring = true;
            this.tssProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialogSincronizacion
            // 
            this.openFileDialogSincronizacion.FileName = "openFileDialog1";
            this.openFileDialogSincronizacion.Filter = "ZIP Files |*.zip";
            // 
            // tsbCaja
            // 
            this.tsbCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbCaja.Image = ((System.Drawing.Image)(resources.GetObject("tsbCaja.Image")));
            this.tsbCaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCaja.Margin = new System.Windows.Forms.Padding(0, 34, 0, 2);
            this.tsbCaja.Name = "tsbCaja";
            this.tsbCaja.Padding = new System.Windows.Forms.Padding(5);
            this.tsbCaja.Size = new System.Drawing.Size(141, 79);
            this.tsbCaja.Text = "CAJA";
            this.tsbCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCaja.ToolTipText = "Presione F3";
            this.tsbCaja.Click += new System.EventHandler(this.tsbCaja_Click);
            // 
            // tsbArticulos
            // 
            this.tsbArticulos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbArticulos.Image = ((System.Drawing.Image)(resources.GetObject("tsbArticulos.Image")));
            this.tsbArticulos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbArticulos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArticulos.Name = "tsbArticulos";
            this.tsbArticulos.Padding = new System.Windows.Forms.Padding(5);
            this.tsbArticulos.Size = new System.Drawing.Size(141, 79);
            this.tsbArticulos.Text = "PRODUCTOS";
            this.tsbArticulos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbArticulos.ToolTipText = "Presione (F1)";
            this.tsbArticulos.Click += new System.EventHandler(this.tsbArticulos_Click);
            // 
            // tsbVentas
            // 
            this.tsbVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbVentas.Image = ((System.Drawing.Image)(resources.GetObject("tsbVentas.Image")));
            this.tsbVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVentas.Name = "tsbVentas";
            this.tsbVentas.Padding = new System.Windows.Forms.Padding(5);
            this.tsbVentas.Size = new System.Drawing.Size(141, 79);
            this.tsbVentas.Text = "VENTAS";
            this.tsbVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVentas.ToolTipText = "Presione F2";
            this.tsbVentas.Click += new System.EventHandler(this.tsbVentas_Click);
            // 
            // tspAccesosDirectos
            // 
            this.tspAccesosDirectos.AllowMerge = false;
            this.tspAccesosDirectos.Dock = System.Windows.Forms.DockStyle.Left;
            this.tspAccesosDirectos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspAccesosDirectos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspAccesosDirectos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tspAccesosDirectos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCaja,
            this.tsbArticulos,
            this.tsbVentas,
            this.tsbControlStock,
            this.tsbTransferencias});
            this.tspAccesosDirectos.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tspAccesosDirectos.Location = new System.Drawing.Point(0, 28);
            this.tspAccesosDirectos.Name = "tspAccesosDirectos";
            this.tspAccesosDirectos.Size = new System.Drawing.Size(144, 513);
            this.tspAccesosDirectos.TabIndex = 4;
            this.tspAccesosDirectos.Text = "toolStrip1";
            // 
            // tsbControlStock
            // 
            this.tsbControlStock.Image = ((System.Drawing.Image)(resources.GetObject("tsbControlStock.Image")));
            this.tsbControlStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbControlStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbControlStock.Name = "tsbControlStock";
            this.tsbControlStock.Padding = new System.Windows.Forms.Padding(5);
            this.tsbControlStock.Size = new System.Drawing.Size(141, 79);
            this.tsbControlStock.Text = "CONTROL STOCK";
            this.tsbControlStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbControlStock.Click += new System.EventHandler(this.tsbControlStock_Click);
            // 
            // tsbTransferencias
            // 
            this.tsbTransferencias.Image = ((System.Drawing.Image)(resources.GetObject("tsbTransferencias.Image")));
            this.tsbTransferencias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTransferencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransferencias.Name = "tsbTransferencias";
            this.tsbTransferencias.Padding = new System.Windows.Forms.Padding(5);
            this.tsbTransferencias.Size = new System.Drawing.Size(141, 79);
            this.tsbTransferencias.Text = "TRANSFERENCIAS";
            this.tsbTransferencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTransferencias.Click += new System.EventHandler(this.tsbTransferencias_Click);
            // 
            // mdiTabStrip2
            // 
            this.mdiTabStrip2.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdiTabStrip2.AllowDrop = true;
            this.mdiTabStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.mdiTabStrip2.InactiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdiTabStrip2.Location = new System.Drawing.Point(144, 28);
            this.mdiTabStrip2.Margin = new System.Windows.Forms.Padding(4);
            this.mdiTabStrip2.MdiNewTabImage = null;
            this.mdiTabStrip2.MinimumSize = new System.Drawing.Size(67, 41);
            this.mdiTabStrip2.MouseOverTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdiTabStrip2.Name = "mdiTabStrip2";
            this.mdiTabStrip2.NewTabToolTipText = "New Tab";
            this.mdiTabStrip2.Padding = new System.Windows.Forms.Padding(7, 4, 27, 6);
            this.mdiTabStrip2.Size = new System.Drawing.Size(980, 43);
            this.mdiTabStrip2.TabIndex = 8;
            this.mdiTabStrip2.TabPermanence = MdiTabStrip.MdiTabPermanence.LastOpen;
            this.mdiTabStrip2.Text = "mdiTabStrip2";
            // 
            // printer
            // 
            this.printer.Enabled = true;
            this.printer.Location = new System.Drawing.Point(26, 373);
            this.printer.Margin = new System.Windows.Forms.Padding(4);
            this.printer.Name = "printer";
            this.printer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("printer.OcxState")));
            this.printer.Size = new System.Drawing.Size(40, 40);
            this.printer.TabIndex = 10;
            // 
            // mdiPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 566);
            this.Controls.Add(this.printer);
            this.Controls.Add(this.mdiTabStrip2);
            this.Controls.Add(this.tspAccesosDirectos);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mdiPrincipal";
            this.Tag = "SISTEMA DE GESTION";
            this.Text = "SISTEMA DE GESTION";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiPrincipal_Load);
            this.Resize += new System.EventHandler(this.mdiPrincipal_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tspAccesosDirectos.ResumeLayout(false);
            this.tspAccesosDirectos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdiTabStrip2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem tsmSistema;
        private System.Windows.Forms.ToolStripMenuItem tsmIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmCerrarSesion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmCambiarContraseña;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGestionDeArticulos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmGestionDeMarcas;
        private System.Windows.Forms.ToolStripMenuItem tsmGestionDeRubros;
        private System.Windows.Forms.ToolStripMenuItem tsmGestionDeMercaderias;
        private MdiTabStrip.MdiTabStrip mdiTabStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbrirCaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarCaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiGestionProveedores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmExcepciones;
        private System.Windows.Forms.ToolStripMenuItem gesiónDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetalleCompleto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem gestionDeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogSincronizacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem exportarDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmConfiguracion;
        private System.Windows.Forms.ToolStripStatusLabel tssConeccionForzarSincronizacion;
        private System.Windows.Forms.ToolStripMenuItem reconectarForzarSincronizaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbCaja;
        private System.Windows.Forms.ToolStripButton tsbArticulos;
        private System.Windows.Forms.ToolStripButton tsbVentas;
        private System.Windows.Forms.ToolStrip tspAccesosDirectos;
        private MdiTabStrip.MdiTabStrip mdiTabStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmReportarError;
        private System.Windows.Forms.ToolStripMenuItem tsmControlStock;
        private System.Windows.Forms.ToolStripButton tsbControlStock;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsbReposicionStock;
        private System.Windows.Forms.ToolStripStatusLabel tssUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tssProgreso;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ToolStripMenuItem tsmSegundoPlano;
        private System.Windows.Forms.ToolStripMenuItem tsbAcercaDe;
        private System.Windows.Forms.ToolStripStatusLabel tssUltimaSyncExitosa;
        private System.Windows.Forms.ToolStripMenuItem tsmRetiroPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmGastos;
        private System.Windows.Forms.ToolStripButton tsbTransferencias;
        private System.Windows.Forms.ToolStripMenuItem txtSugerenciaCompras;
        private System.Windows.Forms.ToolStripMenuItem afipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cierreZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cierreXToolStripMenuItem;
        private AxEPSON_Impresora_Fiscal.AxPrinterFiscal printer;
    }
}



