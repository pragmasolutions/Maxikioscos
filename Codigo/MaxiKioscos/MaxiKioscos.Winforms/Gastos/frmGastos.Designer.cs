namespace MaxiKioscos.Winforms.Gastos
{
    partial class frmGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chxCajaActual = new System.Windows.Forms.CheckBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.CostoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaCerrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditarCosto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EliminarCosto = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.ddlEstados = new Util.Controles.ucDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer1.Size = new System.Drawing.Size(972, 581);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 120);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.btnAgregarProducto);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 53);
            this.panel2.TabIndex = 5;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(775, 23);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(109, 28);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarProducto.Image")));
            this.btnAgregarProducto.Location = new System.Drawing.Point(671, 23);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(96, 28);
            this.btnAgregarProducto.TabIndex = 24;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.ddlEstados);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.chxCajaActual);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 66);
            this.panel1.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(833, 15);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 9, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(135, 37);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar [F5]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(491, 18);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 9, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(325, 30);
            this.txtBuscar.TabIndex = 5;
            this.txtBuscar.Text = "(NRO COMPROBANTE)";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // chxCajaActual
            // 
            this.chxCajaActual.AutoSize = true;
            this.chxCajaActual.Checked = true;
            this.chxCajaActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxCajaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxCajaActual.Location = new System.Drawing.Point(24, 25);
            this.chxCajaActual.Name = "chxCajaActual";
            this.chxCajaActual.Size = new System.Drawing.Size(168, 22);
            this.chxCajaActual.TabIndex = 3;
            this.chxCajaActual.Text = "Cierre de Caja Actual";
            this.chxCajaActual.UseVisualStyleBackColor = true;
            this.chxCajaActual.CheckedChanged += new System.EventHandler(this.chxCajaActual_CheckedChanged);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.CostoId,
            this.Fecha,
            this.NroComprobante,
            this.CategoriaCosto,
            this.Importe,
            this.Estado,
            this.CajaCerrada,
            this.Detalle,
            this.EditarCosto,
            this.EliminarCosto});
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(972, 456);
            this.dgvListado.TabIndex = 8;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentDoubleClick);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // CostoId
            // 
            this.CostoId.DataPropertyName = "CostoId";
            this.CostoId.HeaderText = "CostoId";
            this.CostoId.Name = "CostoId";
            this.CostoId.ReadOnly = true;
            this.CostoId.Visible = false;
            this.CostoId.Width = 87;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // NroComprobante
            // 
            this.NroComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NroComprobante.DataPropertyName = "NroComprobante";
            this.NroComprobante.HeaderText = "Nro. Comprobante";
            this.NroComprobante.Name = "NroComprobante";
            this.NroComprobante.ReadOnly = true;
            this.NroComprobante.Width = 163;
            // 
            // CategoriaCosto
            // 
            this.CategoriaCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoriaCosto.DataPropertyName = "CategoriaCosto";
            this.CategoriaCosto.HeaderText = "Categoría";
            this.CategoriaCosto.Name = "CategoriaCosto";
            this.CategoriaCosto.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Monto";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 150;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 150;
            // 
            // CajaCerrada
            // 
            this.CajaCerrada.DataPropertyName = "CajaCerrada";
            this.CajaCerrada.HeaderText = "CajaCerrada";
            this.CajaCerrada.Name = "CajaCerrada";
            this.CajaCerrada.ReadOnly = true;
            this.CajaCerrada.Visible = false;
            this.CajaCerrada.Width = 124;
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
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Width = 22;
            // 
            // Detalle
            // 
            this.Detalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Detalle.HeaderText = "";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 22;
            // 
            // EditarCosto
            // 
            this.EditarCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditarCosto.HeaderText = "";
            this.EditarCosto.Name = "EditarCosto";
            this.EditarCosto.ReadOnly = true;
            this.EditarCosto.Width = 22;
            // 
            // EliminarCosto
            // 
            this.EliminarCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EliminarCosto.HeaderText = "";
            this.EliminarCosto.Name = "EliminarCosto";
            this.EliminarCosto.ReadOnly = true;
            this.EliminarCosto.Width = 22;
            // 
            // ucPaginador
            // 
            this.ucPaginador.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ucPaginador.BackColor = System.Drawing.Color.Transparent;
            this.ucPaginador.CurrentPage = 1;
            this.ucPaginador.Location = new System.Drawing.Point(5, 5);
            this.ucPaginador.Margin = new System.Windows.Forms.Padding(5);
            this.ucPaginador.Name = "ucPaginador";
            this.ucPaginador.PageSize = 10;
            this.ucPaginador.PageTotal = null;
            this.ucPaginador.Size = new System.Drawing.Size(657, 48);
            this.ucPaginador.TabIndex = 23;
            // 
            // ddlEstados
            // 
            this.ddlEstados.Alto = 34;
            this.ddlEstados.Ancho = 252;
            this.ddlEstados.DataSource = null;
            this.ddlEstados.Disabled = false;
            this.ddlEstados.DisplayMember = "";
            this.ddlEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ddlEstados.ErrorMessage = "";
            this.ddlEstados.EsObligatorio = true;
            this.ddlEstados.InvalidateChar = null;
            this.ddlEstados.Location = new System.Drawing.Point(218, 18);
            this.ddlEstados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlEstados.Name = "ddlEstados";
            this.ddlEstados.Referencia = null;
            this.ddlEstados.Size = new System.Drawing.Size(252, 34);
            this.ddlEstados.TabIndex = 6;
            this.ddlEstados.Texto = "";
            this.ddlEstados.Valor = 0;
            this.ddlEstados.ValueMember = "";
            this.ddlEstados.ComboSelectedIndexChanged += new System.EventHandler(this.ddlEstados_SelectedIndexChanged);
            // 
            // frmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 581);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGastos";
            this.Text = "Gastos";
            this.Activated += new System.EventHandler(this.frmCostos_Activated);
            this.Load += new System.EventHandler(this.frmCostos_Load);
            this.Shown += new System.EventHandler(this.frmCostos_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn excepcionRubroesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tieneExcepcionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controles.UcPaginador ucPaginador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.CheckBox chxCajaActual;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private Util.Controles.ucDropDownList ddlEstados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CajaCerrada;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
        private System.Windows.Forms.DataGridViewButtonColumn EditarCosto;
        private System.Windows.Forms.DataGridViewButtonColumn EliminarCosto;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;

    }
}