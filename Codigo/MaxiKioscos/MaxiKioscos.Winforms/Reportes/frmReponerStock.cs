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
    public partial class frmReponerStock : Form
    {
        private int? _productoSeleccionado;
        private int? _proveedorSeleccionado;

        private ProductoRepository _productoRepository;
        public ProductoRepository ProductoRepository
        {
            get { return _productoRepository ?? (_productoRepository = new ProductoRepository()); }
            set
            {
                _productoRepository = value;
            }
        }

        private EFRepository<Proveedor> _proveedorRepository;
        public EFRepository<Proveedor> ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new EFRepository<Proveedor>()); }
            set
            {
                _proveedorRepository = value;
            }
        }
        
        private ReporteRepository _reponerStockRepository;
        public ReporteRepository ReponerStockRepository
        {
            get { return _reponerStockRepository ?? (_reponerStockRepository = new ReporteRepository()); }
            set
            {
                _reponerStockRepository = value;
            }
        }

        public List<ProductoHorario> ProductosDatasource { get; set; }


        public frmReponerStock()
        {
            InitializeComponent();
        }

        private void frmReponerStock_Load(object sender, EventArgs e)
        {
            ProductosDatasource = ProductoRepository.ListadoProductoHorario(AppSettings.MaxiKioscoId);
        }

        private void frmReponerStock_KeyDown(object sender, KeyEventArgs e)
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
            this.Cursor = Cursors.WaitCursor;
            rptReponerStock.LocalReport.DataSources.Clear();
            rptReponerStock.ProcessingMode = ProcessingMode.Local;
            string reportPath = @"\RDLS\ReponerStock.rdl";
            rptReponerStock.LocalReport.ReportPath = AppSettings.ApplicationPath + reportPath;
            
            var reponerStock = ReponerStockRepository.StockParaReponer(_productoSeleccionado,_proveedorSeleccionado, AppSettings.MaxiKioscoId);
            rptReponerStock.LocalReport.DataSources.Add(new ReportDataSource("dsReponerStock", reponerStock));
            _productoSeleccionado = (string.IsNullOrEmpty(txtProducto.Text)) ? null : _productoSeleccionado;
            _proveedorSeleccionado = (string.IsNullOrEmpty(txtProveedor.Text)) ? null : _proveedorSeleccionado;
            var parametros = new List<ReportParameter>
                                 {
                                     new ReportParameter("Producto", (string.IsNullOrEmpty(txtProducto.Text)) ? "TODOS" : txtProducto.Text),
                                     new ReportParameter("Proveedor", (string.IsNullOrEmpty(txtProveedor.Text)) ? "TODOS" : txtProveedor.Text),
                                     new ReportParameter("Maxikiosco", AppSettings.Maxikiosco.Nombre),
                                     new ReportParameter("Fecha", DateTime.Now.ToShortDateString())
                                 };
            rptReponerStock.LocalReport.SetParameters(parametros);
            this.rptReponerStock.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        

        #region Privados Combo Producto
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarPorCodigo(ProductoCriterioBusqueda.Codigo);
        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            var texto = txtProducto.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(e.KeyCode);
            }
            else
            {
                TratarTextoDistintoVacio(e.KeyCode);
            }
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            CerrarBuscador();
        }

        private void BuscarPorCodigo(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                var ids = new List<int> {0};
                var productos = ProductosDatasource.Where(p => ids.All(c => c != p.ProductoId)).ToList();
                var frm = new frmBuscador(txtProducto.Text, productos, false, criterio);
                frm.WidthBuscador = txtProducto.Width;
                frm.Cambio += BuscarArticulo;
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;
                
                Point locationOnForm = txtProducto.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();
                txtProducto.Focus();
            }
        }

        private void CerrarBuscador()
        {
            if (this.OwnedForms.Any())
            {
                this.OwnedForms.First().Close();
            }
        }

        private void AbrirBuscador(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                var idsAgregados = new List<int>();
                idsAgregados.Add(0);

                var productos = ProductosDatasource.Where(p => idsAgregados.All(c => c != p.ProductoId)).ToList();
                var frm = new Productos.frmBuscador(txtProducto.Text, productos, false, criterio);
                frm.WidthBuscador = txtProducto.Width;
                frm.Cambio += BuscarArticulo;
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;
                Point locationOnForm = txtProducto.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Show();
                frm.AplicarFiltros(txtProducto.Text);
                txtProducto.Focus();
            }
            else
            {
                var buscador = this.OwnedForms.First() as Productos.frmBuscador;
                buscador.AplicarFiltros(txtProducto.Text);
            }
        }

        private void FrmOnTeclaApretada(Keys key)
        {
            var texto = txtProducto.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(key);
            }
            else
            {
                TratarTextoDistintoVacio(key);
            }
        }

        private void TratarTextoDistintoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape, Keys.Multiply };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.Down:
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        BuscadorSubir();
                        break;
                    case Keys.Enter:
                        Agregar();
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                }
            }
            else
            {
                AbrirBuscador(ProductoCriterioBusqueda.Codigo);
                txtProducto.Focus();
            }
        }

        private void TratarTextoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.F6, Keys.Delete, Keys.Escape, Keys.Back, Keys.Enter, Keys.Down, Keys.Up };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.F6:
                        AbrirBuscador(ProductoCriterioBusqueda.Descripcion);
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                    case Keys.Back:
                        CerrarBuscador();
                        break;
                    case Keys.Enter:
                        Agregar();
                        break;
                    case Keys.Down:
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        BuscadorSubir();
                        break;
                }
            }
        }

        private void Agregar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscador;
                buscador.Aceptar(null);
                buscador.Close();
            }
        }

        private void BuscadorSubir()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscador;
                buscador.Subir();
            }
        }

        private void BuscadorBajar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as frmBuscador;
                buscador.Bajar();
            }
        }

        private void BuscarArticulo(ProductoHorario prod)
        {
            //char guion = "-";
            if (prod != null)
            {
                txtProducto.Text = prod.Descripcion;
                _productoSeleccionado= prod.ProductoId;
            }
            else
            {
                _productoSeleccionado = null;
            }
        }
        #endregion
       
       
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
