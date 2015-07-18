namespace MaxiKioscos.Winforms.Productos
{
    partial class frmDetalleEliminarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleEliminarProducto));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCodigos = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStockReposicion = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtAceptaCantidadesDecimales = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtPrecio = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtRubro = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtMarca = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtDescripcion = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.proveedorProductoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoConIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pprecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prubroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.costoSinIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorProductoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Producto";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 363);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCodigos);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtStockReposicion);
            this.tabPage1.Controls.Add(this.txtAceptaCantidadesDecimales);
            this.tabPage1.Controls.Add(this.txtPrecio);
            this.tabPage1.Controls.Add(this.txtRubro);
            this.tabPage1.Controls.Add(this.txtMarca);
            this.tabPage1.Controls.Add(this.txtDescripcion);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCodigos
            // 
            this.txtCodigos.Location = new System.Drawing.Point(29, 228);
            this.txtCodigos.Name = "txtCodigos";
            this.txtCodigos.Size = new System.Drawing.Size(203, 26);
            this.txtCodigos.TabIndex = 4;
            this.txtCodigos.Texto = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(25, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Códigos";
            // 
            // txtStockReposicion
            // 
            this.txtStockReposicion.Location = new System.Drawing.Point(29, 167);
            this.txtStockReposicion.Name = "txtStockReposicion";
            this.txtStockReposicion.Size = new System.Drawing.Size(203, 26);
            this.txtStockReposicion.TabIndex = 3;
            this.txtStockReposicion.Texto = "";
            // 
            // txtAceptaCantidadesDecimales
            // 
            this.txtAceptaCantidadesDecimales.Location = new System.Drawing.Point(280, 167);
            this.txtAceptaCantidadesDecimales.Name = "txtAceptaCantidadesDecimales";
            this.txtAceptaCantidadesDecimales.Size = new System.Drawing.Size(203, 26);
            this.txtAceptaCantidadesDecimales.TabIndex = 7;
            this.txtAceptaCantidadesDecimales.Texto = "";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(280, 109);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(203, 26);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.Texto = "";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(29, 109);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(203, 26);
            this.txtRubro.TabIndex = 2;
            this.txtRubro.Texto = "";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(280, 46);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(203, 26);
            this.txtMarca.TabIndex = 5;
            this.txtMarca.Texto = "";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(29, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 26);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Texto = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(25, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 20);
            this.label26.TabIndex = 21;
            this.label26.Text = "Descripción";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(276, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 20);
            this.label25.TabIndex = 20;
            this.label25.Text = "Marca";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(276, 86);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 20);
            this.label24.TabIndex = 19;
            this.label24.Text = "Precio";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(276, 144);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 20);
            this.label23.TabIndex = 18;
            this.label23.Text = "Acepta Stock Decimal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(25, 144);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "Stock Reposición";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(25, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Rubro";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvProveedores);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Proveedores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProveedores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProveedores.AutoGenerateColumns = false;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvProveedores.ColumnHeadersHeight = 31;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proveedorProductoIdDataGridViewTextBoxColumn,
            this.proveedorNombreDataGridViewTextBoxColumn,
            this.costoConIVADataGridViewTextBoxColumn,
            this.pprecioDataGridViewTextBoxColumn,
            this.pdescripcionDataGridViewTextBoxColumn,
            this.pmarcaDataGridViewTextBoxColumn,
            this.prubroDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.proveedorIdDataGridViewTextBoxColumn,
            this.productoIdDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.costoSinIVADataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.proveedorDataGridViewTextBoxColumn});
            this.dgvProveedores.DataSource = this.proveedorProductoBindingSource;
            this.dgvProveedores.Location = new System.Drawing.Point(24, 24);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProveedores.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(454, 265);
            this.dgvProveedores.TabIndex = 23;
            // 
            // proveedorProductoIdDataGridViewTextBoxColumn
            // 
            this.proveedorProductoIdDataGridViewTextBoxColumn.DataPropertyName = "ProveedorProductoId";
            this.proveedorProductoIdDataGridViewTextBoxColumn.HeaderText = "ProveedorProductoId";
            this.proveedorProductoIdDataGridViewTextBoxColumn.Name = "proveedorProductoIdDataGridViewTextBoxColumn";
            this.proveedorProductoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedorProductoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedorNombreDataGridViewTextBoxColumn
            // 
            this.proveedorNombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedorNombreDataGridViewTextBoxColumn.DataPropertyName = "ProveedorNombre";
            this.proveedorNombreDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorNombreDataGridViewTextBoxColumn.Name = "proveedorNombreDataGridViewTextBoxColumn";
            this.proveedorNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoConIVADataGridViewTextBoxColumn
            // 
            this.costoConIVADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costoConIVADataGridViewTextBoxColumn.DataPropertyName = "CostoConIVA";
            this.costoConIVADataGridViewTextBoxColumn.HeaderText = "Costo con IVA";
            this.costoConIVADataGridViewTextBoxColumn.Name = "costoConIVADataGridViewTextBoxColumn";
            this.costoConIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.costoConIVADataGridViewTextBoxColumn.Width = 140;
            // 
            // pprecioDataGridViewTextBoxColumn
            // 
            this.pprecioDataGridViewTextBoxColumn.DataPropertyName = "Pprecio";
            this.pprecioDataGridViewTextBoxColumn.HeaderText = "Pprecio";
            this.pprecioDataGridViewTextBoxColumn.Name = "pprecioDataGridViewTextBoxColumn";
            this.pprecioDataGridViewTextBoxColumn.ReadOnly = true;
            this.pprecioDataGridViewTextBoxColumn.Visible = false;
            // 
            // pdescripcionDataGridViewTextBoxColumn
            // 
            this.pdescripcionDataGridViewTextBoxColumn.DataPropertyName = "Pdescripcion";
            this.pdescripcionDataGridViewTextBoxColumn.HeaderText = "Pdescripcion";
            this.pdescripcionDataGridViewTextBoxColumn.Name = "pdescripcionDataGridViewTextBoxColumn";
            this.pdescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.pdescripcionDataGridViewTextBoxColumn.Visible = false;
            // 
            // pmarcaDataGridViewTextBoxColumn
            // 
            this.pmarcaDataGridViewTextBoxColumn.DataPropertyName = "Pmarca";
            this.pmarcaDataGridViewTextBoxColumn.HeaderText = "Pmarca";
            this.pmarcaDataGridViewTextBoxColumn.Name = "pmarcaDataGridViewTextBoxColumn";
            this.pmarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmarcaDataGridViewTextBoxColumn.Visible = false;
            // 
            // prubroDataGridViewTextBoxColumn
            // 
            this.prubroDataGridViewTextBoxColumn.DataPropertyName = "Prubro";
            this.prubroDataGridViewTextBoxColumn.HeaderText = "Prubro";
            this.prubroDataGridViewTextBoxColumn.Name = "prubroDataGridViewTextBoxColumn";
            this.prubroDataGridViewTextBoxColumn.ReadOnly = true;
            this.prubroDataGridViewTextBoxColumn.Visible = false;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedorIdDataGridViewTextBoxColumn
            // 
            this.proveedorIdDataGridViewTextBoxColumn.DataPropertyName = "ProveedorId";
            this.proveedorIdDataGridViewTextBoxColumn.HeaderText = "ProveedorId";
            this.proveedorIdDataGridViewTextBoxColumn.Name = "proveedorIdDataGridViewTextBoxColumn";
            this.proveedorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedorIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
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
            // costoSinIVADataGridViewTextBoxColumn
            // 
            this.costoSinIVADataGridViewTextBoxColumn.DataPropertyName = "CostoSinIVA";
            this.costoSinIVADataGridViewTextBoxColumn.HeaderText = "CostoSinIVA";
            this.costoSinIVADataGridViewTextBoxColumn.Name = "costoSinIVADataGridViewTextBoxColumn";
            this.costoSinIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.costoSinIVADataGridViewTextBoxColumn.Visible = false;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            this.proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.proveedorDataGridViewTextBoxColumn.Visible = false;
            // 
            // proveedorProductoBindingSource
            // 
            this.proveedorProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.ProveedorProducto);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(241, 417);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Cerrar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAceptar_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(391, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancelar_KeyDown);
            // 
            // frmDetalleEliminarProducto
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(541, 465);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 503);
            this.MinimumSize = new System.Drawing.Size(557, 503);
            this.Name = "frmDetalleEliminarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Producto";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDetalleEliminarProducto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorProductoBindingSource)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtStockReposicion;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtAceptaCantidadesDecimales;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtPrecio;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtRubro;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtMarca;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtDescripcion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Label label14;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtCodigos;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoConIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pprecioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prubroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoSinIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource proveedorProductoBindingSource;
        
        
    }
}