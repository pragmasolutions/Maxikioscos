using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Facturas;
using MaxiKioscos.Winforms.Properties;
using System.Drawing;
using MaxiKioscos.Winforms.Clases;

namespace MaxiKioscos.Winforms.Facturas
{
      public partial class FrmGestionFacturas : Form

    {
          public List<Factura> Facturas { get; set; }

        private EFRepository<Factura> _facturaRepository;
        public EFRepository<Factura> FacturaRepository
        {
            get { return _facturaRepository ?? (_facturaRepository = new EFRepository<Factura>()); }
            set
            {
                _facturaRepository = value;
            }
        }
        #region Propiedades

                        #endregion

        #region Inicializar


        public FrmGestionFacturas()
        {

            InitializeComponent();

            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[0].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
        }

        private void frmGestionFacturas_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;
            
            var column1 = new DataGridViewDisableButtonColumn {Width = 22};
            var column2 = new DataGridViewDisableButtonColumn {Width = 22};

            dgvListado.Columns.Add(column1);
            dgvListado.Columns.Add(column2);

            dgvListado.Columns[5].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            Actualizar(null, null);
        }

        #endregion

        #region Handlers
          
        private void Actualizar(object sender, EventArgs e)
        {
            RefrescarDatasource();
            ucPaginador.CurrentPage = 1;
            Buscar();
        }

        private void RefrescarDatasource()
        {
            Facturas = FacturaRepository.Listado(f => f.Proveedor).Where(f => f.MaxiKioscoId == AppSettings.MaxiKioscoId).ToList();
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
            var facturas = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = facturas.ToArray();
        }

        private List<Factura> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var facturas = FacturaRepository.Listado(f => f.Proveedor,f=>f.UsuarioCreador).Where(f => f.MaxiKioscoId == AppSettings.MaxiKioscoId &&
                            (string.IsNullOrEmpty(text) || f.FacturaNro.ToLower().Contains(text.ToLower()) || f.AutoNumero.ToLower().Contains(text.ToLower())
                            || f.Proveedor.Nombre.ToLower().Contains(text.ToLower()))).ToList();
            totalRecords = facturas.Count;
            facturas = facturas.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return facturas;
        }


        #endregion

       
       private void dgvListado_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 8 ||  e.ColumnIndex == 11 || e.ColumnIndex == 12) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                switch (e.ColumnIndex)
                {
                    case 8:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 7;
                        break;
                    case 11:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 7;
                        break;
                    case 12:
                        icon = @"\Resources\delete_icon.ico";
                        paddingLeft = 5;
                        paddingTop = 8;
                        break;
                }
                var ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }

            if ((e.ColumnIndex == 11 || e.ColumnIndex == 12) && e.RowIndex >= 0)
                {
                    if (Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[3].Value) != UsuarioActual.CierreCajaIdActual)
                    {
                        var buttonCell =(DataGridViewDisableButtonCell)dgvListado.Rows[e.RowIndex].Cells[11];
                        buttonCell.Enabled = false;

                        var buttonCell2 = (DataGridViewDisableButtonCell)dgvListado.Rows[e.RowIndex].Cells[12];
                        buttonCell2.Enabled = false;
                    }
                }
        

       }

        private void dgvListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 8 || e.ColumnIndex == 11 || e.ColumnIndex == 12) && e.RowIndex >= 0)
            {
                 var facturaId = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[6].Value);
                 switch (e.ColumnIndex)
                 {
                    case 8:
                        new frmDetalleEliminarFactura(facturaId, "Detalle").ShowDialog();
                        break;
                    case 11:
                        Editar(facturaId);
                        break;
                    case 12:
                        Eliminar(facturaId);
                        break;
                 }
             }

        }

        private void Eliminar(int facturaId)
        {
            var buttonCell2 = (DataGridViewDisableButtonCell)dgvListado.SelectedRows[0].Cells[11];
            if (buttonCell2.Enabled)
            {
                if (new frmDetalleEliminarFactura(facturaId, "Eliminar").ShowDialog() == DialogResult.OK)
                {
                    //borro la factura
                    FacturaRepository.Eliminar(facturaId);
                    FacturaRepository.Commit();
                    Actualizar(null, null);
                    Buscar();
                }
            }
        }

        private void Editar(int facturaId)
        {
            var buttonCell = (DataGridViewDisableButtonCell)dgvListado.SelectedRows[0].Cells[11];
            if (buttonCell.Enabled)
            {
                if (new frmEditarFactura(facturaId).ShowDialog() == DialogResult.OK)
                {
                    FacturaRepository = new EFRepository<Factura>();
                    Actualizar(null, null);
                    Buscar();
                }
            }
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (EventosFlags.CierreCajaEstado == CierreCajaEstadoEnum.Cerrado)
            {    
                MessageBox.Show("Debe abrir una caja primero");
                return;
            }

            if (new frmEditarFactura().ShowDialog() == DialogResult.OK)
            {
                FacturaRepository = new EFRepository<Factura>();
                Actualizar(null, null);
                Buscar();
            }
            dgvListado.Focus();
        }
          
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Enter)
            {
                Actualizar(null, null);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _facturaRepository = new EFRepository<Factura>();
            RefrescarDatasource();
            Buscar();
        }

        private void FrmGestionFacturas_Shown(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var facturaId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[6].Value);
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new frmDetalleEliminarFactura(facturaId, "Detalle").ShowDialog();
                        break;
                    case Keys.M:
                        Editar(facturaId);
                        break;
                    case Keys.Delete:
                        Eliminar(facturaId);
                        break;
                }
            }
        }

        private void FrmGestionFacturas_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
