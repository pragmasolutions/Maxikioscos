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
using Util;
namespace MaxiKioscos.Winforms.Costos
{
    public partial class frmCostos : Form
    {
        public IQueryable<Costo> Costos { get; set; }

        private EFRepository<Costo> _repository;
        public EFRepository<Costo> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Costo>()); }
            set { _repository = value; }
        }

        public frmCostos()
        {
            InitializeComponent();
            dgvListado.AutoGenerateColumns = false;
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            RefrescarDatasource();
        }

        private void RefrescarDatasource()
        {
            Costos = Repository.Listado(c => c.CierreCaja, c => c.CategoriaCosto)
                    .Where(c => c.CierreCaja.UsuarioId == UsuarioActual.UsuarioId)
                    .OrderByDescending(c => c.Fecha);
        }


        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                switch (e.ColumnIndex)
                {
                    case 7:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 8:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 9:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 4;
                        break;
                }
                var ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }

            if ((e.ColumnIndex == 11 || e.ColumnIndex == 12) && e.RowIndex >= 0)
            {
                var item = dgvListado.Rows[e.RowIndex].DataBoundItem as CostoGridStruct;
                
                if (item.Estado == "Aprobado" || item.CajaCerrada)
                {
                    var buttonCell = (DataGridViewDisableButtonCell)dgvListado.Rows[e.RowIndex].Cells[8];
                    buttonCell.Enabled = false;

                    var buttonCell2 = (DataGridViewDisableButtonCell)dgvListado.Rows[e.RowIndex].Cells[9];
                    buttonCell2.Enabled = false;
                }
            }


        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                var costo = dgvListado.Rows[e.RowIndex].DataBoundItem as CostoGridStruct;
                switch (e.ColumnIndex)
                {
                    case 7:
                        new frmDetalleEliminarCosto(costo.CostoId, "Detalle").ShowDialog();
                        break;
                    case 8:
                        Editar(costo);
                        break;
                    case 9:
                        Eliminar(costo);
                        break;
                }
            }

        }

        private void Eliminar(CostoGridStruct costo)
        {
            if (!costo.CajaCerrada && costo.Estado != "Aprobado")
            {
                if (new frmDetalleEliminarCosto(costo.CostoId, "Eliminar").ShowDialog() == DialogResult.OK)
                {
                    //borro la factura
                    Repository.Eliminar(costo.CostoId);
                    Repository.Commit();
                    Actualizar(null, null);
                    Buscar();
                }
            }
        }

        private void Editar(CostoGridStruct costo)
        {
            if (!costo.CajaCerrada && costo.Estado != "Aprobado")
            {
                if (new frmEditarCosto(costo.CostoId).ShowDialog() == DialogResult.OK)
                {
                    Repository = new EFRepository<Costo>();
                    Actualizar(null, null);
                    Buscar();
                }
            }
        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvListado.SelectedRows[0];
            var costoId = Convert.ToInt32(row.Cells[0].Value.ToString());
            new frmDetalleEliminarCosto(costoId, "Detalle").ShowDialog();
        }
     
        private void frmCostos_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            var estados = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("Mostrar todos", 0),
                new KeyValuePair<string, int>("Aprobados", 1),
                new KeyValuePair<string, int>("Desaprobados ", -1)
            };
            ddlEstados.ValueMember = "Value";
            ddlEstados.DisplayMember = "Key";
            ddlEstados.DataSource = estados;

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

        private List<CostoGridStruct> Paginar(out int totalRecords)
        {
            var estado = ddlEstados.Valor;
            var cajaActual = chxCajaActual.Checked;
            var palabras = txtBuscar.Text.ToLower();
            var costos = Costos.Where(c =>
                (string.IsNullOrEmpty(palabras) || palabras == "(nro comprobante)" || c.NroComprobante.ToLower().StartsWith(palabras))
                && (estado == 0 || (estado == 1 && c.Aprobado) ||
                 (estado == -1 && !c.Aprobado))
                && (!cajaActual || (cajaActual && c.CierreCajaId == UsuarioActual.CierreCajaIdActual)));
            totalRecords = costos.Count();
            return costos.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize)
                .Select(c => new CostoGridStruct
                {
                    Estado = c.Aprobado ? "Aprobado" : "No Aprobado",
                    CajaCerrada = c.CierreCaja.FechaFin != null,
                    CategoriaCosto = c.CategoriaCosto.Descripcion,
                    CostoId = c.CostoId,
                    Fecha = c.Fecha,
                    Importe = c.Monto,
                    NroComprobante = c.NroComprobante
                }).ToList();
        }

        private void Actualizar()
        {
            _repository = new EFRepository<Costo>();
            RefrescarDatasource();
            Buscar();
        }


        private void frmCostos_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0 && e.KeyCode == Keys.D)
            {
                var costoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                new frmDetalleEliminarCosto(costoId, "Detalle").ShowDialog();
            }
        }

        private void frmCostos_Activated(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void chxCajaActual_CheckedChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (new frmEditarCosto().ShowDialog() == DialogResult.OK)
            {
                Actualizar(null, null);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "(NRO COMPROBANTE)";
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            LimpiarBotonBusqueda();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            LimpiarBotonBusqueda();
        }

        public void LimpiarBotonBusqueda()
        {
            if (txtBuscar.Text == "(NRO COMPROBANTE)")
            {
                txtBuscar.Text = "";
            }
        }
    }
}
