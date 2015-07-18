using MaxiKioscos.Winforms.Controles;

namespace MaxiKioscos.Winforms.Facturas
{
    partial class FrmGestionFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionFacturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.facturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.facturaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacturaNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CierreCajaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioCreador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacturaDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FacturaEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FacturaEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource1)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvListado, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 457);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 64);
            this.panel1.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(290, 20);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar [F6]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.Actualizar);
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(15, 22);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(248, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Controls.Add(this.btnAgregarFactura);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 42);
            this.panel2.TabIndex = 23;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(728, 16);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 23);
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
            this.ucPaginador.Location = new System.Drawing.Point(0, 0);
            this.ucPaginador.Name = "ucPaginador";
            this.ucPaginador.PageSize = 10;
            this.ucPaginador.PageTotal = null;
            this.ucPaginador.Size = new System.Drawing.Size(484, 39);
            this.ucPaginador.TabIndex = 23;
            // 
            // btnAgregarFactura
            // 
            this.btnAgregarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarFactura.Image")));
            this.btnAgregarFactura.Location = new System.Drawing.Point(650, 16);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(72, 23);
            this.btnAgregarFactura.TabIndex = 24;
            this.btnAgregarFactura.Text = "Agregar";
            this.btnAgregarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.btnAgregarFactura_Click);
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
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeight = 31;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.FacturaNro,
            this.Proveedor,
            this.CierreCajaId,
            this.UsuarioCreador,
            this.ImporteTotal,
            this.dataGridViewTextBoxColumn1,
            this.AutoNumero,
            this.FacturaDetalle,
            this.FacturaEditar,
            this.FacturaEliminar});
            this.dgvListado.DataSource = this.facturaBindingSource1;
            this.dgvListado.Location = new System.Drawing.Point(3, 121);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.RowTemplate.Height = 30;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(815, 333);
            this.dgvListado.TabIndex = 22;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick_1);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting_1);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // facturaBindingSource1
            // 
            this.facturaBindingSource1.DataSource = typeof(MaxiKioscos.Entidades.Factura);
            // 
            // dataGridViewButtonColumn1
            // 
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
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn3.Visible = false;
            this.dataGridViewButtonColumn3.Width = 22;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.FillWeight = 105.3623F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // FacturaNro
            // 
            this.FacturaNro.DataPropertyName = "FacturaNro";
            this.FacturaNro.FillWeight = 105.3623F;
            this.FacturaNro.HeaderText = "Nro. Factura";
            this.FacturaNro.Name = "FacturaNro";
            this.FacturaNro.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Proveedor.DataPropertyName = "ProveedorNombre";
            this.Proveedor.FillWeight = 105.3623F;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // CierreCajaId
            // 
            this.CierreCajaId.DataPropertyName = "CierreCajaId";
            this.CierreCajaId.FillWeight = 105.3623F;
            this.CierreCajaId.HeaderText = "CierreCajaId";
            this.CierreCajaId.Name = "CierreCajaId";
            this.CierreCajaId.ReadOnly = true;
            this.CierreCajaId.Visible = false;
            this.CierreCajaId.Width = 136;
            // 
            // UsuarioCreador
            // 
            this.UsuarioCreador.DataPropertyName = "NombreUsuario";
            this.UsuarioCreador.HeaderText = "Usuario";
            this.UsuarioCreador.Name = "UsuarioCreador";
            this.UsuarioCreador.ReadOnly = true;
            // 
            // ImporteTotal
            // 
            this.ImporteTotal.DataPropertyName = "ImporteTotal";
            this.ImporteTotal.HeaderText = "Importe";
            this.ImporteTotal.Name = "ImporteTotal";
            this.ImporteTotal.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FacturaId";
            this.dataGridViewTextBoxColumn1.HeaderText = "FacturaId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // AutoNumero
            // 
            this.AutoNumero.DataPropertyName = "AutoNumero";
            this.AutoNumero.HeaderText = "Auto Numero";
            this.AutoNumero.Name = "AutoNumero";
            this.AutoNumero.ReadOnly = true;
            // 
            // FacturaDetalle
            // 
            this.FacturaDetalle.FillWeight = 92.71886F;
            this.FacturaDetalle.HeaderText = "";
            this.FacturaDetalle.Name = "FacturaDetalle";
            this.FacturaDetalle.ReadOnly = true;
            this.FacturaDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FacturaDetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FacturaDetalle.Width = 22;
            // 
            // FacturaEditar
            // 
            this.FacturaEditar.FillWeight = 91.12937F;
            this.FacturaEditar.HeaderText = "";
            this.FacturaEditar.Name = "FacturaEditar";
            this.FacturaEditar.ReadOnly = true;
            this.FacturaEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FacturaEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FacturaEditar.Visible = false;
            this.FacturaEditar.Width = 22;
            // 
            // FacturaEliminar
            // 
            this.FacturaEliminar.FillWeight = 89.3401F;
            this.FacturaEliminar.HeaderText = "";
            this.FacturaEliminar.Name = "FacturaEliminar";
            this.FacturaEliminar.ReadOnly = true;
            this.FacturaEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FacturaEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FacturaEliminar.Visible = false;
            this.FacturaEliminar.Width = 22;
            // 
            // FrmGestionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 457);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestionFacturas";
            this.Text = "Facturas";
            this.Activated += new System.EventHandler(this.FrmGestionFacturas_Activated);
            this.Load += new System.EventHandler(this.frmGestionFacturas_Load);
            this.Shown += new System.EventHandler(this.FrmGestionFacturas_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource facturaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource facturaBindingSource1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregarFactura;
        private UcPaginador ucPaginador;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacturaNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CierreCajaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioCreador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoNumero;
        private System.Windows.Forms.DataGridViewButtonColumn FacturaDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn FacturaEditar;
        private System.Windows.Forms.DataGridViewButtonColumn FacturaEliminar;
    }
}