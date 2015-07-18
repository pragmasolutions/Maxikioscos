using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Properties;


namespace MaxiKioscos.Winforms.Proveedores
{
    public partial class FrmEditarProveedor : Form
    //  public partial class FrmEditarProveedor : FormBase<Proveedor>
    {
        private EFRepository<Proveedor> _repository;
        public EFRepository<Proveedor> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Proveedor>()); }
        }

        #region propiedades

        public System.Guid Identifier{get ;set;}

        public string Nombre
        {
            get { return txtNombre.Valor; }
            set { txtNombre.Valor = value; }
        }

        public string Contacto
        {
            get { return txtContacto.Valor; }
            set { txtContacto.Valor = value; }
        }

        public string Direccion
        {
            get { return txtDireccion.Text; }
            set { txtDireccion.Text = value; }
        }

        public System.Nullable<int> Localidad { get; set; }
        
        public string Telefono
        {
            get { return txtTelefono.Valor; }
            set { txtTelefono.Valor = value; }
        }

        public string Celular
        {
            get { return txtCelular.Valor; }
            set { txtCelular.Valor = value; }
        }

        public System.Nullable<int> TipoCuit { get; set; }
        
        public string CuitNro
        {
            get { return txtCuit.Text; }
            set { txtCuit.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string PaginaWeb
        {
            get { return txtWeb.Text; }
            set { txtWeb.Text = value; }
        }

        public string Observaciones
        {
            get { return txtObservaciones.Text; }
            set { txtObservaciones.Text = value; }
        }

        public bool Desincronizado { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public bool Eliminado { get; set; }

        public int CuentaId { get; set; }





        private string _tituloVentana { get; set; }

        public Proveedor Proveedor { get; set; }

        #endregion

        public FrmEditarProveedor(int proveedorId)
            : base()
        {
            InitializeComponent();
            CargarProveedor(proveedorId);
            _tituloVentana = "Editar Proveedor";
        }

        public FrmEditarProveedor()
        {
            InitializeComponent();
            _tituloVentana = "Nuevo Proveedor";
        }

        private void CrearBarraHerramientas()
        {
            barraHerramientas1.CrearItemBarraEspecifica("Aceptar", Properties.Resources.ok, Aceptar);
            barraHerramientas1.CrearItemBarraEspecifica("Cancelar", Properties.Resources.Cerrar, Cancelar);
        }

        private void Aceptar(object sender, EventArgs e)
        {
            //    errorProvider.Dispose();

            //    //var valido = Validacion.Validar(errorProvider, new List<object>
            //    //                                      {
            //      //                                        txtDescripcion,
            //        //                                      txtAbreviatura,
            //          //                                    cmbCategorias
            //            //                              });
            //    if (valido)
            //{

            //ACA HAY QUE VALIDAR CON LA INTERFAZ
            var proveedor = ArmarProveedor();
            

            //Repository.Agregar(proveedor);
            if (proveedor.ProveedorId == 0)
            {
                Repository.Agregar(proveedor);
            }
            else
            {
                Repository.Modificar(proveedor);
            }
            Repository.Commit();
          

            this.Close();

            //    var seGuardo = Repository.Agregar(proveedor);
            //        if (seGuardo)
            //            this.Close();

            //    }

        }

        private void Cancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarProveedor(int proveedorId)
        {

            Proveedor = Repository.Obtener(proveedorId);

            Identifier = Proveedor.Identifier;
            Nombre = Proveedor.Nombre;
            Contacto = Proveedor.Contacto;
            Direccion = Proveedor.Direccion;
            Localidad = Proveedor.LocalidadId;
            Telefono = Proveedor.Telefono;
            Celular = Proveedor.Celular;
            TipoCuit = Proveedor.TipoCuitId;
            CuitNro = Proveedor.CuitNro;
            Email = Proveedor.Email;
            PaginaWeb = Proveedor.PaginaWeb;
            Observaciones = Proveedor.Observaciones;
            Desincronizado = Proveedor.Desincronizado;
            FechaUltimaModificacion = DateTime.Now;
            Eliminado = Proveedor.Eliminado;
            CuentaId = Proveedor.CuentaId;





            //Habilitado = Proveedor.Eliminado;
        }

        private Entidades.Proveedor ArmarProveedor()
        {
            if (Proveedor == null)
            {
                Proveedor = new Entidades.Proveedor();
                Proveedor.Identifier = Guid.NewGuid();
            }
          
            
            Proveedor.Nombre = Nombre;
            Proveedor.Contacto = Contacto;
            Proveedor.Direccion = Direccion;
            //Proveedor.LocalidadId = 1;
            Proveedor.LocalidadId = cmbLocalidad.Valor;
            Proveedor.Telefono = Telefono;
            Proveedor.Celular = Celular;
            //Proveedor.TipoCuitId = 1;
            Proveedor.TipoCuitId = (int)cmbTipoCuit.SelectedValue;
            Proveedor.CuitNro = CuitNro;
            Proveedor.Email = Email;
            Proveedor.PaginaWeb = PaginaWeb;
            Proveedor.Observaciones = Observaciones;
            Proveedor.Desincronizado = true;
            Proveedor.Eliminado = Eliminado;
            //Proveedor.CuentaId = CuentaId;
            Proveedor.CuentaId = 1;

            return Proveedor;
        }

        private void frmEditar_Load(object sender, EventArgs e)
        {
            CrearBarraHerramientas();
            CargarControles();
            Text = _tituloVentana;
        }

        private void CargarControles()
        {
            
            //cargo los tipo de cuits
            var _tipocuit = Repository.MaxiKioscosEntities.TipoCuits.ToList();
            cmbTipoCuit.DisplayMember = "Descripcion";
            cmbTipoCuit.ValueMember = "TipoCuitId";
            cmbTipoCuit.DataSource = _tipocuit;

            //cargo las localidades
            var _localidad = Repository.MaxiKioscosEntities.Localidads.ToList();
            cmbLocalidad.DisplayMember = "Descripcion";
            cmbLocalidad.ValueMember = "LocalidadId";
            cmbLocalidad.DataSource = _localidad;
        }

      


    }

}

       

