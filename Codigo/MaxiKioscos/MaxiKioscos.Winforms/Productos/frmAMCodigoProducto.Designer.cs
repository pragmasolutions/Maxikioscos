namespace MaxiKioscos.Winforms.Productos
{
    partial class frmAMCodigoProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAMCodigoProducto));
            this.bh = new ToolBar.BarraHerramientas();
            this.txtCodigoBarras = new Util.Controles.ucSoloNumero();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bh
            // 
            this.bh.BackColor = System.Drawing.Color.Transparent;
            this.bh.BackgroundColorToolStrip = System.Drawing.Color.Transparent;
            this.bh.Dock = System.Windows.Forms.DockStyle.Top;
            this.bh.FiltroOculto = false;
            this.bh.HabilitarExportar = true;
            this.bh.HabilitarFiltros = true;
            this.bh.HabilitarImprimir = true;
            this.bh.HabilitarVistaPreliminar = true;
            this.bh.Location = new System.Drawing.Point(0, 0);
            this.bh.MostrarExportar = false;
            this.bh.MostrarFiltros = false;
            this.bh.MostrarImprimir = false;
            this.bh.MostrarVistaPreliminar = false;
            this.bh.Name = "bh";
            this.bh.Size = new System.Drawing.Size(364, 31);
            this.bh.TabIndex = 0;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.AceptaDecimales = false;
            this.txtCodigoBarras.Disabled = false;
            this.txtCodigoBarras.ErrorMessage = "";
            this.txtCodigoBarras.EsObligatorio = true;
            this.txtCodigoBarras.Location = new System.Drawing.Point(142, 59);
            this.txtCodigoBarras.LongMax = 13;
            this.txtCodigoBarras.LongMin = 0;
            this.txtCodigoBarras.MaximoValor = null;
            this.txtCodigoBarras.MinimoValor = null;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCodigoBarras.Size = new System.Drawing.Size(169, 28);
            this.txtCodigoBarras.TabIndex = 1;
            this.txtCodigoBarras.Valor = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Código de Barras:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmAMCodigoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 110);
            this.ControlBox = false;
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAMCodigoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAMCodigoProducto";
            this.Load += new System.EventHandler(this.frmAMCodigoProducto_Load);
            this.Shown += new System.EventHandler(this.frmAMCodigoProducto_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolBar.BarraHerramientas bh;
        private Util.Controles.ucSoloNumero txtCodigoBarras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}