namespace MaxiKioscos.Winforms.Controles
{
    partial class UcPaginador
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.txtPaginaActual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPaginas = new System.Windows.Forms.TextBox();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(10, 14);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(34, 23);
            this.btnPrimero.TabIndex = 0;
            this.btnPrimero.Text = "<<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(57, 14);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(35, 23);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(275, 14);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(36, 23);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(324, 14);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(34, 23);
            this.btnUltimo.TabIndex = 3;
            this.btnUltimo.Text = ">>";
            this.btnUltimo.UseVisualStyleBackColor = true;
            // 
            // txtPaginaActual
            // 
            this.txtPaginaActual.Location = new System.Drawing.Point(114, 16);
            this.txtPaginaActual.Name = "txtPaginaActual";
            this.txtPaginaActual.Size = new System.Drawing.Size(56, 20);
            this.txtPaginaActual.TabIndex = 4;
            this.txtPaginaActual.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "de";
            // 
            // txtTotalPaginas
            // 
            this.txtTotalPaginas.Enabled = false;
            this.txtTotalPaginas.Location = new System.Drawing.Point(204, 16);
            this.txtTotalPaginas.Name = "txtTotalPaginas";
            this.txtTotalPaginas.Size = new System.Drawing.Size(56, 20);
            this.txtTotalPaginas.TabIndex = 6;
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "3",
            "10",
            "20",
            "50",
            "100"});
            this.cmbPageSize.Location = new System.Drawing.Point(398, 15);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(75, 21);
            this.cmbPageSize.TabIndex = 7;
            // 
            // UcPaginador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPageSize);
            this.Controls.Add(this.txtTotalPaginas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaginaActual);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimero);
            this.Name = "UcPaginador";
            this.Size = new System.Drawing.Size(490, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.TextBox txtPaginaActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPaginas;
        private System.Windows.Forms.ComboBox cmbPageSize;
    }
}
