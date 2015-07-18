namespace MaxiKioscos.Winforms.Compras
{
    partial class IngresoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgCompraProducto = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarPorMarca = new System.Windows.Forms.Button();
            this.btnBottomNuevoProducto = new System.Windows.Forms.Button();
            this.btnBottomAlterarProducto = new System.Windows.Forms.Button();
            this.btnBottomUnidades = new System.Windows.Forms.Button();
            this.btnBottomBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radDescuentoImporte = new System.Windows.Forms.RadioButton();
            this.radDescuentoPorcentaje = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDGR = new System.Windows.Forms.Label();
            this.chxIVA = new System.Windows.Forms.CheckBox();
            this.chxDGR = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDGR = new Util.Controles.ucDinero();
            this.txtTotalConDescuento = new Util.Controles.ucDinero();
            this.txtDescuento = new Util.Controles.ucDinero();
            this.txtTotalCompra = new Util.Controles.ucDinero();
            this.txtIVA = new Util.Controles.ucDinero();
            this.txtImporteTotal = new Util.Controles.ucDinero();
            this.txtDescuentoImporte = new Util.Controles.ucDinero();
            this.txtDescuentoPorcentaje = new Util.Controles.ucSoloNumero();
            this.ddlFacturas = new Util.Controles.ucDropDownList();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.compraProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compraProductoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadFormateada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primerCodigoProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoSinIVAFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioActualizadoFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gananciaFormateadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockAnteriorFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActualFormateado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoActualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioActualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desincronizadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaUltimaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.identifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoMarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockAnteriorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoActualFormateadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioActualFormateadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoSinIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoActualizadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioActualizadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompraProductoEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCompraProducto)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compraProductoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMostrarTodos);
            this.groupBox1.Controls.Add(this.btnAgregarFactura);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.ddlFacturas);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1161, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACION DE COMPRA";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarTodos.Image")));
            this.btnMostrarTodos.Location = new System.Drawing.Point(912, 36);
            this.btnMostrarTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(51, 34);
            this.btnMostrarTodos.TabIndex = 6;
            this.btnMostrarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregarFactura
            // 
            this.btnAgregarFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarFactura.Image")));
            this.btnAgregarFactura.Location = new System.Drawing.Point(853, 36);
            this.btnAgregarFactura.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(51, 34);
            this.btnAgregarFactura.TabIndex = 3;
            this.btnAgregarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.btnAgregarFactura_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(121, 96);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(613, 29);
            this.txtCodigo.TabIndex = 4;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(756, 95);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 32);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProducto.Location = new System.Drawing.Point(29, 100);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(75, 25);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(460, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Factura";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpFecha.Location = new System.Drawing.Point(121, 36);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(297, 30);
            this.dtpFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // dvgCompraProducto
            // 
            this.dvgCompraProducto.AllowUserToAddRows = false;
            this.dvgCompraProducto.AllowUserToDeleteRows = false;
            this.dvgCompraProducto.AllowUserToOrderColumns = true;
            this.dvgCompraProducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dvgCompraProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgCompraProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dvgCompraProducto.AutoGenerateColumns = false;
            this.dvgCompraProducto.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgCompraProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgCompraProducto.ColumnHeadersHeight = 46;
            this.dvgCompraProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compraProductoIdDataGridViewTextBoxColumn,
            this.CantidadFormateada,
            this.primerCodigoProductoDataGridViewTextBoxColumn,
            this.productoDescripcionDataGridViewTextBoxColumn,
            this.CostoSinIVAFormateado,
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn,
            this.PrecioActualizadoFormateado,
            this.gananciaFormateadaDataGridViewTextBoxColumn,
            this.StockAnteriorFormateado,
            this.StockActualFormateado,
            this.compraIdDataGridViewTextBoxColumn,
            this.productoIdDataGridViewTextBoxColumn,
            this.costoActualDataGridViewTextBoxColumn,
            this.precioActualDataGridViewTextBoxColumn,
            this.desincronizadoDataGridViewCheckBoxColumn,
            this.fechaUltimaModificacionDataGridViewTextBoxColumn,
            this.eliminadoDataGridViewCheckBoxColumn,
            this.identifierDataGridViewTextBoxColumn,
            this.compraDataGridViewTextBoxColumn,
            this.productoDataGridViewTextBoxColumn,
            this.productoMarcaDataGridViewTextBoxColumn,
            this.stockAnteriorDataGridViewTextBoxColumn,
            this.productoNombreDataGridViewTextBoxColumn,
            this.costoActualFormateadoDataGridViewTextBoxColumn,
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn,
            this.precioActualFormateadoDataGridViewTextBoxColumn,
            this.CostoSinIVA,
            this.costoActualizadoDataGridViewTextBoxColumn,
            this.precioActualizadoDataGridViewTextBoxColumn,
            this.StockAnterior,
            this.stockActualDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.CompraProductoEliminar});
            this.dvgCompraProducto.DataSource = this.compraProductoBindingSource;
            this.dvgCompraProducto.Location = new System.Drawing.Point(4, 203);
            this.dvgCompraProducto.Margin = new System.Windows.Forms.Padding(4);
            this.dvgCompraProducto.MultiSelect = false;
            this.dvgCompraProducto.Name = "dvgCompraProducto";
            this.dvgCompraProducto.ReadOnly = true;
            this.dvgCompraProducto.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgCompraProducto.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dvgCompraProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgCompraProducto.Size = new System.Drawing.Size(1163, 485);
            this.dvgCompraProducto.TabIndex = 4;
            this.dvgCompraProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCompraProducto_CellContentClick);
            this.dvgCompraProducto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dvgCompraProducto_CellPainting);
            this.dvgCompraProducto.Click += new System.EventHandler(this.dvgCompraProducto_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(16, 14);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(185, 41);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(209, 14);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 41);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscarPorMarca);
            this.panel1.Controls.Add(this.btnBottomNuevoProducto);
            this.panel1.Controls.Add(this.btnBottomAlterarProducto);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnBottomUnidades);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.btnBottomBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 682);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1620, 106);
            this.panel1.TabIndex = 2;
            // 
            // btnBuscarPorMarca
            // 
            this.btnBuscarPorMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarPorMarca.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarPorMarca.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBuscarPorMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPorMarca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPorMarca.Location = new System.Drawing.Point(244, 62);
            this.btnBuscarPorMarca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarPorMarca.Name = "btnBuscarPorMarca";
            this.btnBuscarPorMarca.Size = new System.Drawing.Size(205, 41);
            this.btnBuscarPorMarca.TabIndex = 14;
            this.btnBuscarPorMarca.Text = "Buscar por Marca (F5)";
            this.btnBuscarPorMarca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarPorMarca.UseVisualStyleBackColor = false;
            this.btnBuscarPorMarca.Click += new System.EventHandler(this.btnBuscarPorMarca_Click);
            // 
            // btnBottomNuevoProducto
            // 
            this.btnBottomNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBottomNuevoProducto.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBottomNuevoProducto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBottomNuevoProducto.Enabled = false;
            this.btnBottomNuevoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBottomNuevoProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBottomNuevoProducto.Location = new System.Drawing.Point(761, 62);
            this.btnBottomNuevoProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBottomNuevoProducto.Name = "btnBottomNuevoProducto";
            this.btnBottomNuevoProducto.Size = new System.Drawing.Size(168, 41);
            this.btnBottomNuevoProducto.TabIndex = 17;
            this.btnBottomNuevoProducto.Text = "Nuevo Producto (+)";
            this.btnBottomNuevoProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBottomNuevoProducto.UseVisualStyleBackColor = false;
            this.btnBottomNuevoProducto.Click += new System.EventHandler(this.btnBottomNuevoProducto_Click);
            // 
            // btnBottomAlterarProducto
            // 
            this.btnBottomAlterarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBottomAlterarProducto.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBottomAlterarProducto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBottomAlterarProducto.Enabled = false;
            this.btnBottomAlterarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBottomAlterarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBottomAlterarProducto.Location = new System.Drawing.Point(585, 62);
            this.btnBottomAlterarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBottomAlterarProducto.Name = "btnBottomAlterarProducto";
            this.btnBottomAlterarProducto.Size = new System.Drawing.Size(168, 41);
            this.btnBottomAlterarProducto.TabIndex = 16;
            this.btnBottomAlterarProducto.Text = "Alterar Producto (/)";
            this.btnBottomAlterarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBottomAlterarProducto.UseVisualStyleBackColor = false;
            this.btnBottomAlterarProducto.Click += new System.EventHandler(this.btnBottomAlterarProducto_Click);
            // 
            // btnBottomUnidades
            // 
            this.btnBottomUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBottomUnidades.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBottomUnidades.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBottomUnidades.Enabled = false;
            this.btnBottomUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBottomUnidades.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBottomUnidades.Location = new System.Drawing.Point(459, 62);
            this.btnBottomUnidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnBottomUnidades.Name = "btnBottomUnidades";
            this.btnBottomUnidades.Size = new System.Drawing.Size(119, 41);
            this.btnBottomUnidades.TabIndex = 15;
            this.btnBottomUnidades.Text = "Unidades (*)";
            this.btnBottomUnidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBottomUnidades.UseVisualStyleBackColor = false;
            this.btnBottomUnidades.Click += new System.EventHandler(this.btnBottomUnidades_Click);
            // 
            // btnBottomBuscar
            // 
            this.btnBottomBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBottomBuscar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBottomBuscar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBottomBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBottomBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBottomBuscar.Location = new System.Drawing.Point(16, 62);
            this.btnBottomBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBottomBuscar.Name = "btnBottomBuscar";
            this.btnBottomBuscar.Size = new System.Drawing.Size(220, 41);
            this.btnBottomBuscar.TabIndex = 13;
            this.btnBottomBuscar.Text = "Buscar por Nombre (F6)";
            this.btnBottomBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBottomBuscar.UseVisualStyleBackColor = false;
            this.btnBottomBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radDescuentoImporte);
            this.groupBox2.Controls.Add(this.radDescuentoPorcentaje);
            this.groupBox2.Controls.Add(this.txtImporteTotal);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtDescuentoImporte);
            this.groupBox2.Controls.Add(this.txtDescuentoPorcentaje);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Location = new System.Drawing.Point(1204, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(400, 170);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FACTURA";
            // 
            // radDescuentoImporte
            // 
            this.radDescuentoImporte.AutoSize = true;
            this.radDescuentoImporte.Checked = true;
            this.radDescuentoImporte.Enabled = false;
            this.radDescuentoImporte.Location = new System.Drawing.Point(229, 128);
            this.radDescuentoImporte.Margin = new System.Windows.Forms.Padding(4);
            this.radDescuentoImporte.Name = "radDescuentoImporte";
            this.radDescuentoImporte.Size = new System.Drawing.Size(17, 16);
            this.radDescuentoImporte.TabIndex = 61;
            this.radDescuentoImporte.TabStop = true;
            this.radDescuentoImporte.UseVisualStyleBackColor = true;
            this.radDescuentoImporte.CheckedChanged += new System.EventHandler(this.radDescuentoImporte_CheckedChanged);
            // 
            // radDescuentoPorcentaje
            // 
            this.radDescuentoPorcentaje.AutoSize = true;
            this.radDescuentoPorcentaje.Enabled = false;
            this.radDescuentoPorcentaje.Location = new System.Drawing.Point(229, 86);
            this.radDescuentoPorcentaje.Margin = new System.Windows.Forms.Padding(4);
            this.radDescuentoPorcentaje.Name = "radDescuentoPorcentaje";
            this.radDescuentoPorcentaje.Size = new System.Drawing.Size(17, 16);
            this.radDescuentoPorcentaje.TabIndex = 60;
            this.radDescuentoPorcentaje.UseVisualStyleBackColor = true;
            this.radDescuentoPorcentaje.CheckedChanged += new System.EventHandler(this.radDescuentoPorcentaje_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(49, 39);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(156, 24);
            this.label25.TabIndex = 58;
            this.label25.Text = "Importe Factura";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(51, 82);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 24);
            this.label24.TabIndex = 53;
            this.label24.Text = "Descuento %";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(5, 124);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(186, 24);
            this.label23.TabIndex = 52;
            this.label23.Text = "Descuento Importe";
            // 
            // lblCosto
            // 
            this.lblCosto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblCosto.Location = new System.Drawing.Point(163, 60);
            this.lblCosto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(66, 48);
            this.lblCosto.TabIndex = 61;
            this.lblCosto.Text = "$0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.Location = new System.Drawing.Point(115, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 48);
            this.label3.TabIndex = 60;
            this.label3.Text = "Total";
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.ForeColor = System.Drawing.Color.Black;
            this.lblIVA.Location = new System.Drawing.Point(33, 43);
            this.lblIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(118, 24);
            this.lblIVA.TabIndex = 56;
            this.lblIVA.Text = "IVA (0,00%)";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Controls.Add(this.chxIVA);
            this.groupBox3.Controls.Add(this.chxDGR);
            this.groupBox3.Controls.Add(this.txtDGR);
            this.groupBox3.Controls.Add(this.txtTotalConDescuento);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtDescuento);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtTotalCompra);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtIVA);
            this.groupBox3.Location = new System.Drawing.Point(1204, 193);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(400, 481);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "COMPRA FINAL";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCosto, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(29, 330);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(233, 110);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblIVA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDGR, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 188);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 81);
            this.tableLayoutPanel1.TabIndex = 72;
            // 
            // lblDGR
            // 
            this.lblDGR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDGR.AutoSize = true;
            this.lblDGR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDGR.ForeColor = System.Drawing.Color.Black;
            this.lblDGR.Location = new System.Drawing.Point(23, 0);
            this.lblDGR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDGR.Name = "lblDGR";
            this.lblDGR.Size = new System.Drawing.Size(128, 24);
            this.lblDGR.TabIndex = 68;
            this.lblDGR.Text = "DGR (0,00%)";
            this.lblDGR.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chxIVA
            // 
            this.chxIVA.AutoSize = true;
            this.chxIVA.Location = new System.Drawing.Point(220, 236);
            this.chxIVA.Margin = new System.Windows.Forms.Padding(4);
            this.chxIVA.Name = "chxIVA";
            this.chxIVA.Size = new System.Drawing.Size(18, 17);
            this.chxIVA.TabIndex = 9;
            this.chxIVA.UseVisualStyleBackColor = true;
            this.chxIVA.CheckedChanged += new System.EventHandler(this.chxIVA_CheckedChanged);
            // 
            // chxDGR
            // 
            this.chxDGR.AutoSize = true;
            this.chxDGR.Location = new System.Drawing.Point(220, 193);
            this.chxDGR.Margin = new System.Windows.Forms.Padding(4);
            this.chxDGR.Name = "chxDGR";
            this.chxDGR.Size = new System.Drawing.Size(18, 17);
            this.chxDGR.TabIndex = 7;
            this.chxDGR.UseVisualStyleBackColor = true;
            this.chxDGR.CheckedChanged += new System.EventHandler(this.chxDGR_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 24);
            this.label6.TabIndex = 66;
            this.label6.Text = "Total con Descuento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(88, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 64;
            this.label5.Text = "Descuento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(65, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 62;
            this.label4.Text = "Total Compra";
            // 
            // txtDGR
            // 
            this.txtDGR.Disabled = false;
            this.txtDGR.ErrorMessage = "";
            this.txtDGR.EsObligatorio = true;
            this.txtDGR.Location = new System.Drawing.Point(250, 186);
            this.txtDGR.LongMax = 32767;
            this.txtDGR.LongMin = 0;
            this.txtDGR.Margin = new System.Windows.Forms.Padding(5);
            this.txtDGR.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDGR.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDGR.Name = "txtDGR";
            this.txtDGR.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDGR.ReadOnly = false;
            this.txtDGR.Size = new System.Drawing.Size(123, 32);
            this.txtDGR.TabIndex = 8;
            this.txtDGR.TextboxTabIndex = 0;
            this.txtDGR.Valor = null;
            this.txtDGR.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtDGR_Cambio);
            // 
            // txtTotalConDescuento
            // 
            this.txtTotalConDescuento.Disabled = true;
            this.txtTotalConDescuento.ErrorMessage = "";
            this.txtTotalConDescuento.EsObligatorio = true;
            this.txtTotalConDescuento.Location = new System.Drawing.Point(251, 115);
            this.txtTotalConDescuento.LongMax = 32767;
            this.txtTotalConDescuento.LongMin = 0;
            this.txtTotalConDescuento.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalConDescuento.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtTotalConDescuento.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalConDescuento.Name = "txtTotalConDescuento";
            this.txtTotalConDescuento.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTotalConDescuento.ReadOnly = false;
            this.txtTotalConDescuento.Size = new System.Drawing.Size(123, 32);
            this.txtTotalConDescuento.TabIndex = 67;
            this.txtTotalConDescuento.TextboxTabIndex = 0;
            this.txtTotalConDescuento.Valor = null;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Disabled = true;
            this.txtDescuento.ErrorMessage = "";
            this.txtDescuento.EsObligatorio = true;
            this.txtDescuento.Location = new System.Drawing.Point(251, 75);
            this.txtDescuento.LongMax = 32767;
            this.txtDescuento.LongMin = 0;
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescuento.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDescuento.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescuento.ReadOnly = false;
            this.txtDescuento.Size = new System.Drawing.Size(123, 32);
            this.txtDescuento.TabIndex = 65;
            this.txtDescuento.TextboxTabIndex = 0;
            this.txtDescuento.Valor = null;
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Disabled = true;
            this.txtTotalCompra.ErrorMessage = "";
            this.txtTotalCompra.EsObligatorio = true;
            this.txtTotalCompra.Location = new System.Drawing.Point(251, 34);
            this.txtTotalCompra.LongMax = 32767;
            this.txtTotalCompra.LongMin = 0;
            this.txtTotalCompra.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalCompra.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtTotalCompra.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTotalCompra.ReadOnly = false;
            this.txtTotalCompra.Size = new System.Drawing.Size(123, 32);
            this.txtTotalCompra.TabIndex = 63;
            this.txtTotalCompra.TextboxTabIndex = 0;
            this.txtTotalCompra.Valor = null;
            // 
            // txtIVA
            // 
            this.txtIVA.Disabled = false;
            this.txtIVA.ErrorMessage = "";
            this.txtIVA.EsObligatorio = true;
            this.txtIVA.Location = new System.Drawing.Point(250, 229);
            this.txtIVA.LongMax = 32767;
            this.txtIVA.LongMin = 0;
            this.txtIVA.Margin = new System.Windows.Forms.Padding(5);
            this.txtIVA.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtIVA.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIVA.ReadOnly = false;
            this.txtIVA.Size = new System.Drawing.Size(123, 32);
            this.txtIVA.TabIndex = 10;
            this.txtIVA.TextboxTabIndex = 0;
            this.txtIVA.Valor = null;
            this.txtIVA.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtIVA_Cambio);
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Disabled = true;
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.ErrorMessage = "";
            this.txtImporteTotal.EsObligatorio = true;
            this.txtImporteTotal.Location = new System.Drawing.Point(252, 36);
            this.txtImporteTotal.LongMax = 32767;
            this.txtImporteTotal.LongMin = 0;
            this.txtImporteTotal.Margin = new System.Windows.Forms.Padding(5);
            this.txtImporteTotal.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtImporteTotal.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtImporteTotal.ReadOnly = false;
            this.txtImporteTotal.Size = new System.Drawing.Size(123, 32);
            this.txtImporteTotal.TabIndex = 59;
            this.txtImporteTotal.TextboxTabIndex = 0;
            this.txtImporteTotal.Valor = null;
            this.txtImporteTotal.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtImporteTotal_Cambio);
            // 
            // txtDescuentoImporte
            // 
            this.txtDescuentoImporte.Disabled = true;
            this.txtDescuentoImporte.ErrorMessage = "";
            this.txtDescuentoImporte.EsObligatorio = true;
            this.txtDescuentoImporte.Location = new System.Drawing.Point(252, 121);
            this.txtDescuentoImporte.LongMax = 32767;
            this.txtDescuentoImporte.LongMin = 0;
            this.txtDescuentoImporte.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescuentoImporte.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDescuentoImporte.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescuentoImporte.Name = "txtDescuentoImporte";
            this.txtDescuentoImporte.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescuentoImporte.ReadOnly = false;
            this.txtDescuentoImporte.Size = new System.Drawing.Size(123, 32);
            this.txtDescuentoImporte.TabIndex = 6;
            this.txtDescuentoImporte.TextboxTabIndex = 0;
            this.txtDescuentoImporte.Valor = null;
            this.txtDescuentoImporte.Cambio += new Util.Controles.ucDinero.CambioEventHandler(this.txtDescuentoImporte_Cambio);
            // 
            // txtDescuentoPorcentaje
            // 
            this.txtDescuentoPorcentaje.AceptaDecimales = true;
            this.txtDescuentoPorcentaje.CaracteresPermitidos = null;
            this.txtDescuentoPorcentaje.Disabled = true;
            this.txtDescuentoPorcentaje.ErrorMessage = "";
            this.txtDescuentoPorcentaje.EsObligatorio = true;
            this.txtDescuentoPorcentaje.Location = new System.Drawing.Point(252, 79);
            this.txtDescuentoPorcentaje.LongMax = 100;
            this.txtDescuentoPorcentaje.LongMin = 0;
            this.txtDescuentoPorcentaje.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescuentoPorcentaje.MaximoValor = null;
            this.txtDescuentoPorcentaje.MinimoValor = null;
            this.txtDescuentoPorcentaje.Name = "txtDescuentoPorcentaje";
            this.txtDescuentoPorcentaje.PosicionText = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescuentoPorcentaje.Size = new System.Drawing.Size(123, 31);
            this.txtDescuentoPorcentaje.TabIndex = 54;
            this.txtDescuentoPorcentaje.Valor = "";
            this.txtDescuentoPorcentaje.ValorDecimal = null;
            this.txtDescuentoPorcentaje.Cambio += new Util.Controles.ucSoloNumero.CambioEventHandler(this.txtDescuentoPorcentaje_Cambio);
            // 
            // ddlFacturas
            // 
            this.ddlFacturas.Alto = 34;
            this.ddlFacturas.Ancho = 291;
            this.ddlFacturas.DataSource = null;
            this.ddlFacturas.Disabled = false;
            this.ddlFacturas.DisplayMember = "";
            this.ddlFacturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFacturas.ErrorMessage = "";
            this.ddlFacturas.EsObligatorio = true;
            this.ddlFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ddlFacturas.InvalidateChar = null;
            this.ddlFacturas.Location = new System.Drawing.Point(553, 36);
            this.ddlFacturas.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ddlFacturas.Name = "ddlFacturas";
            this.ddlFacturas.Referencia = null;
            this.ddlFacturas.Size = new System.Drawing.Size(291, 34);
            this.ddlFacturas.TabIndex = 2;
            this.ddlFacturas.Valor = 0;
            this.ddlFacturas.ValueMember = "";
            this.ddlFacturas.ComboSelectedIndexChanged += new System.EventHandler(this.ddlFacturas_ComboSelectedIndexChanged);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 22;
            // 
            // compraProductoBindingSource
            // 
            this.compraProductoBindingSource.DataSource = typeof(MaxiKioscos.Entidades.CompraProducto);
            // 
            // compraProductoIdDataGridViewTextBoxColumn
            // 
            this.compraProductoIdDataGridViewTextBoxColumn.DataPropertyName = "CompraProductoId";
            this.compraProductoIdDataGridViewTextBoxColumn.HeaderText = "CompraProductoId";
            this.compraProductoIdDataGridViewTextBoxColumn.Name = "compraProductoIdDataGridViewTextBoxColumn";
            this.compraProductoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.compraProductoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // CantidadFormateada
            // 
            this.CantidadFormateada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CantidadFormateada.DataPropertyName = "CantidadFormateada";
            this.CantidadFormateada.HeaderText = "Cant";
            this.CantidadFormateada.Name = "CantidadFormateada";
            this.CantidadFormateada.ReadOnly = true;
            this.CantidadFormateada.Width = 40;
            // 
            // primerCodigoProductoDataGridViewTextBoxColumn
            // 
            this.primerCodigoProductoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.primerCodigoProductoDataGridViewTextBoxColumn.DataPropertyName = "PrimerCodigoProducto";
            this.primerCodigoProductoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.primerCodigoProductoDataGridViewTextBoxColumn.Name = "primerCodigoProductoDataGridViewTextBoxColumn";
            this.primerCodigoProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.primerCodigoProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // productoDescripcionDataGridViewTextBoxColumn
            // 
            this.productoDescripcionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productoDescripcionDataGridViewTextBoxColumn.DataPropertyName = "ProductoDescripcion";
            this.productoDescripcionDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDescripcionDataGridViewTextBoxColumn.Name = "productoDescripcionDataGridViewTextBoxColumn";
            this.productoDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CostoSinIVAFormateado
            // 
            this.CostoSinIVAFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostoSinIVAFormateado.DataPropertyName = "CostoSinIVAFormateado";
            this.CostoSinIVAFormateado.HeaderText = "Costo s/IVA";
            this.CostoSinIVAFormateado.Name = "CostoSinIVAFormateado";
            this.CostoSinIVAFormateado.ReadOnly = true;
            this.CostoSinIVAFormateado.Width = 70;
            // 
            // costoActualizadoFormateadoDataGridViewTextBoxColumn
            // 
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.DataPropertyName = "CostoActualizadoFormateado";
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.HeaderText = "Costo c/IVA";
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.Name = "costoActualizadoFormateadoDataGridViewTextBoxColumn";
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoActualizadoFormateadoDataGridViewTextBoxColumn.Width = 70;
            // 
            // PrecioActualizadoFormateado
            // 
            this.PrecioActualizadoFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecioActualizadoFormateado.DataPropertyName = "PrecioActualizadoFormateado";
            this.PrecioActualizadoFormateado.HeaderText = "Precio";
            this.PrecioActualizadoFormateado.Name = "PrecioActualizadoFormateado";
            this.PrecioActualizadoFormateado.ReadOnly = true;
            this.PrecioActualizadoFormateado.Width = 70;
            // 
            // gananciaFormateadaDataGridViewTextBoxColumn
            // 
            this.gananciaFormateadaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gananciaFormateadaDataGridViewTextBoxColumn.DataPropertyName = "GananciaFormateada";
            this.gananciaFormateadaDataGridViewTextBoxColumn.HeaderText = "Ganancia";
            this.gananciaFormateadaDataGridViewTextBoxColumn.Name = "gananciaFormateadaDataGridViewTextBoxColumn";
            this.gananciaFormateadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.gananciaFormateadaDataGridViewTextBoxColumn.Width = 70;
            // 
            // StockAnteriorFormateado
            // 
            this.StockAnteriorFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StockAnteriorFormateado.DataPropertyName = "StockAnteriorFormateado";
            this.StockAnteriorFormateado.HeaderText = "Stock Ant.";
            this.StockAnteriorFormateado.Name = "StockAnteriorFormateado";
            this.StockAnteriorFormateado.ReadOnly = true;
            this.StockAnteriorFormateado.Width = 70;
            // 
            // StockActualFormateado
            // 
            this.StockActualFormateado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StockActualFormateado.DataPropertyName = "StockActualFormateado";
            this.StockActualFormateado.HeaderText = "Stock Actual";
            this.StockActualFormateado.Name = "StockActualFormateado";
            this.StockActualFormateado.ReadOnly = true;
            this.StockActualFormateado.Width = 70;
            // 
            // compraIdDataGridViewTextBoxColumn
            // 
            this.compraIdDataGridViewTextBoxColumn.DataPropertyName = "CompraId";
            this.compraIdDataGridViewTextBoxColumn.HeaderText = "CompraId";
            this.compraIdDataGridViewTextBoxColumn.Name = "compraIdDataGridViewTextBoxColumn";
            this.compraIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.compraIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoIdDataGridViewTextBoxColumn
            // 
            this.productoIdDataGridViewTextBoxColumn.DataPropertyName = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.HeaderText = "ProductoId";
            this.productoIdDataGridViewTextBoxColumn.Name = "productoIdDataGridViewTextBoxColumn";
            this.productoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // costoActualDataGridViewTextBoxColumn
            // 
            this.costoActualDataGridViewTextBoxColumn.DataPropertyName = "CostoActual";
            this.costoActualDataGridViewTextBoxColumn.HeaderText = "CostoActual";
            this.costoActualDataGridViewTextBoxColumn.Name = "costoActualDataGridViewTextBoxColumn";
            this.costoActualDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoActualDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioActualDataGridViewTextBoxColumn
            // 
            this.precioActualDataGridViewTextBoxColumn.DataPropertyName = "PrecioActual";
            this.precioActualDataGridViewTextBoxColumn.HeaderText = "PrecioActual";
            this.precioActualDataGridViewTextBoxColumn.Name = "precioActualDataGridViewTextBoxColumn";
            this.precioActualDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioActualDataGridViewTextBoxColumn.Visible = false;
            // 
            // desincronizadoDataGridViewCheckBoxColumn
            // 
            this.desincronizadoDataGridViewCheckBoxColumn.DataPropertyName = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.HeaderText = "Desincronizado";
            this.desincronizadoDataGridViewCheckBoxColumn.Name = "desincronizadoDataGridViewCheckBoxColumn";
            this.desincronizadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.desincronizadoDataGridViewCheckBoxColumn.Visible = false;
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
            // identifierDataGridViewTextBoxColumn
            // 
            this.identifierDataGridViewTextBoxColumn.DataPropertyName = "Identifier";
            this.identifierDataGridViewTextBoxColumn.HeaderText = "Identifier";
            this.identifierDataGridViewTextBoxColumn.Name = "identifierDataGridViewTextBoxColumn";
            this.identifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.identifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // compraDataGridViewTextBoxColumn
            // 
            this.compraDataGridViewTextBoxColumn.DataPropertyName = "Compra";
            this.compraDataGridViewTextBoxColumn.HeaderText = "Compra";
            this.compraDataGridViewTextBoxColumn.Name = "compraDataGridViewTextBoxColumn";
            this.compraDataGridViewTextBoxColumn.ReadOnly = true;
            this.compraDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoDataGridViewTextBoxColumn
            // 
            this.productoDataGridViewTextBoxColumn.DataPropertyName = "Producto";
            this.productoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.productoDataGridViewTextBoxColumn.Name = "productoDataGridViewTextBoxColumn";
            this.productoDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoMarcaDataGridViewTextBoxColumn
            // 
            this.productoMarcaDataGridViewTextBoxColumn.DataPropertyName = "ProductoMarca";
            this.productoMarcaDataGridViewTextBoxColumn.HeaderText = "ProductoMarca";
            this.productoMarcaDataGridViewTextBoxColumn.Name = "productoMarcaDataGridViewTextBoxColumn";
            this.productoMarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoMarcaDataGridViewTextBoxColumn.Visible = false;
            // 
            // stockAnteriorDataGridViewTextBoxColumn
            // 
            this.stockAnteriorDataGridViewTextBoxColumn.DataPropertyName = "StockAnterior";
            this.stockAnteriorDataGridViewTextBoxColumn.HeaderText = "StockAnterior";
            this.stockAnteriorDataGridViewTextBoxColumn.Name = "stockAnteriorDataGridViewTextBoxColumn";
            this.stockAnteriorDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockAnteriorDataGridViewTextBoxColumn.Visible = false;
            // 
            // productoNombreDataGridViewTextBoxColumn
            // 
            this.productoNombreDataGridViewTextBoxColumn.DataPropertyName = "ProductoNombre";
            this.productoNombreDataGridViewTextBoxColumn.HeaderText = "ProductoNombre";
            this.productoNombreDataGridViewTextBoxColumn.Name = "productoNombreDataGridViewTextBoxColumn";
            this.productoNombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoNombreDataGridViewTextBoxColumn.Visible = false;
            // 
            // costoActualFormateadoDataGridViewTextBoxColumn
            // 
            this.costoActualFormateadoDataGridViewTextBoxColumn.DataPropertyName = "CostoActualFormateado";
            this.costoActualFormateadoDataGridViewTextBoxColumn.HeaderText = "CostoActualFormateado";
            this.costoActualFormateadoDataGridViewTextBoxColumn.Name = "costoActualFormateadoDataGridViewTextBoxColumn";
            this.costoActualFormateadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoActualFormateadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioActualizadoFormateadoDataGridViewTextBoxColumn
            // 
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn.DataPropertyName = "PrecioActualizadoFormateado";
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn.HeaderText = "PrecioActualizadoFormateado";
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn.Name = "precioActualizadoFormateadoDataGridViewTextBoxColumn";
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioActualizadoFormateadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // precioActualFormateadoDataGridViewTextBoxColumn
            // 
            this.precioActualFormateadoDataGridViewTextBoxColumn.DataPropertyName = "PrecioActualFormateado";
            this.precioActualFormateadoDataGridViewTextBoxColumn.HeaderText = "PrecioActualFormateado";
            this.precioActualFormateadoDataGridViewTextBoxColumn.Name = "precioActualFormateadoDataGridViewTextBoxColumn";
            this.precioActualFormateadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioActualFormateadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // CostoSinIVA
            // 
            this.CostoSinIVA.DataPropertyName = "CostoSinIVA";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.CostoSinIVA.DefaultCellStyle = dataGridViewCellStyle3;
            this.CostoSinIVA.HeaderText = "Costo s/IVA";
            this.CostoSinIVA.Name = "CostoSinIVA";
            this.CostoSinIVA.ReadOnly = true;
            this.CostoSinIVA.Visible = false;
            // 
            // costoActualizadoDataGridViewTextBoxColumn
            // 
            this.costoActualizadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costoActualizadoDataGridViewTextBoxColumn.DataPropertyName = "CostoActualizado";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.costoActualizadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.costoActualizadoDataGridViewTextBoxColumn.HeaderText = "Costo c/IVA";
            this.costoActualizadoDataGridViewTextBoxColumn.Name = "costoActualizadoDataGridViewTextBoxColumn";
            this.costoActualizadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoActualizadoDataGridViewTextBoxColumn.Visible = false;
            this.costoActualizadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // precioActualizadoDataGridViewTextBoxColumn
            // 
            this.precioActualizadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.precioActualizadoDataGridViewTextBoxColumn.DataPropertyName = "PrecioActualizado";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.precioActualizadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.precioActualizadoDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioActualizadoDataGridViewTextBoxColumn.Name = "precioActualizadoDataGridViewTextBoxColumn";
            this.precioActualizadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioActualizadoDataGridViewTextBoxColumn.Visible = false;
            this.precioActualizadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // StockAnterior
            // 
            this.StockAnterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StockAnterior.DataPropertyName = "StockAnterior";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.StockAnterior.DefaultCellStyle = dataGridViewCellStyle6;
            this.StockAnterior.HeaderText = "Stock Ant.";
            this.StockAnterior.Name = "StockAnterior";
            this.StockAnterior.ReadOnly = true;
            this.StockAnterior.Visible = false;
            this.StockAnterior.Width = 80;
            // 
            // stockActualDataGridViewTextBoxColumn
            // 
            this.stockActualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stockActualDataGridViewTextBoxColumn.DataPropertyName = "StockActual";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.stockActualDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.stockActualDataGridViewTextBoxColumn.HeaderText = "Stock Actual";
            this.stockActualDataGridViewTextBoxColumn.Name = "stockActualDataGridViewTextBoxColumn";
            this.stockActualDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockActualDataGridViewTextBoxColumn.Visible = false;
            this.stockActualDataGridViewTextBoxColumn.Width = 90;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cant";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Visible = false;
            this.cantidadDataGridViewTextBoxColumn.Width = 50;
            // 
            // CompraProductoEliminar
            // 
            this.CompraProductoEliminar.HeaderText = "";
            this.CompraProductoEliminar.Name = "CompraProductoEliminar";
            this.CompraProductoEliminar.ReadOnly = true;
            this.CompraProductoEliminar.Width = 22;
            // 
            // IngresoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 788);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dvgCompraProducto);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IngresoProductos";
            this.Text = "Ingreso de Mercadería";
            this.Load += new System.EventHandler(this.IngresoProductos_Load);
            this.Shown += new System.EventHandler(this.IngresoProductos_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCompraProducto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compraProductoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private Util.Controles.ucDropDownList ddlFacturas;
        private System.Windows.Forms.DataGridView dvgCompraProducto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaSecuenciaExportacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBottomAlterarProducto;
        private System.Windows.Forms.Button btnBottomUnidades;
        private System.Windows.Forms.Button btnBottomBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private Util.Controles.ucDinero txtDescuentoImporte;
        private Util.Controles.ucSoloNumero txtDescuentoPorcentaje;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private Util.Controles.ucDinero txtIVA;
        private System.Windows.Forms.Label lblIVA;
        private Util.Controles.ucDinero txtImporteTotal;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockTransaccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnBottomNuevoProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAgregarFactura;
        private System.Windows.Forms.GroupBox groupBox3;
        private Util.Controles.ucDinero txtTotalConDescuento;
        private System.Windows.Forms.Label label6;
        private Util.Controles.ucDinero txtDescuento;
        private System.Windows.Forms.Label label5;
        private Util.Controles.ucDinero txtTotalCompra;
        private System.Windows.Forms.Label label4;
        private Util.Controles.ucDinero txtDGR;
        private System.Windows.Forms.Label lblDGR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chxIVA;
        private System.Windows.Forms.CheckBox chxDGR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radDescuentoImporte;
        private System.Windows.Forms.RadioButton radDescuentoPorcentaje;
        private System.Windows.Forms.Button btnBuscarPorMarca;
        private System.Windows.Forms.BindingSource compraProductoBindingSource;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraProductoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadFormateada;
        private System.Windows.Forms.DataGridViewTextBoxColumn primerCodigoProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoSinIVAFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoActualizadoFormateadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioActualizadoFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn gananciaFormateadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockAnteriorFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActualFormateado;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn desincronizadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUltimaModificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identifierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoMarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockAnteriorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoActualFormateadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioActualizadoFormateadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioActualFormateadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoSinIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoActualizadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioActualizadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn CompraProductoEliminar;
    }
}