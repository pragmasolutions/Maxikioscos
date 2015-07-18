namespace MaxiKioscos.Winforms.OperacionesCaja
{
    partial class OperacionCajaDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperacionCajaDetalle));
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUsuarioCreador = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMonto = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtFecha = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.txtTipo = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.label14.Text = "Detalle de Operación";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(284, 52);
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
            this.label22.Location = new System.Drawing.Point(37, 143);
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
            this.label25.Location = new System.Drawing.Point(288, 74);
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
            this.label26.Location = new System.Drawing.Point(33, 52);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 20);
            this.label26.TabIndex = 2;
            this.label26.Text = "Tipo";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(41, 166);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(454, 68);
            this.txtObservaciones.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtUsuarioCreador);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 258);
            this.panel1.TabIndex = 2;
            // 
            // txtUsuarioCreador
            // 
            this.txtUsuarioCreador.Location = new System.Drawing.Point(41, 97);
            this.txtUsuarioCreador.Name = "txtUsuarioCreador";
            this.txtUsuarioCreador.Size = new System.Drawing.Size(203, 26);
            this.txtUsuarioCreador.TabIndex = 2;
            this.txtUsuarioCreador.Texto = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(37, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 26;
            this.label15.Text = "Creador";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(292, 97);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(203, 26);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.Texto = "";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(288, 75);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(203, 26);
            this.txtFecha.TabIndex = 3;
            this.txtFecha.Texto = "";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTipo.Location = new System.Drawing.Point(37, 75);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(203, 26);
            this.txtTipo.TabIndex = 1;
            this.txtTipo.Texto = "";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(352, 313);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Cerrar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // OperacionCajaDetalle
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 363);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OperacionCajaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Operación";
            this.Shown += new System.EventHandler(this.OperacionCajaDetalle_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtTipo;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtMonto;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtFecha;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Panel panel1;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtUsuarioCreador;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAceptar;
        
    }
}