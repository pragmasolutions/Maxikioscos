namespace MaxiKioscos.Winforms.Transferencias.Modulos
{
    partial class frmBuscadorTransferencia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscadorTransferencia));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chxBuscarPorMarca = new System.Windows.Forms.CheckBox();
            this.chxBuscarPorNombre = new System.Windows.Forms.CheckBox();
            this.chxBuscarPorCodigo = new System.Windows.Forms.CheckBox();
            this.productoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitarioFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActualFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendidoEnUltimoMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendidoEnUltimoMesFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoId,
            this.codigoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.marca,
            this.PrecioUnitarioFormateado,
            this.StockActualFormateado,
            this.precio,
            this.stockActual,
            this.VendidoEnUltimoMes,
            this.VendidoEnUltimoMesFormateado});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(4, 4);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(1271, 264);
            this.dgvListado.TabIndex = 5;
            this.dgvListado.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvListado, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.32819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.67181F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1279, 319);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 276);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 39);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.12469F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87531F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 622F));
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorMarca, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorNombre, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorCodigo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1269, 37);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // chxBuscarPorMarca
            // 
            this.chxBuscarPorMarca.AutoSize = true;
            this.chxBuscarPorMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxBuscarPorMarca.ForeColor = System.Drawing.Color.Black;
            this.chxBuscarPorMarca.Location = new System.Drawing.Point(650, 4);
            this.chxBuscarPorMarca.Margin = new System.Windows.Forms.Padding(4);
            this.chxBuscarPorMarca.Name = "chxBuscarPorMarca";
            this.chxBuscarPorMarca.Size = new System.Drawing.Size(180, 28);
            this.chxBuscarPorMarca.TabIndex = 9;
            this.chxBuscarPorMarca.Text = "Buscar por Marca";
            this.chxBuscarPorMarca.UseVisualStyleBackColor = true;
            this.chxBuscarPorMarca.CheckedChanged += new System.EventHandler(this.chxBuscarPorNombre_CheckedChanged);
            // 
            // chxBuscarPorNombre
            // 
            this.chxBuscarPorNombre.AutoSize = true;
            this.chxBuscarPorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxBuscarPorNombre.ForeColor = System.Drawing.Color.Black;
            this.chxBuscarPorNombre.Location = new System.Drawing.Point(328, 4);
            this.chxBuscarPorNombre.Margin = new System.Windows.Forms.Padding(4);
            this.chxBuscarPorNombre.Name = "chxBuscarPorNombre";
            this.chxBuscarPorNombre.Size = new System.Drawing.Size(197, 28);
            this.chxBuscarPorNombre.TabIndex = 8;
            this.chxBuscarPorNombre.Text = "Buscar por Nombre";
            this.chxBuscarPorNombre.UseVisualStyleBackColor = true;
            this.chxBuscarPorNombre.CheckedChanged += new System.EventHandler(this.chxBuscarPorNombre_CheckedChanged);
            // 
            // chxBuscarPorCodigo
            // 
            this.chxBuscarPorCodigo.AutoSize = true;
            this.chxBuscarPorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxBuscarPorCodigo.ForeColor = System.Drawing.Color.Black;
            this.chxBuscarPorCodigo.Location = new System.Drawing.Point(4, 4);
            this.chxBuscarPorCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.chxBuscarPorCodigo.Name = "chxBuscarPorCodigo";
            this.chxBuscarPorCodigo.Size = new System.Drawing.Size(189, 28);
            this.chxBuscarPorCodigo.TabIndex = 7;
            this.chxBuscarPorCodigo.Text = "Buscar por Código";
            this.chxBuscarPorCodigo.UseVisualStyleBackColor = true;
            this.chxBuscarPorCodigo.CheckedChanged += new System.EventHandler(this.chxBuscarPorNombre_CheckedChanged);
            // 
            // productoId
            // 
            this.productoId.DataPropertyName = "ProductoId";
            this.productoId.HeaderText = "ProductoId";
            this.productoId.Name = "productoId";
            this.productoId.ReadOnly = true;
            this.productoId.Visible = false;
            this.productoId.Width = 146;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 130;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.marca.DataPropertyName = "Marca";
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 165;
            // 
            // PrecioUnitarioFormateado
            // 
            this.PrecioUnitarioFormateado.DataPropertyName = "PrecioUnitarioFormateado";
            this.PrecioUnitarioFormateado.HeaderText = "Precio";
            this.PrecioUnitarioFormateado.Name = "PrecioUnitarioFormateado";
            this.PrecioUnitarioFormateado.ReadOnly = true;
            this.PrecioUnitarioFormateado.Width = 114;
            // 
            // StockActualFormateado
            // 
            this.StockActualFormateado.DataPropertyName = "StockActualFormateado";
            this.StockActualFormateado.HeaderText = "Stock Actual";
            this.StockActualFormateado.Name = "StockActualFormateado";
            this.StockActualFormateado.ReadOnly = true;
            this.StockActualFormateado.Width = 181;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.precio.DefaultCellStyle = dataGridViewCellStyle3;
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Visible = false;
            this.precio.Width = 114;
            // 
            // stockActual
            // 
            this.stockActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stockActual.DataPropertyName = "StockActual";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.stockActual.DefaultCellStyle = dataGridViewCellStyle4;
            this.stockActual.HeaderText = "Stock Actual";
            this.stockActual.Name = "stockActual";
            this.stockActual.ReadOnly = true;
            this.stockActual.Visible = false;
            this.stockActual.Width = 135;
            // 
            // VendidoEnUltimoMes
            // 
            this.VendidoEnUltimoMes.DataPropertyName = "VendidoEnUltimoMes";
            this.VendidoEnUltimoMes.HeaderText = "VendidoUltimoMes";
            this.VendidoEnUltimoMes.Name = "VendidoEnUltimoMes";
            this.VendidoEnUltimoMes.ReadOnly = true;
            this.VendidoEnUltimoMes.Visible = false;
            this.VendidoEnUltimoMes.Width = 259;
            // 
            // VendidoEnUltimoMesFormateado
            // 
            this.VendidoEnUltimoMesFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VendidoEnUltimoMesFormateado.DataPropertyName = "VendidoEnUltimoMesFormateado";
            this.VendidoEnUltimoMesFormateado.HeaderText = "Vendido Ultimo Mes";
            this.VendidoEnUltimoMesFormateado.Name = "VendidoEnUltimoMesFormateado";
            this.VendidoEnUltimoMesFormateado.ReadOnly = true;
            this.VendidoEnUltimoMesFormateado.Width = 190;
            // 
            // frmBuscadorTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1279, 319);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBuscadorTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Buscar artículo";
            this.Load += new System.EventHandler(this.frmBuscador_Load);
            this.Shown += new System.EventHandler(this.frmBuscador_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscador_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chxBuscarPorNombre;
        private System.Windows.Forms.CheckBox chxBuscarPorCodigo;
        private System.Windows.Forms.CheckBox chxBuscarPorMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitarioFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActualFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendidoEnUltimoMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendidoEnUltimoMesFormateado;
    }
}