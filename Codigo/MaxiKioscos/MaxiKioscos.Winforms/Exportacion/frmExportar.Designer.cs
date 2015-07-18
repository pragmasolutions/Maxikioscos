namespace MaxiKioscos.Winforms.Exportacion
{
    partial class frmExportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportar));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSeleccionarDestino = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.radCompleta = new System.Windows.Forms.RadioButton();
            this.radDesdeFecha = new System.Windows.Forms.RadioButton();
            this.radDesincronizados = new System.Windows.Forms.RadioButton();
            this.dtpFecha = new Util.Controles.ucDatePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.lblTitulo.Size = new System.Drawing.Size(144, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Exportar Datos";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSeleccionarDestino);
            this.panel1.Controls.Add(this.txtDestino);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.radCompleta);
            this.panel1.Controls.Add(this.radDesdeFecha);
            this.panel1.Controls.Add(this.radDesincronizados);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 295);
            this.panel1.TabIndex = 12;
            // 
            // btnSeleccionarDestino
            // 
            this.btnSeleccionarDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarDestino.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarDestino.Image")));
            this.btnSeleccionarDestino.Location = new System.Drawing.Point(301, 237);
            this.btnSeleccionarDestino.Name = "btnSeleccionarDestino";
            this.btnSeleccionarDestino.Size = new System.Drawing.Size(35, 26);
            this.btnSeleccionarDestino.TabIndex = 51;
            this.btnSeleccionarDestino.UseVisualStyleBackColor = true;
            this.btnSeleccionarDestino.Click += new System.EventHandler(this.btnSeleccionarDestino_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestino.Enabled = false;
            this.txtDestino.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.Location = new System.Drawing.Point(21, 238);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(275, 25);
            this.txtDestino.TabIndex = 50;
            this.txtDestino.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(17, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 20);
            this.label14.TabIndex = 49;
            this.label14.Text = "Seleccione destino";
            // 
            // radCompleta
            // 
            this.radCompleta.AutoSize = true;
            this.radCompleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCompleta.Location = new System.Drawing.Point(31, 167);
            this.radCompleta.Name = "radCompleta";
            this.radCompleta.Size = new System.Drawing.Size(124, 20);
            this.radCompleta.TabIndex = 48;
            this.radCompleta.TabStop = true;
            this.radCompleta.Text = "Todos los datos";
            this.radCompleta.UseVisualStyleBackColor = true;
            this.radCompleta.CheckedChanged += new System.EventHandler(this.radOpcion_CheckedChanged);
            // 
            // radDesdeFecha
            // 
            this.radDesdeFecha.AutoSize = true;
            this.radDesdeFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDesdeFecha.Location = new System.Drawing.Point(31, 98);
            this.radDesdeFecha.Name = "radDesdeFecha";
            this.radDesdeFecha.Size = new System.Drawing.Size(137, 20);
            this.radDesdeFecha.TabIndex = 47;
            this.radDesdeFecha.TabStop = true;
            this.radDesdeFecha.Text = "A partir de la fecha";
            this.radDesdeFecha.UseVisualStyleBackColor = true;
            this.radDesdeFecha.CheckedChanged += new System.EventHandler(this.radOpcion_CheckedChanged);
            // 
            // radDesincronizados
            // 
            this.radDesincronizados.AutoSize = true;
            this.radDesincronizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDesincronizados.Location = new System.Drawing.Point(31, 57);
            this.radDesincronizados.Name = "radDesincronizados";
            this.radDesincronizados.Size = new System.Drawing.Size(127, 20);
            this.radDesincronizados.TabIndex = 46;
            this.radDesincronizados.TabStop = true;
            this.radDesincronizados.Text = "Desincronizados";
            this.radDesincronizados.UseVisualStyleBackColor = true;
            this.radDesincronizados.CheckedChanged += new System.EventHandler(this.radOpcion_CheckedChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Fecha = new System.DateTime(2014, 9, 20, 0, 0, 0, 0);
            this.dtpFecha.FechaMaxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.FechaMinima = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Location = new System.Drawing.Point(52, 124);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(165, 29);
            this.dtpFecha.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(17, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(148, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Seleccione una opción";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(40, 360);
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
            this.btnCancelar.Location = new System.Drawing.Point(196, 360);
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
            // frmExportar
            // 
            this.AcceptButton = this.btnAceptar;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(355, 405);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportar";
            this.Text = "Exportar Datos";
            this.Load += new System.EventHandler(this.frmExportar_Load);
            this.Shown += new System.EventHandler(this.frmExportar_Shown);
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
        private Util.Controles.ucDatePicker dtpFecha;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSeleccionarDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radCompleta;
        private System.Windows.Forms.RadioButton radDesdeFecha;
        private System.Windows.Forms.RadioButton radDesincronizados;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        
        
    }
}