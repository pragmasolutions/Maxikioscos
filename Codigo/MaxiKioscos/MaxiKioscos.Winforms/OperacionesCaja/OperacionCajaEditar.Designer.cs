namespace MaxiKioscos.Winforms.OperacionesCaja
{
    partial class OperacionCajaEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperacionCajaEditar));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDineroEnCaja = new System.Windows.Forms.Label();
            this.txtUsuarioCreador = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMonto = new Util.Controles.ucDinero();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtFecha = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtTipo = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(160, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Operación";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(284, 131);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 20);
            this.label21.TabIndex = 7;
            this.label21.Text = "Fecha";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(37, 222);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 20);
            this.label22.TabIndex = 8;
            this.label22.Text = "Observaciones";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(288, 155);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 20);
            this.label25.TabIndex = 11;
            this.label25.Text = "Monto";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(33, 131);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 20);
            this.label26.TabIndex = 12;
            this.label26.Text = "Tipo";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(41, 245);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(454, 68);
            this.txtObservaciones.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtUsuarioCreador);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 328);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblDineroEnCaja);
            this.groupBox1.Location = new System.Drawing.Point(41, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 70);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(108, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 18);
            this.label16.TabIndex = 19;
            this.label16.Text = "Caja Actual:";
            // 
            // lblDineroEnCaja
            // 
            this.lblDineroEnCaja.AutoSize = true;
            this.lblDineroEnCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroEnCaja.Location = new System.Drawing.Point(209, 27);
            this.lblDineroEnCaja.Name = "lblDineroEnCaja";
            this.lblDineroEnCaja.Size = new System.Drawing.Size(17, 18);
            this.lblDineroEnCaja.TabIndex = 15;
            this.lblDineroEnCaja.Text = "$";
            // 
            // txtUsuarioCreador
            // 
            this.txtUsuarioCreador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuarioCreador.Location = new System.Drawing.Point(41, 178);
            this.txtUsuarioCreador.Name = "txtUsuarioCreador";
            this.txtUsuarioCreador.Size = new System.Drawing.Size(203, 26);
            this.txtUsuarioCreador.TabIndex = 2;
            this.txtUsuarioCreador.TabStop = false;
            this.txtUsuarioCreador.Texto = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(37, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 13;
            this.label15.Text = "Creador";
            // 
            // txtMonto
            // 
            this.txtMonto.Disabled = false;
            this.txtMonto.ErrorMessage = "";
            this.txtMonto.EsObligatorio = true;
            this.txtMonto.Location = new System.Drawing.Point(292, 178);
            this.txtMonto.LongMax = 32767;
            this.txtMonto.LongMin = 0;
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
            this.txtMonto.Size = new System.Drawing.Size(203, 26);
            this.txtMonto.TabIndex = 4;
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
            this.btnCancelar.Location = new System.Drawing.Point(361, 385);
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
            this.btnAceptar.Location = new System.Drawing.Point(199, 385);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(288, 154);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(203, 26);
            this.txtFecha.TabIndex = 3;
            this.txtFecha.TabStop = false;
            this.txtFecha.Texto = "";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTipo.Location = new System.Drawing.Point(37, 154);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(203, 26);
            this.txtTipo.TabIndex = 1;
            this.txtTipo.TabStop = false;
            this.txtTipo.Texto = "";
            // 
            // OperacionCajaEditar
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(533, 431);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OperacionCajaEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Operación";
            this.Load += new System.EventHandler(this.OperacionCajaEditar_Load);
            this.Shown += new System.EventHandler(this.OperacionCajaEditar_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtTipo;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFecha;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel panel1;
        private Util.Controles.ucDinero txtMonto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtUsuarioCreador;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDineroEnCaja;
        private System.Windows.Forms.Label label16;
        
    }
}