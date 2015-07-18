namespace MaxiKioscos.Winforms.Usuarios
{
    partial class frmCambiarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarPassword));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pswConfirmar = new Util.Controles.ucPassword();
            this.label16 = new System.Windows.Forms.Label();
            this.pswNueva = new Util.Controles.ucPassword();
            this.label15 = new System.Windows.Forms.Label();
            this.pswAnterior = new Util.Controles.ucPassword();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUsuario = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.label26 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.lblTitulo.Size = new System.Drawing.Size(194, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cambiar Contraseña";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pswConfirmar);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.pswNueva);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.pswAnterior);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 310);
            this.panel1.TabIndex = 1;
            // 
            // pswConfirmar
            // 
            this.pswConfirmar.Alto = 25;
            this.pswConfirmar.Ancho = 203;
            this.pswConfirmar.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.pswConfirmar.CharCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.pswConfirmar.ErrorMessage = "";
            this.pswConfirmar.EsObligatorio = true;
            this.pswConfirmar.IgualAControl = null;
            this.pswConfirmar.InvalidateChar = null;
            this.pswConfirmar.Location = new System.Drawing.Point(21, 257);
            this.pswConfirmar.LongMax = 32767;
            this.pswConfirmar.LongMin = 0;
            this.pswConfirmar.MultiLineas = false;
            this.pswConfirmar.Name = "pswConfirmar";
            this.pswConfirmar.Password = "";
            this.pswConfirmar.Referencia = null;
            this.pswConfirmar.Size = new System.Drawing.Size(203, 25);
            this.pswConfirmar.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(17, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 20);
            this.label16.TabIndex = 50;
            this.label16.Text = "Confirmar Contraseña";
            // 
            // pswNueva
            // 
            this.pswNueva.Alto = 25;
            this.pswNueva.Ancho = 203;
            this.pswNueva.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.pswNueva.CharCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.pswNueva.ErrorMessage = "";
            this.pswNueva.EsObligatorio = true;
            this.pswNueva.IgualAControl = null;
            this.pswNueva.InvalidateChar = null;
            this.pswNueva.Location = new System.Drawing.Point(21, 191);
            this.pswNueva.LongMax = 32767;
            this.pswNueva.LongMin = 0;
            this.pswNueva.MultiLineas = false;
            this.pswNueva.Name = "pswNueva";
            this.pswNueva.Password = "";
            this.pswNueva.Referencia = null;
            this.pswNueva.Size = new System.Drawing.Size(203, 25);
            this.pswNueva.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(17, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Nueva Contraseña";
            // 
            // pswAnterior
            // 
            this.pswAnterior.Alto = 25;
            this.pswAnterior.Ancho = 203;
            this.pswAnterior.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.pswAnterior.CharCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.pswAnterior.ErrorMessage = "";
            this.pswAnterior.EsObligatorio = true;
            this.pswAnterior.IgualAControl = null;
            this.pswAnterior.InvalidateChar = null;
            this.pswAnterior.Location = new System.Drawing.Point(21, 124);
            this.pswAnterior.LongMax = 32767;
            this.pswAnterior.LongMin = 0;
            this.pswAnterior.MultiLineas = false;
            this.pswAnterior.Name = "pswAnterior";
            this.pswAnterior.Password = "";
            this.pswAnterior.Referencia = null;
            this.pswAnterior.Size = new System.Drawing.Size(203, 25);
            this.pswAnterior.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 20);
            this.label14.TabIndex = 46;
            this.label14.Text = "Contraseña Anterior";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(21, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(203, 26);
            this.txtUsuario.TabIndex = 45;
            this.txtUsuario.Texto = "";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Usuario";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(22, 371);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 2;
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
            this.btnCancelar.Location = new System.Drawing.Point(178, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCambiarPassword
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(337, 421);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.frmCambiarPassword_Load);
            this.Shown += new System.EventHandler(this.frmCambiarPassword_Shown);
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
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label14;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtUsuario;
        private Util.Controles.ucPassword pswConfirmar;
        private System.Windows.Forms.Label label16;
        private Util.Controles.ucPassword pswNueva;
        private System.Windows.Forms.Label label15;
        private Util.Controles.ucPassword pswAnterior;
        
        
    }
}