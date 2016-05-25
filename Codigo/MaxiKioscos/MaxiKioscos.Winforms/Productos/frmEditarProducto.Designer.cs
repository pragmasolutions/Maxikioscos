namespace MaxiKioscos.Winforms.Productos
{
    partial class frmEditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chxDisponibleEnDeposito = new System.Windows.Forms.CheckBox();
            this.ddlRubro = new Telerik.WinControls.UI.RadDropDownList();
            this.label20 = new System.Windows.Forms.Label();
            this.ddlMarca = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPorcentajeGanancia = new Util.Controles.ucProcentaje();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUltimoCosto = new Util.Controles.ucDinero();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioSinIva = new Util.Controles.ucDinero();
            this.btnCrearCodigo = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvCodigos = new System.Windows.Forms.DataGridView();
            this.codigoProductoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CodigoEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.codigoProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chxAceptaDecimales = new System.Windows.Forms.CheckBox();
            this.txtPrecio = new Util.Controles.ucDinero();
            this.txtStockReposicion = new Util.Controles.ucSoloNumero();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.txtFactorAgrupamiento = new Util.Controles.ucSoloNumero();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoProductoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 35);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Producto";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFactorAgrupamiento);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.chxDisponibleEnDeposito);
            this.panel1.Controls.Add(this.ddlRubro);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.ddlMarca);
            this.panel1.Controls.Add(this.txtPorcentajeGanancia);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtUltimoCosto);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtPrecioSinIva);
            this.panel1.Controls.Add(this.btnCrearCodigo);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.dgvCodigos);
            this.panel1.Controls.Add(this.chxAceptaDecimales);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.txtStockReposicion);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 563);
            this.panel1.TabIndex = 1;
            // 
            // chxDisponibleEnDeposito
            // 
            this.chxDisponibleEnDeposito.AutoSize = true;
            this.chxDisponibleEnDeposito.Location = new System.Drawing.Point(271, 295);
            this.chxDisponibleEnDeposito.Name = "chxDisponibleEnDeposito";
            this.chxDisponibleEnDeposito.Size = new System.Drawing.Size(18, 17);
            this.chxDisponibleEnDeposito.TabIndex = 10;
            this.chxDisponibleEnDeposito.UseVisualStyleBackColor = true;
            // 
            // ddlRubro
            // 
            this.ddlRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRubro.DropDownAnimationEnabled = true;
            this.ddlRubro.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlRubro.Location = new System.Drawing.Point(272, 112);
            this.ddlRubro.MaxDropDownItems = 0;
            this.ddlRubro.Name = "ddlRubro";
            this.ddlRubro.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlRubro.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlRubro.ShowImageInEditorArea = true;
            this.ddlRubro.Size = new System.Drawing.Size(203, 32);
            this.ddlRubro.TabIndex = 7;
            this.ddlRubro.Text = "radDropDownList1";
            this.ddlRubro.ThemeName = "Windows7";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(267, 268);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(186, 23);
            this.label20.TabIndex = 52;
            this.label20.Text = "Disponible en Depósito";
            // 
            // ddlMarca
            // 
            this.ddlMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlMarca.DropDownAnimationEnabled = true;
            this.ddlMarca.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlMarca.Location = new System.Drawing.Point(272, 49);
            this.ddlMarca.MaxDropDownItems = 0;
            this.ddlMarca.Name = "ddlMarca";
            this.ddlMarca.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlMarca.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlMarca.ShowImageInEditorArea = true;
            this.ddlMarca.Size = new System.Drawing.Size(203, 32);
            this.ddlMarca.TabIndex = 6;
            this.ddlMarca.Text = "radDropDownList1";
            this.ddlMarca.ThemeName = "Windows7";
            // 
            // txtPorcentajeGanancia
            // 
            this.txtPorcentajeGanancia.Disabled = false;
            this.txtPorcentajeGanancia.ErrorMessage = "";
            this.txtPorcentajeGanancia.EsObligatorio = true;
            this.txtPorcentajeGanancia.Location = new System.Drawing.Point(21, 174);
            this.txtPorcentajeGanancia.LongMax = 32767;
            this.txtPorcentajeGanancia.LongMin = 0;
            this.txtPorcentajeGanancia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPorcentajeGanancia.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPorcentajeGanancia.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcentajeGanancia.Name = "txtPorcentajeGanancia";
            this.txtPorcentajeGanancia.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPorcentajeGanancia.ReadOnly = false;
            this.txtPorcentajeGanancia.Size = new System.Drawing.Size(203, 26);
            this.txtPorcentajeGanancia.TabIndex = 2;
            this.txtPorcentajeGanancia.TextboxTabIndex = 5;
            this.txtPorcentajeGanancia.Valor = null;
            this.txtPorcentajeGanancia.Cambio += new Util.Controles.ucProcentaje.CambioEventHandler(this.txtPorcentajeGanancia_Cambio);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(17, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 23);
            this.label16.TabIndex = 54;
            this.label16.Text = "Porcentaje Ganancia";
            // 
            // txtUltimoCosto
            // 
            this.txtUltimoCosto.Disabled = false;
            this.txtUltimoCosto.ErrorMessage = "";
            this.txtUltimoCosto.EsObligatorio = true;
            this.txtUltimoCosto.Location = new System.Drawing.Point(21, 112);
            this.txtUltimoCosto.LongMax = 32767;
            this.txtUltimoCosto.LongMin = 0;
            this.txtUltimoCosto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUltimoCosto.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtUltimoCosto.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtUltimoCosto.Name = "txtUltimoCosto";
            this.txtUltimoCosto.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUltimoCosto.ReadOnly = false;
            this.txtUltimoCosto.Size = new System.Drawing.Size(203, 26);
            this.txtUltimoCosto.TabIndex = 1;
            this.txtUltimoCosto.TextboxTabIndex = 3;
            this.txtUltimoCosto.Valor = null;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(17, 89);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 23);
            this.label18.TabIndex = 53;
            this.label18.Text = "Ultimo Costo con IVA";
            // 
            // txtPrecioSinIva
            // 
            this.txtPrecioSinIva.Disabled = false;
            this.txtPrecioSinIva.ErrorMessage = "";
            this.txtPrecioSinIva.EsObligatorio = true;
            this.txtPrecioSinIva.Location = new System.Drawing.Point(21, 290);
            this.txtPrecioSinIva.LongMax = 32767;
            this.txtPrecioSinIva.LongMin = 0;
            this.txtPrecioSinIva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecioSinIva.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecioSinIva.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecioSinIva.Name = "txtPrecioSinIva";
            this.txtPrecioSinIva.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecioSinIva.ReadOnly = false;
            this.txtPrecioSinIva.Size = new System.Drawing.Size(203, 26);
            this.txtPrecioSinIva.TabIndex = 4;
            this.txtPrecioSinIva.TextboxTabIndex = 0;
            this.txtPrecioSinIva.Valor = null;
            this.txtPrecioSinIva.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecioSinIva_Cambio);
            // 
            // btnCrearCodigo
            // 
            this.btnCrearCodigo.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearCodigo.Image")));
            this.btnCrearCodigo.Location = new System.Drawing.Point(403, 406);
            this.btnCrearCodigo.Name = "btnCrearCodigo";
            this.btnCrearCodigo.Size = new System.Drawing.Size(72, 23);
            this.btnCrearCodigo.TabIndex = 11;
            this.btnCrearCodigo.Text = "Agregar";
            this.btnCrearCodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrearCodigo.UseVisualStyleBackColor = true;
            this.btnCrearCodigo.Click += new System.EventHandler(this.btnCrearCodigo_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(17, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 23);
            this.label15.TabIndex = 50;
            this.label15.Text = "Precio Sin IVA ";
            // 
            // dgvCodigos
            // 
            this.dgvCodigos.AllowUserToAddRows = false;
            this.dgvCodigos.AllowUserToDeleteRows = false;
            this.dgvCodigos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCodigos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCodigos.AutoGenerateColumns = false;
            this.dgvCodigos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodigos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCodigos.ColumnHeadersHeight = 31;
            this.dgvCodigos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoProductoIdDataGridViewTextBoxColumn,
            this.productoIdDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.CodigoEditar,
            this.CodigoEliminar});
            this.dgvCodigos.DataSource = this.codigoProductoBindingSource;
            this.dgvCodigos.Location = new System.Drawing.Point(21, 431);
            this.dgvCodigos.MultiSelect = false;
            this.dgvCodigos.Name = "dgvCodigos";
            this.dgvCodigos.ReadOnly = true;
            this.dgvCodigos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCodigos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCodigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodigos.Size = new System.Drawing.Size(454, 112);
            this.dgvCodigos.TabIndex = 10;
            this.dgvCodigos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodigos_CellContentClick);
            this.dgvCodigos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCodigos_CellPainting);
            // 
            // codigoProductoIdDataGridViewTextBoxColumn
            // 
            this.codigoProductoIdDataGridViewTextBoxColumn.DataPropertyName = "CodigoProductoId";
            this.codigoProductoIdDataGridViewTextBoxColumn.HeaderText = "CodigoProductoId";
            this.codigoProductoIdDataGridViewTextBoxColumn.Name = "codigoProductoIdDataGridViewTextBoxColumn";
            this.codigoProductoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoProductoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desincronizadoDataGridViewCheckBoxColumn
            // 
            this.desincronizadoDataGridViewCheckBoxColumn.DataPropertyName = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.HeaderText = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.Name = "desincronizadoDataGridViewCheckBoxColumn";
            this.desincronizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.desincronizadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // fechaUltimaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // eliminadoDataGridViewCheckBoxColumn
            // 
            this.eliminadoDataGridViewCheckBoxColumn.DataPropertyName = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.HeaderText = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.Name = "eliminadoDataGridViewCheckBoxColumn";
            this.eliminadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eliminadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoDataGridViewTextBoxColumn.Visible = false;
            // 
            // CodigoEditar
            // 
            this.CodigoEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoEditar.HeaderText = "";
            this.CodigoEditar.Name = "CodigoEditar";
            this.CodigoEditar.ReadOnly = true;
            this.CodigoEditar.Width = 22;
            // 
            // CodigoEliminar
            // 
            this.CodigoEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoEliminar.HeaderText = "";
            this.CodigoEliminar.Name = "CodigoEliminar";
            this.CodigoEliminar.ReadOnly = true;
            this.CodigoEliminar.Width = 22;
            // 
            // codigoProductoBindingSource
            // 
            this.codigoProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.CodigoProducto);
            // 
            // chxAceptaDecimales
            // 
            this.chxAceptaDecimales.AutoSize = true;
            this.chxAceptaDecimales.Location = new System.Drawing.Point(272, 176);
            this.chxAceptaDecimales.Name = "chxAceptaDecimales";
            this.chxAceptaDecimales.Size = new System.Drawing.Size(18, 17);
            this.chxAceptaDecimales.TabIndex = 8;
            this.chxAceptaDecimales.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Disabled = false;
            this.txtPrecio.ErrorMessage = "";
            this.txtPrecio.EsObligatorio = true;
            this.txtPrecio.Location = new System.Drawing.Point(21, 230);
            this.txtPrecio.LongMax = 32767;
            this.txtPrecio.LongMin = 0;
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecio.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecio.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecio.ReadOnly = false;
            this.txtPrecio.Size = new System.Drawing.Size(203, 26);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.TextboxTabIndex = 7;
            this.txtPrecio.Valor = null;
            this.txtPrecio.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecio_Cambio);
            // 
            // txtStockReposicion
            // 
            this.txtStockReposicion.AceptaDecimales = false;
            this.txtStockReposicion.CaracteresPermitidos = null;
            this.txtStockReposicion.Disabled = false;
            this.txtStockReposicion.ErrorMessage = "";
            this.txtStockReposicion.EsObligatorio = true;
            this.txtStockReposicion.Location = new System.Drawing.Point(272, 230);
            this.txtStockReposicion.LongMax = 32767;
            this.txtStockReposicion.LongMin = 0;
            this.txtStockReposicion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStockReposicion.MaximoValor = null;
            this.txtStockReposicion.MinimoValor = null;
            this.txtStockReposicion.Name = "txtStockReposicion";
            this.txtStockReposicion.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStockReposicion.Size = new System.Drawing.Size(203, 25);
            this.txtStockReposicion.TabIndex = 9;
            this.txtStockReposicion.Valor = "";
            this.txtStockReposicion.ValorDecimal = null;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(21, 49);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 29);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 407);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 23);
            this.label14.TabIndex = 46;
            this.label14.Text = "Códigos";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 23);
            this.label26.TabIndex = 44;
            this.label26.Text = "Descripción";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(268, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 43;
            this.label25.Text = "Marca";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(17, 207);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(122, 23);
            this.label24.TabIndex = 42;
            this.label24.Text = "Precio Con IVA";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(268, 149);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(174, 23);
            this.label23.TabIndex = 41;
            this.label23.Text = "Acepta Stock Decimal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(268, 207);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(143, 23);
            this.label19.TabIndex = 40;
            this.label19.Text = "Stock Reposición";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(267, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 23);
            this.label17.TabIndex = 45;
            this.label17.Text = "Rubro";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(183, 613);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(333, 613);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Width = 22;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Width = 22;
            // 
            // txtFactorAgrupamiento
            // 
            this.txtFactorAgrupamiento.AceptaDecimales = false;
            this.txtFactorAgrupamiento.CaracteresPermitidos = null;
            this.txtFactorAgrupamiento.Disabled = false;
            this.txtFactorAgrupamiento.ErrorMessage = "";
            this.txtFactorAgrupamiento.EsObligatorio = true;
            this.txtFactorAgrupamiento.Location = new System.Drawing.Point(22, 359);
            this.txtFactorAgrupamiento.LongMax = 32767;
            this.txtFactorAgrupamiento.LongMin = 0;
            this.txtFactorAgrupamiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFactorAgrupamiento.MaximoValor = null;
            this.txtFactorAgrupamiento.MinimoValor = null;
            this.txtFactorAgrupamiento.Name = "txtFactorAgrupamiento";
            this.txtFactorAgrupamiento.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFactorAgrupamiento.Size = new System.Drawing.Size(202, 31);
            this.txtFactorAgrupamiento.TabIndex = 5;
            this.txtFactorAgrupamiento.Valor = "";
            this.txtFactorAgrupamiento.ValorDecimal = null;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(18, 332);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(194, 23);
            this.label21.TabIndex = 56;
            this.label21.Text = "Factor de Agrupamiento";
            // 
            // frmEditarProducto
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(513, 654);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Producto";
            this.Load += new System.EventHandler(this.frmEditarProducto_Load);
            this.Shown += new System.EventHandler(this.frmEditarProducto_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoProductoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chxAceptaDecimales;
        private Util.Controles.ucDinero txtPrecio;
        private Util.Controles.ucSoloNumero txtStockReposicion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvCodigos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProductoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn CodigoEditar;
        private System.Windows.Forms.DataGridViewButtonColumn CodigoEliminar;
        private System.Windows.Forms.BindingSource codigoProductoBindingSource;
        private System.Windows.Forms.Button btnCrearCodigo;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Util.Controles.ucDinero txtPrecioSinIva;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Util.Controles.ucDinero txtUltimoCosto;
        private System.Windows.Forms.Label label18;
        private Util.Controles.ucProcentaje txtPorcentajeGanancia;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        public Telerik.WinControls.UI.RadDropDownList ddlRubro;
        public Telerik.WinControls.UI.RadDropDownList ddlMarca;
        private System.Windows.Forms.CheckBox chxDisponibleEnDeposito;
        private System.Windows.Forms.Label label20;
        private Util.Controles.ucSoloNumero txtFactorAgrupamiento;
        private System.Windows.Forms.Label label21;
        
        
    }
}