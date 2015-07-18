using MaxiKioscos.Winforms.Controles;

namespace MaxiKioscos.Winforms.ControlStock
{
    partial class frmControlStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlProveedor = new Util.Controles.ucDropDownList();
            this.ddlRubro = new Util.Controles.ucDropDownList();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.btnAgregarControl = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.controlStockIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroControlFormateadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCorreccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parametros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlStockImprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DetalleControl = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Localidad";
            this.dataGridViewTextBoxColumn2.HeaderText = "Localidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 147;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Localidad";
            this.dataGridViewTextBoxColumn3.HeaderText = "Localidad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvListado, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1489, 788);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.ddlProveedor);
            this.panel1.Controls.Add(this.ddlRubro);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1481, 78);
            this.panel1.TabIndex = 0;
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.Alto = 34;
            this.ddlProveedor.Ancho = 252;
            this.ddlProveedor.DataSource = null;
            this.ddlProveedor.Disabled = false;
            this.ddlProveedor.DisplayMember = "";
            this.ddlProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ddlProveedor.ErrorMessage = "";
            this.ddlProveedor.EsObligatorio = true;
            this.ddlProveedor.InvalidateChar = null;
            this.ddlProveedor.Location = new System.Drawing.Point(351, 21);
            this.ddlProveedor.Margin = new System.Windows.Forms.Padding(5);
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Referencia = null;
            this.ddlProveedor.Size = new System.Drawing.Size(252, 34);
            this.ddlProveedor.TabIndex = 9;
            this.ddlProveedor.Valor = 0;
            this.ddlProveedor.ValueMember = "";
            // 
            // ddlRubro
            // 
            this.ddlRubro.Alto = 34;
            this.ddlRubro.Ancho = 252;
            this.ddlRubro.DataSource = null;
            this.ddlRubro.Disabled = false;
            this.ddlRubro.DisplayMember = "";
            this.ddlRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ddlRubro.ErrorMessage = "";
            this.ddlRubro.EsObligatorio = true;
            this.ddlRubro.InvalidateChar = null;
            this.ddlRubro.Location = new System.Drawing.Point(29, 21);
            this.ddlRubro.Margin = new System.Windows.Forms.Padding(5);
            this.ddlRubro.Name = "ddlRubro";
            this.ddlRubro.Referencia = null;
            this.ddlRubro.Size = new System.Drawing.Size(252, 34);
            this.ddlRubro.TabIndex = 8;
            this.ddlRubro.Valor = 0;
            this.ddlRubro.ValueMember = "";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(668, 21);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 9, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 34);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar [F5]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.Actualizar);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeight = 31;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.controlStockIdDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.nroControlFormateadoDataGridViewTextBoxColumn,
            this.rubroDescripcionDataGridViewTextBoxColumn,
            this.proveedorNombreDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.fechaCorreccionDataGridViewTextBoxColumn,
            this.Parametros,
            this.ControlStockImprimir,
            this.DetalleControl});
            this.dgvListado.Location = new System.Drawing.Point(4, 149);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListado.RowTemplate.Height = 30;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(1481, 635);
            this.dgvListado.TabIndex = 22;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Controls.Add(this.btnAgregarControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 90);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1481, 51);
            this.panel2.TabIndex = 23;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(1361, 20);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(108, 28);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // ucPaginador
            // 
            this.ucPaginador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPaginador.BackColor = System.Drawing.Color.Transparent;
            this.ucPaginador.CurrentPage = 1;
            this.ucPaginador.Location = new System.Drawing.Point(0, -1);
            this.ucPaginador.Margin = new System.Windows.Forms.Padding(5);
            this.ucPaginador.Name = "ucPaginador";
            this.ucPaginador.PageSize = 10;
            this.ucPaginador.PageTotal = null;
            this.ucPaginador.Size = new System.Drawing.Size(645, 48);
            this.ucPaginador.TabIndex = 23;
            // 
            // btnAgregarControl
            // 
            this.btnAgregarControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarControl.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarControl.Image")));
            this.btnAgregarControl.Location = new System.Drawing.Point(1257, 20);
            this.btnAgregarControl.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarControl.Name = "btnAgregarControl";
            this.btnAgregarControl.Size = new System.Drawing.Size(96, 28);
            this.btnAgregarControl.TabIndex = 24;
            this.btnAgregarControl.Text = "Agregar";
            this.btnAgregarControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarControl.UseVisualStyleBackColor = true;
            this.btnAgregarControl.Click += new System.EventHandler(this.btnAgregarControl_Click);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.FillWeight = 92.71886F;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Width = 22;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn2.FillWeight = 91.12937F;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn2.Visible = false;
            this.dataGridViewButtonColumn2.Width = 22;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.FillWeight = 89.3401F;
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn3.Visible = false;
            this.dataGridViewButtonColumn3.Width = 22;
            // 
            // controlStockIdDataGridViewTextBoxColumn
            // 
            this.controlStockIdDataGridViewTextBoxColumn.DataPropertyName = "ControlStockId";
            this.controlStockIdDataGridViewTextBoxColumn.HeaderText = "ControlStockId";
            this.controlStockIdDataGridViewTextBoxColumn.Name = "controlStockIdDataGridViewTextBoxColumn";
            this.controlStockIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.controlStockIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaCreacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCreacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // nroControlFormateadoDataGridViewTextBoxColumn
            // 
            this.nroControlFormateadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nroControlFormateadoDataGridViewTextBoxColumn.DataPropertyName = "NroControl";
            this.nroControlFormateadoDataGridViewTextBoxColumn.HeaderText = "Nro Control";
            this.nroControlFormateadoDataGridViewTextBoxColumn.Name = "nroControlFormateadoDataGridViewTextBoxColumn";
            this.nroControlFormateadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroControlFormateadoDataGridViewTextBoxColumn.Width = 120;
            // 
            // rubroDescripcionDataGridViewTextBoxColumn
            // 
            this.rubroDescripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rubroDescripcionDataGridViewTextBoxColumn.DataPropertyName = "Rubro";
            this.rubroDescripcionDataGridViewTextBoxColumn.HeaderText = "Rubro";
            this.rubroDescripcionDataGridViewTextBoxColumn.Name = "rubroDescripcionDataGridViewTextBoxColumn";
            this.rubroDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proveedorNombreDataGridViewTextBoxColumn
            // 
            this.proveedorNombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedorNombreDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            this.proveedorNombreDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            this.proveedorNombreDataGridViewTextBoxColumn.Name = "proveedorNombreDataGridViewTextBoxColumn";
            this.proveedorNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 120;
            // 
            // fechaCorreccionDataGridViewTextBoxColumn
            // 
            this.fechaCorreccionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fechaCorreccionDataGridViewTextBoxColumn.DataPropertyName = "FechaCorreccion";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.fechaCorreccionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaCorreccionDataGridViewTextBoxColumn.HeaderText = "Corrección";
            this.fechaCorreccionDataGridViewTextBoxColumn.Name = "fechaCorreccionDataGridViewTextBoxColumn";
            this.fechaCorreccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCorreccionDataGridViewTextBoxColumn.Width = 150;
            // 
            // Parametros
            // 
            this.Parametros.DataPropertyName = "Parametros";
            this.Parametros.HeaderText = "Parámetros";
            this.Parametros.Name = "Parametros";
            this.Parametros.ReadOnly = true;
            this.Parametros.Width = 240;
            // 
            // ControlStockImprimir
            // 
            this.ControlStockImprimir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ControlStockImprimir.HeaderText = "";
            this.ControlStockImprimir.Name = "ControlStockImprimir";
            this.ControlStockImprimir.ReadOnly = true;
            this.ControlStockImprimir.Width = 22;
            // 
            // DetalleControl
            // 
            this.DetalleControl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DetalleControl.HeaderText = "";
            this.DetalleControl.Name = "DetalleControl";
            this.DetalleControl.ReadOnly = true;
            this.DetalleControl.Width = 22;
            // 
            // frmControlStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1489, 788);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmControlStock";
            this.Text = "Control de Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmControlStock_Activated);
            this.Load += new System.EventHandler(this.frmControlStock_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abreviatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoría;
        private System.Windows.Forms.DataGridViewTextBoxColumn HabilitadoTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregarControl;
        private UcPaginador ucPaginador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnActualizar;
        private Util.Controles.ucDropDownList ddlProveedor;
        private Util.Controles.ucDropDownList ddlRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlStockIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroControlFormateadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCorreccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parametros;
        private System.Windows.Forms.DataGridViewButtonColumn ControlStockImprimir;
        private System.Windows.Forms.DataGridViewButtonColumn DetalleControl;
    }
}