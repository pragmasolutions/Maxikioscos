namespace MaxiKioscos.Winforms.ControlStock
{
    partial class frmDetalleControlStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleControlStock));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFechaCorreccion = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEstado = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtFecha = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProveedor = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtRubro = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.controlStockDetalleGridStructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlStockDetalleIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlStockDetalleGridStructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(249, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Control de Stock";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFechaCorreccion);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Controls.Add(this.txtRubro);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.dgvDetalles);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 441);
            this.panel1.TabIndex = 1;
            // 
            // txtFechaCorreccion
            // 
            this.txtFechaCorreccion.Location = new System.Drawing.Point(532, 42);
            this.txtFechaCorreccion.Name = "txtFechaCorreccion";
            this.txtFechaCorreccion.Size = new System.Drawing.Size(203, 26);
            this.txtFechaCorreccion.TabIndex = 37;
            this.txtFechaCorreccion.Texto = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(528, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 20);
            this.label16.TabIndex = 40;
            this.label16.Text = "Fecha Corrección";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(272, 108);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(203, 26);
            this.txtEstado.TabIndex = 34;
            this.txtEstado.Texto = "";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(21, 108);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(203, 26);
            this.txtFecha.TabIndex = 33;
            this.txtFecha.Texto = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 20);
            this.label14.TabIndex = 36;
            this.label14.Text = "Fecha";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(268, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 20);
            this.label15.TabIndex = 35;
            this.label15.Text = "Estado";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(272, 42);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(203, 26);
            this.txtProveedor.TabIndex = 30;
            this.txtProveedor.Texto = "";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(21, 42);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(203, 26);
            this.txtRubro.TabIndex = 29;
            this.txtRubro.Texto = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 20);
            this.label26.TabIndex = 32;
            this.label26.Text = "Rubro";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(268, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 20);
            this.label25.TabIndex = 31;
            this.label25.Text = "Proveedor";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalles.AutoGenerateColumns = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalles.ColumnHeadersHeight = 31;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.controlStockDetalleIdDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.correccionDataGridViewTextBoxColumn,
            this.motivoDataGridViewTextBoxColumn});
            this.dgvDetalles.DataSource = this.controlStockDetalleGridStructBindingSource;
            this.dgvDetalles.Location = new System.Drawing.Point(21, 153);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(714, 271);
            this.dgvDetalles.TabIndex = 28;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(592, 495);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Cerrar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // controlStockDetalleGridStructBindingSource
            // 
            this.controlStockDetalleGridStructBindingSource.DataSource = typeof(MaxiKioscos.Winforms.DataStruct.ControlStockDetalleGridStruct);
            // 
            // controlStockDetalleIdDataGridViewTextBoxColumn
            // 
            this.controlStockDetalleIdDataGridViewTextBoxColumn.DataPropertyName = "ControlStockDetalleId";
            this.controlStockDetalleIdDataGridViewTextBoxColumn.HeaderText = "ControlStockDetalleId";
            this.controlStockDetalleIdDataGridViewTextBoxColumn.Name = "controlStockDetalleIdDataGridViewTextBoxColumn";
            this.controlStockDetalleIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.controlStockDetalleIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 110;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 80;
            // 
            // correccionDataGridViewTextBoxColumn
            // 
            this.correccionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.correccionDataGridViewTextBoxColumn.DataPropertyName = "Correccion";
            this.correccionDataGridViewTextBoxColumn.HeaderText = "Correccion";
            this.correccionDataGridViewTextBoxColumn.Name = "correccionDataGridViewTextBoxColumn";
            this.correccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.correccionDataGridViewTextBoxColumn.Width = 80;
            // 
            // motivoDataGridViewTextBoxColumn
            // 
            this.motivoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.motivoDataGridViewTextBoxColumn.DataPropertyName = "Motivo";
            this.motivoDataGridViewTextBoxColumn.HeaderText = "Motivo Corrección";
            this.motivoDataGridViewTextBoxColumn.Name = "motivoDataGridViewTextBoxColumn";
            this.motivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.motivoDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmDetalleControlStock
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 540);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDetalleControlStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Control de Stock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlStockDetalleGridStructBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFechaCorreccion;
        private System.Windows.Forms.Label label16;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtEstado;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtProveedor;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtRubro;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.BindingSource controlStockDetalleGridStructBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlStockDetalleIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoDataGridViewTextBoxColumn;
        
        
    }
}