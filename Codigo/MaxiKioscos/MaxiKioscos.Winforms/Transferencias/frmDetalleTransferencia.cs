using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;

namespace MaxiKioscos.Winforms.Transferencias
{
    public partial class frmDetalleTransferencia : Form
    {
        #region Repositorios
        private EFRepository<Transferencia> _repository;
        public EFRepository<Transferencia> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Transferencia>()); }
        }

        private EFRepository<TransferenciaProducto> _transferenciaProductorepository;
        public EFRepository<TransferenciaProducto> TransferenciaProductoRepository
        {
            get { return _transferenciaProductorepository ?? (_transferenciaProductorepository = new EFRepository<TransferenciaProducto>()); }
        }

        #endregion
        
        #region propiedades
        
        public Transferencia Transferencia { get; set; }
        private string Operacion { get; set; }

        #endregion

        #region Inicializar
        public frmDetalleTransferencia(int transferenciaId, string operacion)
            : base()
        {
            InitializeComponent();

            Operacion = operacion;
            if (operacion == "Eliminar")
            {
                lblTitulo.Text = "Eliminar Transferencia";
                this.Text = "Eliminar Transferencia";
                btnCancelar.Visible = true;
                btnAceptar.Text = "Aceptar";
            }
            else
            {
                lblTitulo.Text = "Detalle de Transferencia";
                this.Text = "Detalle de Transferencia";
                btnCancelar.Visible = false;
                btnAceptar.Location = new Point(591, 621);
                this.Select();
            }

            Transferencia = Repository.Obtener(x => x.TransferenciaId == transferenciaId,
                                                    t => t.Origen,
                                                    t => t.Destino,
                                                    t => t.TransferenciaProductos,
                                                    t => t.TransferenciaProductos.Select(tp => tp.Producto),
                                                    t => t.TransferenciaProductos.Select(tp => tp.Producto).Select(p => p.CodigosProductos));
        }
        #endregion

        #region Metodos
        private void frmDetalleTransferencia_Load(object sender, EventArgs e)
        {
            txtAutoNumero.Texto = Transferencia.AutoNumero;
            txtFecha.Texto = String.Format("{0} {1}", Transferencia.FechaCreacion.ToShortDateString(), Transferencia.FechaCreacion.ToShortTimeString());
            txtFechaAprobacion.Texto = Transferencia.FechaAprobacion.HasValue
                ? String.Format("{0} {1}", Transferencia.FechaAprobacion.Value.ToShortDateString(),
                    Transferencia.FechaAprobacion.Value.ToShortTimeString())
                : string.Empty;
            txtAutoNumero.Texto = Transferencia.AutoNumero;
            txtDestino.Texto = Transferencia.Destino.Nombre;
            txtOrigen.Texto = Transferencia.Origen.Nombre;

            dgvListado.AutoGenerateColumns = false;
            dgvListado.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvListado.DataSource = Transferencia.TransferenciaProductos.Where(x => !x.Eliminado).Select(x => new
            {
                x.Cantidad,
                Codigo = x.Producto.CodigosListado,
                x.Producto.Descripcion,
                Precio = x.PrecioVenta
            }).ToList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Eliminar")
            {
                var productos = TransferenciaProductoRepository.Listado()
                    .Where(c => c.ProductoId == Transferencia.TransferenciaId && !c.Eliminado).ToList();
                foreach (var prod in productos)
                {
                    TransferenciaProductoRepository.Eliminar(prod);
                }
                Repository.Eliminar(Transferencia.TransferenciaId);
                Repository.Commit();
            }
            this.Close();
        }

        #endregion
    }
}
