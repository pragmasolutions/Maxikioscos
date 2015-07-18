namespace MaxiKioscos.Winforms.CorreccionesStock
{
    partial class frmEditarCorreccionStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarCorreccionStock));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCorreccion = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.txtMotivoCorreccion = new Util.Controles.ucTexto();
            this.txtPrecio = new Util.Controles.ucDinero();
            this.txtCantidadActual = new Util.Controles.ucSoloNumero();
            this.txtCantidadOriginal = new Util.Controles.ucSoloNumero();
            this.txtProductoNombre = new Util.Controles.ucSoloNumero();
            this.pnlCorreccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Retiro de Mercadería";
            // 
            // pnlCorreccion
            // 
            this.pnlCorreccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCorreccion.Controls.Add(this.txtMotivoCorreccion);
            this.pnlCorreccion.Controls.Add(this.txtPrecio);
            this.pnlCorreccion.Controls.Add(this.label14);
            this.pnlCorreccion.Controls.Add(this.txtCantidadActual);
            this.pnlCorreccion.Controls.Add(this.txtCantidadOriginal);
            this.pnlCorreccion.Controls.Add(this.txtProductoNombre);
            this.pnlCorreccion.Controls.Add(this.label26);
            this.pnlCorreccion.Controls.Add(this.label25);
            this.pnlCorreccion.Controls.Add(this.label24);
            this.pnlCorreccion.Controls.Add(this.label19);
            this.pnlCorreccion.Location = new System.Drawing.Point(35, 150);
            this.pnlCorreccion.Name = "pnlCorreccion";
            this.pnlCorreccion.Size = new System.Drawing.Size(621, 229);
            this.pnlCorreccion.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(303, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 56;
            this.label14.Text = "Cantidad";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(19, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Producto";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(21, 149);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 20);
            this.label25.TabIndex = 43;
            this.label25.Text = "Precio";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(21, 83);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 20);
            this.label24.TabIndex = 42;
            this.label24.Text = "Stock";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(303, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 20);
            this.label19.TabIndex = 39;
            this.label19.Text = "Motivo de correccion";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(343, 398);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 14;
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
            this.btnCancelar.Location = new System.Drawing.Point(519, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Location = new System.Drawing.Point(35, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 65);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCION DE PRODUCTO";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(81, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(404, 24);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(491, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 26);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProducto.Location = new System.Drawing.Point(20, 23);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(59, 20);
            this.lblProducto.TabIndex = 4;
            this.lblProducto.Text = "Código";
            // 
            // txtMotivoCorreccion
            // 
            this.txtMotivoCorreccion.Alto = 26;
            this.txtMotivoCorreccion.Ancho = 203;
            this.txtMotivoCorreccion.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.txtMotivoCorreccion.CaracteresValidos = null;
            this.txtMotivoCorreccion.CharCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivoCorreccion.Disabled = true;
            this.txtMotivoCorreccion.Enabled = false;
            this.txtMotivoCorreccion.ErrorMessage = "";
            this.txtMotivoCorreccion.EsObligatorio = true;
            this.txtMotivoCorreccion.InvalidateChar = null;
            this.txtMotivoCorreccion.Location = new System.Drawing.Point(307, 49);
            this.txtMotivoCorreccion.LongMax = 32767;
            this.txtMotivoCorreccion.LongMin = 0;
            this.txtMotivoCorreccion.MultiLineas = false;
            this.txtMotivoCorreccion.Name = "txtMotivoCorreccion";
            this.txtMotivoCorreccion.Referencia = null;
            this.txtMotivoCorreccion.Size = new System.Drawing.Size(203, 26);
            this.txtMotivoCorreccion.TabIndex = 58;
            this.txtMotivoCorreccion.Valor = "RETIRO";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Disabled = false;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.ErrorMessage = "";
            this.txtPrecio.EsObligatorio = true;
            this.txtPrecio.Location = new System.Drawing.Point(25, 171);
            this.txtPrecio.LongMax = 32767;
            this.txtPrecio.LongMin = 0;
            this.txtPrecio.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecio.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(200, 26);
            this.txtPrecio.TabIndex = 57;
            this.txtPrecio.TextboxTabIndex = 0;
            this.txtPrecio.Valor = null;
            // 
            // txtCantidadActual
            // 
            this.txtCantidadActual.AceptaDecimales = true;
            this.txtCantidadActual.CaracteresPermitidos = null;
            this.txtCantidadActual.Disabled = false;
            this.txtCantidadActual.ErrorMessage = "";
            this.txtCantidadActual.EsObligatorio = true;
            this.txtCantidadActual.Location = new System.Drawing.Point(307, 108);
            this.txtCantidadActual.LongMax = 32767;
            this.txtCantidadActual.LongMin = 0;
            this.txtCantidadActual.MaximoValor = null;
            this.txtCantidadActual.MinimoValor = null;
            this.txtCantidadActual.Name = "txtCantidadActual";
            this.txtCantidadActual.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCantidadActual.Size = new System.Drawing.Size(203, 25);
            this.txtCantidadActual.TabIndex = 55;
            this.txtCantidadActual.Valor = "";
            this.txtCantidadActual.ValorDecimal = null;
            this.txtCantidadActual.TeclaApretada += new Util.Controles.ucSoloNumero.TeclaApretadaEventHandler(this.txtCantidadActual_TeclaApretada);
            // 
            // txtCantidadOriginal
            // 
            this.txtCantidadOriginal.AceptaDecimales = true;
            this.txtCantidadOriginal.CaracteresPermitidos = null;
            this.txtCantidadOriginal.Disabled = true;
            this.txtCantidadOriginal.Enabled = false;
            this.txtCantidadOriginal.ErrorMessage = "";
            this.txtCantidadOriginal.EsObligatorio = true;
            this.txtCantidadOriginal.Location = new System.Drawing.Point(25, 107);
            this.txtCantidadOriginal.LongMax = 100;
            this.txtCantidadOriginal.LongMin = 0;
            this.txtCantidadOriginal.MaximoValor = null;
            this.txtCantidadOriginal.MinimoValor = null;
            this.txtCantidadOriginal.Name = "txtCantidadOriginal";
            this.txtCantidadOriginal.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCantidadOriginal.Size = new System.Drawing.Size(200, 25);
            this.txtCantidadOriginal.TabIndex = 49;
            this.txtCantidadOriginal.Valor = "";
            this.txtCantidadOriginal.ValorDecimal = null;
            // 
            // txtProductoNombre
            // 
            this.txtProductoNombre.AceptaDecimales = false;
            this.txtProductoNombre.CaracteresPermitidos = null;
            this.txtProductoNombre.Disabled = true;
            this.txtProductoNombre.Enabled = false;
            this.txtProductoNombre.ErrorMessage = "";
            this.txtProductoNombre.EsObligatorio = true;
            this.txtProductoNombre.Location = new System.Drawing.Point(23, 49);
            this.txtProductoNombre.LongMax = 32767;
            this.txtProductoNombre.LongMin = 0;
            this.txtProductoNombre.MaximoValor = null;
            this.txtProductoNombre.MinimoValor = null;
            this.txtProductoNombre.Name = "txtProductoNombre";
            this.txtProductoNombre.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProductoNombre.Size = new System.Drawing.Size(203, 25);
            this.txtProductoNombre.TabIndex = 46;
            this.txtProductoNombre.Valor = "";
            this.txtProductoNombre.ValorDecimal = null;
            // 
            // frmEditarCorreccionStock
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(668, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlCorreccion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditarCorreccionStock";
            this.Text = "Editar Corrección Stock";
            this.Load += new System.EventHandler(this.frmEditarCorreccionStock_Load);
            this.Shown += new System.EventHandler(this.frmEditarCorreccionStock_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEditarCorreccionStock_KeyUp);
            this.pnlCorreccion.ResumeLayout(false);
            this.pnlCorreccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Panel pnlCorreccion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private Util.Controles.ucSoloNumero txtCantidadOriginal;
        private Util.Controles.ucSoloNumero txtProductoNombre;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label14;
        private Util.Controles.ucSoloNumero txtCantidadActual;
        private Util.Controles.ucDinero txtPrecio;
        private System.Windows.Forms.TextBox txtCodigo;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private Util.Controles.ucTexto txtMotivoCorreccion;
        
        
    }
}