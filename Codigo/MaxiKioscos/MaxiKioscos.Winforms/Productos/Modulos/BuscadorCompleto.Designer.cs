namespace MaxiKioscos.Winforms.Productos
{
    partial class BuscadorCompleto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscadorCompleto));
            this.dvgBusqueda = new System.Windows.Forms.DataGridView();
            this.productoCompletoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chxBuscarPorMarca = new System.Windows.Forms.CheckBox();
            this.chxBuscarPorNombre = new System.Windows.Forms.CheckBox();
            this.chxBuscarPorCodigo = new System.Windows.Forms.CheckBox();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoCompletoBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgBusqueda
            // 
            this.dvgBusqueda.AllowUserToAddRows = false;
            this.dvgBusqueda.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgBusqueda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgBusqueda.AutoGenerateColumns = false;
            this.dvgBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dvgBusqueda.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgBusqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoIdDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.StockFormateado,
            this.stockDataGridViewTextBoxColumn});
            this.dvgBusqueda.DataSource = this.productoCompletoBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgBusqueda.DefaultCellStyle = dataGridViewCellStyle3;
            this.dvgBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgBusqueda.Location = new System.Drawing.Point(4, 4);
            this.dvgBusqueda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvgBusqueda.Name = "dvgBusqueda";
            this.dvgBusqueda.ReadOnly = true;
            this.dvgBusqueda.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgBusqueda.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgBusqueda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvgBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgBusqueda.Size = new System.Drawing.Size(1263, 340);
            this.dvgBusqueda.TabIndex = 0;
            this.dvgBusqueda.TabStop = false;
            this.dvgBusqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgBusqueda_CellContentClick);
            this.dvgBusqueda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgBusqueda_CellContentDoubleClick);
            this.dvgBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dvgBusqueda_KeyDown);
            // 
            // productoCompletoBindingSource
            // 
            this.productoCompletoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.ProductoCompleto);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dvgBusqueda, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.16199F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.83801F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1271, 395);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 352);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 39);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorMarca, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorNombre, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chxBuscarPorCodigo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1261, 37);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // chxBuscarPorMarca
            // 
            this.chxBuscarPorMarca.AutoSize = true;
            this.chxBuscarPorMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxBuscarPorMarca.ForeColor = System.Drawing.Color.Black;
            this.chxBuscarPorMarca.Location = new System.Drawing.Point(538, 4);
            this.chxBuscarPorMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chxBuscarPorMarca.Name = "chxBuscarPorMarca";
            this.chxBuscarPorMarca.Size = new System.Drawing.Size(180, 28);
            this.chxBuscarPorMarca.TabIndex = 10;
            this.chxBuscarPorMarca.Text = "Buscar por Marca";
            this.chxBuscarPorMarca.UseVisualStyleBackColor = true;
            this.chxBuscarPorMarca.CheckedChanged += new System.EventHandler(this.chxBuscarPorNombre_CheckedChanged);
            // 
            // chxBuscarPorNombre
            // 
            this.chxBuscarPorNombre.AutoSize = true;
            this.chxBuscarPorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxBuscarPorNombre.ForeColor = System.Drawing.Color.Black;
            this.chxBuscarPorNombre.Location = new System.Drawing.Point(271, 4);
            this.chxBuscarPorNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.chxBuscarPorCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chxBuscarPorCodigo.Name = "chxBuscarPorCodigo";
            this.chxBuscarPorCodigo.Size = new System.Drawing.Size(189, 28);
            this.chxBuscarPorCodigo.TabIndex = 7;
            this.chxBuscarPorCodigo.Text = "Buscar por Código";
            this.chxBuscarPorCodigo.UseVisualStyleBackColor = true;
            this.chxBuscarPorCodigo.CheckedChanged += new System.EventHandler(this.chxBuscarPorNombre_CheckedChanged);
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            this.productoIdDataGridViewTextBoxColumn.Width = 107;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 120;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.Width = 200;
            // 
            // StockFormateado
            // 
            this.StockFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StockFormateado.DataPropertyName = "StockFormateado";
            this.StockFormateado.HeaderText = "Stock";
            this.StockFormateado.Name = "StockFormateado";
            this.StockFormateado.ReadOnly = true;
            this.StockFormateado.Width = 80;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Visible = false;
            this.stockDataGridViewTextBoxColumn.Width = 80;
            // 
            // BuscadorCompleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1271, 395);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "BuscadorCompleto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.BuscadorCompleto_Load);
            this.Shown += new System.EventHandler(this.BuscadorCompleto_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoCompletoBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgBusqueda;
        private System.Windows.Forms.BindingSource productoCompletoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chxBuscarPorNombre;
        private System.Windows.Forms.CheckBox chxBuscarPorCodigo;
        private System.Windows.Forms.CheckBox chxBuscarPorMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
    }
}