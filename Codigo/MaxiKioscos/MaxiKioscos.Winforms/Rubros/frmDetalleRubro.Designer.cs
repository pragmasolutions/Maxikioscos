namespace MaxiKioscos.Winforms.Rubros
{
    partial class frmDetalleRubro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleRubro));
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExcepciones = new System.Windows.Forms.DataGridView();
            this.excepcionRubroIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desdeHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hastaHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recargoAbsolutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recargoPorcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maxiKioscoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxiKioscoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excepcionRubroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtDescripcion = new MaxiKiosco.Win.Util.Controles.ucTextBoxGris();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcepciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excepcionRubroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(12, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "Detalle de Rubro";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(33, 61);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 20);
            this.label26.TabIndex = 0;
            this.label26.Text = "Descripción";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvExcepciones);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(-5, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 307);
            this.panel1.TabIndex = 1;
            // 
            // dgvExcepciones
            // 
            this.dgvExcepciones.AllowUserToAddRows = false;
            this.dgvExcepciones.AllowUserToDeleteRows = false;
            this.dgvExcepciones.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExcepciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcepciones.AutoGenerateColumns = false;
            this.dgvExcepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExcepciones.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExcepciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExcepciones.ColumnHeadersHeight = 31;
            this.dgvExcepciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.excepcionRubroIdDataGridViewTextBoxColumn,
            this.desdeHoraDataGridViewTextBoxColumn,
            this.hastaHoraDataGridViewTextBoxColumn,
            this.recargoAbsolutoDataGridViewTextBoxColumn,
            this.recargoPorcentajeDataGridViewTextBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.rubroIdDataGridViewTextBoxColumn,
            this.desdeDataGridViewTextBoxColumn,
            this.hastaDataGridViewTextBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.maxiKioscoIdDataGridViewTextBoxColumn,
            this.rubroDataGridViewTextBoxColumn,
            this.maxiKioscoDataGridViewTextBoxColumn});
            this.dgvExcepciones.DataSource = this.excepcionRubroBindingSource;
            this.dgvExcepciones.Location = new System.Drawing.Point(41, 131);
            this.dgvExcepciones.MultiSelect = false;
            this.dgvExcepciones.Name = "dgvExcepciones";
            this.dgvExcepciones.ReadOnly = true;
            this.dgvExcepciones.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExcepciones.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcepciones.Size = new System.Drawing.Size(477, 150);
            this.dgvExcepciones.TabIndex = 2;
            // 
            // excepcionRubroIdDataGridViewTextBoxColumn
            // 
            this.excepcionRubroIdDataGridViewTextBoxColumn.DataPropertyName = "ExcepcionRubroId";
            this.excepcionRubroIdDataGridViewTextBoxColumn.HeaderText = "ExcepcionRubroId";
            this.excepcionRubroIdDataGridViewTextBoxColumn.Name = "excepcionRubroIdDataGridViewTextBoxColumn";
            this.excepcionRubroIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.excepcionRubroIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // desdeHoraDataGridViewTextBoxColumn
            // 
            this.desdeHoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.desdeHoraDataGridViewTextBoxColumn.DataPropertyName = "DesdeHora";
            this.desdeHoraDataGridViewTextBoxColumn.HeaderText = "Desde";
            this.desdeHoraDataGridViewTextBoxColumn.Name = "desdeHoraDataGridViewTextBoxColumn";
            this.desdeHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.desdeHoraDataGridViewTextBoxColumn.Width = 110;
            // 
            // hastaHoraDataGridViewTextBoxColumn
            // 
            this.hastaHoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.hastaHoraDataGridViewTextBoxColumn.DataPropertyName = "HastaHora";
            this.hastaHoraDataGridViewTextBoxColumn.HeaderText = "Hasta";
            this.hastaHoraDataGridViewTextBoxColumn.Name = "hastaHoraDataGridViewTextBoxColumn";
            this.hastaHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.hastaHoraDataGridViewTextBoxColumn.Width = 110;
            // 
            // recargoAbsolutoDataGridViewTextBoxColumn
            // 
            this.recargoAbsolutoDataGridViewTextBoxColumn.DataPropertyName = "RecargoAbsoluto";
            this.recargoAbsolutoDataGridViewTextBoxColumn.HeaderText = "Recargo Absoluto";
            this.recargoAbsolutoDataGridViewTextBoxColumn.Name = "recargoAbsolutoDataGridViewTextBoxColumn";
            this.recargoAbsolutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recargoPorcentajeDataGridViewTextBoxColumn
            // 
            this.recargoPorcentajeDataGridViewTextBoxColumn.DataPropertyName = "RecargoPorcentaje";
            this.recargoPorcentajeDataGridViewTextBoxColumn.HeaderText = "Recargo Porcentaje";
            this.recargoPorcentajeDataGridViewTextBoxColumn.Name = "recargoPorcentajeDataGridViewTextBoxColumn";
            this.recargoPorcentajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // rubroIdDataGridViewTextBoxColumn
            // 
            this.rubroIdDataGridViewTextBoxColumn.DataPropertyName = "RubroId";
            this.rubroIdDataGridViewTextBoxColumn.HeaderText = "RubroId";
            this.rubroIdDataGridViewTextBoxColumn.Name = "rubroIdDataGridViewTextBoxColumn";
            this.rubroIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.rubroIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // desdeDataGridViewTextBoxColumn
            // 
            this.desdeDataGridViewTextBoxColumn.DataPropertyName = "Desde";
            this.desdeDataGridViewTextBoxColumn.HeaderText = "Desde";
            this.desdeDataGridViewTextBoxColumn.Name = "desdeDataGridViewTextBoxColumn";
            this.desdeDataGridViewTextBoxColumn.ReadOnly = true;
            this.desdeDataGridViewTextBoxColumn.Visible = false;
            // 
            // hastaDataGridViewTextBoxColumn
            // 
            this.hastaDataGridViewTextBoxColumn.DataPropertyName = "Hasta";
            this.hastaDataGridViewTextBoxColumn.HeaderText = "Hasta";
            this.hastaDataGridViewTextBoxColumn.Name = "hastaDataGridViewTextBoxColumn";
            this.hastaDataGridViewTextBoxColumn.ReadOnly = true;
            this.hastaDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaUltimaModificacionDataGridViewTextBoxColumn
            // 
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.HeaderText = "FechaUltimaModificacion";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Name = "fechaUltimaModificacionDataGridViewTextBoxColumn";
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaUltimaModificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // eliminadoDataGridViewCheckBoxColumn
            // 
            this.eliminadoDataGridViewCheckBoxColumn.DataPropertyName = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.HeaderText = "Eliminado";
            this.eliminadoDataGridViewCheckBoxColumn.Name = "eliminadoDataGridViewCheckBoxColumn";
            this.eliminadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.eliminadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // desincronizadoDataGridViewCheckBoxColumn
            // 
            this.desincronizadoDataGridViewCheckBoxColumn.DataPropertyName = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.HeaderText = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.Name = "desincronizadoDataGridViewCheckBoxColumn";
            this.desincronizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.desincronizadoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // maxiKioscoIdDataGridViewTextBoxColumn
            // 
            this.maxiKioscoIdDataGridViewTextBoxColumn.DataPropertyName = "MaxiKioscoId";
            this.maxiKioscoIdDataGridViewTextBoxColumn.HeaderText = "MaxiKioscoId";
            this.maxiKioscoIdDataGridViewTextBoxColumn.Name = "maxiKioscoIdDataGridViewTextBoxColumn";
            this.maxiKioscoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxiKioscoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // rubroDataGridViewTextBoxColumn
            // 
            this.rubroDataGridViewTextBoxColumn.DataPropertyName = "Rubro";
            this.rubroDataGridViewTextBoxColumn.HeaderText = "Rubro";
            this.rubroDataGridViewTextBoxColumn.Name = "rubroDataGridViewTextBoxColumn";
            this.rubroDataGridViewTextBoxColumn.ReadOnly = true;
            this.rubroDataGridViewTextBoxColumn.Visible = false;
            // 
            // maxiKioscoDataGridViewTextBoxColumn
            // 
            this.maxiKioscoDataGridViewTextBoxColumn.DataPropertyName = "MaxiKiosco";
            this.maxiKioscoDataGridViewTextBoxColumn.HeaderText = "MaxiKiosco";
            this.maxiKioscoDataGridViewTextBoxColumn.Name = "maxiKioscoDataGridViewTextBoxColumn";
            this.maxiKioscoDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxiKioscoDataGridViewTextBoxColumn.Visible = false;
            // 
            // excepcionRubroBindingSource
            // 
            this.excepcionRubroBindingSource.DataSource = typeof(MaxiKioscos.Entidades.ExcepcionRubro);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(37, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Excepciones";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(37, 87);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(203, 26);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Texto = "";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(375, 370);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 33);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Cerrar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // frmDetalleRubro
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 420);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDetalleRubro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Rubro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcepciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excepcionRubroBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label26;
        private MaxiKiosco.Win.Util.Controles.ucTextBoxGris txtDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvExcepciones;
        private System.Windows.Forms.BindingSource excepcionRubroBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn excepcionRubroIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desdeHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hastaHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recargoAbsolutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recargoPorcentajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxiKioscoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxiKioscoDataGridViewTextBoxColumn;
        
        
    }
}