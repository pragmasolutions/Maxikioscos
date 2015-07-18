using MaxiKioscos.Winforms.Controles;

namespace MaxiKioscos.Winforms.CorreccionesStock
{
    partial class frmGestionCorreccionStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionCorreccionStock));
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correccionStockIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoCorreccionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxiKioscoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoCorreccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxiKioscoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.correccionStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.facturaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correccionStockBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.dgvListado, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 640);
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
            this.panel1.Size = new System.Drawing.Size(1111, 64);
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
            this.descripcionDataGridViewTextBoxColumn,
            this.ProductoId,
            this.Cantidad,
            this.Precio,
            this.correccionStockIdDataGridViewTextBoxColumn,
            this.productoIdDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.motivoCorreccionIdDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.maxiKioscoIdDataGridViewTextBoxColumn,
            this.motivoCorreccionDataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.maxiKioscoDataGridViewTextBoxColumn,
            this.Search,
            this.editar});
            this.dgvListado.DataSource = this.correccionStockBindingSource;
            this.dgvListado.Location = new System.Drawing.Point(3, 121);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.RowTemplate.Height = 30;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(1111, 516);
            this.dgvListado.TabIndex = 22;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick_1);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "CantidadModificada";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // correccionStockIdDataGridViewTextBoxColumn
            // 
            this.correccionStockIdDataGridViewTextBoxColumn.DataPropertyName = "CorreccionStockId";
            this.correccionStockIdDataGridViewTextBoxColumn.HeaderText = "CorreccionStockId";
            this.correccionStockIdDataGridViewTextBoxColumn.Name = "correccionStockIdDataGridViewTextBoxColumn";
            this.correccionStockIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.correccionStockIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioDataGridViewTextBoxColumn.Visible = false;
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
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "Ultima Modificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Width = 200;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // motivoCorreccionIdDataGridViewTextBoxColumn
            // 
            this.motivoCorreccionIdDataGridViewTextBoxColumn.DataPropertyName = "MotivoCorreccionId";
            this.motivoCorreccionIdDataGridViewTextBoxColumn.HeaderText = "MotivoCorreccionId";
            this.motivoCorreccionIdDataGridViewTextBoxColumn.Name = "motivoCorreccionIdDataGridViewTextBoxColumn";
            this.motivoCorreccionIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.motivoCorreccionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Visible = false;
            // 
            // maxiKioscoIdDataGridViewTextBoxColumn
            // 
            this.maxiKioscoIdDataGridViewTextBoxColumn.DataPropertyName = "MaxiKioscoId";
            this.maxiKioscoIdDataGridViewTextBoxColumn.HeaderText = "MaxiKioscoId";
            this.maxiKioscoIdDataGridViewTextBoxColumn.Name = "maxiKioscoIdDataGridViewTextBoxColumn";
            this.maxiKioscoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxiKioscoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // motivoCorreccionDataGridViewTextBoxColumn
            // 
            this.motivoCorreccionDataGridViewTextBoxColumn.DataPropertyName = "Motivo";
            this.motivoCorreccionDataGridViewTextBoxColumn.HeaderText = "Motivo";
            this.motivoCorreccionDataGridViewTextBoxColumn.Name = "motivoCorreccionDataGridViewTextBoxColumn";
            this.motivoCorreccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.motivoCorreccionDataGridViewTextBoxColumn.Width = 200;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoDataGridViewTextBoxColumn.Visible = false;
            // 
            // maxiKioscoDataGridViewTextBoxColumn
            // 
            this.maxiKioscoDataGridViewTextBoxColumn.DataPropertyName = "MaxiKiosco";
            this.maxiKioscoDataGridViewTextBoxColumn.HeaderText = "MaxiKiosco";
            this.maxiKioscoDataGridViewTextBoxColumn.Name = "maxiKioscoDataGridViewTextBoxColumn";
            this.maxiKioscoDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxiKioscoDataGridViewTextBoxColumn.Visible = false;
            // 
            // Search
            // 
            this.Search.HeaderText = "";
            this.Search.Name = "Search";
            this.Search.ReadOnly = true;
            this.Search.Width = 22;
            // 
            // editar
            // 
            this.editar.HeaderText = "";
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Width = 22;
            // 
            // correccionStockBindingSource
            // 
            this.correccionStockBindingSource.DataSource = typeof(MaxiKioscos.Entidades.CorreccionStock);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Controls.Add(this.btnAgregarFactura);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 42);
            this.panel2.TabIndex = 23;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(1021, 16);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(81, 23);
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
            this.btnAgregarFactura.Location = new System.Drawing.Point(943, 16);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(72, 23);
            this.btnAgregarFactura.TabIndex = 24;
            this.btnAgregarFactura.Text = "Agregar";
            this.btnAgregarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.btnAgregarFactura_Click);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FillWeight = 92.71886F;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Width = 22;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.FillWeight = 91.12937F;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
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
            // facturaBindingSource1
            // 
            this.facturaBindingSource1.DataSource = typeof(MaxiKioscos.Entidades.Factura);
            // 
            // frmGestionCorreccionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1117, 640);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestionCorreccionStock";
            this.Text = "Retiro de Mercadería";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmGestionCorreccionStock_Activated);
            this.Load += new System.EventHandler(this.frmGestionCorreccionStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correccionStockBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.BindingSource correccionStockBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn correccionStockIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoCorreccionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxiKioscoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoCorreccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxiKioscoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Search;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.Button btnActualizar;
    }
}