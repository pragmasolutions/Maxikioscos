namespace MaxiKioscos.Winforms.Reportes
{
    partial class frmReponerStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReponerStock));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.rptReponerStock = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rptReponerStock);
            this.splitContainer1.Size = new System.Drawing.Size(964, 480);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 490F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtProducto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProveedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarProveedor, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarProducto, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Producto";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor";
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(103, 12);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(470, 26);
            this.txtProducto.TabIndex = 1;
            this.txtProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyUp);
            this.txtProducto.Leave += new System.EventHandler(this.txtProducto_Leave);
            // 
            // txtProveedor
            // 
            this.txtProveedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(103, 62);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(470, 26);
            this.txtProveedor.TabIndex = 3;
            this.txtProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProveedor_KeyUp);
            this.txtProveedor.Leave += new System.EventHandler(this.txtProveedor_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(673, 63);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar [F6]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProveedor.Image")));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(593, 61);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(30, 28);
            this.btnBuscarProveedor.TabIndex = 4;
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.Image")));
            this.btnBuscarProducto.Location = new System.Drawing.Point(593, 11);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(30, 28);
            this.btnBuscarProducto.TabIndex = 2;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // rptReponerStock
            // 
            this.rptReponerStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptReponerStock.Location = new System.Drawing.Point(0, 0);
            this.rptReponerStock.Name = "rptReponerStock";
            this.rptReponerStock.ShowBackButton = false;
            this.rptReponerStock.ShowCredentialPrompts = false;
            this.rptReponerStock.ShowDocumentMapButton = false;
            this.rptReponerStock.ShowFindControls = false;
            this.rptReponerStock.ShowParameterPrompts = false;
            this.rptReponerStock.ShowPromptAreaButton = false;
            this.rptReponerStock.ShowStopButton = false;
            this.rptReponerStock.ShowZoomControl = false;
            this.rptReponerStock.Size = new System.Drawing.Size(964, 376);
            this.rptReponerStock.TabIndex = 0;
            // 
            // frmReponerStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 480);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReponerStock";
            this.Text = "Productos por debajo del Stock de Reposición";
            this.Load += new System.EventHandler(this.frmReponerStock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReponerStock_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer rptReponerStock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnBuscarProveedor;
    }
}