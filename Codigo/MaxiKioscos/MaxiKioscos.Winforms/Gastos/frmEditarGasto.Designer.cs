namespace MaxiKioscos.Winforms.Gastos
{
    partial class frmEditarGasto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarGasto));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlCategorias = new Telerik.WinControls.UI.RadDropDownList();
            this.txtFecha = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtNroComprobante = new Util.Controles.ucTexto();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMonto = new Util.Controles.ucDinero();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategorias)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(160, 35);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Gasto";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(37, 178);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 23);
            this.label22.TabIndex = 8;
            this.label22.Text = "Observaciones";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(37, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 23);
            this.label25.TabIndex = 11;
            this.label25.Text = "Monto";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(41, 201);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(454, 129);
            this.txtObservaciones.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ddlCategorias);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.txtNroComprobante);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 361);
            this.panel1.TabIndex = 1;
            // 
            // ddlCategorias
            // 
            this.ddlCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlCategorias.DropDownAnimationEnabled = true;
            this.ddlCategorias.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlCategorias.Location = new System.Drawing.Point(41, 119);
            this.ddlCategorias.MaxDropDownItems = 0;
            this.ddlCategorias.Name = "ddlCategorias";
            this.ddlCategorias.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlCategorias.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlCategorias.ShowImageInEditorArea = true;
            this.ddlCategorias.Size = new System.Drawing.Size(203, 28);
            this.ddlCategorias.TabIndex = 3;
            this.ddlCategorias.Text = "radDropDownList1";
            this.ddlCategorias.ThemeName = "Windows7";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(326, 119);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(170, 32);
            this.txtFecha.TabIndex = 4;
            this.txtFecha.Texto = "";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(322, 92);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(57, 23);
            this.lblFecha.TabIndex = 17;
            this.lblFecha.Text = "Fecha";
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Alto = 32;
            this.txtNroComprobante.Ancho = 169;
            this.txtNroComprobante.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.txtNroComprobante.CaracteresValidos = null;
            this.txtNroComprobante.CharCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroComprobante.Disabled = false;
            this.txtNroComprobante.ErrorMessage = "";
            this.txtNroComprobante.EsObligatorio = false;
            this.txtNroComprobante.InvalidateChar = null;
            this.txtNroComprobante.Location = new System.Drawing.Point(326, 49);
            this.txtNroComprobante.LongMax = 32767;
            this.txtNroComprobante.LongMin = 0;
            this.txtNroComprobante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNroComprobante.MultiLineas = false;
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Referencia = null;
            this.txtNroComprobante.Size = new System.Drawing.Size(169, 32);
            this.txtNroComprobante.TabIndex = 2;
            this.txtNroComprobante.Valor = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(322, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 23);
            this.label15.TabIndex = 14;
            this.label15.Text = "Nro. Comprobante";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(37, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 23);
            this.label14.TabIndex = 13;
            this.label14.Text = "Categoría";
            // 
            // txtMonto
            // 
            this.txtMonto.Disabled = false;
            this.txtMonto.ErrorMessage = "";
            this.txtMonto.EsObligatorio = true;
            this.txtMonto.Location = new System.Drawing.Point(41, 49);
            this.txtMonto.LongMax = 32767;
            this.txtMonto.LongMin = 0;
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtMonto.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMonto.ReadOnly = false;
            this.txtMonto.Size = new System.Drawing.Size(203, 31);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TextboxTabIndex = 3;
            this.txtMonto.Valor = null;
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
            this.btnCancelar.Location = new System.Drawing.Point(362, 411);
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
            this.btnAceptar.Location = new System.Drawing.Point(200, 411);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmEditarGasto
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(533, 452);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarGasto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Gasto";
            this.Shown += new System.EventHandler(this.frmCostoEditar_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategorias)).EndInit();
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
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel panel1;
        private Util.Controles.ucDinero txtMonto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private Util.Controles.ucTexto txtNroComprobante;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFecha;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFecha;
        public Telerik.WinControls.UI.RadDropDownList ddlCategorias;
        
    }
}