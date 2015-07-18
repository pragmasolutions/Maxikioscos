namespace MaxiKioscos.Winforms.Proveedores
{
    partial class frmDetalleProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleProveedor));
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.ucTextBoxGrisCelular = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisWeb = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisEmail = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisNroCuit = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisTipoCuit = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisTelefono = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisLocalidad = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisDomicilio = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisContacto = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.ucTextBoxGrisNombre = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.proveedorProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtNoReflejarFacturaEnCaja = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorProductoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(12, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(196, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "Detalle de Proveedor";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 562);
            this.panel1.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 547);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.frmDetalleProveedor_Load);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNoReflejarFacturaEnCaja);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtObservaciones);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisCelular);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisWeb);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisEmail);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisNroCuit);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisTipoCuit);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisTelefono);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisLocalidad);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisDomicilio);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisContacto);
            this.tabPage1.Controls.Add(this.ucTextBoxGrisNombre);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(29, 430);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(454, 68);
            this.txtObservaciones.TabIndex = 33;
            // 
            // ucTextBoxGrisCelular
            // 
            this.ucTextBoxGrisCelular.Location = new System.Drawing.Point(280, 298);
            this.ucTextBoxGrisCelular.Name = "ucTextBoxGrisCelular";
            this.ucTextBoxGrisCelular.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisCelular.TabIndex = 32;
            this.ucTextBoxGrisCelular.Texto = "";
            // 
            // ucTextBoxGrisWeb
            // 
            this.ucTextBoxGrisWeb.Location = new System.Drawing.Point(280, 235);
            this.ucTextBoxGrisWeb.Name = "ucTextBoxGrisWeb";
            this.ucTextBoxGrisWeb.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisWeb.TabIndex = 30;
            this.ucTextBoxGrisWeb.Texto = "";
            // 
            // ucTextBoxGrisEmail
            // 
            this.ucTextBoxGrisEmail.Location = new System.Drawing.Point(280, 172);
            this.ucTextBoxGrisEmail.Name = "ucTextBoxGrisEmail";
            this.ucTextBoxGrisEmail.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisEmail.TabIndex = 28;
            this.ucTextBoxGrisEmail.Texto = "";
            // 
            // ucTextBoxGrisNroCuit
            // 
            this.ucTextBoxGrisNroCuit.Location = new System.Drawing.Point(280, 109);
            this.ucTextBoxGrisNroCuit.Name = "ucTextBoxGrisNroCuit";
            this.ucTextBoxGrisNroCuit.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisNroCuit.TabIndex = 26;
            this.ucTextBoxGrisNroCuit.Texto = "";
            // 
            // ucTextBoxGrisTipoCuit
            // 
            this.ucTextBoxGrisTipoCuit.Location = new System.Drawing.Point(280, 46);
            this.ucTextBoxGrisTipoCuit.Name = "ucTextBoxGrisTipoCuit";
            this.ucTextBoxGrisTipoCuit.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisTipoCuit.TabIndex = 24;
            this.ucTextBoxGrisTipoCuit.Texto = "";
            // 
            // ucTextBoxGrisTelefono
            // 
            this.ucTextBoxGrisTelefono.Location = new System.Drawing.Point(29, 298);
            this.ucTextBoxGrisTelefono.Name = "ucTextBoxGrisTelefono";
            this.ucTextBoxGrisTelefono.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisTelefono.TabIndex = 31;
            this.ucTextBoxGrisTelefono.Texto = "";
            // 
            // ucTextBoxGrisLocalidad
            // 
            this.ucTextBoxGrisLocalidad.Location = new System.Drawing.Point(29, 235);
            this.ucTextBoxGrisLocalidad.Name = "ucTextBoxGrisLocalidad";
            this.ucTextBoxGrisLocalidad.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisLocalidad.TabIndex = 29;
            this.ucTextBoxGrisLocalidad.Texto = "";
            // 
            // ucTextBoxGrisDomicilio
            // 
            this.ucTextBoxGrisDomicilio.Location = new System.Drawing.Point(29, 172);
            this.ucTextBoxGrisDomicilio.Name = "ucTextBoxGrisDomicilio";
            this.ucTextBoxGrisDomicilio.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisDomicilio.TabIndex = 27;
            this.ucTextBoxGrisDomicilio.Texto = "";
            // 
            // ucTextBoxGrisContacto
            // 
            this.ucTextBoxGrisContacto.Location = new System.Drawing.Point(29, 109);
            this.ucTextBoxGrisContacto.Name = "ucTextBoxGrisContacto";
            this.ucTextBoxGrisContacto.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisContacto.TabIndex = 25;
            this.ucTextBoxGrisContacto.Texto = "";
            // 
            // ucTextBoxGrisNombre
            // 
            this.ucTextBoxGrisNombre.Location = new System.Drawing.Point(29, 46);
            this.ucTextBoxGrisNombre.Name = "ucTextBoxGrisNombre";
            this.ucTextBoxGrisNombre.Size = new System.Drawing.Size(203, 26);
            this.ucTextBoxGrisNombre.TabIndex = 23;
            this.ucTextBoxGrisNombre.Texto = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(25, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 20);
            this.label26.TabIndex = 21;
            this.label26.Text = "Nombre";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(25, 86);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 20);
            this.label25.TabIndex = 20;
            this.label25.Text = "Contacto";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(25, 212);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 20);
            this.label24.TabIndex = 19;
            this.label24.Text = "Localidad";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(25, 275);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 20);
            this.label23.TabIndex = 18;
            this.label23.Text = "Telefono";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(25, 403);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 20);
            this.label22.TabIndex = 17;
            this.label22.Text = "Observaciones";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(276, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 20);
            this.label21.TabIndex = 16;
            this.label21.Text = "Tipo de Cuit";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(276, 275);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 20);
            this.label20.TabIndex = 15;
            this.label20.Text = "Celular";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(276, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "Nro Cuit";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(276, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 20);
            this.label18.TabIndex = 13;
            this.label18.Text = "Email";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(25, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Domicilio";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(279, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 20);
            this.label16.TabIndex = 12;
            this.label16.Text = "Página Web";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvListado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.AutoGenerateColumns = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoIdDataGridViewTextBoxColumn,
            this.Rubro,
            this.MarcaString,
            this.Descripcion,
            this.Precio,
            this.identifierDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn});
            this.dgvListado.DataSource = this.productoBindingSource2;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(3, 3);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(503, 446);
            this.dgvListado.TabIndex = 0;
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // Rubro
            // 
            this.Rubro.DataPropertyName = "Prubro";
            this.Rubro.HeaderText = "Rubro";
            this.Rubro.Name = "Rubro";
            this.Rubro.ReadOnly = true;
            // 
            // MarcaString
            // 
            this.MarcaString.DataPropertyName = "Pmarca";
            this.MarcaString.HeaderText = "Marca";
            this.MarcaString.Name = "MarcaString";
            this.MarcaString.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Pdescripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Pprecio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
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
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // eliminadoDataGridViewCheckBoxColumn
            // 
            this.eliminadoDataGridViewCheckBoxColumn.DataPropertyName = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.HeaderText = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.Name = "eliminadoDataGridViewCheckBoxColumn";
            this.eliminadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eliminadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // productoBindingSource2
            // 
            this.productoBindingSource2.DataSource = typeof(MaxiKioscos.Entidades.Producto);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(386, 621);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Cerrar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.Producto);
            // 
            // productoBindingSource1
            // 
            this.productoBindingSource1.DataSource = typeof(MaxiKioscos.Entidades.Producto);
            // 
            // proveedorProductoBindingSource
            // 
            this.proveedorProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.ProveedorProducto);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(25, 340);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "Esconder Facturas en Caja";
            // 
            // txtNoReflejarFacturaEnCaja
            // 
            this.txtNoReflejarFacturaEnCaja.Location = new System.Drawing.Point(29, 362);
            this.txtNoReflejarFacturaEnCaja.Name = "txtNoReflejarFacturaEnCaja";
            this.txtNoReflejarFacturaEnCaja.Size = new System.Drawing.Size(203, 26);
            this.txtNoReflejarFacturaEnCaja.TabIndex = 35;
            this.txtNoReflejarFacturaEnCaja.Texto = "";
            // 
            // frmDetalleProveedor
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 671);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDetalleProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Proveedor";
            this.Load += new System.EventHandler(this.frmDetalleProveedor_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorProductoBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtObservaciones;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisCelular;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisWeb;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisEmail;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisNroCuit;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisTipoCuit;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisTelefono;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisLocalidad;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisDomicilio;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisContacto;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris ucTextBoxGrisNombre;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.BindingSource productoBindingSource1;
        private System.Windows.Forms.BindingSource proveedorProductoBindingSource;
        private System.Windows.Forms.BindingSource productoBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcaString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtNoReflejarFacturaEnCaja;
        private System.Windows.Forms.Label label15;
        
        
    }
}