namespace MaxiKioscos.Winforms.Proveedores
{
    partial class frmProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProveedorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuitNroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DetalleProveedor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // proveedorBindingSource
            // 
            this.proveedorBindingSource.DataSource = typeof(MaxiKioscos.Entidades.Proveedor);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvListado);
            this.splitContainer1.Size = new System.Drawing.Size(772, 326);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Controls.Add(this.ucPaginador, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 120);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ucPaginador
            // 
            this.ucPaginador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPaginador.BackColor = System.Drawing.Color.Transparent;
            this.ucPaginador.CurrentPage = 1;
            this.ucPaginador.Location = new System.Drawing.Point(3, 78);
            this.ucPaginador.Name = "ucPaginador";
            this.ucPaginador.PageSize = 10;
            this.ucPaginador.PageTotal = null;
            this.ucPaginador.Size = new System.Drawing.Size(548, 39);
            this.ucPaginador.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 70);
            this.panel1.TabIndex = 24;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(268, 20);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar [F6]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(14, 22);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(248, 20);
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(649, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 70);
            this.panel2.TabIndex = 25;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(652, 83);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeight = 40;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.ProveedorId,
            this.Localidad,
            this.contactoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.localidadIdDataGridViewTextBoxColumn,
            this.cuitNroDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.DetalleProveedor});
            this.dgvListado.DataSource = this.proveedorBindingSource;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.RowTemplate.Height = 30;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(772, 202);
            this.dgvListado.TabIndex = 24;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.FillWeight = 106.599F;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProveedorId
            // 
            this.ProveedorId.DataPropertyName = "ProveedorId";
            this.ProveedorId.HeaderText = "ProveedorId";
            this.ProveedorId.Name = "ProveedorId";
            this.ProveedorId.ReadOnly = true;
            this.ProveedorId.Visible = false;
            // 
            // Localidad
            // 
            this.Localidad.DataPropertyName = "Localidad";
            this.Localidad.HeaderText = "Localidad";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Visible = false;
            // 
            // contactoDataGridViewTextBoxColumn
            // 
            this.contactoDataGridViewTextBoxColumn.DataPropertyName = "Contacto";
            this.contactoDataGridViewTextBoxColumn.FillWeight = 106.599F;
            this.contactoDataGridViewTextBoxColumn.HeaderText = "Contacto";
            this.contactoDataGridViewTextBoxColumn.Name = "contactoDataGridViewTextBoxColumn";
            this.contactoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.FillWeight = 106.599F;
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LocalidadString";
            this.dataGridViewTextBoxColumn1.FillWeight = 106.599F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Localidad";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // localidadIdDataGridViewTextBoxColumn
            // 
            this.localidadIdDataGridViewTextBoxColumn.DataPropertyName = "LocalidadId";
            this.localidadIdDataGridViewTextBoxColumn.HeaderText = "LocalidadId";
            this.localidadIdDataGridViewTextBoxColumn.Name = "localidadIdDataGridViewTextBoxColumn";
            this.localidadIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.localidadIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // cuitNroDataGridViewTextBoxColumn
            // 
            this.cuitNroDataGridViewTextBoxColumn.DataPropertyName = "CuitNro";
            this.cuitNroDataGridViewTextBoxColumn.FillWeight = 106.599F;
            this.cuitNroDataGridViewTextBoxColumn.HeaderText = "Nro Cuit";
            this.cuitNroDataGridViewTextBoxColumn.Name = "cuitNroDataGridViewTextBoxColumn";
            this.cuitNroDataGridViewTextBoxColumn.ReadOnly = true;
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
            // DetalleProveedor
            // 
            this.DetalleProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DetalleProveedor.FillWeight = 67.00507F;
            this.DetalleProveedor.HeaderText = "";
            this.DetalleProveedor.Name = "DetalleProveedor";
            this.DetalleProveedor.ReadOnly = true;
            this.DetalleProveedor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DetalleProveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DetalleProveedor.Width = 25;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.FillWeight = 67.00507F;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Width = 25;
            // 
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 326);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            this.Shown += new System.EventHandler(this.frmProveedores_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmProveedores_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controles.UcPaginador ucPaginador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProveedorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitNroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DetalleProveedor;
    }
}