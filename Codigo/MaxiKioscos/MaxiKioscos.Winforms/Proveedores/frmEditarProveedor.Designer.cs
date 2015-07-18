namespace MaxiKioscos.Winforms.Proveedores
{
    partial class FrmEditarProveedor
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbTipoCuit = new System.Windows.Forms.ComboBox();
            this.barraHerramientas1 = new ToolBar.BarraHerramientas();
            this.txtCelular = new Util.Controles.ucSoloNumero();
            this.txtTelefono = new Util.Controles.ucSoloNumero();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContacto = new Util.Controles.ucTexto();
            this.chxHabilitado = new System.Windows.Forms.CheckBox();
            this.cmbLocalidad = new Util.Controles.ucDropDownList();
            this.txtNombre = new Util.Controles.ucTexto();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmbTipoCuit);
            this.splitContainer1.Panel2.Controls.Add(this.barraHerramientas1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCelular);
            this.splitContainer1.Panel2.Controls.Add(this.txtTelefono);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.txtObservaciones);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.txtWeb);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.txtCuit);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtDireccion);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtContacto);
            this.splitContainer1.Panel2.Controls.Add(this.chxHabilitado);
            this.splitContainer1.Panel2.Controls.Add(this.cmbLocalidad);
            this.splitContainer1.Panel2.Controls.Add(this.txtNombre);
            this.splitContainer1.Size = new System.Drawing.Size(619, 458);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 10;
            // 
            // cmbTipoCuit
            // 
            this.cmbTipoCuit.Enabled = false;
            this.cmbTipoCuit.FormattingEnabled = true;
            this.cmbTipoCuit.Location = new System.Drawing.Point(118, 218);
            this.cmbTipoCuit.Name = "cmbTipoCuit";
            this.cmbTipoCuit.Size = new System.Drawing.Size(189, 21);
            this.cmbTipoCuit.TabIndex = 36;
            // 
            // barraHerramientas1
            // 
            this.barraHerramientas1.BackColor = System.Drawing.Color.Transparent;
            this.barraHerramientas1.BackgroundColorToolStrip = System.Drawing.Color.Transparent;
            this.barraHerramientas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraHerramientas1.FiltroOculto = false;
            this.barraHerramientas1.HabilitarExportar = true;
            this.barraHerramientas1.HabilitarFiltros = true;
            this.barraHerramientas1.HabilitarImprimir = true;
            this.barraHerramientas1.HabilitarVistaPreliminar = true;
            this.barraHerramientas1.Location = new System.Drawing.Point(0, 0);
            this.barraHerramientas1.MostrarExportar = false;
            this.barraHerramientas1.MostrarFiltros = false;
            this.barraHerramientas1.MostrarImprimir = false;
            this.barraHerramientas1.MostrarVistaPreliminar = false;
            this.barraHerramientas1.Name = "barraHerramientas1";
            this.barraHerramientas1.Size = new System.Drawing.Size(505, 31);
            this.barraHerramientas1.TabIndex = 14;
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.ErrorMessage = "";
            this.txtCelular.EsObligatorio = true;
            this.txtCelular.Location = new System.Drawing.Point(118, 186);
            this.txtCelular.LongMax = 32767;
            this.txtCelular.LongMin = 0;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCelular.Size = new System.Drawing.Size(189, 20);
            this.txtCelular.TabIndex = 6;
            this.txtCelular.Valor = "";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.ErrorMessage = "";
            this.txtTelefono.EsObligatorio = true;
            this.txtTelefono.Location = new System.Drawing.Point(118, 159);
            this.txtTelefono.LongMax = 32767;
            this.txtTelefono.LongMin = 0;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTelefono.Size = new System.Drawing.Size(189, 20);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.Valor = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 381);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Eliminado";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(118, 381);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Desincronizado";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(118, 331);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(189, 20);
            this.txtObservaciones.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Web";
            // 
            // txtWeb
            // 
            this.txtWeb.Enabled = false;
            this.txtWeb.Location = new System.Drawing.Point(118, 303);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(189, 20);
            this.txtWeb.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "E-Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(118, 275);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(189, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Cuit Numero";
            // 
            // txtCuit
            // 
            this.txtCuit.Enabled = false;
            this.txtCuit.Location = new System.Drawing.Point(118, 247);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(189, 20);
            this.txtCuit.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tipo Cuit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Celular";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Localidad";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(118, 103);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(189, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Contacto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // txtContacto
            // 
            this.txtContacto.Alto = 20;
            this.txtContacto.Ancho = 189;
            this.txtContacto.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.txtContacto.CharCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContacto.Enabled = false;
            this.txtContacto.ErrorMessage = "";
            this.txtContacto.EsObligatorio = true;
            this.txtContacto.InvalidateChar = null;
            this.txtContacto.Location = new System.Drawing.Point(118, 75);
            this.txtContacto.LongMax = 32767;
            this.txtContacto.LongMin = 0;
            this.txtContacto.MultiLineas = false;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Referencia = null;
            this.txtContacto.Size = new System.Drawing.Size(189, 20);
            this.txtContacto.TabIndex = 2;
            this.txtContacto.Valor = "";
            // 
            // chxHabilitado
            // 
            this.chxHabilitado.AutoSize = true;
            this.chxHabilitado.Enabled = false;
            this.chxHabilitado.Location = new System.Drawing.Point(118, 360);
            this.chxHabilitado.Name = "chxHabilitado";
            this.chxHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chxHabilitado.TabIndex = 12;
            this.chxHabilitado.UseVisualStyleBackColor = true;
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.Alto = 22;
            this.cmbLocalidad.Ancho = 189;
            this.cmbLocalidad.DataSource = null;
            this.cmbLocalidad.DisplayMember = "";
            this.cmbLocalidad.Enabled = false;
            this.cmbLocalidad.ErrorMessage = "";
            this.cmbLocalidad.EsObligatorio = true;
            this.cmbLocalidad.InvalidateChar = null;
            this.cmbLocalidad.Location = new System.Drawing.Point(118, 131);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Referencia = null;
            this.cmbLocalidad.Size = new System.Drawing.Size(189, 22);
            this.cmbLocalidad.TabIndex = 4;
            this.cmbLocalidad.Valor = 0;
            this.cmbLocalidad.ValueMember = "";
            // 
            // txtNombre
            // 
            this.txtNombre.Alto = 20;
            this.txtNombre.Ancho = 189;
            this.txtNombre.BarraScroll = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.CharCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.ErrorMessage = "";
            this.txtNombre.EsObligatorio = true;
            this.txtNombre.InvalidateChar = null;
            this.txtNombre.Location = new System.Drawing.Point(118, 47);
            this.txtNombre.LongMax = 32767;
            this.txtNombre.LongMin = 0;
            this.txtNombre.MultiLineas = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Referencia = null;
            this.txtNombre.Size = new System.Drawing.Size(189, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Valor = "";
            // 
            // FrmEditarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 458);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmEditarProveedor";
            this.Text = "Editar Proveedor";
            this.Load += new System.EventHandler(this.frmEditar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ToolBar.BarraHerramientas barraHerramientas1;
        private Util.Controles.ucTexto txtNombre;
        private Util.Controles.ucDropDownList cmbLocalidad;
        private System.Windows.Forms.CheckBox chxHabilitado;
        private Util.Controles.ucTexto txtContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Util.Controles.ucSoloNumero txtCelular;
        private Util.Controles.ucSoloNumero txtTelefono;
        private System.Windows.Forms.ComboBox cmbTipoCuit;
    }
}