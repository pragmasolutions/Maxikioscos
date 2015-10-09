using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Entidades;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.UserControls;

namespace MaxiKioscos.Winforms.Productos
{
    public partial class frmProductos : Form
    {
        #region properties
        public IQueryable<Producto> Productos { get; set; }

        private ProductoRepository _repository;
        public ProductoRepository Repository
        {
            get { return _repository ?? (_repository = new ProductoRepository()); }
            set { _repository = value; }
        }

        private ProveedorRepository _proveedorRepository;
        public ProveedorRepository ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new ProveedorRepository()); }
            set { _proveedorRepository = value; }
        }

        #endregion

        public frmProductos()
        {
            InitializeComponent();
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            RefrescarDatasource();
        }

        private void RefrescarDatasource()
        {
            Productos = Repository.Listado(p => p.CodigosProductos, p => p.Marca, p => p.Rubro,
                            p => p.ProveedorProductos, p => p.ProveedorProductos.Select(pp => pp.Proveedor),
                            p => p.ComprasProductos)
                            .Where(m => m.CuentaId == UsuarioActual.CuentaId && !m.EsPromocion).OrderBy(p => p.Descripcion);
        }

        private void dgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 33 || e.ColumnIndex == 34 || e.ColumnIndex == 35) && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                string icon = string.Empty;
                int paddingTop = 0;
                int paddingLeft = 0;

                switch (e.ColumnIndex)
                {
                    case 33:
                        icon = @"\Resources\details_icon.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 34:
                        icon = @"\Resources\ico_edit.ico";
                        paddingLeft = 3;
                        paddingTop = 3;
                        break;
                    case 35:
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
            if ((e.ColumnIndex == 33 || e.ColumnIndex == 34 || e.ColumnIndex == 35) && e.RowIndex >= 0)
            {
                var productoId = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[0].Value);
                switch (e.ColumnIndex)
                {
                    case 33:
                        new frmDetalleEliminarProducto(productoId, "Detalle").ShowDialog();
                        break;
                    case 34:
                        var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EditarProducto(productoId);
                        }
                        break;
                    case 35:
                        user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EliminarProducto(productoId);
                        }
                        break;
                }
            }
        }

        private void EliminarProducto(int productoId)
        {
            if (new frmDetalleEliminarProducto(productoId, "Eliminar").ShowDialog() == DialogResult.OK)
            {
                ActualizarGrilla();
            }
        }

        private void EditarProducto(int productoId)
        {
            using (var form = new frmEditarProducto(productoId))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ActualizarGrilla();
                }
            }
        }

        private void ActualizarGrilla()
        {
            Repository = new ProductoRepository();
            //Productos = Repository.Listado(p => p.CodigosProductos, p => p.Marca, p => p.Rubro)
            //         .Where(m => m.CuentaId == UsuarioActual.CuentaId).OrderBy(p => p.Descripcion).ToList();

            Productos = Repository.Listado(p => p.CodigosProductos, p => p.Marca, p => p.Rubro,
                            p => p.ProveedorProductos, p => p.ProveedorProductos.Select(pp => pp.Proveedor),
                            p => p.ComprasProductos)
                .Where(m => m.CuentaId == UsuarioActual.CuentaId).OrderBy(p => p.Descripcion);
            Buscar();
            //Actualizar(null, null);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Actualizar(null, null);
        }

        private void dgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvListado.SelectedRows[0];
            var productoID = Convert.ToInt32(row.Cells[0].Value.ToString());
           new frmDetalleEliminarProducto(productoID, "Detalle").ShowDialog();
        }
        
        private void frmGestionMarcas_Load(object sender, EventArgs e)
        {
            ucPaginador.PageSize = 50;
            ucPaginador.Next.Click += Siguiente;
            ucPaginador.Previous.Click += Anterior;
            ucPaginador.First.Click += Primero;
            ucPaginador.Last.Click += Ultimo;
            ucPaginador.PageSizeControl.TextChanged += Actualizar;

            CargarFiltros();

            Actualizar(null, null);
            txtBuscar.GotFocus += TxtBuscarOnGotFocus;
        }

        private void TxtBuscarOnGotFocus(object sender, EventArgs eventArgs)
        {
            if (txtBuscar.Text == "(INGRESE DESCRIPCION)")
            {
                txtBuscar.Text = string.Empty;
            }
        }

        private void CargarFiltros()
        {
            var marcas = ProveedorRepository.Listado().OrderBy(m => m.Nombre).ToList();
            marcas.Insert(0, new Proveedor(){ Nombre = "-- Seleccione Proveedor --"});
            ddlProveedor.DisplayMember = "Nombre";
            ddlProveedor.ValueMember = "ProveedorId";
            ddlProveedor.DataSource = marcas;
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
            var productos = Paginar(out totalRegistros);

            ucPaginador.ActualizarBotones(totalRegistros);
            dgvListado.DataSource = productos.ToArray();
        }

        private List<Producto> Paginar(out int totalRecords)
        {
            var text = txtBuscar.Text.Trim();
            var productos = Productos.Where(p => (string.IsNullOrEmpty(text) || text == "(INGRESE DESCRIPCION)"
                            || p.Descripcion.ToLower().Contains(text.ToLower())
                            || p.CodigosProductos.Any(c => c.Codigo.StartsWith(text)))
                            && (ddlProveedor.Valor == 0 || p.ProveedorProductos.Any(pp => pp.ProveedorId == ddlProveedor.Valor)));
            totalRecords = productos.Count();
            return productos.Skip(ucPaginador.PageSize * (ucPaginador.CurrentPage - 1)).Take(ucPaginador.PageSize).ToList();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
            if (user != 0)
            {
                if (new frmCrearProducto().ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrilla();
                }
            }
            dgvListado.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            _repository = new ProductoRepository();
            RefrescarDatasource();
            Buscar();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Text = "(INGRESE DESCRIPCION)";
            }
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                var productoId = Convert.ToInt32(dgvListado.SelectedRows[0].Cells[0].Value);
                switch (e.KeyCode)
                {
                    case Keys.D:
                        new frmDetalleEliminarProducto(productoId, "Detalle").ShowDialog();
                        break;
                    case Keys.M:
                        var user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EditarProducto(productoId);
                        }
                        break;
                    case Keys.Delete:
                        user = SeguridadHelper.SolicitarPermisosUsuario(new List<string>() { "SuperAdministrador", "Administrador", "Encargado" });
                        if (user != 0)
                        {
                            EliminarProducto(productoId);
                        }
                        break;
                }
            }
        }

        private void frmProductos_Activated(object sender, EventArgs e)
        {
            btnActualizar_Click(null, null);
        }
    }
}
