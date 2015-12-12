using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Facturas;
using MaxiKioscos.Winforms.Properties;
using System.Drawing;
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Winforms.ControlStock.DTO;

namespace MaxiKioscos.Winforms.ControlStock
{
    public partial class frmControlStock : Form
    {
        #region Properties

        public List<Entidades.ControlStock> ControlesStock { get; set; } 

        private ControlStockRepository _controlStockRepository;
        public ControlStockRepository ControlStockRepository
        {
            get { return _controlStockRepository ?? (_controlStockRepository = new ControlStockRepository()); }
            set
            {
                _controlStockRepository = value;
            }
        }

        private EFRepository<Proveedor> _proveedorRepository;
        public EFRepository<Proveedor> ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new EFRepository<Proveedor>()); }
            set { _proveedorRepository = value; }
        }

        private EFRepository<Rubro> _rubroRepository;
        public EFRepository<Rubro> RubroRepository
        {
            get { return _rubroRepository ?? (_rubroRepository = new EFRepository<Rubro>()); }
            set
            {
                _rubroRepository = value;
            }
        }

        #endregion

        #region Inicializar


        public frmControlStock()
        {
            InitializeComponent();
            dgvListado.AutoGenerateColumns = false;
        }

        private void frmControlStock_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 30;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            dgvListado.Columns[9].DefaultCellStyle.Format = AppSettings.CompleteDateColumnFormat;
            
            ControlesStock = ControlStockRepository.Listado(p => p.MaxiKiosco, p => p.Proveedor, p => p.Rubro)
                                        .Where(c => c.MaxiKioscoId == AppSettings.MaxiKioscoId)
                                        .OrderByDescending(c => c.FechaCreacion).ToList();

            CargarFiltros();
            
            Actualizar(null, null);
        }

        private void CargarFiltros()
        {
            var proveedores = ProveedorRepository.Listado().OrderBy(p => p.Nombre).ToList();
            proveedores.Insert(0, new Proveedor {ProveedorId = 0, Nombre = "(Seleccione Proveedor)"});
            ddlProveedor.DisplayMember = "Nombre";
            ddlProveedor.ValueMember = "ProveedorId";
            ddlProveedor.DataSource = proveedores;

            var rubros = RubroRepository.Listado().OrderBy(p => p.Descripcion).ToList();
            rubros.Insert(0, new Rubro { RubroId = 0, Descripcion= "(Seleccione Rubro)" });
            ddlRubro.DisplayMember = "Descripcion";
            ddlRubro.ValueMember = "RubroId";
            ddlRubro.DataSource = rubros;
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

        private List<ControlStockDTO> Paginar(out int totalRecords)
        {
            var correccionstock = ControlesStock.Where(d => (ddlRubro.Valor == 0 || d.RubroId == ddlRubro.Valor)
                                                            &&
                                                            (ddlProveedor.Valor == 0 || d.RubroId == ddlProveedor.Valor))
                .Select(c => new ControlStockDTO
                {
                    ControlStockId = c.ControlStockId,
                    Estado = c.Estado,
                    Fecha = c.FechaCreacion.ToShortDateString(),
                    FechaCorreccion = c.FechaCorreccion == null ? "" : c.FechaCorreccion.Value.ToShortDateString(),
                    NroControl = c.NroControlFormateado,
                    Parametros = c.Parametros,
                    Proveedor = c.ProveedorNombre,
                    Rubro = c.RubroDescripcion
                }).ToList();
            totalRecords = correccionstock.Count;
            correccionstock = correccionstock.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
            return correccionstock;
        }

        #endregion
        
       
       

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                var id = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 8:
                        new frmImprimirPlanilla(id).ShowDialog();
                        break;
                    case 9:
                        new frmDetalleControlStock(id).ShowDialog();
                        break;
                }
                //Buscar();
            }
        }

        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
            {
                //Editar
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                
                var icon = e.ColumnIndex == 8 ? @"\Resources\print_icon.ico" : @"\Resources\details_icon.ico";
                var paddingLeft = 4;
                var paddingTop = 7;


                Icon ico = new Icon(AppSettings.ApplicationPath + icon);
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + paddingLeft, e.CellBounds.Top + paddingTop);
                e.Handled = true;
            }
        }

        private void btnAgregarControl_Click(object sender, EventArgs e)
        {
            var rubroId = ddlRubro.Valor;
            var proveedorId = ddlProveedor.Valor;

            if (new frmCrearControlStock(rubroId, proveedorId).ShowDialog() == DialogResult.OK)
            {
                ControlStockRepository = new ControlStockRepository();
                Buscar();
                Actualizar(null, null);
            }
            dgvListado.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ControlStockRepository = new ControlStockRepository();
            ControlesStock = ControlStockRepository.Listado(p => p.MaxiKiosco, p => p.Proveedor, p => p.Rubro)
                                    .Where(c => c.MaxiKioscoId == AppSettings.MaxiKioscoId)
                                    .OrderByDescending(c => c.FechaCreacion).ToList();
            Buscar();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                switch (e.KeyCode)
                {
                    case Keys.P:
                        new frmImprimirPlanilla(id).ShowDialog();
                        break;
                    case Keys.D:
                        new frmDetalleControlStock(id).ShowDialog();
                        break;
                }
            }
        }

        private void frmControlStock_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
