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

namespace MaxiKioscos.Winforms.CorreccionesStock
{
      public partial class frmGestionCorreccionStock : Form

    {
        public List<CorreccionStock> CorreccionesStock { get; set; } 

        private EFSimpleRepository<CorreccionStock> _correccionstock;
        public EFSimpleRepository<CorreccionStock> CorreccionStockRepository
        {
            get { return _correccionstock ?? (_correccionstock = new EFSimpleRepository<CorreccionStock>()); }
            set
            {
                _correccionstock = value;
            }
        }
        #region Propiedades

                        #endregion

        #region Inicializar


        public frmGestionCorreccionStock()
        {
            InitializeComponent();
        }

        private void frmGestionCorreccionStock_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 10;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            dgvListado.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.Columns[9].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            
            try
            {
                CorreccionesStock = CorreccionStockRepository.Listado(p => p.Producto, p => p.MotivoCorreccion)
                                        .Where(c => c.MaxiKioscoId == AppSettings.MaxiKioscoId).ToList();
            } 
            catch (Exception exception)
            { 
                throw exception ;
            }
            
            Actualizar(null, null);
        }

        #endregion

        #region Handlers

        

        

       
        private void Actualizar(object sender, EventArgs e)
        {
            ucPaginador.CurrentPage = 1;
            btnActualizar_Click(null,null);
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
            var correccionesstock = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = correccionesstock.ToArray();
        }

        private List<CorreccionStock> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var correccionstock = CorreccionesStock.Where(d => (string.IsNullOrEmpty(text) || d.Producto.Descripcion.ToLower().Contains(text.ToLower())) && d.Eliminado == false).ToList();
            totalRecords = correccionstock.Count;
            correccionstock = correccionstock.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return correccionstock;
        }

        
       
        #endregion

       
       

        private void dgvListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 17) && e.RowIndex >= 0)
            {
                var frm = new frmDetalleCorreccionStock(Convert.ToInt32(dgvListado.CurrentRow.Cells[4].Value));
                frm.ShowDialog();
                Buscar();
            }

            if ((e.ColumnIndex == 18) && e.RowIndex >= 0)
            {
                var frm = new frmEditarCorreccionStock(Convert.ToInt32(dgvListado.CurrentRow.Cells[4].Value));
                //frm.ShowDialog();
                CorreccionStockRepository = new EFSimpleRepository<CorreccionStock>();
                btnActualizar_Click(null,null);
                Buscar();
            }

        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (new frmEditarCorreccionStock().ShowDialog() == DialogResult.OK)
            {
                CorreccionStockRepository = new EFSimpleRepository<CorreccionStock>();
                Buscar();
                Actualizar(null, null);
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


        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 17) && e.RowIndex >= 0)
            {
                //Editar
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell bc = dgvListado[e.ColumnIndex, e.RowIndex] as DataGridViewButtonCell;

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                icon = @"\Resources\details_icon.ico";
                paddingLeft = 4;
                paddingTop = 7;


                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }

            if ((e.ColumnIndex == 18) && e.RowIndex >= 0)
            {
                //Eliminar
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell bc = dgvListado[e.ColumnIndex, e.RowIndex] as DataGridViewButtonCell;

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;
                icon = @"\Resources\delete_icon.ico";
                paddingLeft = 5;
                paddingTop = 7;


                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }

            
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CorreccionesStock = CorreccionStockRepository.Listado(p => p.Producto, p => p.MotivoCorreccion).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            //Actualizar(null, null);
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        var frm = new frmDetalleCorreccionStock(Convert.ToInt32(dgvListado.SelectedRows[0].Cells[4].Value));
                        frm.ShowDialog();
                        Buscar();
                        break;
                    case Keys.Delete:
                        var frmEditar = new frmEditarCorreccionStock(Convert.ToInt32(dgvListado.SelectedRows[0].Cells[4].Value));
                        CorreccionStockRepository = new EFSimpleRepository<CorreccionStock>();
                        btnActualizar_Click(null, null);
                        Buscar();
                        break;
                }
            }
        }

        private void frmGestionCorreccionStock_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
