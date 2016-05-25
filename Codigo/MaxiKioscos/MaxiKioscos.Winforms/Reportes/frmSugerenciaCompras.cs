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
using MaxiKioscos.Winforms.Configuracion;
using Microsoft.Reporting.WinForms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Productos;
namespace MaxiKioscos.Winforms.Reportes
{
    public partial class frmSugerenciaCompras : Form
    {
        private int? _proveedorSeleccionado;

        private EFRepository<Proveedor> _proveedorRepository;
        public EFRepository<Proveedor> ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new EFRepository<Proveedor>()); }
            set
            {
                _proveedorRepository = value;
            }
        }
        
        private ReporteRepository _reporteRepository;
        public ReporteRepository ReporteRepository
        {
            get { return _reporteRepository ?? (_reporteRepository = new ReporteRepository()); }
            set
            {
                _reporteRepository = value;
            }
        }
        
        public frmSugerenciaCompras()
        {
            InitializeComponent();
        }

        private void frmSugerenciaCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                Actualizar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
        
        private void Actualizar()
        {
            _proveedorSeleccionado = (string.IsNullOrEmpty(txtProveedor.Text)) ? null : _proveedorSeleccionado;
            if (!string.IsNullOrEmpty(txtDias.Valor) && _proveedorSeleccionado != null)
            {
                this.Cursor = Cursors.WaitCursor;
                rptSugerenciaCompras.LocalReport.DataSources.Clear();
                rptSugerenciaCompras.ProcessingMode = ProcessingMode.Local;
                string reportPath = @"\RDLS\SugerenciaCompras.rdl";
                rptSugerenciaCompras.LocalReport.ReportPath = AppSettings.ApplicationPath + reportPath;

                var sugerenciaCompras = ReporteRepository.ProductoSugerenciaCompras(_proveedorSeleccionado.GetValueOrDefault(), txtDias.ValorEntero.GetValueOrDefault(), AppSettings.MaxiKioscoId);
                rptSugerenciaCompras.LocalReport.DataSources.Add(new ReportDataSource("dsSugerenciaCompras", sugerenciaCompras));

                var parametros = new List<ReportParameter>
                                 {
                                     new ReportParameter("Proveedor", (string.IsNullOrEmpty(txtProveedor.Text)) ? "TODOS" : txtProveedor.Text),
                                     new ReportParameter("Maxikiosco", AppSettings.Maxikiosco.Nombre),
                                     new ReportParameter("Fecha", DateTime.Now.ToShortDateString())
                                 };
                rptSugerenciaCompras.LocalReport.SetParameters(parametros);
                this.rptSugerenciaCompras.RefreshReport();
                this.Cursor = Cursors.Default;
            }
        }

        #region Privados Combo Proveedor
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarPorProveedor();
        }

        private void txtProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            var texto = txtProveedor.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacioProv(e.KeyCode);
            }
            else
            {
                TratarTextoDistintoVacioProv(e.KeyCode);
            }
        }

        private void txtProveedor_Leave(object sender, EventArgs e)
        {
            CerrarBuscadorProveedor();
        }

        private void BuscarPorProveedor()
        {
            if (!this.OwnedForms.Any())
            {
                frmBuscadorProveedor frm = new frmBuscadorProveedor(txtProveedor.Text);

                frm.Cambio += BuscarProveedor;
                frm.TeclaApretada += FrmOnTeclaApretadaProv;
                frm.Owner = this;


                Point locationOnForm = txtProveedor.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();
                txtProveedor.Focus();
            }
        }

        private void CerrarBuscadorProveedor()
        {
            if (this.OwnedForms.Any())
            {
                this.OwnedForms.First().Close();
            }
        }

        private void AbrirBuscadorProv()
        {
            if (!this.OwnedForms.Any())
            {
                var frm = new frmBuscadorProveedor(txtProveedor.Text);
                frm.Cambio += BuscarProveedor;
                frm.TeclaApretada += FrmOnTeclaApretadaProv;
                frm.Owner = this;
                Point locationOnForm = txtProveedor.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();
                frm.AplicarFiltros(txtProveedor.Text);
                txtProveedor.Focus();
            }
            else
            {
                var buscador = this.OwnedForms.First() as frmBuscadorProveedor;
                buscador.AplicarFiltros(txtProveedor.Text);
            }
        }

        private void FrmOnTeclaApretadaProv(Keys key)
        {
            var texto = txtProveedor.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacioProv(key);
            }
            else
            {
                TratarTextoDistintoVacioProv(key);
            }
        }

        private void TratarTextoDistintoVacioProv(Keys keyCode)
        {
            var especiales = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape, Keys.Multiply };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.Down:
                        BuscadorBajarProv();
                        break;
                    case Keys.Up:
                        BuscadorSubirProv();
                        break;
                    case Keys.Enter:
                        AgregarProveedor();
                        break;
                    case Keys.Escape:
                        CerrarBuscadorProveedor();
                        break;
                }
            }
            else
            {
                AbrirBuscadorProv();
                txtProveedor.Focus();
            }
        }

        private void TratarTextoVacioProv(Keys keyCode)
        {
            var especiales = new[] { Keys.F6, Keys.Delete, Keys.Escape, Keys.Back, Keys.Enter, Keys.Down, Keys.Up };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.F6:
                        AbrirBuscadorProv();
                        break;
                    case Keys.Escape:
                        CerrarBuscadorProveedor();
                        break;
                    case Keys.Back:
                        CerrarBuscadorProveedor();
                        break;
                    case Keys.Enter:
                        AgregarProveedor();
                        break;
                    case Keys.Down:
                        BuscadorBajarProv();
                        break;
                    case Keys.Up:
                        BuscadorSubirProv();
                        break;
                }
            }
        }

        private void AgregarProveedor()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscadorProveedor;
                buscador.Aceptar();
                buscador.Close();
            }
        }

        private void BuscadorSubirProv()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscadorProveedor;
                buscador.Subir();
            }
        }

        private void BuscadorBajarProv()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscadorProveedor;
                buscador.Bajar();
            }
        }

        private void BuscarProveedor(Proveedor prov)
        {
            //char guion = "-";
            if (prov != null)
            {
                txtProveedor.Text = prov.Nombre;
                _proveedorSeleccionado = prov.ProveedorId;
            }
            else
            {
                _proveedorSeleccionado = null;
            }
        }
        #endregion
        
    }
}
