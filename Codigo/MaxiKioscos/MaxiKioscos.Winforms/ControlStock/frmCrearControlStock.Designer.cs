namespace MaxiKioscos.Winforms.ControlStock
{
    partial class frmCrearControlStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearControlStock));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSoloStockCero = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtCantidadFilas = new Util.Controles.ucSoloNumero();
            this.label16 = new System.Windows.Forms.Label();
            this.ddlRubro = new Telerik.WinControls.UI.RadDropDownList();
            this.chxSoloMasVendidos = new System.Windows.Forms.CheckBox();
            this.ddlProveedor = new Telerik.WinControls.UI.RadDropDownList();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlLimites = new System.Windows.Forms.Panel();
            this.txtLimiteSuperior = new Util.Controles.ucSoloNumero();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLimiteInferior = new Util.Controles.ucSoloNumero();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlLimites.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(88, 36);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Crear";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkSoloStockCero);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.btnReiniciar);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.txtCantidadFilas);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.ddlRubro);
            this.panel1.Controls.Add(this.chxSoloMasVendidos);
            this.panel1.Controls.Add(this.ddlProveedor);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 627);
            this.panel1.TabIndex = 1;
            // 
            // chkSoloStockCero
            // 
            this.chkSoloStockCero.AutoSize = true;
            this.chkSoloStockCero.Location = new System.Drawing.Point(24, 277);
            this.chkSoloStockCero.Name = "chkSoloStockCero";
            this.chkSoloStockCero.Size = new System.Drawing.Size(18, 17);
            this.chkSoloStockCero.TabIndex = 58;
            this.chkSoloStockCero.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(20, 256);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(146, 24);
            this.label20.TabIndex = 59;
            this.label20.Text = "Excluir stock 0";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnReiniciar.Image")));
            this.btnReiniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReiniciar.Location = new System.Drawing.Point(22, 524);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(215, 40);
            this.btnReiniciar.TabIndex = 57;
            this.btnReiniciar.Text = "Reiniciar Filtros";
            this.btnReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Visible = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(263, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(790, 627);
            this.reportViewer1.TabIndex = 56;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(22, 468);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(215, 40);
            this.btnGenerar.TabIndex = 51;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtCantidadFilas
            // 
            this.txtCantidadFilas.AceptaDecimales = false;
            this.txtCantidadFilas.CaracteresPermitidos = null;
            this.txtCantidadFilas.Disabled = true;
            this.txtCantidadFilas.ErrorMessage = "";
            this.txtCantidadFilas.EsObligatorio = true;
            this.txtCantidadFilas.Location = new System.Drawing.Point(21, 411);
            this.txtCantidadFilas.LongMax = 32767;
            this.txtCantidadFilas.LongMin = 0;
            this.txtCantidadFilas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidadFilas.MaximoValor = null;
            this.txtCantidadFilas.MinimoValor = null;
            this.txtCantidadFilas.Name = "txtCantidadFilas";
            this.txtCantidadFilas.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCantidadFilas.Size = new System.Drawing.Size(79, 31);
            this.txtCantidadFilas.TabIndex = 5;
            this.txtCantidadFilas.Valor = "";
            this.txtCantidadFilas.ValorDecimal = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(18, 385);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(172, 24);
            this.label16.TabIndex = 55;
            this.label16.Text = "Cantidad de Filas";
            // 
            // ddlRubro
            // 
            this.ddlRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRubro.DropDownAnimationEnabled = true;
            this.ddlRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ddlRubro.Location = new System.Drawing.Point(22, 196);
            this.ddlRubro.MaxDropDownItems = 0;
            this.ddlRubro.Name = "ddlRubro";
            this.ddlRubro.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlRubro.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlRubro.ShowImageInEditorArea = true;
            this.ddlRubro.Size = new System.Drawing.Size(203, 32);
            this.ddlRubro.TabIndex = 3;
            this.ddlRubro.Text = "radDropDownList1";
            this.ddlRubro.ThemeName = "Windows7";
            // 
            // chxSoloMasVendidos
            // 
            this.chxSoloMasVendidos.AutoSize = true;
            this.chxSoloMasVendidos.Location = new System.Drawing.Point(23, 344);
            this.chxSoloMasVendidos.Name = "chxSoloMasVendidos";
            this.chxSoloMasVendidos.Size = new System.Drawing.Size(18, 17);
            this.chxSoloMasVendidos.TabIndex = 4;
            this.chxSoloMasVendidos.UseVisualStyleBackColor = true;
            this.chxSoloMasVendidos.CheckedChanged += new System.EventHandler(this.chxSoloMasVendidos_CheckedChanged);
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlProveedor.DropDownAnimationEnabled = true;
            this.ddlProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ddlProveedor.Location = new System.Drawing.Point(22, 115);
            this.ddlProveedor.MaxDropDownItems = 0;
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlProveedor.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlProveedor.ShowImageInEditorArea = true;
            this.ddlProveedor.Size = new System.Drawing.Size(203, 32);
            this.ddlProveedor.TabIndex = 2;
            this.ddlProveedor.Text = "radDropDownList1";
            this.ddlProveedor.ThemeName = "Windows7";
            this.ddlProveedor.Leave += new System.EventHandler(this.ddlProveedor_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(18, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(220, 24);
            this.label15.TabIndex = 53;
            this.label15.Text = "Solo los más vendidos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(19, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 24);
            this.label14.TabIndex = 50;
            this.label14.Text = "Rubro";
            // 
            // txtFecha
            // 
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtFecha.Location = new System.Drawing.Point(21, 38);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(162, 29);
            this.txtFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(17, 10);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 24);
            this.lblFecha.TabIndex = 47;
            this.lblFecha.Text = "Fecha";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(19, 94);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 24);
            this.label19.TabIndex = 39;
            this.label19.Text = "Proveedor";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(741, 684);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(897, 684);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlLimites
            // 
            this.pnlLimites.Controls.Add(this.txtLimiteSuperior);
            this.pnlLimites.Controls.Add(this.label18);
            this.pnlLimites.Controls.Add(this.txtLimiteInferior);
            this.pnlLimites.Controls.Add(this.label17);
            this.pnlLimites.Location = new System.Drawing.Point(7, 671);
            this.pnlLimites.Name = "pnlLimites";
            this.pnlLimites.Size = new System.Drawing.Size(689, 58);
            this.pnlLimites.TabIndex = 8;
            this.pnlLimites.Visible = false;
            // 
            // txtLimiteSuperior
            // 
            this.txtLimiteSuperior.AceptaDecimales = false;
            this.txtLimiteSuperior.CaracteresPermitidos = null;
            this.txtLimiteSuperior.Disabled = false;
            this.txtLimiteSuperior.ErrorMessage = "";
            this.txtLimiteSuperior.EsObligatorio = true;
            this.txtLimiteSuperior.Location = new System.Drawing.Point(394, 14);
            this.txtLimiteSuperior.LongMax = 32767;
            this.txtLimiteSuperior.LongMin = 0;
            this.txtLimiteSuperior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLimiteSuperior.MaximoValor = null;
            this.txtLimiteSuperior.MinimoValor = null;
            this.txtLimiteSuperior.Name = "txtLimiteSuperior";
            this.txtLimiteSuperior.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLimiteSuperior.Size = new System.Drawing.Size(79, 31);
            this.txtLimiteSuperior.TabIndex = 54;
            this.txtLimiteSuperior.Valor = "20.00";
            this.txtLimiteSuperior.ValorDecimal = new decimal(new int[] {
            2000,
            0,
            0,
            131072});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(290, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 24);
            this.label18.TabIndex = 53;
            this.label18.Text = "hasta fila:";
            // 
            // txtLimiteInferior
            // 
            this.txtLimiteInferior.AceptaDecimales = false;
            this.txtLimiteInferior.CaracteresPermitidos = null;
            this.txtLimiteInferior.Disabled = false;
            this.txtLimiteInferior.ErrorMessage = "";
            this.txtLimiteInferior.EsObligatorio = true;
            this.txtLimiteInferior.Location = new System.Drawing.Point(122, 15);
            this.txtLimiteInferior.LongMax = 32767;
            this.txtLimiteInferior.LongMin = 0;
            this.txtLimiteInferior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLimiteInferior.MaximoValor = null;
            this.txtLimiteInferior.MinimoValor = null;
            this.txtLimiteInferior.Name = "txtLimiteInferior";
            this.txtLimiteInferior.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLimiteInferior.Size = new System.Drawing.Size(79, 31);
            this.txtLimiteInferior.TabIndex = 52;
            this.txtLimiteInferior.Valor = "1.00";
            this.txtLimiteInferior.ValorDecimal = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(7, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 24);
            this.label17.TabIndex = 51;
            this.label17.Text = "Desde fila:";
            // 
            // frmCrearControlStock
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1050, 729);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLimites);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCrearControlStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Control de Stock";
            this.Load += new System.EventHandler(this.frmCrearControlStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRubro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlLimites.ResumeLayout(false);
            this.pnlLimites.PerformLayout();
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
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label14;
        public Telerik.WinControls.UI.RadDropDownList ddlRubro;
        public Telerik.WinControls.UI.RadDropDownList ddlProveedor;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private System.Windows.Forms.Button btnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Util.Controles.ucSoloNumero txtCantidadFilas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chxSoloMasVendidos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Panel pnlLimites;
        private Util.Controles.ucSoloNumero txtLimiteSuperior;
        private System.Windows.Forms.Label label18;
        private Util.Controles.ucSoloNumero txtLimiteInferior;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkSoloStockCero;
        private System.Windows.Forms.Label label20;
        
        
    }
}