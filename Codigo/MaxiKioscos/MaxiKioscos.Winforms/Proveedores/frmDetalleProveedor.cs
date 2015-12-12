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

namespace MaxiKioscos.Winforms.Proveedores
{
    public partial class frmDetalleProveedor : Form
    {
        #region Repositorios
        private EFRepository<Proveedor> _repository;
        public EFRepository<Proveedor> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Proveedor>()); }
        }

        public List<ProveedorProducto> ProductoCompletos { get; set; }
        public List<Producto> Productos { get; set; }

        private EFRepository<ProveedorProducto> _repositoryProducto;
        public EFRepository<ProveedorProducto> RepositoryProducto
        {
            get { return _repositoryProducto ?? (_repositoryProducto = new EFRepository<ProveedorProducto>()); }
        }
        #endregion
        
        #region propiedades

        public System.Guid Identifier { get; set; }

        public string Nombre
        {
            get { return ucTextBoxGrisNombre.Texto; }
            set { ucTextBoxGrisNombre.Texto = value; }
        }

        public string Contacto
        {
            get { return ucTextBoxGrisContacto.Texto; }
            set { ucTextBoxGrisContacto.Texto = value; }
        }

        public string Direccion
        {
            get { return ucTextBoxGrisDomicilio.Texto; }
            set { ucTextBoxGrisDomicilio.Texto = value; }
        }

        public string Localidad
        {
            get { return ucTextBoxGrisLocalidad.Texto; }
            set { ucTextBoxGrisLocalidad.Texto=value;}
        }

        public string Telefono
        {
            get { return ucTextBoxGrisTelefono.Texto; }
            set { ucTextBoxGrisTelefono.Texto = value; }
        }

        public string Celular
        {
            get { return ucTextBoxGrisCelular.Texto; }
            set { ucTextBoxGrisCelular.Texto = value; }
        }

        public string TipoComprobante
        {
            get { return txtTipoComprobante.Texto; }
            set { txtTipoComprobante.Texto = value; }
        }

        public string TipoCuit
        {
            get { return ucTextBoxGrisTipoCuit.Texto; }
            set { ucTextBoxGrisTipoCuit.Texto = value; }
        }

        public string CuitNro
        {
            get { return ucTextBoxGrisNroCuit.Texto; }
            set { ucTextBoxGrisNroCuit.Texto = value; }
        }

        public string Email
        {
            get { return ucTextBoxGrisEmail.Texto; }
            set { ucTextBoxGrisEmail.Texto = value; }
        }

        public string PaginaWeb
        {
            get { return ucTextBoxGrisWeb.Texto; }
            set { ucTextBoxGrisWeb.Texto = value; }
        }

        public string Observaciones
        {
            get { return txtObservaciones.Text; }
            set { txtObservaciones.Text = value; }
        }

        public bool NoReflejarFacturaEnCaja
        {
            get { return txtNoReflejarFacturaEnCaja.Texto == "Si"; }
            set { txtNoReflejarFacturaEnCaja.Texto = value ? "Si" : "No"; }
        }
        
        public bool Desincronizado { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public bool Eliminado { get; set; }

        public int CuentaId { get; set; }

        private string _tituloVentana { get; set; }

        public Proveedor Proveedor { get; set; }

        #endregion

        #region Inicializar
        public frmDetalleProveedor(int proveedorId)
            : base()
        {
            InitializeComponent();
            CargarProveedor(proveedorId);
            _tituloVentana = "Detalles del Proveedor "+ ucTextBoxGrisNombre.Texto;

            //Lleno el dgv de listado de productos de proveedores.
            var listado = RepositoryProducto.Listado(p => p.Producto, m=>m.Producto.Marca,p=>p.Producto.Rubro).Where(a => a.ProveedorId == proveedorId).ToList();

            dgvListado.DataSource = listado;
            dgvListado.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;

        }
        #endregion

        #region Metodos
        private void CargarProveedor(int proveedorId)
        {

            Proveedor = Repository.Obtener(proveedorId);
            
            Identifier = Proveedor.Identifier;
            Nombre = Proveedor.Nombre;
            Contacto = Proveedor.Contacto;
            Direccion = Proveedor.Direccion;
            Localidad = Proveedor.LocalidadString;
            TipoCuit = Proveedor.TipoCuitString;
            Telefono = Proveedor.Telefono;
            Celular = Proveedor.Celular;
            TipoComprobante = Proveedor.TipoComprobante;
            CuitNro = Proveedor.CuitNro;
            Email = Proveedor.Email;
            PaginaWeb = Proveedor.PaginaWeb;
            Observaciones = Proveedor.Observaciones;
            Desincronizado = Proveedor.Desincronizado;
            FechaUltimaModificacion = DateTime.Now;
            Eliminado = Proveedor.Eliminado;
            CuentaId = Proveedor.CuentaId;
            NoReflejarFacturaEnCaja = Proveedor.NoReflejarFacturaEnCaja;
        }

        private void frmDetalleProveedor_Load(object sender, EventArgs e)
        {
            //CargarControles();
            Text = _tituloVentana;
            label14.Text = _tituloVentana;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
