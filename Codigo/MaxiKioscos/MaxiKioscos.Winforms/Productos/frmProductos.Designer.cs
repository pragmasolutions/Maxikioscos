namespace MaxiKioscos.Winforms.Productos
{
    partial class frmProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCantidadFilas = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosListadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioConIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costosResumenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimaModificacionCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimaCompraCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedoresListadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costosListadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaUltimaCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimoCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockReposicionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cuentaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.precioSinIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosProductosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventaProductosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprasProductosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correccionStocksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorProductosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductoEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductoEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlProveedor = new Util.Controles.ucDropDownList();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCantidadFilas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssCantidadFilas
            // 
            this.tssCantidadFilas.Name = "tssCantidadFilas";
            this.tssCantidadFilas.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListado, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeight = 31;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoIdDataGridViewTextBoxColumn,
            this.codigosListadoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.marcaStringDataGridViewTextBoxColumn,
            this.precioConIVADataGridViewTextBoxColumn,
            this.costosResumenDataGridViewTextBoxColumn,
            this.ultimaModificacionCostoDataGridViewTextBoxColumn,
            this.ultimaCompraCostoDataGridViewTextBoxColumn,
            this.rubroStringDataGridViewTextBoxColumn,
            this.proveedoresListadoDataGridViewTextBoxColumn,
            this.costosListadoDataGridViewTextBoxColumn,
            this.fechaUltimaCompraDataGridViewTextBoxColumn,
            this.costosDataGridViewTextBoxColumn,
            this.ultimoCostoDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.rubroIdDataGridViewTextBoxColumn,
            this.marcaIdDataGridViewTextBoxColumn,
            this.stockReposicionDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.cuentaIdDataGridViewTextBoxColumn,
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn,
            this.precioSinIVADataGridViewTextBoxColumn,
            this.codigosProductosDataGridViewTextBoxColumn,
            this.cuentaDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.rubroDataGridViewTextBoxColumn,
            this.ventaProductosDataGridViewTextBoxColumn,
            this.stocksDataGridViewTextBoxColumn,
            this.comprasProductosDataGridViewTextBoxColumn,
            this.correccionStocksDataGridViewTextBoxColumn,
            this.proveedorProductosDataGridViewTextBoxColumn,
            this.ProductoDetalle,
            this.ProductoEditar,
            this.ProductoEliminar});
            this.dgvListado.DataSource = this.productoBindingSource;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(3, 121);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(896, 411);
            this.dgvListado.TabIndex = 7;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentDoubleClick);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            this.productoIdDataGridViewTextBoxColumn.Width = 94;
            // 
            // codigosListadoDataGridViewTextBoxColumn
            // 
            this.codigosListadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigosListadoDataGridViewTextBoxColumn.DataPropertyName = "CodigosListado";
            this.codigosListadoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigosListadoDataGridViewTextBoxColumn.Name = "codigosListadoDataGridViewTextBoxColumn";
            this.codigosListadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigosListadoDataGridViewTextBoxColumn.Width = 110;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marcaStringDataGridViewTextBoxColumn
            // 
            this.marcaStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.marcaStringDataGridViewTextBoxColumn.DataPropertyName = "MarcaString";
            this.marcaStringDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaStringDataGridViewTextBoxColumn.Name = "marcaStringDataGridViewTextBoxColumn";
            this.marcaStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaStringDataGridViewTextBoxColumn.Width = 120;
            // 
            // precioConIVADataGridViewTextBoxColumn
            // 
            this.precioConIVADataGridViewTextBoxColumn.DataPropertyName = "PrecioConIVA";
            this.precioConIVADataGridViewTextBoxColumn.HeaderText = "Precio con IVA";
            this.precioConIVADataGridViewTextBoxColumn.Name = "precioConIVADataGridViewTextBoxColumn";
            this.precioConIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.precioConIVADataGridViewTextBoxColumn.Width = 114;
            // 
            // costosResumenDataGridViewTextBoxColumn
            // 
            this.costosResumenDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costosResumenDataGridViewTextBoxColumn.DataPropertyName = "CostosResumen";
            this.costosResumenDataGridViewTextBoxColumn.HeaderText = "Costos";
            this.costosResumenDataGridViewTextBoxColumn.Name = "costosResumenDataGridViewTextBoxColumn";
            this.costosResumenDataGridViewTextBoxColumn.ReadOnly = true;
            this.costosResumenDataGridViewTextBoxColumn.Width = 140;
            // 
            // ultimaModificacionCostoDataGridViewTextBoxColumn
            // 
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.DataPropertyName = "UltimaModificacionCosto";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.HeaderText = "Modificación Costo";
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.Name = "ultimaModificacionCostoDataGridViewTextBoxColumn";
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ultimaModificacionCostoDataGridViewTextBoxColumn.Width = 135;
            // 
            // ultimaCompraCostoDataGridViewTextBoxColumn
            // 
            this.ultimaCompraCostoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ultimaCompraCostoDataGridViewTextBoxColumn.DataPropertyName = "UltimaCompraCosto";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.ultimaCompraCostoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.ultimaCompraCostoDataGridViewTextBoxColumn.HeaderText = "Ultima Compra";
            this.ultimaCompraCostoDataGridViewTextBoxColumn.Name = "ultimaCompraCostoDataGridViewTextBoxColumn";
            this.ultimaCompraCostoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rubroStringDataGridViewTextBoxColumn
            // 
            this.rubroStringDataGridViewTextBoxColumn.DataPropertyName = "RubroString";
            this.rubroStringDataGridViewTextBoxColumn.HeaderText = "RubroString";
            this.rubroStringDataGridViewTextBoxColumn.Name = "rubroStringDataGridViewTextBoxColumn";
            this.rubroStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.rubroStringDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedoresListadoDataGridViewTextBoxColumn
            // 
            this.proveedoresListadoDataGridViewTextBoxColumn.DataPropertyName = "ProveedoresListado";
            this.proveedoresListadoDataGridViewTextBoxColumn.HeaderText = "ProveedoresListado";
            this.proveedoresListadoDataGridViewTextBoxColumn.Name = "proveedoresListadoDataGridViewTextBoxColumn";
            this.proveedoresListadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedoresListadoDataGridViewTextBoxColumn.Visible = false;
            this.proveedoresListadoDataGridViewTextBoxColumn.Width = 143;
            // 
            // costosListadoDataGridViewTextBoxColumn
            // 
            this.costosListadoDataGridViewTextBoxColumn.DataPropertyName = "CostosListado";
            this.costosListadoDataGridViewTextBoxColumn.HeaderText = "CostosListado";
            this.costosListadoDataGridViewTextBoxColumn.Name = "costosListadoDataGridViewTextBoxColumn";
            this.costosListadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costosListadoDataGridViewTextBoxColumn.Visible = false;
            this.costosListadoDataGridViewTextBoxColumn.Width = 112;
            // 
            // fechaUltimaCompraDataGridViewTextBoxColumn
            // 
            this.fechaUltimaCompraDataGridViewTextBoxColumn.DataPropertyName = "FechaUltimaCompra";
            this.fechaUltimaCompraDataGridViewTextBoxColumn.HeaderText = "FechaUltimaCompra";
            this.fechaUltimaCompraDataGridViewTextBoxColumn.Name = "fechaUltimaCompraDataGridViewTextBoxColumn";
            this.fechaUltimaCompraDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaCompraDataGridViewTextBoxColumn.Visible = false;
            this.fechaUltimaCompraDataGridViewTextBoxColumn.Width = 151;
            // 
            // costosDataGridViewTextBoxColumn
            // 
            this.costosDataGridViewTextBoxColumn.DataPropertyName = "Costos";
            this.costosDataGridViewTextBoxColumn.HeaderText = "Costos";
            this.costosDataGridViewTextBoxColumn.Name = "costosDataGridViewTextBoxColumn";
            this.costosDataGridViewTextBoxColumn.ReadOnly = true;
            this.costosDataGridViewTextBoxColumn.Visible = false;
            this.costosDataGridViewTextBoxColumn.Width = 72;
            // 
            // ultimoCostoDataGridViewTextBoxColumn
            // 
            this.ultimoCostoDataGridViewTextBoxColumn.DataPropertyName = "UltimoCosto";
            this.ultimoCostoDataGridViewTextBoxColumn.HeaderText = "UltimoCosto";
            this.ultimoCostoDataGridViewTextBoxColumn.Name = "ultimoCostoDataGridViewTextBoxColumn";
            this.ultimoCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ultimoCostoDataGridViewTextBoxColumn.Visible = false;
            this.ultimoCostoDataGridViewTextBoxColumn.Width = 102;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            this.identifierDataGridViewTextBoxColumn.Width = 81;
            // 
            // rubroIdDataGridViewTextBoxColumn
            // 
            this.rubroIdDataGridViewTextBoxColumn.DataPropertyName = "RubroId";
            this.rubroIdDataGridViewTextBoxColumn.HeaderText = "RubroId";
            this.rubroIdDataGridViewTextBoxColumn.Name = "rubroIdDataGridViewTextBoxColumn";
            this.rubroIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.rubroIdDataGridViewTextBoxColumn.Visible = false;
            this.rubroIdDataGridViewTextBoxColumn.Width = 78;
            // 
            // marcaIdDataGridViewTextBoxColumn
            // 
            this.marcaIdDataGridViewTextBoxColumn.DataPropertyName = "MarcaId";
            this.marcaIdDataGridViewTextBoxColumn.HeaderText = "MarcaId";
            this.marcaIdDataGridViewTextBoxColumn.Name = "marcaIdDataGridViewTextBoxColumn";
            this.marcaIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaIdDataGridViewTextBoxColumn.Visible = false;
            this.marcaIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // stockReposicionDataGridViewTextBoxColumn
            // 
            this.stockReposicionDataGridViewTextBoxColumn.DataPropertyName = "StockReposicion";
            this.stockReposicionDataGridViewTextBoxColumn.HeaderText = "StockReposicion";
            this.stockReposicionDataGridViewTextBoxColumn.Name = "stockReposicionDataGridViewTextBoxColumn";
            this.stockReposicionDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockReposicionDataGridViewTextBoxColumn.Visible = false;
            this.stockReposicionDataGridViewTextBoxColumn.Width = 128;
            // 
            // desincronizadoDataGridViewCheckBoxColumn
            // 
            this.desincronizadoDataGridViewCheckBoxColumn.DataPropertyName = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.HeaderText = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.Name = "desincronizadoDataGridViewCheckBoxColumn";
            this.desincronizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.desincronizadoDataGridViewCheckBoxColumn.Visible = false;
            this.desincronizadoDataGridViewCheckBoxColumn.Width = 101;
            // 
            // fechaUltimaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Width = 178;
            // 
            // eliminadoDataGridViewCheckBoxColumn
            // 
            this.eliminadoDataGridViewCheckBoxColumn.DataPropertyName = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.HeaderText = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.Name = "eliminadoDataGridViewCheckBoxColumn";
            this.eliminadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eliminadoDataGridViewCheckBoxColumn.Visible = false;
            this.eliminadoDataGridViewCheckBoxColumn.Width = 71;
            // 
            // cuentaIdDataGridViewTextBoxColumn
            // 
            this.cuentaIdDataGridViewTextBoxColumn.DataPropertyName = "CuentaId";
            this.cuentaIdDataGridViewTextBoxColumn.HeaderText = "CuentaId";
            this.cuentaIdDataGridViewTextBoxColumn.Name = "cuentaIdDataGridViewTextBoxColumn";
            this.cuentaIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaIdDataGridViewTextBoxColumn.Visible = false;
            this.cuentaIdDataGridViewTextBoxColumn.Width = 84;
            // 
            // aceptaCantidadesDecimalesDataGridViewCheckBoxColumn
            // 
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.DataPropertyName = "AceptaCantidadesDecimales";
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.HeaderText = "AceptaCantidadesDecimales";
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.Name = "aceptaCantidadesDecimalesDataGridViewCheckBoxColumn";
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.ReadOnly = true;
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.Visible = false;
            this.aceptaCantidadesDecimalesDataGridViewCheckBoxColumn.Width = 176;
            // 
            // precioSinIVADataGridViewTextBoxColumn
            // 
            this.precioSinIVADataGridViewTextBoxColumn.DataPropertyName = "PrecioSinIVA";
            this.precioSinIVADataGridViewTextBoxColumn.HeaderText = "PrecioSinIVA";
            this.precioSinIVADataGridViewTextBoxColumn.Name = "precioSinIVADataGridViewTextBoxColumn";
            this.precioSinIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.precioSinIVADataGridViewTextBoxColumn.Visible = false;
            this.precioSinIVADataGridViewTextBoxColumn.Width = 105;
            // 
            // codigosProductosDataGridViewTextBoxColumn
            // 
            this.codigosProductosDataGridViewTextBoxColumn.DataPropertyName = "CodigosProductos";
            this.codigosProductosDataGridViewTextBoxColumn.HeaderText = "CodigosProductos";
            this.codigosProductosDataGridViewTextBoxColumn.Name = "codigosProductosDataGridViewTextBoxColumn";
            this.codigosProductosDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigosProductosDataGridViewTextBoxColumn.Visible = false;
            this.codigosProductosDataGridViewTextBoxColumn.Width = 136;
            // 
            // cuentaDataGridViewTextBoxColumn
            // 
            this.cuentaDataGridViewTextBoxColumn.DataPropertyName = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.Name = "cuentaDataGridViewTextBoxColumn";
            this.cuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaDataGridViewTextBoxColumn.Visible = false;
            this.cuentaDataGridViewTextBoxColumn.Width = 74;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.Visible = false;
            this.marcaDataGridViewTextBoxColumn.Width = 70;
            // 
            // rubroDataGridViewTextBoxColumn
            // 
            this.rubroDataGridViewTextBoxColumn.DataPropertyName = "Rubro";
            this.rubroDataGridViewTextBoxColumn.HeaderText = "Rubro";
            this.rubroDataGridViewTextBoxColumn.Name = "rubroDataGridViewTextBoxColumn";
            this.rubroDataGridViewTextBoxColumn.ReadOnly = true;
            this.rubroDataGridViewTextBoxColumn.Visible = false;
            this.rubroDataGridViewTextBoxColumn.Width = 68;
            // 
            // ventaProductosDataGridViewTextBoxColumn
            // 
            this.ventaProductosDataGridViewTextBoxColumn.DataPropertyName = "VentaProductos";
            this.ventaProductosDataGridViewTextBoxColumn.HeaderText = "VentaProductos";
            this.ventaProductosDataGridViewTextBoxColumn.Name = "ventaProductosDataGridViewTextBoxColumn";
            this.ventaProductosDataGridViewTextBoxColumn.ReadOnly = true;
            this.ventaProductosDataGridViewTextBoxColumn.Visible = false;
            this.ventaProductosDataGridViewTextBoxColumn.Width = 121;
            // 
            // stocksDataGridViewTextBoxColumn
            // 
            this.stocksDataGridViewTextBoxColumn.DataPropertyName = "Stocks";
            this.stocksDataGridViewTextBoxColumn.HeaderText = "Stocks";
            this.stocksDataGridViewTextBoxColumn.Name = "stocksDataGridViewTextBoxColumn";
            this.stocksDataGridViewTextBoxColumn.ReadOnly = true;
            this.stocksDataGridViewTextBoxColumn.Visible = false;
            this.stocksDataGridViewTextBoxColumn.Width = 71;
            // 
            // comprasProductosDataGridViewTextBoxColumn
            // 
            this.comprasProductosDataGridViewTextBoxColumn.DataPropertyName = "ComprasProductos";
            this.comprasProductosDataGridViewTextBoxColumn.HeaderText = "ComprasProductos";
            this.comprasProductosDataGridViewTextBoxColumn.Name = "comprasProductosDataGridViewTextBoxColumn";
            this.comprasProductosDataGridViewTextBoxColumn.ReadOnly = true;
            this.comprasProductosDataGridViewTextBoxColumn.Visible = false;
            this.comprasProductosDataGridViewTextBoxColumn.Width = 141;
            // 
            // correccionStocksDataGridViewTextBoxColumn
            // 
            this.correccionStocksDataGridViewTextBoxColumn.DataPropertyName = "CorreccionStocks";
            this.correccionStocksDataGridViewTextBoxColumn.HeaderText = "CorreccionStocks";
            this.correccionStocksDataGridViewTextBoxColumn.Name = "correccionStocksDataGridViewTextBoxColumn";
            this.correccionStocksDataGridViewTextBoxColumn.ReadOnly = true;
            this.correccionStocksDataGridViewTextBoxColumn.Visible = false;
            this.correccionStocksDataGridViewTextBoxColumn.Width = 133;
            // 
            // proveedorProductosDataGridViewTextBoxColumn
            // 
            this.proveedorProductosDataGridViewTextBoxColumn.DataPropertyName = "ProveedorProductos";
            this.proveedorProductosDataGridViewTextBoxColumn.HeaderText = "ProveedorProductos";
            this.proveedorProductosDataGridViewTextBoxColumn.Name = "proveedorProductosDataGridViewTextBoxColumn";
            this.proveedorProductosDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedorProductosDataGridViewTextBoxColumn.Visible = false;
            this.proveedorProductosDataGridViewTextBoxColumn.Width = 146;
            // 
            // ProductoDetalle
            // 
            this.ProductoDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductoDetalle.HeaderText = "";
            this.ProductoDetalle.Name = "ProductoDetalle";
            this.ProductoDetalle.ReadOnly = true;
            this.ProductoDetalle.Width = 22;
            // 
            // ProductoEditar
            // 
            this.ProductoEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductoEditar.HeaderText = "";
            this.ProductoEditar.Name = "ProductoEditar";
            this.ProductoEditar.ReadOnly = true;
            this.ProductoEditar.Width = 22;
            // 
            // ProductoEliminar
            // 
            this.ProductoEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductoEliminar.HeaderText = "";
            this.ProductoEliminar.Name = "ProductoEliminar";
            this.ProductoEliminar.ReadOnly = true;
            this.ProductoEliminar.Width = 22;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.Producto);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.ddlProveedor);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 64);
            this.panel1.TabIndex = 0;
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.Alto = 28;
            this.ddlProveedor.Ancho = 241;
            this.ddlProveedor.DataSource = null;
            this.ddlProveedor.Disabled = false;
            this.ddlProveedor.DisplayMember = "";
            this.ddlProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ddlProveedor.ErrorMessage = "";
            this.ddlProveedor.EsObligatorio = false;
            this.ddlProveedor.InvalidateChar = null;
            this.ddlProveedor.Location = new System.Drawing.Point(307, 20);
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Referencia = null;
            this.ddlProveedor.Size = new System.Drawing.Size(241, 28);
            this.ddlProveedor.TabIndex = 1;
            this.ddlProveedor.Valor = 0;
            this.ddlProveedor.ValueMember = "";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(18, 21);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(245, 26);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "(INGRESE DESCRIPCION)";
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(565, 19);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar [F5]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.Actualizar);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.btnAgregarProducto);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(896, 42);
            this.panel2.TabIndex = 9;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(805, 16);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarProducto.Image")));
            this.btnAgregarProducto.Location = new System.Drawing.Point(727, 16);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(72, 23);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // ucPaginador
            // 
            this.ucPaginador.BackColor = System.Drawing.Color.Transparent;
            this.ucPaginador.CurrentPage = 1;
            this.ucPaginador.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucPaginador.Location = new System.Drawing.Point(0, 0);
            this.ucPaginador.Name = "ucPaginador";
            this.ucPaginador.PageSize = 50;
            this.ucPaginador.PageTotal = null;
            this.ucPaginador.Size = new System.Drawing.Size(548, 42);
            this.ucPaginador.TabIndex = 0;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 22;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Width = 22;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Width = 22;
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 472);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductos";
            this.Text = "Gestión de Productos";
            this.Activated += new System.EventHandler(this.frmProductos_Activated);
            this.Load += new System.EventHandler(this.frmGestionMarcas_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssCantidadFilas;
        private System.Windows.Forms.DataGridViewTextBoxColumn excepcionRubroesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tieneExcepcionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private Controles.UcPaginador ucPaginador;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private Util.Controles.ucDropDownList ddlProveedor;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosListadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioConIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costosResumenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaModificacionCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaCompraCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedoresListadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costosListadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimoCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockReposicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aceptaCantidadesDecimalesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSinIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosProductosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaProductosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprasProductosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correccionStocksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ProductoDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn ProductoEditar;
        private System.Windows.Forms.DataGridViewButtonColumn ProductoEliminar;

    }
}