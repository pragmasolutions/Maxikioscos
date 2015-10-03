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
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.OperacionesCaja;
using MaxiKioscos.Winforms.Principal;
using Util;
namespace MaxiKioscos.Winforms.RetirosPersonales
{
    public partial class frmRetirosPersonales : Form
    {
        public IQueryable<RetiroPersonal> RetirosPersonales { get; set; }

        public mdiPrincipal Parent { get; set; }

        private EFRepository<RetiroPersonal> _repository;
        public EFRepository<RetiroPersonal> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<RetiroPersonal>()); }
            set { _repository = value; }
        }

        public frmRetirosPersonales(mdiPrincipal parent)
        {
            InitializeComponent();
            dgvListado.AutoGenerateColumns = false;
            dgvListado.Columns[2].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            Parent = parent;
            RefrescarDatasource();
        }

        private void RefrescarDatasource()
        {
            RetirosPersonales = Repository.Listado(c => c.CierreCaja)
                    .Where(c => c.CierreCaja.UsuarioId == UsuarioActual.UsuarioId)
                    .OrderByDescending(c => c.FechaRetiroPersonal);
        }


        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var ico = new Icon(AppSettings.ApplicationPath + @"\Resources\details_icon.ico");
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                e.Handled = true;
            }
            
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var retiroPersonal = dgvListado.Rows[e.RowIndex].DataBoundItem as RetiroPersonalGridStruct;
                new frmDetalleRetiroPersonal(retiroPersonal.RetiroPersonalId).ShowDialog();
            }

        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvListado.SelectedRows[0];
            var costoId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleRetiroPersonal(costoId).ShowDialog();
        }

        private void frmRetirosPersonales_Load(object sender, EventArgs e)
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
            var costos = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = costos.ToArray();
        }

        private List<RetiroPersonalGridStruct> Paginar(out int totalRecords)
        {
            var cajaActual = chxCajaActual.Checked;
            var costos = RetirosPersonales.Where(c =>
                !cajaActual || (cajaActual && c.CierreCajaId == UsuarioActual.CierreCajaIdActual));
            totalRecords = costos.Count();
            return costos.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize)
                .Select(rp => new RetiroPersonalGridStruct
                {
                    RetiroPersonalId = rp.RetiroPersonalId,
                    Fecha = rp.FechaRetiroPersonal,
                    Importe = rp.ImporteTotal
                }).ToList();
        }

        private void Actualizar()
        {
            _repository = new EFRepository<RetiroPersonal>();
            RefrescarDatasource();
            Buscar();
        }


        private void frmRetirosPersonales_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var costoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                new frmDetalleRetiroPersonal(costoId).ShowDialog();
            }
        }

        private void frmRetirosPersonales_Activated(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void chxCajaActual_CheckedChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregarRetiroPersonal_Click(object sender, EventArgs e)
        {
            var pantalla = new frmNuevoRetiroPersonal();
            bool copia = false;
            foreach (var frm in Parent.MdiChildren)
            {
                if (pantalla.Name == frm.Name)
                {
                    frm.Close();
                }
            }
            
            pantalla.Closed += ApplicationTab_Closed;
            pantalla.Load += PantallaOnLoad;
            pantalla.MdiParent = Parent;
            pantalla.Show();
        }

        private void ApplicationTab_Closed(object sender, EventArgs e)
        {
            var vantana = sender as Form;
            vantana.Closed -= ApplicationTab_Closed;

            this.Actualizar();
        }

        private void PantallaOnLoad(object sender, EventArgs eventArgs)
        {
            ((Form)sender).WindowState = FormWindowState.Maximized;
        }
    }
}
