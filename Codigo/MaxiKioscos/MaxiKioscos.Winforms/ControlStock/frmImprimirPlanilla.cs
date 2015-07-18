using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using Microsoft.Reporting.WinForms;

namespace MaxiKioscos.Winforms.ControlStock
{
    public partial class frmImprimirPlanilla : Form
    {
        private ControlStockRepository _controlStockRepository;
        public ControlStockRepository ControlStockRepository
        {
            get { return _controlStockRepository ?? (_controlStockRepository = new ControlStockRepository()); }
        }

        private int _controlStockId = 0;

        public frmImprimirPlanilla(int controlStockId)
        {
            InitializeComponent();
            _controlStockId = controlStockId;
            LlenarPlanilla();
        }

        private void LlenarPlanilla()
        {
            var controlStock = ControlStockRepository.Obtener(c => c.ControlStockId == _controlStockId,
                                                           c => c.MaxiKiosco, c => c.Proveedor, c => c.Rubro);
            var detalles = ControlStockRepository.ReporteControlStockPlanilla(_controlStockId).ToList();


            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;


            string reportPath = @"\RDLS\ControlStock.rdl";
            localReport.ReportPath = AppSettings.ApplicationPath + reportPath;
            localReport.DataSources.Add(new ReportDataSource("DataSet1", detalles));


            //Construyo los parámetros
            var rpMaxikiosco = new ReportParameter();
            rpMaxikiosco.Name = "Maxikiosco";
            rpMaxikiosco.Values.Add(controlStock.MaxiKiosco.Nombre);

            var rpControlStockId = new ReportParameter();
            rpControlStockId.Name = "ControlStockId";
            rpControlStockId.Values.Add(_controlStockId.ToString());

            var rpFecha = new ReportParameter();
            rpFecha.Name = "Fecha";
            rpFecha.Values.Add(controlStock.FechaCreacion.ToShortDateString());

            var rProveedor = new ReportParameter();
            rProveedor.Name = "Proveedor";
            rProveedor.Values.Add(string.IsNullOrEmpty(controlStock.ProveedorNombre) ? "-" : controlStock.ProveedorNombre);

            var rpRubro = new ReportParameter();
            rpRubro.Name = "Rubro";
            rpRubro.Values.Add(string.IsNullOrEmpty(controlStock.RubroDescripcion) ? "-" : controlStock.RubroDescripcion);

            var rpEstado = new ReportParameter();
            rpEstado.Name = "Estado";
            rpEstado.Values.Add(controlStock.Estado);

            var rpFechaCorreccion = new ReportParameter();
            rpFechaCorreccion.Name = "FechaCorreccion";
            rpFechaCorreccion.Values.Add(controlStock.FechaCorreccion == null
                                                    ? "-"
                                                    : controlStock.FechaCorreccion.GetValueOrDefault().ToShortDateString());

            var rpNroControl = new ReportParameter();
            rpNroControl.Name = "NroControl";
            rpNroControl.Values.Add(controlStock.NroControlFormateado);

            // Set the report parameters for the report
            localReport.SetParameters(new[] { rpMaxikiosco,
                                                rpControlStockId,
                                                rpFecha,
                                                rProveedor,
                                                rpRubro,
                                                rpEstado,
                                                rpFechaCorreccion,
                                                rpNroControl});

            // Refresh the report
            reportViewer1.RefreshReport();
        }

        private void frmImprimirPlanilla_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void frmImprimirPlanilla_Activated(object sender, EventArgs e)
        {
            LlenarPlanilla();
        }
    }
}
