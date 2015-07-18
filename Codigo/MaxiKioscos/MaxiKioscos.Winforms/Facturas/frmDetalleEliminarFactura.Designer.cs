namespace MaxiKioscos.Winforms.Facturas
{
    partial class frmDetalleEliminarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleEliminarFactura));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucAutonumerico = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProveedor = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtFecha = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtImporteTotal = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtFacturaNro = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvCompraProductos = new System.Windows.Forms.DataGridView();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioActualizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraProductoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(172, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Factura";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 363);
            this.panel1.TabIndex = 12;
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
            this.tabPage1.Controls.Add(this.ucAutonumerico);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtProveedor);
            this.tabPage1.Controls.Add(this.txtFecha);
            this.tabPage1.Controls.Add(this.txtImporteTotal);
            this.tabPage1.Controls.Add(this.txtFacturaNro);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label25);
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
            // ucAutonumerico
            // 
            this.ucAutonumerico.Location = new System.Drawing.Point(278, 46);
            this.ucAutonumerico.Name = "ucAutonumerico";
            this.ucAutonumerico.Size = new System.Drawing.Size(203, 26);
            this.ucAutonumerico.TabIndex = 3;
            this.ucAutonumerico.Texto = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(274, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Autonumérico";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(29, 167);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(203, 26);
            this.txtProveedor.TabIndex = 2;
            this.txtProveedor.Texto = "";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(29, 109);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(203, 26);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.Texto = "";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Location = new System.Drawing.Point(278, 109);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(203, 26);
            this.txtImporteTotal.TabIndex = 4;
            this.txtImporteTotal.Texto = "";
            // 
            // txtFacturaNro
            // 
            this.txtFacturaNro.Location = new System.Drawing.Point(29, 46);
            this.txtFacturaNro.Name = "txtFacturaNro";
            this.txtFacturaNro.Size = new System.Drawing.Size(203, 26);
            this.txtFacturaNro.TabIndex = 0;
            this.txtFacturaNro.Texto = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(25, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(106, 20);
            this.label26.TabIndex = 21;
            this.label26.Text = "Factura Número";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(274, 86);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 20);
            this.label25.TabIndex = 20;
            this.label25.Text = "Importe Total";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(25, 144);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "Proveedor";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(25, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Fecha";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvCompraProductos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCompraProductos
            // 
            this.dgvCompraProductos.AllowUserToAddRows = false;
            this.dgvCompraProductos.AllowUserToDeleteRows = false;
            this.dgvCompraProductos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCompraProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompraProductos.AutoGenerateColumns = false;
            this.dgvCompraProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompraProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompraProductos.ColumnHeadersHeight = 31;
            this.dgvCompraProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.PrecioActualizado});
            this.dgvCompraProductos.DataSource = this.compraProductoBindingSource;
            this.dgvCompraProductos.Location = new System.Drawing.Point(24, 24);
            this.dgvCompraProductos.MultiSelect = false;
            this.dgvCompraProductos.Name = "dgvCompraProductos";
            this.dgvCompraProductos.ReadOnly = true;
            this.dgvCompraProductos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCompraProductos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompraProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompraProductos.Size = new System.Drawing.Size(454, 265);
            this.dgvCompraProductos.TabIndex = 23;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "ProductoNombre";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PrecioActualizado
            // 
            this.PrecioActualizado.DataPropertyName = "PrecioActualizado";
            this.PrecioActualizado.HeaderText = "Precio";
            this.PrecioActualizado.Name = "PrecioActualizado";
            this.PrecioActualizado.ReadOnly = true;
            // 
            // compraProductoBindingSource
            // 
            this.compraProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.CompraProducto);
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
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Cerrar";
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
            this.btnCancelar.Location = new System.Drawing.Point(391, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // frmDetalleEliminarFactura
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(541, 465);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetalleEliminarFactura";
            this.Text = "Detalle de Factura";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraProductoBindingSource)).EndInit();
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
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtProveedor;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFecha;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtImporteTotal;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFacturaNro;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCompraProductos;
        private System.Windows.Forms.BindingSource compraProductoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioActualizado;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucAutonumerico;
        private System.Windows.Forms.Label label14;
        
        
    }
}