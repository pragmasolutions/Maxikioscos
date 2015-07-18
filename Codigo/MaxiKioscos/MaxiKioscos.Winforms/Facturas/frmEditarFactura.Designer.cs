namespace MaxiKioscos.Winforms.Facturas
{
    partial class frmEditarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarFactura));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlProveedor = new Telerik.WinControls.UI.RadDropDownList();
            this.txtAutonumerico = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFecha = new Util.Controles.ucDatePicker();
            this.txtImporteTotal = new Util.Controles.ucDinero();
            this.txtFacturaNro = new Util.Controles.ucSoloNumero();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProveedor)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(136, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Factura";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ddlProveedor);
            this.panel1.Controls.Add(this.txtAutonumerico);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.txtImporteTotal);
            this.panel1.Controls.Add(this.txtFacturaNro);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 212);
            this.panel1.TabIndex = 1;
            // 
            // ddlProveedor
            // 
            this.ddlProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlProveedor.DropDownAnimationEnabled = true;
            this.ddlProveedor.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.ddlProveedor.Location = new System.Drawing.Point(275, 33);
            this.ddlProveedor.MaxDropDownItems = 0;
            this.ddlProveedor.Name = "ddlProveedor";
            this.ddlProveedor.Padding = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            this.ddlProveedor.RootElement.Padding = new System.Windows.Forms.Padding(2);
            this.ddlProveedor.ShowImageInEditorArea = true;
            this.ddlProveedor.Size = new System.Drawing.Size(203, 28);
            this.ddlProveedor.TabIndex = 4;
            this.ddlProveedor.Text = "radDropDownList1";
            this.ddlProveedor.ThemeName = "Windows7";
            // 
            // txtAutonumerico
            // 
            this.txtAutonumerico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutonumerico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAutonumerico.Font = new System.Drawing.Font("Arial Narrow", 11.25F);
            this.txtAutonumerico.Location = new System.Drawing.Point(21, 33);
            this.txtAutonumerico.Name = "txtAutonumerico";
            this.txtAutonumerico.Size = new System.Drawing.Size(203, 25);
            this.txtAutonumerico.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Autonumérico";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Fecha = new System.DateTime(2015, 1, 23, 0, 0, 0, 0);
            this.dtpFecha.FechaMaxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.FechaMinima = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Location = new System.Drawing.Point(21, 164);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(203, 29);
            this.dtpFecha.TabIndex = 3;
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Disabled = false;
            this.txtImporteTotal.ErrorMessage = "";
            this.txtImporteTotal.EsObligatorio = true;
            this.txtImporteTotal.Location = new System.Drawing.Point(275, 100);
            this.txtImporteTotal.LongMax = 32767;
            this.txtImporteTotal.LongMin = 0;
            this.txtImporteTotal.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtImporteTotal.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImporteTotal.ReadOnly = false;
            this.txtImporteTotal.Size = new System.Drawing.Size(200, 26);
            this.txtImporteTotal.TabIndex = 5;
            this.txtImporteTotal.TextboxTabIndex = 0;
            this.txtImporteTotal.Valor = null;
            // 
            // txtFacturaNro
            // 
            this.txtFacturaNro.AceptaDecimales = false;
            this.txtFacturaNro.CaracteresPermitidos = null;
            this.txtFacturaNro.Disabled = false;
            this.txtFacturaNro.ErrorMessage = "";
            this.txtFacturaNro.EsObligatorio = true;
            this.txtFacturaNro.Location = new System.Drawing.Point(21, 100);
            this.txtFacturaNro.LongMax = 32767;
            this.txtFacturaNro.LongMin = 0;
            this.txtFacturaNro.MaximoValor = null;
            this.txtFacturaNro.MinimoValor = null;
            this.txtFacturaNro.Name = "txtFacturaNro";
            this.txtFacturaNro.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFacturaNro.Size = new System.Drawing.Size(203, 25);
            this.txtFacturaNro.TabIndex = 2;
            this.txtFacturaNro.Valor = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(106, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Factura Número";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(271, 77);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 20);
            this.label25.TabIndex = 43;
            this.label25.Text = "Importe Total";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(271, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 20);
            this.label19.TabIndex = 39;
            this.label19.Text = "Proveedor";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(17, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "Fecha";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(176, 267);
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
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(332, 267);
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
            // frmEditarFactura
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(494, 312);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Factura";
            this.Shown += new System.EventHandler(this.frmEditarFactura_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProveedor)).EndInit();
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
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private Util.Controles.ucDinero txtImporteTotal;
        private Util.Controles.ucSoloNumero txtFacturaNro;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private Util.Controles.ucDatePicker dtpFecha;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAutonumerico;
        public Telerik.WinControls.UI.RadDropDownList ddlProveedor;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        
        
    }
}