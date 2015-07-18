namespace MaxiKioscos.Winforms.Productos.Modulos
{
    partial class IngresarPrecioCosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresarPrecioCosto));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPorcentajeGanancia = new Util.Controles.ucProcentaje();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioSinIVA = new Util.Controles.ucDinero();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCostoSinIVA = new Util.Controles.ucDinero();
            this.label16 = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProducto = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPrecioConIVA = new Util.Controles.ucDinero();
            this.txtCostoConIVA = new Util.Controles.ucDinero();
            this.label26 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(216, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Ingresar Costo y Precio";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPorcentajeGanancia);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtPrecioSinIVA);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtCostoSinIVA);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblProveedor);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtProducto);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtPrecioConIVA);
            this.panel1.Controls.Add(this.txtCostoConIVA);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 345);
            this.panel1.TabIndex = 1;
            // 
            // txtPorcentajeGanancia
            // 
            this.txtPorcentajeGanancia.Disabled = false;
            this.txtPorcentajeGanancia.ErrorMessage = "";
            this.txtPorcentajeGanancia.EsObligatorio = true;
            this.txtPorcentajeGanancia.Location = new System.Drawing.Point(32, 222);
            this.txtPorcentajeGanancia.LongMax = 32767;
            this.txtPorcentajeGanancia.LongMin = 0;
            this.txtPorcentajeGanancia.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPorcentajeGanancia.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcentajeGanancia.Name = "txtPorcentajeGanancia";
            this.txtPorcentajeGanancia.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPorcentajeGanancia.ReadOnly = false;
            this.txtPorcentajeGanancia.Size = new System.Drawing.Size(159, 26);
            this.txtPorcentajeGanancia.TabIndex = 3;
            this.txtPorcentajeGanancia.TextboxTabIndex = 0;
            this.txtPorcentajeGanancia.Valor = null;
            this.txtPorcentajeGanancia.Cambio += new Util.Controles.ucProcentaje.CambioEventHandler(this.txtPorcentajeGanancia_Cambio);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(28, 198);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 20);
            this.label18.TabIndex = 20;
            this.label18.Text = "Porcentaje de Ganancia";
            // 
            // txtPrecioSinIVA
            // 
            this.txtPrecioSinIVA.Disabled = false;
            this.txtPrecioSinIVA.ErrorMessage = "";
            this.txtPrecioSinIVA.EsObligatorio = true;
            this.txtPrecioSinIVA.Location = new System.Drawing.Point(32, 293);
            this.txtPrecioSinIVA.LongMax = 32767;
            this.txtPrecioSinIVA.LongMin = 0;
            this.txtPrecioSinIVA.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecioSinIVA.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecioSinIVA.Name = "txtPrecioSinIVA";
            this.txtPrecioSinIVA.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecioSinIVA.ReadOnly = false;
            this.txtPrecioSinIVA.Size = new System.Drawing.Size(156, 25);
            this.txtPrecioSinIVA.TabIndex = 4;
            this.txtPrecioSinIVA.TextboxTabIndex = 1;
            this.txtPrecioSinIVA.Valor = null;
            this.txtPrecioSinIVA.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecioSinIVA_Cambio);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(28, 272);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 20);
            this.label17.TabIndex = 19;
            this.label17.Text = "Precio sin IVA";
            // 
            // txtCostoSinIVA
            // 
            this.txtCostoSinIVA.Disabled = false;
            this.txtCostoSinIVA.ErrorMessage = "";
            this.txtCostoSinIVA.EsObligatorio = true;
            this.txtCostoSinIVA.Location = new System.Drawing.Point(32, 149);
            this.txtCostoSinIVA.LongMax = 32767;
            this.txtCostoSinIVA.LongMin = 0;
            this.txtCostoSinIVA.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCostoSinIVA.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtCostoSinIVA.Name = "txtCostoSinIVA";
            this.txtCostoSinIVA.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCostoSinIVA.ReadOnly = false;
            this.txtCostoSinIVA.Size = new System.Drawing.Size(159, 25);
            this.txtCostoSinIVA.TabIndex = 1;
            this.txtCostoSinIVA.TextboxTabIndex = 0;
            this.txtCostoSinIVA.Valor = null;
            this.txtCostoSinIVA.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtCostoSinIVA_Cambio);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(28, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "Costo sin IVA";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.Black;
            this.lblProveedor.Location = new System.Drawing.Point(129, 16);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(121, 20);
            this.lblProveedor.TabIndex = 15;
            this.lblProveedor.Text = "PROVEEDOR";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(28, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 20);
            this.label15.TabIndex = 14;
            this.label15.Text = "Costos para";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(32, 77);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(345, 26);
            this.txtProducto.TabIndex = 1;
            this.txtProducto.TabStop = false;
            this.txtProducto.Texto = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(28, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Producto";
            // 
            // txtPrecioConIVA
            // 
            this.txtPrecioConIVA.Disabled = false;
            this.txtPrecioConIVA.ErrorMessage = "";
            this.txtPrecioConIVA.EsObligatorio = true;
            this.txtPrecioConIVA.Location = new System.Drawing.Point(218, 293);
            this.txtPrecioConIVA.LongMax = 32767;
            this.txtPrecioConIVA.LongMin = 0;
            this.txtPrecioConIVA.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecioConIVA.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.txtPrecioConIVA.Name = "txtPrecioConIVA";
            this.txtPrecioConIVA.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrecioConIVA.ReadOnly = false;
            this.txtPrecioConIVA.Size = new System.Drawing.Size(156, 25);
            this.txtPrecioConIVA.TabIndex = 5;
            this.txtPrecioConIVA.TextboxTabIndex = 1;
            this.txtPrecioConIVA.Valor = null;
            this.txtPrecioConIVA.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPrecioConIVA_Cambio);
            // 
            // txtCostoConIVA
            // 
            this.txtCostoConIVA.Disabled = false;
            this.txtCostoConIVA.ErrorMessage = "";
            this.txtCostoConIVA.EsObligatorio = true;
            this.txtCostoConIVA.Location = new System.Drawing.Point(218, 149);
            this.txtCostoConIVA.LongMax = 32767;
            this.txtCostoConIVA.LongMin = 0;
            this.txtCostoConIVA.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCostoConIVA.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCostoConIVA.Name = "txtCostoConIVA";
            this.txtCostoConIVA.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCostoConIVA.ReadOnly = false;
            this.txtCostoConIVA.Size = new System.Drawing.Size(159, 25);
            this.txtCostoConIVA.TabIndex = 2;
            this.txtCostoConIVA.TextboxTabIndex = 0;
            this.txtCostoConIVA.Valor = null;
            this.txtCostoConIVA.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtCostoConIVA_Cambio);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(214, 126);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(112, 20);
            this.label26.TabIndex = 12;
            this.label26.Text = "Costo con IVA";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(214, 272);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 20);
            this.label21.TabIndex = 7;
            this.label21.Text = "Precio con IVA";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(243, 395);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(89, 395);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // IngresarPrecioCosto
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(396, 438);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IngresarPrecioCosto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Producto";
            this.Load += new System.EventHandler(this.IngresarPrecioCosto_Load);
            this.Shown += new System.EventHandler(this.IngresarPrecioCosto_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label21;
        private Util.Controles.ucDinero txtPrecioConIVA;
        private Util.Controles.ucDinero txtCostoConIVA;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtProducto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label15;
        private Util.Controles.ucDinero txtCostoSinIVA;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private Util.Controles.ucDinero txtPrecioSinIVA;
        private System.Windows.Forms.Label label17;
        private Util.Controles.ucProcentaje txtPorcentajeGanancia;
        
    }
}