namespace MaxiKioscos.Winforms.Ventas
{
    partial class frmModificarCantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarCantidad));
            this.txtCantidad = new Util.Controles.ucSoloNumero();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.AceptaDecimales = false;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Disabled = false;
            this.txtCantidad.ErrorMessage = "";
            this.txtCantidad.EsObligatorio = true;
            this.txtCantidad.Location = new System.Drawing.Point(114, 39);
            this.txtCantidad.LongMax = 2;
            this.txtCantidad.LongMin = 0;
            this.txtCantidad.MaximoValor = null;
            this.txtCantidad.MinimoValor = null;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCantidad.Size = new System.Drawing.Size(116, 25);
            this.txtCantidad.TabIndex = 0;
            this.txtCantidad.Valor = "";
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad:";
            // 
            // lblProducto
            // 
            this.lblProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(0, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(309, 33);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "* Para una devolución, ingrese la cantidad en negativo.";
            // 
            // frmModificarCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 104);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmModificarCantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar cantidad";
            this.Load += new System.EventHandler(this.frmModificarCantidad_Load);
            this.Shown += new System.EventHandler(this.frmModificarCantidad_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModificarCantidad_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Util.Controles.ucSoloNumero txtCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label2;
    }
}