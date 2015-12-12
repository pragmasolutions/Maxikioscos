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
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.OperacionesCaja;
using MaxiKioscos.Winforms.Principal;
using Util;
namespace MaxiKioscos.Winforms.Transferencias
{
    public partial class frmTransferencias : Form
    {
        public IQueryable<Transferencia> Transferencias { get; set; }

        public mdiPrincipal Parent { get; set; }

        private EFRepository<Transferencia> _repository;
        public EFRepository<Transferencia> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Transferencia>()); }
            set { _repository = value; }
        }

        public frmTransferencias(mdiPrincipal parent)
        {
            InitializeComponent();
            dgvListado.AutoGenerateColumns = false;
            Parent = parent;
            RefrescarDatasource();
        }

        private void RefrescarDatasource()
        {
            Transferencias = Repository.Listado(t => t.Origen)
                    .Where(t => t.UsuarioId == UsuarioActual.UsuarioId)
                    .OrderByDescending(c => c.FechaCreacion);
        }



        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;

                switch (e.ColumnIndex)
                {
                    case 5:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 6:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 7:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 4;
                        break;
                }
                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7) && e.RowIndex >= 0)
            {
                var transferencia = dgvListado.Rows[e.RowIndex].DataBoundItem as TransferenciaGridStruct;
                
                switch (e.ColumnIndex)
                {
                    case 5:
                        new frmDetalleTransferencia(transferencia.TransferenciaId, "Detalle").ShowDialog();
                        break;
                    case 6:
                        if (transferencia.Estado == "Pendiente" && transferencia.AutoNumero.StartsWith(AppSettings.Maxikiosco.Abreviacion + "_"))
                        {
                            Parent.AbrirTab(new frmCrearTransferencia(transferencia.TransferenciaId));
                        }
                        else
                        {
                            MessageBox.Show("Solo puede editar transferencias de estado Pendiente que se hayan generado desde el kiosco");
                        }
                        break;
                    case 7:
                        if (transferencia.Estado == "Pendiente" && transferencia.AutoNumero.StartsWith(AppSettings.Maxikiosco.Abreviacion + "_"))
                        {
                            var result = new frmDetalleTransferencia(transferencia.TransferenciaId, "Eliminar").ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                RefrescarDatasource();
                                Buscar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Solo puede eliminar transferencias de estado Pendiente que se hayan generado desde el kiosco");
                        }
                        break;
                }
            }
        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvListado.SelectedRows[0];
            var transferenciaId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleTransferencia(transferenciaId, "Detalle").ShowDialog();
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            var list = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(-1, "(TODOS LOS ESTADOS)"),
                new KeyValuePair<int, string>(1, "APROBADOS"),
                new KeyValuePair<int, string>(2, "PENDIENTES")
            };

            ddlEstados.ValueMember = "Key";
            ddlEstados.DisplayMember = "Value";
            ddlEstados.DataSource = list;
            
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
            var transferencias = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = transferencias.ToArray();
        }

        private List<TransferenciaGridStruct> Paginar(out int totalRecords)
        {
            var estado = ddlEstados.Valor;
            var numero = txtBuscar.Text;
            var transferencias = Transferencias.Where(x => 
                (estado == -1 || (estado == 1 && x.FechaAprobacion != null) || (estado == 2 && x.FechaAprobacion == null))
                && (string.IsNullOrEmpty(numero) || numero == "(AUTONUMERO)" || numero.ToLower() == x.AutoNumero.ToLower()));
            totalRecords = transferencias.Count();
            return transferencias.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList()
                .Select(t => new TransferenciaGridStruct
                {
                    TransferenciaId = t.TransferenciaId,
                    Fecha = t.FechaCreacion,
                    Estado = t.FechaAprobacion == null ? "Pendiente" : "Aprobada",
                    AutoNumero = t.AutoNumero,
                    Origen = t.Origen.Nombre
                }).ToList();
        }

        private void Actualizar()
        {
            _repository = new EFRepository<Transferencia>();
            RefrescarDatasource();
            Buscar();
        }


        private void frmTransferencias_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var transferenciaId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                new frmDetalleTransferencia(transferenciaId, "Detalle").ShowDialog();
            }
        }

        private void frmTransferencias_Activated(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {
            if (UsuarioActual.Cuenta.MaxiKioscoIdentifierPredeterminadoTransferencias == null)
            {
                MessageBox.Show("Error: Comuníquese con el administrador para que configure el depósito predeterminado");
            }
            else
            {
                var pantalla = new frmCrearTransferencia();
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

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "(AUTONUMERO)";
            }
        }

        private void txtBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBuscar.Text == "(AUTONUMERO)")
            {
                txtBuscar.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(null, null);
        }
    }
}
