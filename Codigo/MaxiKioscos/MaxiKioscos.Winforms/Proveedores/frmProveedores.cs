using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;


namespace MaxiKioscos.Winforms.Proveedores
{
    public partial class frmProveedores : Form
    {
        
        public List<Proveedor> Proveedores { get; set; }

        private EFRepository<Proveedor> _repository;
        public EFRepository<Proveedor> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Proveedor>()); }
        }

       

        #region Inicializar


         public frmProveedores()
        {
            InitializeComponent();
            //Rubros = Repository.MaxiKioscosEntities.RubroListadoPorKiosco(AppSettings.MaxiKioscoId).ToList();
            
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            Actualizar(null, null);
        }
        #endregion

        #region Handlers
        
        private void Actualizar(object sender, EventArgs e)
        {
            ucPaginador.CurrentPage = 1;
            Buscar();
        }

        private void Siguiente(object sender, EventArgs e)
        {
            if (ucPaginador.PuedeAvanzar)
            {
                ucPaginador.CurrentPage = ucPaginador.CurrentPage + 1;
                Buscar();
            }
        }

        private void Anterior(object sender, EventArgs e)
        {
            if (ucPaginador.PuedeRetroceder)
            {
                ucPaginador.CurrentPage = ucPaginador.CurrentPage - 1;
                Buscar();
            }
        }

        private void Primero(object sender, EventArgs e)
        {
            if (ucPaginador.PuedeRetroceder)
            {
                ucPaginador.CurrentPage = 1;
                Buscar();
            }
        }

        private void Ultimo(object sender, EventArgs e)
        {
            if (ucPaginador.PuedeAvanzar)
            {
                ucPaginador.CurrentPage = ucPaginador.PageTotal.GetValueOrDefault();
                Buscar();
            }
        }

        #endregion

        #region Metodos Privados
        
        private void Buscar()
        {
            Int32 totalRegistros;
            var proveedores = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = proveedores;
        }

        private List<Proveedor> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var proveedores = Repository.Listado(p => p.Localidad)
                    .Where(p => string.IsNullOrEmpty(text) || p.Nombre.ToLower().Contains(text.ToLower()))
                    .OrderBy(p => p.Nombre).ToList();
            totalRecords = proveedores.Count;
            proveedores = proveedores.Skip(ucPaginador.PageSize*(ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return proveedores;
        }
       
        #endregion

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmDetalleProveedor(Convert.ToInt32(dgvListado.CurrentRow.Cells["ProveedorId"].Value));
            frm.ShowDialog();
            Buscar();
       
        }
        

        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 11) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell bc = dgvListado[e.ColumnIndex, e.RowIndex] as DataGridViewButtonCell;

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                icon = @"\Resources\details_icon.ico";
                paddingLeft = 5;
                paddingTop = 7;


                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(null, null);
        }

        private void frmProveedores_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Enter)
            {
                Buscar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _repository = new EFRepository<Proveedor>();
            //RefrescarDatasource();
            Buscar();
        }

        private void frmProveedores_Shown(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var id = Convert.ToInt32(dgvListado.SelectedRows[0].Cells["ProveedorId"].Value);
                var frm = new frmDetalleProveedor(id);
                frm.ShowDialog();
            }
        }
    }   
}
