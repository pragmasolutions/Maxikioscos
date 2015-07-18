namespace MaxiKioscos.Winforms.Excepciones
{
    partial class frmGestionExcepciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionExcepciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.excepcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.excepcionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cierreCajaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCargaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ExcEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ExcEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.ucPaginador = new MaxiKioscos.Winforms.Controles.UcPaginador();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.excepcionBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // excepcionBindingSource
            // 
            this.excepcionBindingSource.DataSource = typeof(MaxiKioscos.Entidades.Excepcion);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 469);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 64);
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(15, 22);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(248, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.AllowUserToResizeRows = false;
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
            this.excepcionIdDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.cierreCajaIdDataGridViewTextBoxColumn,
            this.fechaCargaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn,
            this.ExcDetalle,
            this.ExcEditar,
            this.ExcEliminar});
            this.dgvListado.DataSource = this.excepcionBindingSource;
            this.dgvListado.Location = new System.Drawing.Point(3, 121);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.RowTemplate.Height = 30;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(837, 345);
            this.dgvListado.TabIndex = 22;
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            this.dgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvListado_CellPainting);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // excepcionIdDataGridViewTextBoxColumn
            // 
            this.excepcionIdDataGridViewTextBoxColumn.DataPropertyName = "ExcepcionId";
            this.excepcionIdDataGridViewTextBoxColumn.HeaderText = "ExcepcionId";
            this.excepcionIdDataGridViewTextBoxColumn.Name = "excepcionIdDataGridViewTextBoxColumn";
            this.excepcionIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.excepcionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // cierreCajaIdDataGridViewTextBoxColumn
            // 
            this.cierreCajaIdDataGridViewTextBoxColumn.DataPropertyName = "CierreCajaId";
            this.cierreCajaIdDataGridViewTextBoxColumn.HeaderText = "CierreCajaId";
            this.cierreCajaIdDataGridViewTextBoxColumn.Name = "cierreCajaIdDataGridViewTextBoxColumn";
            this.cierreCajaIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cierreCajaIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCargaDataGridViewTextBoxColumn
            // 
            this.fechaCargaDataGridViewTextBoxColumn.DataPropertyName = "FechaCarga";
            this.fechaCargaDataGridViewTextBoxColumn.HeaderText = "Fecha de Carga";
            this.fechaCargaDataGridViewTextBoxColumn.Name = "fechaCargaDataGridViewTextBoxColumn";
            this.fechaCargaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCargaDataGridViewTextBoxColumn.Width = 150;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ExcDetalle
            // 
            this.ExcDetalle.FillWeight = 92.71886F;
            this.ExcDetalle.HeaderText = "";
            this.ExcDetalle.Name = "ExcDetalle";
            this.ExcDetalle.ReadOnly = true;
            this.ExcDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcDetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExcDetalle.Width = 22;
            // 
            // ExcEditar
            // 
            this.ExcEditar.FillWeight = 91.12937F;
            this.ExcEditar.HeaderText = "";
            this.ExcEditar.Name = "ExcEditar";
            this.ExcEditar.ReadOnly = true;
            this.ExcEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExcEditar.Width = 22;
            // 
            // ExcEliminar
            // 
            this.ExcEliminar.FillWeight = 89.3401F;
            this.ExcEliminar.HeaderText = "";
            this.ExcEliminar.Name = "ExcEliminar";
            this.ExcEliminar.ReadOnly = true;
            this.ExcEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ExcEliminar.Width = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.ucPaginador);
            this.panel2.Controls.Add(this.btnAgregarFactura);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 42);
            this.panel2.TabIndex = 23;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(746, 16);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 23);
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
            this.btnAgregarFactura.Location = new System.Drawing.Point(668, 16);
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
            // frmGestionExcepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmGestionExcepciones";
            this.Text = "Gestión de Excepciones";
            this.Activated += new System.EventHandler(this.frmGestionExcepciones_Activated);
            this.Load += new System.EventHandler(this.frmGestionExcepciones_Load);
            this.Shown += new System.EventHandler(this.frmGestionExcepciones_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGestionExcepciones_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.excepcionBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource excepcionBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Panel panel2;
        private Controles.UcPaginador ucPaginador;
        private System.Windows.Forms.Button btnAgregarFactura;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn excepcionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cierreCajaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCargaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ExcDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn ExcEditar;
        private System.Windows.Forms.DataGridViewButtonColumn ExcEliminar;
        private System.Windows.Forms.Button btnActualizar;

    }
}