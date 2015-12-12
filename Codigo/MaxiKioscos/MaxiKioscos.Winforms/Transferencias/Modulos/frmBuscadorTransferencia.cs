using System;
using System.Collections;
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
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Productos;

namespace MaxiKioscos.Winforms.Transferencias.Modulos
{
    public partial class frmBuscadorTransferencia : Form
    {
        private EFRepository<Producto> _repository;
        public List<ProductoTransferenciaDesktop> Productos { get; set; }
        
        public ProductoTransferenciaDesktop ProductoSeleccionado { get; set; }
        public EFRepository<Producto> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Producto>()); }
        }

        public bool RecordarBusqueda
        {
            get
            {
                if (chxBuscarPorCodigo == null)
                    return false;
                return !chxBuscarPorCodigo.Checked;
            }
        }

        public delegate void CambioEventHandler(ProductoTransferenciaDesktop ProductoTransferenciaDesktop);
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


        public delegate void MensajeErrorEventHandler();
        private MensajeErrorEventHandler MensajeErrorEvent;

        public event MensajeErrorEventHandler MensajeError
        {
            add
            {
                MensajeErrorEvent = (MensajeErrorEventHandler)System.Delegate.Combine(MensajeErrorEvent, value);
            }
            remove
            {
                MensajeErrorEvent = (MensajeErrorEventHandler)System.Delegate.Remove(MensajeErrorEvent, value);
            }
        }

        private ProductoCriterioBusqueda _criterioBusqueda;

        public int WidthBuscador { get { return this.Width; } set { this.Width = value; } }

        public string Texto { get; set; }
        public List<int> AgregadosIds { get; set; }
        private bool _esVenta = true;

        public frmBuscadorTransferencia(string texto, List<ProductoTransferenciaDesktop> productos, bool esVenta, ProductoCriterioBusqueda criterio)
        {
            InitializeComponent();
            _criterioBusqueda = criterio;
            Texto = texto;
            Productos = productos;
            _esVenta = esVenta;

            switch (criterio)
            {
                case ProductoCriterioBusqueda.Descripcion:
                    tableLayoutPanel2.BackColor = Color.Gold;
                    break;
                case ProductoCriterioBusqueda.Marca:
                    tableLayoutPanel2.BackColor = Color.DarkSalmon;
                    break;
            }
        }

        private void frmBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            TeclaApretadaEvent(e.KeyCode);
        }
        
        public void Aceptar(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                codigo = codigo.ToLower();
            }
            if (dgvListado.Rows.Count == 0)
            {
                ProductoSeleccionado = Productos.FirstOrDefault(p => p.Codigo.Split(',').Any(c => c.ToLower() == codigo));
                if (ProductoSeleccionado != null)
                {
                    CambioEvent(ProductoSeleccionado);
                    DialogResult = DialogResult.OK;
                }
            }
            else if (dgvListado.SelectedRows.Count > 0)
            {
                var productoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["productoId"].Value.ToString());
                var prod = Productos.FirstOrDefault(p => p.ProductoId == productoId);
                if (!_esVenta || prod.Codigos.Any(c => c.ToLower() == codigo) || _criterioBusqueda != ProductoCriterioBusqueda.Codigo)
                {
                    ProductoSeleccionado = prod;
                    CambioEvent(ProductoSeleccionado);
                    DialogResult = DialogResult.OK;
                }
            }
            if (ProductoSeleccionado == null)
            {
                if (MensajeErrorEvent != null)
                {
                    MensajeErrorEvent();
                }

                MessageBox.Show("Producto no encontrado");
                DialogResult = DialogResult.None;
            }
            
        }
        
        public void AplicarFiltros(string texto)
        {
            var text = texto.Trim().ToLower();
            var lista = Productos.Where(p => (chxBuscarPorNombre.Checked && p.Descripcion.ToLower().Contains(text)
                                              || (chxBuscarPorMarca.Checked && (p.Marca != null && p.Marca.ToLower().Contains(text)))
                                              || (!string.IsNullOrEmpty(p.Codigo) && chxBuscarPorCodigo.Checked &&
                                                    p.Codigos.Any(c => c.ToLower().StartsWith(text))))).ToArray();

            if (chxBuscarPorNombre.Checked || chxBuscarPorMarca.Checked)
            {
                dgvListado.DataSource = lista.OrderBy(p => p.Descripcion).ToArray();
            }
            else
            {
                foreach (var ProductoTransferenciaDesktop in lista)
                {
                    ProductoTransferenciaDesktop.Filter = text.ToLower();
                }
                var array = new ArrayList(lista);

                //var array = lista.ToArray();
                array.Sort();
                dgvListado.DataSource = array.ToArray().ToList();
            }
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

        private void frmBuscador_Shown(object sender, EventArgs e)
        {
            //txtBuscar.Select();
        }

        private void frmBuscador_Load(object sender, EventArgs e)
        {
            dgvListado.AutoGenerateColumns = false;
            if (!_esVenta)
            {
                dgvListado.Columns["marca"].Visible = false;
                dgvListado.Columns["precio"].Visible = false;
                dgvListado.Columns["stockActual"].Visible = false;
                dgvListado.Columns["PrecioUnitarioFormateado"].Visible = false;
                dgvListado.Columns["StockActualFormateado"].Visible = false;
            }
            chxBuscarPorCodigo.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Codigo;
            chxBuscarPorNombre.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Descripcion;
            chxBuscarPorMarca.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Marca;
            AplicarFiltros(Texto);
        }

        private void chxBuscarPorNombre_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros(Texto);
        }

        
    }
}
