namespace MaxiKioscos.Winforms.Productos
{
    partial class frmCrearProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearProducto));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigo = new Util.Controles.ucTexto();
            this.ddlRubro = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlMarca = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPrecioSinIva = new Util.Controles.ucDinero();
            this.label15 = new System.Windows.Forms.Label();
            this.chxAceptaDecimales = new System.Windows.Forms.CheckBox();
            this.txtPrecio = new Util.Controles.ucDinero();
            this.txtStockReposicion = new Util.Controles.ucSoloNumero();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.codigoProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoProductoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(148, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Producto";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.ddlRubro);
            this.panel1.Controls.Add(this.ddlMarca);
            this.panel1.Controls.Add(this.txtPrecioSinIva);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.chxAceptaDecimales);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.txtStockReposicion);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 296);
            this.panel1.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Alto = 25;
            this.txtCodigo.Ancho = 203;
            this.txtCodigo.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.txtCodigo.CaracteresValidos = "";
            this.txtCodigo.CharCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.ErrorMessage = "";
            this.txtCodigo.EsObligatorio = true;
            this.txtCodigo.InvalidateChar = null;
            this.txtCodigo.Location = new System.Drawing.Point(21, 233);
            this.txtCodigo.LongMax = 30;
            this.txtCodigo.LongMin = 0;
            this.txtCodigo.MultiLineas = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Referencia = null;
            this.txtCodigo.Size = new System.Drawing.Size(203, 25);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.Valor = "";
            // 
            // ddlRubro
            // 
            this.ddlRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRubro.DropDownAnimationEnabled = true;
            this.ddlRubro.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlRubro.Location = new System.Drawing.Point(272, 112);
            this.ddlRubro.MaxDropDownItems = 0;
            this.ddlRubro.Name = "ddlRubro";
            this.ddlRubro.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlRubro.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlRubro.ShowImageInEditorArea = true;
            this.ddlRubro.Size = new System.Drawing.Size(203, 28);
            this.ddlRubro.TabIndex = 5;
            this.ddlRubro.Text = "radDropDownList1";
            this.ddlRubro.ThemeName = "Windows7";
            // 
            // ddlMarca
            // 
            this.ddlMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlMarca.DropDownAnimationEnabled = true;
            this.ddlMarca.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlMarca.Location = new System.Drawing.Point(272, 49);
            this.ddlMarca.MaxDropDownItems = 0;
            this.ddlMarca.Name = "ddlMarca";
            this.ddlMarca.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlMarca.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlMarca.ShowImageInEditorArea = true;
            this.ddlMarca.Size = new System.Drawing.Size(203, 28);
            this.ddlMarca.TabIndex = 4;
            this.ddlMarca.Text = "radDropDownList1";
            this.ddlMarca.ThemeName = "Windows7";
            // 
            // txtPrecioSinIva
            // 
            this.txtPrecioSinIva.Disabled = false;
            this.txtPrecioSinIva.ErrorMessage = "";
            this.txtPrecioSinIva.EsObligatorio = true;
            this.txtPrecioSinIva.Location = new System.Drawing.Point(21, 172);
            this.txtPrecioSinIva.LongMax = 32767;
            this.txtPrecioSinIva.LongMin = 0;
            this.txtPrecioSinIva.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecioSinIva.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecioSinIva.Name = "txtPrecioSinIva";
            this.txtPrecioSinIva.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecioSinIva.ReadOnly = false;
            this.txtPrecioSinIva.Size = new System.Drawing.Size(203, 26);
            this.txtPrecioSinIva.TabIndex = 2;
            this.txtPrecioSinIva.TextboxTabIndex = 0;
            this.txtPrecioSinIva.Valor = null;
            this.txtPrecioSinIva.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecioSinIva_Cambio);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(17, 149);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Precio Sin IVA ";
            // 
            // chxAceptaDecimales
            // 
            this.chxAceptaDecimales.AutoSize = true;
            this.chxAceptaDecimales.Location = new System.Drawing.Point(272, 176);
            this.chxAceptaDecimales.Name = "chxAceptaDecimales";
            this.chxAceptaDecimales.Size = new System.Drawing.Size(15, 14);
            this.chxAceptaDecimales.TabIndex = 6;
            this.chxAceptaDecimales.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Disabled = false;
            this.txtPrecio.ErrorMessage = "";
            this.txtPrecio.EsObligatorio = true;
            this.txtPrecio.Location = new System.Drawing.Point(21, 112);
            this.txtPrecio.LongMax = 32767;
            this.txtPrecio.LongMin = 0;
            this.txtPrecio.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecio.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecio.ReadOnly = false;
            this.txtPrecio.Size = new System.Drawing.Size(203, 26);
            this.txtPrecio.TabIndex = 1;
            this.txtPrecio.TextboxTabIndex = 0;
            this.txtPrecio.Valor = null;
            this.txtPrecio.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecio_Cambio);
            // 
            // txtStockReposicion
            // 
            this.txtStockReposicion.AceptaDecimales = false;
            this.txtStockReposicion.CaracteresPermitidos = null;
            this.txtStockReposicion.Disabled = false;
            this.txtStockReposicion.ErrorMessage = "";
            this.txtStockReposicion.EsObligatorio = true;
            this.txtStockReposicion.Location = new System.Drawing.Point(272, 233);
            this.txtStockReposicion.LongMax = 32767;
            this.txtStockReposicion.LongMin = 0;
            this.txtStockReposicion.MaximoValor = null;
            this.txtStockReposicion.MinimoValor = null;
            this.txtStockReposicion.Name = "txtStockReposicion";
            this.txtStockReposicion.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStockReposicion.Size = new System.Drawing.Size(203, 25);
            this.txtStockReposicion.TabIndex = 7;
            this.txtStockReposicion.Valor = "";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(21, 49);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 25);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 20);
            this.label14.TabIndex = 46;
            this.label14.Text = "Código";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Descripción";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(268, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 20);
            this.label25.TabIndex = 43;
            this.label25.Text = "Marca";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(17, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 20);
            this.label24.TabIndex = 42;
            this.label24.Text = "Precio Con IVA";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(268, 149);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 20);
            this.label23.TabIndex = 41;
            this.label23.Text = "Acepta Stock Decimal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(268, 210);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 20);
            this.label19.TabIndex = 40;
            this.label19.Text = "Stock Reposición";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(267, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "Rubro";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(183, 353);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
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
            this.btnCancelar.Location = new System.Drawing.Point(333, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // codigoProductoBindingSource
            // 
            this.codigoProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.CodigoProducto);
            // 
            // frmCrearProducto
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(513, 399);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCrearProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Producto";
            this.Shown += new System.EventHandler(this.frmCrearProducto_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoProductoBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chxAceptaDecimales;
        private Util.Controles.ucDinero txtPrecio;
        private Util.Controles.ucSoloNumero txtStockReposicion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.BindingSource codigoProductoBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Util.Controles.ucDinero txtPrecioSinIva;
        private System.Windows.Forms.Label label15;
        public Telerik.WinControls.UI.RadDropDownList ddlMarca;
        public Telerik.WinControls.UI.RadDropDownList ddlRubro;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private Util.Controles.ucTexto txtCodigo;
        
        
    }
}