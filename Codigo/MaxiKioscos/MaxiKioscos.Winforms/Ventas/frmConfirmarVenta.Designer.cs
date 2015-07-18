namespace MaxiKioscos.Winforms.Ventas
{
    partial class frmConfirmarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarVenta));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCambio = new Util.Controles.ucDinero();
            this.txtPagaCon = new Util.Controles.ucDinero();
            this.txtImporte = new Util.Controles.ucDinero();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitulo.Location = new System.Drawing.Point(10, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(156, 29);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Confirmar Venta";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCambio);
            this.panel1.Controls.Add(this.txtPagaCon);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 206);
            this.panel1.TabIndex = 3;
            // 
            // txtCambio
            // 
            this.txtCambio.Disabled = true;
            this.txtCambio.ErrorMessage = "";
            this.txtCambio.EsObligatorio = true;
            this.txtCambio.Location = new System.Drawing.Point(34, 167);
            this.txtCambio.LongMax = 32767;
            this.txtCambio.LongMin = 0;
            this.txtCambio.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtCambio.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCambio.ReadOnly = false;
            this.txtCambio.Size = new System.Drawing.Size(200, 26);
            this.txtCambio.TabIndex = 30;
            this.txtCambio.TabStop = false;
            this.txtCambio.TextboxTabIndex = 0;
            this.txtCambio.Valor = null;
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Disabled = false;
            this.txtPagaCon.ErrorMessage = "";
            this.txtPagaCon.EsObligatorio = true;
            this.txtPagaCon.Location = new System.Drawing.Point(34, 104);
            this.txtPagaCon.LongMax = 32767;
            this.txtPagaCon.LongMin = 0;
            this.txtPagaCon.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPagaCon.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPagaCon.ReadOnly = false;
            this.txtPagaCon.Size = new System.Drawing.Size(200, 26);
            this.txtPagaCon.TabIndex = 1;
            this.txtPagaCon.TextboxTabIndex = 1;
            this.txtPagaCon.Valor = null;
            this.txtPagaCon.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtPagaCon_Cambio);
            this.txtPagaCon.TeclaApretada += new Util.Controles.ucDinero.TeclaApretadaEventHandler(this.txtPagaCon_TeclaApretada);
            // 
            // txtImporte
            // 
            this.txtImporte.Disabled = true;
            this.txtImporte.ErrorMessage = "";
            this.txtImporte.EsObligatorio = true;
            this.txtImporte.Location = new System.Drawing.Point(34, 39);
            this.txtImporte.LongMax = 32767;
            this.txtImporte.LongMin = 0;
            this.txtImporte.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtImporte.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImporte.ReadOnly = false;
            this.txtImporte.Size = new System.Drawing.Size(200, 26);
            this.txtImporte.TabIndex = 28;
            this.txtImporte.TabStop = false;
            this.txtImporte.TextboxTabIndex = 0;
            this.txtImporte.Valor = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Cambio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Importe Total";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(30, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 20);
            this.label26.TabIndex = 23;
            this.label26.Text = "Paga con";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.41155F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.58845F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 317);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 262);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(266, 52);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(136, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(3, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(127, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Confirmar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // frmConfirmarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(272, 317);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConfirmarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar artículo";
            this.Load += new System.EventHandler(this.frmConfirmarVenta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventaProductoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Util.Controles.ucDinero txtCambio;
        private Util.Controles.ucDinero txtPagaCon;
        private Util.Controles.ucDinero txtImporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}