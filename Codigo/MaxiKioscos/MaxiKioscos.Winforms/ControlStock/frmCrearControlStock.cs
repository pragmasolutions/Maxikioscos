using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKiosco.Win.Util;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.UserControls;
using Microsoft.Reporting.WinForms;
using Util;

namespace MaxiKioscos.Winforms.ControlStock
{
    public partial class frmCrearControlStock : Form
    {
        #region Repositories

        private ControlStockRepository _controlStockRepository;
        public ControlStockRepository ControlStockRepository
        {
            get { return _controlStockRepository ?? (_controlStockRepository = new ControlStockRepository()); }
        }

        private StockRepository _stockRepository;
        public StockRepository StockRepository
        {
            get { return _stockRepository ?? (_stockRepository = new StockRepository()); }
        }

        private EFRepository<Proveedor> _proveedorRepository;
        public EFRepository<Proveedor> ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new EFRepository<Proveedor>()); }
        }

        private EFRepository<Rubro> _rubroRepository;
        public EFRepository<Rubro> RubroRepository
        {
            get { return _rubroRepository ?? (_rubroRepository = new EFRepository<Rubro>()); }
        }

        private EFRepository<Compra> _comprasRepository;
        public EFRepository<Compra> ComprasRepository
        {
            get { return _comprasRepository ?? (_comprasRepository = new EFRepository<Compra>()); }
        }

        private EFRepository<Factura> _facturasRepository;
        public EFRepository<Factura> FacturasRepository
        {
            get { return _facturasRepository ?? (_facturasRepository = new EFRepository<Factura>()); }
        }

        #endregion

        #region Constructores
        public frmCrearControlStock(int rubroId, int proveedorId)
        {
            InitializeComponent();
            StockRepository.Actualizar();
            CargarControles();

            if (proveedorId != 0)
                ddlProveedor.SelectedValue = proveedorId;
            if (rubroId != 0)
                ddlRubro.SelectedValue = rubroId;

            txtFecha.Text = DateTime.Now.ToShortDateString();

        }
        #endregion

        public List<Rubro> Rubros { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public int LimiteInferior { get; set; }
        public int LimiteSuperior { get; set; }

        public int? ProveedorId
        {
            get { return (int) ddlProveedor.SelectedValue == 0 ? (int?) null : (int) ddlProveedor.SelectedValue; }
        }

        public int? RubroId
        {
            get
            {
                return (int)ddlRubro.SelectedValue == 0 ? (int?)null : (int?)ddlRubro.SelectedValue;
            }
        }

        public bool SoloMasVendidos
        {
            get { return chxSoloMasVendidos.Checked; }
        }

        public int? CantidadFilas
        {
            get
            {
                return string.IsNullOrEmpty(txtCantidadFilas.Valor)
                        ? (int?)null
                        : Convert.ToInt32(txtCantidadFilas.Valor.Split('.')[0]);
            }
        }

        #region Metodos
        
        
        private void CargarControles()
        {
            Proveedores = ProveedorRepository.Listado().OrderBy(p => p.Nombre).ToList();
            var proveedores = Proveedores.ToList();
            proveedores.Insert(0, new Proveedor() { ProveedorId = 0, Nombre = "(Seleccione Proveedor)"});
            ddlProveedor.DisplayMember = "Nombre";
            ddlProveedor.ValueMember = "ProveedorId";
            ddlProveedor.DataSource = proveedores;

            Rubros = RubroRepository.Listado().OrderBy(p => p.Descripcion).ToList();
            var rubros = Rubros.ToList();
            rubros.Insert(0, new Rubro { RubroId = 0, Descripcion = "(Seleccione Rubro)" });
            ddlRubro.DisplayMember = "Descripcion";
            ddlRubro.ValueMember = "RubroId";
            ddlRubro.DataSource = rubros;
        }

        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLimiteInferior.Valor) || string.IsNullOrEmpty(txtLimiteSuperior.Valor))
            {
                MessageBox.Show("Debe ingresar los límites inferior y superior");
                this.DialogResult = DialogResult.None;
                return;
            }

            var inferior = Convert.ToInt32(txtLimiteInferior.Valor);
            var superior = Convert.ToInt32(txtLimiteSuperior.Valor);
            if (superior < inferior)
            {
                MessageBox.Show("El límite inferior debe ser menor que el límite superior");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (inferior < 1)
            {
                MessageBox.Show("El valor mínimo para el límite inferior es 1");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (superior > LimiteSuperior)
            {
                MessageBox.Show("El valor máximo para el límite superior es " + LimiteSuperior);
                this.DialogResult = DialogResult.None; 
                return;
            }

            CrearControl(inferior, superior);
        }

        public void CrearControl(int inferior, int superior)
        {
            var stocksInicializados = ControlStockRepository.CrearControlStock(AppSettings.MaxiKioscoId, ProveedorId,
                                         RubroId, UsuarioActual.UsuarioId, SoloMasVendidos, CantidadFilas, inferior, superior);
            if (!stocksInicializados)
            {
                MessageBox.Show("Ha ocurrido un error registrado el control.");
                this.DialogResult = DialogResult.None;
            }
        }
        #endregion

        private void chxSoloMasVendidos_CheckedChanged(object sender, EventArgs e)
        {
            if (chxSoloMasVendidos.Checked)
            {
                txtCantidadFilas.Valor = "20";
                txtCantidadFilas.Disabled = false;
            }
            else
            {
                txtCantidadFilas.Valor = "";
                txtCantidadFilas.Disabled = true;
            }
        }

        private void ddlProveedor_Leave(object sender, EventArgs e)
        {
            var proveedorId = Convert.ToInt32(ddlProveedor.SelectedValue);
            List<Rubro> rubros = proveedorId == 0
                ? Rubros.ToList()
                : RubroRepository.MaxiKioscosEntities.ProveedorObtenerRubros(proveedorId).ToList();
            
            rubros.Insert(0, new Rubro { RubroId = 0, Descripcion = "(Seleccione Rubro)" });
            ddlRubro.DisplayMember = "Descripcion";
            ddlRubro.ValueMember = "RubroId";
            ddlRubro.DataSource = rubros;
        }

        private void frmCrearControlStock_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ProveedorId != null || RubroId != null)
            {
                if (ProveedorId != null)
                {
                    //Verifico si tiene facturas sin compras asociadas
                    var facturasIds = FacturasRepository.Listado().Where(f => f.ProveedorId == ProveedorId).Select(f => f.FacturaId).ToList();
                    var compras = ComprasRepository.Listado().Where(c => facturasIds.Contains(c.FacturaId)).Count();
                    if (facturasIds.Count() != compras)
                    {
                        var mensaje = "El proveedor seleccionado tiene facturas no han sido completadas. Está seguro que desea continuar?";
                        using (var popup = new ConfirmationForm(mensaje, "Si", "No"))
                        {
                            var result = popup.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                GenerarReporte();
                            }
                            else
                            {
                                DialogResult = DialogResult.None;
                            }
                        }
                    }
                    else
                    {
                        GenerarReporte();
                    }
                }
                else
                {
                    GenerarReporte();
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un proveedor y/o un rubro");
                this.DialogResult = DialogResult.None;
            }
        }

        private void GenerarReporte()
        {
            txtCantidadFilas.Disabled = true;
            chxSoloMasVendidos.Enabled = false;
            ddlProveedor.Enabled = false;
            ddlRubro.Enabled = false;
            btnGenerar.Enabled = false;
            btnReiniciar.Visible = true;
            btnAceptar.Enabled = true;
            pnlLimites.Visible = true;

            var detalles = ControlStockRepository.ReporteControlStockVistaPrevia(AppSettings.MaxiKioscoId, ProveedorId, 
                                                                            RubroId, SoloMasVendidos, CantidadFilas).ToList();

            LimiteInferior = 1;
            LimiteSuperior = detalles.Count();
            txtLimiteInferior.Valor = "1";
            txtLimiteSuperior.Valor = LimiteSuperior.ToString();
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;


            string reportPath = @"\RDLS\ControlStockVistaPrevia.rdl";
            localReport.ReportPath = AppSettings.ApplicationPath + reportPath;
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("DataSet1", detalles));	

            //Construyo los parámetros
            var rpMaxikiosco = new ReportParameter();
            rpMaxikiosco.Name = "Maxikiosco";
            rpMaxikiosco.Values.Add(AppSettings.Maxikiosco.Nombre);
            
            var rpFecha = new ReportParameter();
            rpFecha.Name = "Fecha";
            rpFecha.Values.Add(DateTime.Now.ToShortDateString());

            var rProveedor = new ReportParameter();
            rProveedor.Name = "Proveedor";
            rProveedor.Values.Add(ProveedorId.HasValue
                                    ? Proveedores.FirstOrDefault(p => p.ProveedorId == ProveedorId).Nombre
                                    : "-");

            var rpRubro = new ReportParameter();
            rpRubro.Name = "Rubro";
            rpRubro.Values.Add(RubroId.HasValue
                                    ? Rubros.FirstOrDefault(r => r.RubroId == RubroId).Descripcion
                                    : "-");

            var rpEstado = new ReportParameter();
            rpEstado.Name = "Estado";
            rpEstado.Values.Add("Abierto");

            var rpFechaCorreccion = new ReportParameter();
            rpFechaCorreccion.Name = "FechaCorreccion";
            rpFechaCorreccion.Values.Add("-");

            var nroControl = ControlStockRepository.Listado().Max(c => c.NroControl).GetValueOrDefault() + 1;
            var rpNroControl = new ReportParameter();
            rpNroControl.Name = "NroControl";
            rpNroControl.Values.Add(AppSettings.Maxikiosco.Abreviacion + nroControl);

            // Set the report parameters for the report
            localReport.SetParameters(new[] { rpMaxikiosco,
                                                rpFecha,
                                                rProveedor,
                                                rpRubro,
                                                rpEstado,
                                                rpFechaCorreccion,
                                                rpNroControl});

            // Refresh the report
            reportViewer1.RefreshReport();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtCantidadFilas.Disabled = false;
            chxSoloMasVendidos.Enabled = true;
            ddlProveedor.Enabled = true;
            ddlRubro.Enabled = true;
            btnGenerar.Enabled = true;
            btnReiniciar.Visible = false;
            btnAceptar.Enabled = false;
            pnlLimites.Visible = false;
        }
    }
}
