using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using Microsoft.Reporting.WinForms;

namespace MaxiKioscos.Winforms.CierreCajas
{
    public partial class CierreCajaDetalle : Form
    {
        private EFRepository<CierreCaja> _cierreCajaRepository;
        public EFRepository<CierreCaja> CierreCajaRepository
        {
            get
            {
                if (_cierreCajaRepository == null)
                    _cierreCajaRepository = new EFRepository<CierreCaja>();
                return _cierreCajaRepository;
            }
        } 

        public CierreCajaDetalle(int cierreCajaId)
        {
            InitializeComponent();
            var cierreCaja = CierreCajaRepository.Obtener(c => c.CierreCajaId == cierreCajaId, c => c.MaxiKiosco, c => c.Usuario);
            var detalle = CierreCajaRepository.MaxiKioscosEntities.CierreCajaDetalle(cierreCajaId).ToList();


            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;


            string reportPath = @"\RDLS\CierreCajaDetalle.rdl";
            localReport.ReportPath = AppSettings.ApplicationPath + reportPath;
            localReport.DataSources.Add(new ReportDataSource("DataSet1", detalle));
            

            //Construyo los parámetros
            var rpMaxikiosco = new ReportParameter();
            rpMaxikiosco.Name = "Maxikiosco";
            rpMaxikiosco.Values.Add(cierreCaja.MaxiKiosco.Nombre);

            var rpCierreCajaId = new ReportParameter();
            rpCierreCajaId.Name = "CierreCajaId";
            rpCierreCajaId.Values.Add(cierreCajaId.ToString());

            var rpFechaDesde = new ReportParameter();
            rpFechaDesde.Name = "FechaDesde";
            rpFechaDesde.Values.Add(cierreCaja.FechaInicioFormateada);

            var rpFechaHasta = new ReportParameter();
            rpFechaHasta.Name = "FechaHasta";
            rpFechaHasta.Values.Add(cierreCaja.FechaFinFormateada);

            var rpUsuario = new ReportParameter();
            rpUsuario.Name = "Usuario";
            rpUsuario.Values.Add(String.Format("{0} {1}", cierreCaja.Usuario.Nombre, cierreCaja.Usuario.Apellido));

            var rpCajaFinal = new ReportParameter();
            rpCajaFinal.Name = "CajaFinal";
            rpCajaFinal.Values.Add(string.Format("${0:f2}", cierreCaja.CajaFinal));

            var rpDiferencia = new ReportParameter();
            rpDiferencia.Name = "Diferencia";
            rpDiferencia.Values.Add(string.Format("${0:f2}", cierreCaja.Diferencia));

            // Set the report parameters for the report
            localReport.SetParameters(new ReportParameter[] { rpMaxikiosco,
                                                            rpCierreCajaId,
                                                            rpFechaDesde,
                                                            rpFechaHasta,
                                                            rpUsuario,
                                                            rpCajaFinal,
                                                            rpDiferencia});

            // Refresh the report
            reportViewer1.RefreshReport();
        }

        private void CierreCajaDetalle_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
