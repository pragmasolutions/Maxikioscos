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
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.OperacionesCaja;
using Util;
namespace MaxiKioscos.Winforms.Rubros
{
    public partial class frmGestionRubros : Form
    {
        public List<RubroCompleto> Rubros { get; set; }

        private EFRepository<Rubro> _repository;
        public EFRepository<Rubro> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Rubro>()); }
        }

        public frmGestionRubros()
        {
            InitializeComponent();
            RefrescarDatasource();
        }

        private void RefrescarDatasource()
        {
            Rubros = Repository.MaxiKioscosEntities.RubroListadoPorKiosco(AppSettings.MaxiKioscoId).ToList();
        }

        private void frmGestionRubros_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            Actualizar(null, null);
        }

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

        private void Buscar()
        {
            Int32 totalRegistros;
            var rubros = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = rubros.ToArray();
        }

        private List<RubroCompleto> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var rubros = Rubros.Where(d => string.IsNullOrEmpty(text) || d.Descripcion.ToLower().Contains(text.ToLower())).ToList();
            totalRecords = rubros.Count;
            rubros = rubros.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return rubros;
        }


        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var icon = @"\Resources\details_icon.ico";

                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                e.Handled = true;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                var rubroId = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[0].Value);
                new frmDetalleRubro(rubroId).ShowDialog();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Enter)
            {
                Actualizar(null, null);
            }
        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvListado.SelectedRows[0];
            var rubroId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleRubro(rubroId).ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _repository=new EFRepository<Rubro>();
            RefrescarDatasource();
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(null, null);
        }

        private void frmGestionRubros_Shown(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var rubroId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                new frmDetalleRubro(rubroId).ShowDialog();
            }
        }

        private void frmGestionRubros_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
