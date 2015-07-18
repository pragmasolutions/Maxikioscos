using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKiosco.Win.Util;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.Facturas
{
    public partial class frmEditarFactura : Form
        
    {
        private EFRepository<Factura> _facturaRepository;
        public EFRepository<Factura> FacturaRepository
        {
            get
            {
                if (_facturaRepository == null)
                    _facturaRepository = new EFRepository<Factura>();
                return _facturaRepository;
            }
        }

        private EFRepository<Proveedor> _proveedorRepository;
        public EFRepository<Proveedor> ProveedorRepository
        {
            get
            {
                if (_proveedorRepository == null)
                    _proveedorRepository = new EFRepository<Proveedor>();
                return _proveedorRepository;
            }
        }

        #region Constructores
        public frmEditarFactura()
        {
            InitializeComponent();
            CargarProveedores();
            CargarAutonumerico();
            
            lblTitulo.Text = "Crear Factura";
            this.Text = "Crear Factura";
            txtAutonumerico.Enabled = false;

        }

        public frmEditarFactura(int facturaId)
        {
            InitializeComponent();

            CargarProveedores();
            CargarFactura(facturaId);
            lblTitulo.Text = "Editar Factura";
            this.Text = "Editar Factura";
            txtAutonumerico.Enabled = false;

        }
        #endregion

        #region Propiedades

        public string FacturaNro
        {
            get { return txtFacturaNro.Valor; }
            set { txtFacturaNro.Valor = value; }
        }

        public decimal ImporteTotal
        {
            get { return txtImporteTotal.Valor.GetValueOrDefault(); }
            set { txtImporteTotal.Valor = value; }
        }

        public DateTime Fecha
        {
            get { return dtpFecha.Fecha; }
            set { dtpFecha.Fecha = value; }
        }
        
        public int ProveedorId
        {
            get { return (int)ddlProveedor.SelectedValue; }
            set { ddlProveedor.SelectedValue = value; }
        }

        public Factura Factura { get; set; }

        public string Autonumerico
        {
            get { return txtAutonumerico.Text; }
            set { txtAutonumerico.Text = value; }
        }


        #endregion

        #region Metodos

        private void CargarAutonumerico()
        {
            var abreviacion = AppSettings.Maxikiosco.Abreviacion;
            var facturas = FacturaRepository.Listado()
                            .Where(f => f.MaxiKioscoId == AppSettings.MaxiKioscoId
                                    && f.AutoNumero.StartsWith(abreviacion)).OrderByDescending(f=> f.FacturaId).ToList();
            var numero = 0;
            if (facturas.Any())
            {
                var factura = facturas.First();
                numero = Convert.ToInt32(factura.AutoNumero.Replace(abreviacion, ""));
            }
            txtAutonumerico.Text = String.Format("{0}{1}", abreviacion, numero + 1);
        }
        
        private void CargarProveedores()
        {
            var proveedores = ProveedorRepository.Listado().OrderBy(p => p.Nombre).ToList();
            proveedores.Insert(0, new Proveedor());
            ddlProveedor.DisplayMember = "Nombre";
            ddlProveedor.ValueMember = "ProveedorId";
            ddlProveedor.DataSource = proveedores;
            
        }

        private void CargarFactura(int facturaId)
        {

            Factura = FacturaRepository.Obtener(f => f.FacturaId == facturaId, f => f.Proveedor, 
                f => f.Compras, f => f.Compras.Select(c => c.ComprasProductos),
                f => f.Compras.Select(c => c.ComprasProductos.Select(cp => cp.Producto)));

            FacturaNro = Factura.FacturaNro;
            ImporteTotal = Factura.ImporteTotal;
            Fecha = Factura.Fecha;
            ProveedorId = Factura.ProveedorId;
            txtAutonumerico.Text = Factura.AutoNumero;
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtFacturaNro,
                                                      txtImporteTotal,
                                                      ddlProveedor
                                                  });
            if (valido)
            {


                if (Factura != null)
                {
                    //verifico que ya no haya una factura con el mismo numero y proveedor
                    var existente = FacturaRepository.Obtener(f => f.FacturaNro == FacturaNro
                                                           && f.ProveedorId == ProveedorId
                                                           && f.FacturaId != Factura.FacturaId);
                    if (existente != null)
                    {
                        MessageBox.Show("Ya existe una factura para el proveedor seleccionado con el mismo número");
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        Factura.FacturaNro = FacturaNro;
                        Factura.ImporteTotal = ImporteTotal;
                        Factura.ProveedorId = ProveedorId;
                        //Factura.UsuarioId = UsuarioActual.UsuarioId;
                        FacturaRepository.Modificar(Factura);
                        FacturaRepository.Commit();
                    }
                }
                else
                {
                    var existente = FacturaRepository.Obtener(f => f.FacturaNro == FacturaNro
                                                           && f.ProveedorId == ProveedorId);
                    if (existente != null)
                    {
                        MessageBox.Show("Ya existe una factura para el proveedor seleccionado con el mismo número");
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        Factura = new Factura()
                        {
                            CierreCajaId = UsuarioActual.CierreCajaIdActual,
                            Identifier = Guid.NewGuid(),
                            FacturaNro = FacturaNro,
                            ImporteTotal = ImporteTotal,
                            ProveedorId = ProveedorId,
                            MaxiKioscoId = AppSettings.MaxiKioscoId,
                            Fecha = Fecha,
                            AutoNumero = txtAutonumerico.Text,
                            UsuarioId = UsuarioActual.UsuarioId,
                            FechaCreacion = DateTime.Now
                        };
                        FacturaRepository.Agregar(Factura);
                        FacturaRepository.Commit();
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
        #endregion

        private void frmEditarFactura_Shown(object sender, EventArgs e)
        {
            dtpFecha.Select();
        }
    }
}
