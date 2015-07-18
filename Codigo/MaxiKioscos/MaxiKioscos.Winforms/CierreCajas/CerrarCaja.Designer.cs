namespace MaxiKioscos.Winforms.CierreCajas
{
    partial class CerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CerrarCaja));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt2 = new Util.Controles.ucSoloNumero();
            this.txt5 = new Util.Controles.ucSoloNumero();
            this.txt10 = new Util.Controles.ucSoloNumero();
            this.txt20 = new Util.Controles.ucSoloNumero();
            this.txt50 = new Util.Controles.ucSoloNumero();
            this.txt100 = new Util.Controles.ucSoloNumero();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chxDetallar = new System.Windows.Forms.CheckBox();
            this.txtCajaFinal = new Util.Controles.ucDinero();
            this.label15 = new System.Windows.Forms.Label();
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
            this.lblTitulo.Size = new System.Drawing.Size(115, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cerrar Caja";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt2);
            this.panel1.Controls.Add(this.txt5);
            this.panel1.Controls.Add(this.txt10);
            this.panel1.Controls.Add(this.txt20);
            this.panel1.Controls.Add(this.txt50);
            this.panel1.Controls.Add(this.txt100);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.chxDetallar);
            this.panel1.Controls.Add(this.txtCajaFinal);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 243);
            this.panel1.TabIndex = 1;
            // 
            // txt2
            // 
            this.txt2.AceptaDecimales = false;
            this.txt2.Disabled = false;
            this.txt2.ErrorMessage = "";
            this.txt2.EsObligatorio = true;
            this.txt2.Location = new System.Drawing.Point(228, 189);
            this.txt2.LongMax = 32767;
            this.txt2.LongMin = 0;
            this.txt2.MaximoValor = null;
            this.txt2.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt2.Name = "txt2";
            this.txt2.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt2.Size = new System.Drawing.Size(55, 25);
            this.txt2.TabIndex = 27;
            this.txt2.Valor = "";
            // 
            // txt5
            // 
            this.txt5.AceptaDecimales = false;
            this.txt5.Disabled = false;
            this.txt5.ErrorMessage = "";
            this.txt5.EsObligatorio = true;
            this.txt5.Location = new System.Drawing.Point(229, 158);
            this.txt5.LongMax = 32767;
            this.txt5.LongMin = 0;
            this.txt5.MaximoValor = null;
            this.txt5.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt5.Name = "txt5";
            this.txt5.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt5.Size = new System.Drawing.Size(54, 25);
            this.txt5.TabIndex = 26;
            this.txt5.Valor = "";
            // 
            // txt10
            // 
            this.txt10.AceptaDecimales = false;
            this.txt10.Disabled = false;
            this.txt10.ErrorMessage = "";
            this.txt10.EsObligatorio = true;
            this.txt10.Location = new System.Drawing.Point(229, 127);
            this.txt10.LongMax = 32767;
            this.txt10.LongMin = 0;
            this.txt10.MaximoValor = null;
            this.txt10.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt10.Name = "txt10";
            this.txt10.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt10.Size = new System.Drawing.Size(54, 25);
            this.txt10.TabIndex = 25;
            this.txt10.Valor = "";
            // 
            // txt20
            // 
            this.txt20.AceptaDecimales = false;
            this.txt20.Disabled = false;
            this.txt20.ErrorMessage = "";
            this.txt20.EsObligatorio = true;
            this.txt20.Location = new System.Drawing.Point(80, 189);
            this.txt20.LongMax = 32767;
            this.txt20.LongMin = 0;
            this.txt20.MaximoValor = null;
            this.txt20.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt20.Name = "txt20";
            this.txt20.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt20.Size = new System.Drawing.Size(51, 25);
            this.txt20.TabIndex = 24;
            this.txt20.Valor = "";
            // 
            // txt50
            // 
            this.txt50.AceptaDecimales = false;
            this.txt50.Disabled = false;
            this.txt50.ErrorMessage = "";
            this.txt50.EsObligatorio = true;
            this.txt50.Location = new System.Drawing.Point(80, 158);
            this.txt50.LongMax = 32767;
            this.txt50.LongMin = 0;
            this.txt50.MaximoValor = null;
            this.txt50.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt50.Name = "txt50";
            this.txt50.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt50.Size = new System.Drawing.Size(51, 25);
            this.txt50.TabIndex = 23;
            this.txt50.Valor = "";
            // 
            // txt100
            // 
            this.txt100.AceptaDecimales = false;
            this.txt100.Disabled = false;
            this.txt100.ErrorMessage = "";
            this.txt100.EsObligatorio = true;
            this.txt100.Location = new System.Drawing.Point(80, 127);
            this.txt100.LongMax = 32767;
            this.txt100.LongMin = 0;
            this.txt100.MaximoValor = null;
            this.txt100.MinimoValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt100.Name = "txt100";
            this.txt100.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt100.Size = new System.Drawing.Size(51, 25);
            this.txt100.TabIndex = 22;
            this.txt100.Valor = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(201, 191);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 20);
            this.label20.TabIndex = 21;
            this.label20.Text = "$2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(201, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 20);
            this.label19.TabIndex = 20;
            this.label19.Text = "$5";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(194, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 20);
            this.label18.TabIndex = 19;
            this.label18.Text = "$10";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(45, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 20);
            this.label17.TabIndex = 18;
            this.label17.Text = "$20";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(44, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "$50";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(37, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 20);
            this.label14.TabIndex = 16;
            this.label14.Text = "$100";
            // 
            // chxDetallar
            // 
            this.chxDetallar.AutoSize = true;
            this.chxDetallar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold);
            this.chxDetallar.Location = new System.Drawing.Point(41, 86);
            this.chxDetallar.Name = "chxDetallar";
            this.chxDetallar.Size = new System.Drawing.Size(75, 24);
            this.chxDetallar.TabIndex = 15;
            this.chxDetallar.Text = "Detallar";
            this.chxDetallar.UseVisualStyleBackColor = true;
            this.chxDetallar.CheckedChanged += new System.EventHandler(this.chxDetallar_CheckedChanged);
            // 
            // txtCajaFinal
            // 
            this.txtCajaFinal.Disabled = false;
            this.txtCajaFinal.ErrorMessage = "";
            this.txtCajaFinal.EsObligatorio = true;
            this.txtCajaFinal.Location = new System.Drawing.Point(41, 50);
            this.txtCajaFinal.LongMax = 32767;
            this.txtCajaFinal.LongMin = 0;
            this.txtCajaFinal.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCajaFinal.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCajaFinal.Name = "txtCajaFinal";
            this.txtCajaFinal.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCajaFinal.ReadOnly = false;
            this.txtCajaFinal.Size = new System.Drawing.Size(242, 30);
            this.txtCajaFinal.TabIndex = 1;
            this.txtCajaFinal.TextboxTabIndex = 0;
            this.txtCajaFinal.Valor = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(37, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 20);
            this.label15.TabIndex = 13;
            this.label15.Text = "Caja Final";
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
            this.btnCancelar.Location = new System.Drawing.Point(181, 300);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(61, 300);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // CerrarCaja
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(319, 344);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CerrarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerrar Caja";
            this.Load += new System.EventHandler(this.CerrarCaja_Load);
            this.Shown += new System.EventHandler(this.CerrarCaja_Shown);
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private Util.Controles.ucDinero txtCajaFinal;
        private System.Windows.Forms.CheckBox chxDetallar;
        private Util.Controles.ucSoloNumero txt2;
        private Util.Controles.ucSoloNumero txt5;
        private Util.Controles.ucSoloNumero txt10;
        private Util.Controles.ucSoloNumero txt20;
        private Util.Controles.ucSoloNumero txt50;
        private Util.Controles.ucSoloNumero txt100;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        
    }
}