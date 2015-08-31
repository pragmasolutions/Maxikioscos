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
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.CorreccionesStock;
using MaxiKioscos.Winforms.Interfaces;

namespace MaxiKioscos.Winforms.Productos
{
    public partial class BuscadorCompleto : Form
    {
        public List<ProductoCompleto> DataSource { get; set; }
        public string Texto { get; set; }

        private ProductoCriterioBusqueda _criterioBusqueda;

        public bool RecordarBusqueda
        {
            get
            {
                if (chxBuscarPorCodigo == null)
                    return false;
                return !chxBuscarPorCodigo.Checked;
            }
        }
        
        public bool CerradoDesdeTextbox { get; set; }

        public ProductoCompleto ProductoSeleccionado { get; set; }

        
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

        public BuscadorCompleto(string texto, List<ProductoCompleto> datasource, ProductoCriterioBusqueda criterio)
        {
            InitializeComponent();
            _criterioBusqueda = criterio;
            CerradoDesdeTextbox = true;
            DataSource = datasource;
            Texto = texto;

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

        public void AplicarFiltros()
        {
            var text = Texto.Trim().ToLower();
            var lista = DataSource.Where(p => (chxBuscarPorNombre.Checked && p.Descripcion.ToLower().Contains(text)
                                              || (chxBuscarPorMarca.Checked && p.Marca != null && p.Marca.ToLower().Contains(text))
                                              || (!string.IsNullOrEmpty(p.Codigo) && chxBuscarPorCodigo.Checked &&
                                                    p.Codigos.Any(c => c.ToLower().StartsWith(text))))).ToArray();

            if (chxBuscarPorNombre.Checked || chxBuscarPorMarca.Checked)
            {
                dvgBusqueda.DataSource = lista.OrderBy(p => p.Descripcion).ToArray();
            }
            else
            {
                foreach (var productoHorario in lista)
                {
                    productoHorario.Filter = text.ToLower();
                }
                var array = new ArrayList(lista);

                //var array = lista.ToArray();
                array.Sort();
                dvgBusqueda.DataSource = array.ToArray().ToList();
            }
        }

        public void Bajar()
        {
            if (dvgBusqueda.RowCount > 0)
            {
                if (dvgBusqueda.SelectedRows.Count > 0)
                {
                    int rowCount = dvgBusqueda.Rows.Count;
                    int index = dvgBusqueda.SelectedCells[0].OwningRow.Index;

                    if (index != (rowCount - 1)) // include the header row
                    {
                        var nextIndex = index + 1;

                        dvgBusqueda.ClearSelection();
                        dvgBusqueda.Rows[index + 1].Selected = true;

                        // keep selection visible
                        if ((nextIndex) >= (dvgBusqueda.FirstDisplayedScrollingRowIndex + dvgBusqueda.DisplayedRowCount(false)))
                            dvgBusqueda.FirstDisplayedScrollingRowIndex = dvgBusqueda.FirstDisplayedScrollingRowIndex + 1;
                    }
                }
            }
        }

        public void Subir()
        {
            if (dvgBusqueda.RowCount > 0)
            {
                if (dvgBusqueda.SelectedRows.Count > 0)
                {
                    int index = dvgBusqueda.SelectedCells[0].OwningRow.Index;

                    if (index != 0) // include the header row
                    {
                        var nextIndex = index - 1;
                        dvgBusqueda.ClearSelection();
                        dvgBusqueda.Rows[index - 1].Selected = true;

                        // keep selection visible
                        if ((nextIndex) < dvgBusqueda.FirstDisplayedScrollingRowIndex)
                            dvgBusqueda.FirstDisplayedScrollingRowIndex = nextIndex;

                        //dvgBusqueda.ClearSelection();
                        //dvgBusqueda.Rows[index - 1].Selected = true;
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        #region Eventos de grilla

        private void dvgBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAceptar_Click(sender, null);
        }

        private void dvgBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var parent = this.Owner as IBuscadorParent;
            parent.FocusOnCodeTextbox();
        }
        
        #endregion

        private void BuscadorCompleto_Shown(object sender, EventArgs e)
        {
            
        }

        private void BuscadorCompleto_Load(object sender, EventArgs e)
        {
            chxBuscarPorCodigo.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Codigo;
            chxBuscarPorNombre.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Descripcion;
            chxBuscarPorMarca.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Marca;

            AplicarFiltros();
        }

        public ProductoCompleto ObtenerProducto()
        {
            if (dvgBusqueda.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dvgBusqueda.SelectedRows[0];
                var productoId = Convert.ToInt32(row.Cells[0].Value.ToString());
                ProductoSeleccionado = DataSource.FirstOrDefault(p => p.ProductoId == productoId);
                return ProductoSeleccionado;
            }
            return null;
        }

        private void dvgBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Agregar();
                    break;;
                case Keys.Escape:
                    Cerrar();
                    break;
                case Keys.Up:
                    Subir();
                    break;
                case Keys.Down:
                    Bajar();
                    break;
            }
        }

        private void Cerrar()
        {
            ProductoSeleccionado = null;
            CerradoDesdeTextbox = false;
            this.Close();
        }

        private void Agregar()
        {
            if (dvgBusqueda.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dvgBusqueda.SelectedRows[0];
                var productoId = Convert.ToInt32(row.Cells[0].Value.ToString());
                ProductoSeleccionado = DataSource.FirstOrDefault(p => p.ProductoId == productoId);
                this.DialogResult = DialogResult.OK;
                CerradoDesdeTextbox = false;
                this.Close();
            }
        }

        private void chxBuscarPorNombre_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        public void EstablecerCriterio(ProductoCriterioBusqueda criterio)
        {
            _criterioBusqueda = criterio;
            chxBuscarPorCodigo.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Codigo;
            chxBuscarPorNombre.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Descripcion;
            chxBuscarPorMarca.Checked = _criterioBusqueda == ProductoCriterioBusqueda.Marca;

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
    }
}

