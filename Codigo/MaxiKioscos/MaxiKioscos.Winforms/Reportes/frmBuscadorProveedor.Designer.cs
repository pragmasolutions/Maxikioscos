namespace MaxiKioscos.Winforms.Reportes
{
    partial class frmBuscadorProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscadorProveedor));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCuitStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuitNroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCuitIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paginaWebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cuentaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percepcionDGRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cuentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCuitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioProveedoresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlesStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proveedorId,
            this.nombreDataGridViewTextBoxColumn,
            this.contactoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.celularDataGridViewTextBoxColumn,
            this.tipoCuitStringDataGridViewTextBoxColumn,
            this.cuitNroDataGridViewTextBoxColumn,
            this.localidadStringDataGridViewTextBoxColumn,
            this.tipoCuitIdDataGridViewTextBoxColumn,
            this.localidadIdDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.paginaWebDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.cuentaIdDataGridViewTextBoxColumn,
            this.percepcionDGRDataGridViewTextBoxColumn,
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn,
            this.cuentaDataGridViewTextBoxColumn,
            this.facturasDataGridViewTextBoxColumn,
            this.localidadDataGridViewTextBoxColumn,
            this.tipoCuitDataGridViewTextBoxColumn,
            this.usuarioProveedoresDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.controlesStockDataGridViewTextBoxColumn});
            this.dgvListado.DataSource = this.proveedorBindingSource;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(0, 0);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(470, 204);
            this.dgvListado.TabIndex = 5;
            this.dgvListado.TabStop = false;
            // 
            // proveedorBindingSource
            // 
            this.proveedorBindingSource.DataSource = typeof(MaxiKioscos.Entidades.Proveedor);
            // 
            // proveedorId
            // 
            this.proveedorId.DataPropertyName = "ProveedorId";
            this.proveedorId.HeaderText = "ProveedorId";
            this.proveedorId.Name = "proveedorId";
            this.proveedorId.ReadOnly = true;
            this.proveedorId.Visible = false;
            this.proveedorId.Width = 94;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactoDataGridViewTextBoxColumn
            // 
            this.contactoDataGridViewTextBoxColumn.DataPropertyName = "Contacto";
            this.contactoDataGridViewTextBoxColumn.HeaderText = "Contacto";
            this.contactoDataGridViewTextBoxColumn.Name = "contactoDataGridViewTextBoxColumn";
            this.contactoDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactoDataGridViewTextBoxColumn.Visible = false;
            this.contactoDataGridViewTextBoxColumn.Width = 94;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionDataGridViewTextBoxColumn.Visible = false;
            this.direccionDataGridViewTextBoxColumn.Width = 96;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Teléfono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Visible = false;
            this.telefonoDataGridViewTextBoxColumn.Width = 91;
            // 
            // celularDataGridViewTextBoxColumn
            // 
            this.celularDataGridViewTextBoxColumn.DataPropertyName = "Celular";
            this.celularDataGridViewTextBoxColumn.HeaderText = "Celular";
            this.celularDataGridViewTextBoxColumn.Name = "celularDataGridViewTextBoxColumn";
            this.celularDataGridViewTextBoxColumn.ReadOnly = true;
            this.celularDataGridViewTextBoxColumn.Visible = false;
            this.celularDataGridViewTextBoxColumn.Width = 79;
            // 
            // tipoCuitStringDataGridViewTextBoxColumn
            // 
            this.tipoCuitStringDataGridViewTextBoxColumn.DataPropertyName = "TipoCuitString";
            this.tipoCuitStringDataGridViewTextBoxColumn.HeaderText = "Tipo CUIT";
            this.tipoCuitStringDataGridViewTextBoxColumn.Name = "tipoCuitStringDataGridViewTextBoxColumn";
            this.tipoCuitStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCuitStringDataGridViewTextBoxColumn.Visible = false;
            // 
            // cuitNroDataGridViewTextBoxColumn
            // 
            this.cuitNroDataGridViewTextBoxColumn.DataPropertyName = "CuitNro";
            this.cuitNroDataGridViewTextBoxColumn.HeaderText = "Nro. CUIT";
            this.cuitNroDataGridViewTextBoxColumn.Name = "cuitNroDataGridViewTextBoxColumn";
            this.cuitNroDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuitNroDataGridViewTextBoxColumn.Visible = false;
            // 
            // localidadStringDataGridViewTextBoxColumn
            // 
            this.localidadStringDataGridViewTextBoxColumn.DataPropertyName = "LocalidadString";
            this.localidadStringDataGridViewTextBoxColumn.HeaderText = "Localidad";
            this.localidadStringDataGridViewTextBoxColumn.Name = "localidadStringDataGridViewTextBoxColumn";
            this.localidadStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.localidadStringDataGridViewTextBoxColumn.Visible = false;
            this.localidadStringDataGridViewTextBoxColumn.Width = 96;
            // 
            // tipoCuitIdDataGridViewTextBoxColumn
            // 
            this.tipoCuitIdDataGridViewTextBoxColumn.DataPropertyName = "TipoCuitId";
            this.tipoCuitIdDataGridViewTextBoxColumn.HeaderText = "TipoCuitId";
            this.tipoCuitIdDataGridViewTextBoxColumn.Name = "tipoCuitIdDataGridViewTextBoxColumn";
            this.tipoCuitIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCuitIdDataGridViewTextBoxColumn.Visible = false;
            this.tipoCuitIdDataGridViewTextBoxColumn.Width = 99;
            // 
            // localidadIdDataGridViewTextBoxColumn
            // 
            this.localidadIdDataGridViewTextBoxColumn.DataPropertyName = "LocalidadId";
            this.localidadIdDataGridViewTextBoxColumn.HeaderText = "LocalidadId";
            this.localidadIdDataGridViewTextBoxColumn.Name = "localidadIdDataGridViewTextBoxColumn";
            this.localidadIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.localidadIdDataGridViewTextBoxColumn.Visible = false;
            this.localidadIdDataGridViewTextBoxColumn.Width = 107;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Visible = false;
            this.emailDataGridViewTextBoxColumn.Width = 70;
            // 
            // paginaWebDataGridViewTextBoxColumn
            // 
            this.paginaWebDataGridViewTextBoxColumn.DataPropertyName = "PaginaWeb";
            this.paginaWebDataGridViewTextBoxColumn.HeaderText = "PaginaWeb";
            this.paginaWebDataGridViewTextBoxColumn.Name = "paginaWebDataGridViewTextBoxColumn";
            this.paginaWebDataGridViewTextBoxColumn.ReadOnly = true;
            this.paginaWebDataGridViewTextBoxColumn.Visible = false;
            this.paginaWebDataGridViewTextBoxColumn.Width = 109;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionesDataGridViewTextBoxColumn.Visible = false;
            this.observacionesDataGridViewTextBoxColumn.Width = 133;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            this.identifierDataGridViewTextBoxColumn.Width = 87;
            // 
            // desincronizadoDataGridViewCheckBoxColumn
            // 
            this.desincronizadoDataGridViewCheckBoxColumn.DataPropertyName = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.HeaderText = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.Name = "desincronizadoDataGridViewCheckBoxColumn";
            this.desincronizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.desincronizadoDataGridViewCheckBoxColumn.Visible = false;
            this.desincronizadoDataGridViewCheckBoxColumn.Width = 118;
            // 
            // fechaUltimaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Width = 200;
            // 
            // eliminadoDataGridViewCheckBoxColumn
            // 
            this.eliminadoDataGridViewCheckBoxColumn.DataPropertyName = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.HeaderText = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.Name = "eliminadoDataGridViewCheckBoxColumn";
            this.eliminadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eliminadoDataGridViewCheckBoxColumn.Visible = false;
            this.eliminadoDataGridViewCheckBoxColumn.Width = 79;
            // 
            // cuentaIdDataGridViewTextBoxColumn
            // 
            this.cuentaIdDataGridViewTextBoxColumn.DataPropertyName = "CuentaId";
            this.cuentaIdDataGridViewTextBoxColumn.HeaderText = "CuentaId";
            this.cuentaIdDataGridViewTextBoxColumn.Name = "cuentaIdDataGridViewTextBoxColumn";
            this.cuentaIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaIdDataGridViewTextBoxColumn.Visible = false;
            this.cuentaIdDataGridViewTextBoxColumn.Width = 91;
            // 
            // percepcionDGRDataGridViewTextBoxColumn
            // 
            this.percepcionDGRDataGridViewTextBoxColumn.DataPropertyName = "PercepcionDGR";
            this.percepcionDGRDataGridViewTextBoxColumn.HeaderText = "PercepcionDGR";
            this.percepcionDGRDataGridViewTextBoxColumn.Name = "percepcionDGRDataGridViewTextBoxColumn";
            this.percepcionDGRDataGridViewTextBoxColumn.ReadOnly = true;
            this.percepcionDGRDataGridViewTextBoxColumn.Visible = false;
            this.percepcionDGRDataGridViewTextBoxColumn.Width = 142;
            // 
            // aplicaPercepcionIVADataGridViewCheckBoxColumn
            // 
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.DataPropertyName = "AplicaPercepcionIVA";
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.HeaderText = "AplicaPercepcionIVA";
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.Name = "aplicaPercepcionIVADataGridViewCheckBoxColumn";
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.ReadOnly = true;
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.Visible = false;
            this.aplicaPercepcionIVADataGridViewCheckBoxColumn.Width = 149;
            // 
            // cuentaDataGridViewTextBoxColumn
            // 
            this.cuentaDataGridViewTextBoxColumn.DataPropertyName = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.HeaderText = "Cuenta";
            this.cuentaDataGridViewTextBoxColumn.Name = "cuentaDataGridViewTextBoxColumn";
            this.cuentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaDataGridViewTextBoxColumn.Visible = false;
            this.cuentaDataGridViewTextBoxColumn.Width = 80;
            // 
            // facturasDataGridViewTextBoxColumn
            // 
            this.facturasDataGridViewTextBoxColumn.DataPropertyName = "Facturas";
            this.facturasDataGridViewTextBoxColumn.HeaderText = "Facturas";
            this.facturasDataGridViewTextBoxColumn.Name = "facturasDataGridViewTextBoxColumn";
            this.facturasDataGridViewTextBoxColumn.ReadOnly = true;
            this.facturasDataGridViewTextBoxColumn.Visible = false;
            this.facturasDataGridViewTextBoxColumn.Width = 91;
            // 
            // localidadDataGridViewTextBoxColumn
            // 
            this.localidadDataGridViewTextBoxColumn.DataPropertyName = "Localidad";
            this.localidadDataGridViewTextBoxColumn.HeaderText = "Localidad";
            this.localidadDataGridViewTextBoxColumn.Name = "localidadDataGridViewTextBoxColumn";
            this.localidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.localidadDataGridViewTextBoxColumn.Visible = false;
            this.localidadDataGridViewTextBoxColumn.Width = 96;
            // 
            // tipoCuitDataGridViewTextBoxColumn
            // 
            this.tipoCuitDataGridViewTextBoxColumn.DataPropertyName = "TipoCuit";
            this.tipoCuitDataGridViewTextBoxColumn.HeaderText = "TipoCuit";
            this.tipoCuitDataGridViewTextBoxColumn.Name = "tipoCuitDataGridViewTextBoxColumn";
            this.tipoCuitDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCuitDataGridViewTextBoxColumn.Visible = false;
            this.tipoCuitDataGridViewTextBoxColumn.Width = 88;
            // 
            // usuarioProveedoresDataGridViewTextBoxColumn
            // 
            this.usuarioProveedoresDataGridViewTextBoxColumn.DataPropertyName = "UsuarioProveedores";
            this.usuarioProveedoresDataGridViewTextBoxColumn.HeaderText = "UsuarioProveedores";
            this.usuarioProveedoresDataGridViewTextBoxColumn.Name = "usuarioProveedoresDataGridViewTextBoxColumn";
            this.usuarioProveedoresDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioProveedoresDataGridViewTextBoxColumn.Visible = false;
            this.usuarioProveedoresDataGridViewTextBoxColumn.Width = 170;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProveedorProductoes";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProveedorProductoes";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 179;
            // 
            // controlesStockDataGridViewTextBoxColumn
            // 
            this.controlesStockDataGridViewTextBoxColumn.DataPropertyName = "ControlesStock";
            this.controlesStockDataGridViewTextBoxColumn.HeaderText = "ControlesStock";
            this.controlesStockDataGridViewTextBoxColumn.Name = "controlesStockDataGridViewTextBoxColumn";
            this.controlesStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.controlesStockDataGridViewTextBoxColumn.Visible = false;
            this.controlesStockDataGridViewTextBoxColumn.Width = 137;
            // 
            // frmBuscadorProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(470, 204);
            this.Controls.Add(this.dgvListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBuscadorProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Buscar artículo";
            this.Load += new System.EventHandler(this.frmBuscadorProvedor_Load);
            this.Shown += new System.EventHandler(this.frmBuscadorProvedor_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscadorProvedor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn celularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCuitStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuitNroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCuitIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paginaWebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percepcionDGRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aplicaPercepcionIVADataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCuitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioProveedoresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlesStockDataGridViewTextBoxColumn;
    }
}