using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Entidades;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Configuracion;
namespace MaxiKioscos.Winforms.Reportes
{
    public partial class frmBuscadorProveedor : Form
    {
        private EFRepository<Proveedor> _repository;
        public List<Proveedor> Proveedores { get; set; }
        private ProveedorRepository repoProveedor=new ProveedorRepository();
        public Proveedor ProveedorSeleccionado { get; set; }
        public EFRepository<Proveedor> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Proveedor>()); }
        }

        public delegate void CambioEventHandler(Proveedor proveedor);
        private CambioEventHandler CambioEvent;

        public event CambioEventHandler Cambio
        {
            add
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Combine(CambioEvent, value);
            }
            remove
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Remove(CambioEvent, value);
            }
        }

        public delegate void TeclaApretadaEventHandler(Keys key);
        private TeclaApretadaEventHandler TeclaApretadaEvent;

        public event TeclaApretadaEventHandler TeclaApretada
        {
            add
            {
                TeclaApretadaEvent = (TeclaApretadaEventHandler)System.Delegate.Combine(TeclaApretadaEvent, value);
            }
            remove
            {
                TeclaApretadaEvent = (TeclaApretadaEventHandler)System.Delegate.Remove(TeclaApretadaEvent, value);
            }
        }


        public string Texto { get; set; }

        public frmBuscadorProveedor(string texto)
        {
            InitializeComponent();
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            Proveedores = repoProveedor.Listado().ToList();
            Texto = texto;
        }
        
        public void Aceptar()
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var proveedorId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["proveedorId"].Value.ToString());
                ProveedorSeleccionado = Proveedores.FirstOrDefault(p => p.ProveedorId == proveedorId);
                CambioEvent(ProveedorSeleccionado);
                DialogResult = DialogResult.OK;
            }
        }
        
        public void AplicarFiltros(string texto)
        {
            var text = texto.Trim().ToLower();
            var datasource = Proveedores.Where(p => p.Nombre.ToLower().Contains(text)).ToList();
            dgvListado.DataSource = datasource.ToArray();
        }


        public void Bajar()
        {
            if (dgvListado.RowCount > 0)
            {
                if (dgvListado.SelectedRows.Count > 0)
                {
                    int rowCount = dgvListado.Rows.Count;
                    int index = dgvListado.SelectedCells[0].OwningRow.Index;

                    if (index != (rowCount - 1)) // include the header row
                    {
                        var nextIndex = index + 1;
                       
                        dgvListado.ClearSelection();
                        dgvListado.Rows[nextIndex].Selected = true;

                        // keep selection visible
                        if ((nextIndex) >= (dgvListado.FirstDisplayedScrollingRowIndex + dgvListado.DisplayedRowCount(false)))
                            dgvListado.FirstDisplayedScrollingRowIndex = dgvListado.FirstDisplayedScrollingRowIndex + 1;
                    }
                }
            }
        }

        public void Subir()
        {
            if (dgvListado.RowCount > 0)
            {
                if (dgvListado.SelectedRows.Count > 0)
                {
                    int index = dgvListado.SelectedCells[0].OwningRow.Index;

                    if (index != 0) // include the header row
                    {
                        var nextIndex = index - 1;
                        dgvListado.ClearSelection();
                        dgvListado.Rows[index - 1].Selected = true;

                        // keep selection visible
                        if ((nextIndex) < dgvListado.FirstDisplayedScrollingRowIndex)
                            dgvListado.FirstDisplayedScrollingRowIndex = nextIndex;
                    }
                }
            }
        }
        
        private void frmBuscadorProvedor_KeyDown(object sender, KeyEventArgs e)
        {
            TeclaApretadaEvent(e.KeyCode);
        }

        private void frmBuscadorProvedor_Load(object sender, EventArgs e)
        {
            AplicarFiltros(Texto);
        }

        private void frmBuscadorProvedor_Shown(object sender, EventArgs e)
        {

        }
    }
}
