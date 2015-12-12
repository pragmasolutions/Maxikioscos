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

namespace MaxiKioscos.Winforms.Excepciones
{
    public partial class frmGestionExcepciones : Form
    {

        #region "Propiedades"

        public List<Excepcion> Excepciones { get; set; }

        private CierreCaja _cierre;

        private EFRepository<Excepcion> _repository;
        public EFRepository<Excepcion> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Excepcion>()); }

            set
            {
                _repository = value;
            }

        }

        private EFRepository<CierreCaja> _cierreCajaRepository;
        public EFRepository<CierreCaja> CierreCajaRepository
        {
            get { return _cierreCajaRepository ?? (_cierreCajaRepository = new EFRepository<CierreCaja>()); }
        }

        #endregion


        public frmGestionExcepciones()
        {
            InitializeComponent();


            dgvListado.Columns[5].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[3].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;

            Refrescar();
        }

        private void Refrescar()
        {
            _cierre = CierreCajaRepository.Listado(c => c.Usuario).Where(
                   c => c.MaxiKioskoId == AppSettings.MaxiKioscoId)
                   .OrderByDescending(c => c.FechaFin).FirstOrDefault(c => c.FechaFin != null);

            Actualizar(null, null);
        }

        private void frmGestionExcepciones_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            Buscar();
        }

        #region "Handlers"
        private void Agregar(object sender, EventArgs e)
        {
            var frm = new frmABMExcepciones(_cierre.CierreCajaId);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                Buscar();
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var frm = new frmABMExcepciones(_cierre.CierreCajaId, (int)dgvListado.SelectedRows[0].Cells[0].Value);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Buscar();
                }
            }
        }

        private void Actualizar(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Buscar();
            this.Cursor = Cursors.Default;
        }

        private void Detalle(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var frm = new frmDetalle((int)dgvListado.SelectedRows[0].Cells["excepcionId"].Value, "Detalle");
                frm.ShowDialog();
            }
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
        

        #region "Metodos Privados"

        private void Buscar()
        {
            try
            {
                if (_cierre != null)
                {
                    Int32 totalRegistros;
                    RefrescarDatasource();
                    var excepciones = Paginar(out totalRegistros);

                    ucPaginador.ActualizarBotones(totalRegistros);
                    dgvListado.DataSource = excepciones.ToArray();
                }
                else
                {
                    dgvListado.DataSource = null;
                }
            }
            catch (Exception)
            {
                Mensajes.Seleccion(false);
            }
        }

        private void RefrescarDatasource()
        {
            Excepciones = Repository.Listado().Where(e => e.CierreCajaId == _cierre.CierreCajaId).ToList();
        }


        private List<Excepcion> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var excepciones = Excepciones.Where(e => string.IsNullOrEmpty(text) || e.Descripcion.ToLower().Contains(text.ToLower())).ToList();
            totalRecords = excepciones.Count;
            excepciones = excepciones.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return excepciones;
        }

      
        #endregion

        private void frmGestionExcepciones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F1):
                    Agregar(null,null);
                    break;
                case (Keys.F2):
                    Modificar(null,null);
                    break;
                case (Keys.Escape):
                    this.Close();
                    break;
                case (Keys.F6):
                    Actualizar(null,null);
                    break;
            }
        }

        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 6 ||  e.ColumnIndex == 7 || e.ColumnIndex == 8) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                switch (e.ColumnIndex)
                {
                    case 6:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 7;
                        break;
                    case 7:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 7;
                        break;
                    case 8:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 7;
                        break;
                }
                var ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
             }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8) && e.RowIndex >= 0)
            {
                var ExcepcionId = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 6:
                        new frmDetalle(ExcepcionId,"Detalle").ShowDialog();
                        break;
                    case 7:
                        if (new frmABMExcepciones(_cierre.CierreCajaId, ExcepcionId).ShowDialog() == DialogResult.OK)
                        {
                            Repository = new EFRepository<Excepcion>();
                            Buscar();
                        }
                       break;
                    case 8:
                       if (new frmDetalle(ExcepcionId,"Eliminar").ShowDialog() == DialogResult.OK)
                       {
                           //borro la factura
                           Repository.Eliminar(ExcepcionId);
                           Repository.Commit();

                           Buscar();
                       }
                        break;
                }
            }
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (new frmABMExcepciones(_cierre.CierreCajaId).ShowDialog() == DialogResult.OK)
            {
                Repository = new EFRepository<Excepcion>();
                Buscar();
            }
            dgvListado.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ucPaginador.CurrentPage = 1;
            Buscar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDatasource();
            Refrescar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Enter)
            {
                Actualizar(null, null);
            }
        }

        private void frmGestionExcepciones_Shown(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            var id = ObtenerIdSeleccionado().GetValueOrDefault();
            if (id != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new frmDetalle(id, "Detalle").ShowDialog();
                        break;
                    case Keys.M:
                        if (new frmABMExcepciones(_cierre.CierreCajaId, id).ShowDialog() == DialogResult.OK)
                        {
                            Repository = new EFRepository<Excepcion>();
                            Buscar();
                        }
                        break;
                    case Keys.Delete:
                        if (new frmDetalle(id, "Eliminar").ShowDialog() == DialogResult.OK)
                        {
                            //borro la factura
                            Repository.Eliminar(id);
                            Repository.Commit();

                            Buscar();
                        }
                        break;
                }
            }
            
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                return id;
            }
            return null;
        }

        private void frmGestionExcepciones_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
