namespace MaxiKioscos.Winforms.CorreccionesStock
{
    partial class frmDetalleCorreccionStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCorreccionStock));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCorreccion = new System.Windows.Forms.Panel();
            this.txtPrecio = new Util.Controles.ucDinero();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCantidadActual = new Util.Controles.ucSoloNumero();
            this.txtProductoNombre = new Util.Controles.ucSoloNumero();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ddlMotivoCorreccion = new Telerik.WinControls.UI.RadDropDownList();
            this.pnlCorreccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivoCorreccion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(219, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Correccion Stock";
            // 
            // pnlCorreccion
            // 
            this.pnlCorreccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCorreccion.Controls.Add(this.ddlMotivoCorreccion);
            this.pnlCorreccion.Controls.Add(this.txtPrecio);
            this.pnlCorreccion.Controls.Add(this.label14);
            this.pnlCorreccion.Controls.Add(this.txtCantidadActual);
            this.pnlCorreccion.Controls.Add(this.txtProductoNombre);
            this.pnlCorreccion.Controls.Add(this.label26);
            this.pnlCorreccion.Controls.Add(this.label25);
            this.pnlCorreccion.Controls.Add(this.label19);
            this.pnlCorreccion.Location = new System.Drawing.Point(17, 51);
            this.pnlCorreccion.Name = "pnlCorreccion";
            this.pnlCorreccion.Size = new System.Drawing.Size(538, 158);
            this.pnlCorreccion.TabIndex = 12;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Disabled = false;
            this.txtPrecio.ErrorMessage = "";
            this.txtPrecio.EsObligatorio = true;
            this.txtPrecio.Location = new System.Drawing.Point(23, 105);
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
            // txtCantidadActual
            // 
            this.txtCantidadActual.AceptaDecimales = false;
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
            // 
            // txtProductoNombre
            // 
            this.txtProductoNombre.AceptaDecimales = false;
            this.txtProductoNombre.Disabled = true;
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
            this.label25.Location = new System.Drawing.Point(19, 83);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 20);
            this.label25.TabIndex = 43;
            this.label25.Text = "Precio";
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
            this.btnAceptar.Location = new System.Drawing.Point(261, 227);
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
            this.btnCancelar.Location = new System.Drawing.Point(417, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ddlMotivoCorreccion
            // 
            this.ddlMotivoCorreccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlMotivoCorreccion.DropDownAnimationEnabled = true;
            this.ddlMotivoCorreccion.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlMotivoCorreccion.Location = new System.Drawing.Point(307, 49);
            this.ddlMotivoCorreccion.MaxDropDownItems = 0;
            this.ddlMotivoCorreccion.Name = "ddlMotivoCorreccion";
            this.ddlMotivoCorreccion.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlMotivoCorreccion.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlMotivoCorreccion.ShowImageInEditorArea = true;
            this.ddlMotivoCorreccion.Size = new System.Drawing.Size(203, 24);
            this.ddlMotivoCorreccion.TabIndex = 58;
            this.ddlMotivoCorreccion.Text = "radDropDownList1";
            // 
            // frmDetalleCorreccionStock
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(573, 264);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlCorreccion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetalleCorreccionStock";
            this.Text = "Editar Correccion Stock";
            this.Load += new System.EventHandler(this.frmEditarCorreccionStock_Load);
            this.pnlCorreccion.ResumeLayout(false);
            this.pnlCorreccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivoCorreccion)).EndInit();
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
        private Util.Controles.ucSoloNumero txtProductoNombre;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label14;
        private Util.Controles.ucSoloNumero txtCantidadActual;
        private Util.Controles.ucDinero txtPrecio;
        public Telerik.WinControls.UI.RadDropDownList ddlMotivoCorreccion;
        
        
    }
}