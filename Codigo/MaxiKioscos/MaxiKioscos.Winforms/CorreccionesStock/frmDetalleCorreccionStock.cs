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
using MaxiKioscos.Winforms.Productos;
using Util;

namespace MaxiKioscos.Winforms.CorreccionesStock
{
    public partial class frmDetalleCorreccionStock : Form
    {
        #region repositorios

        public List<CorreccionStock> CorreccionStock { get; set; }
        private EFSimpleRepository<CorreccionStock> _correccionstockRepository;
        public EFSimpleRepository<CorreccionStock> CorreccionStockRepository
        {
            get
            {
                if (_correccionstockRepository == null)
                    _correccionstockRepository = new EFSimpleRepository<CorreccionStock>();
                return _correccionstockRepository;
            } 
        }


        private EFRepository<Stock> _stockRepository;
        public EFRepository<Stock> StockRepository
        {
            get
            {
                if (_stockRepository == null)
                    _stockRepository = new EFRepository<Stock>();
                return _stockRepository;
            }
        }

        private EFRepository<StockTransaccion> _stocktransaccionRepository;
        public EFRepository<StockTransaccion> StockTransaccionRepository
        {
            get
            {
                if (_stocktransaccionRepository == null)
                    _stocktransaccionRepository = new EFRepository<StockTransaccion>();
                return _stocktransaccionRepository;
            }
        }
       
        private EFSimpleRepository<ProductoCompleto> _productoRepository;
        public EFSimpleRepository<ProductoCompleto> ProductoRepository
        {
            get
            {
                if (_productoRepository == null)
                    _productoRepository = new EFSimpleRepository<ProductoCompleto>();
                return _productoRepository;
            }
        }

        
        private EFSimpleRepository<MotivoCorreccion> _motivoRepository;
        public EFSimpleRepository<MotivoCorreccion> MotivoRepository
        {
            get
            {
                if (_motivoRepository == null)
                    _motivoRepository = new EFSimpleRepository<MotivoCorreccion>();
                return _motivoRepository;
            }
        }
    #endregion
        
        #region propiedades

       public string Descripcion
        {
            get { return txtProductoNombre.Valor; }
            set { txtProductoNombre.Valor = value; }
        }

        public decimal Precio
        {
            get { return txtPrecio.Valor.GetValueOrDefault(); }
            set { txtPrecio.Valor = value; }
        }
        
        public string CantidadActual
        {
            get { return  txtCantidadActual.Valor; }
            set { txtCantidadActual.Valor = value; }
        }
        
        public int MotivoId
        {
            get { return (int)ddlMotivoCorreccion.SelectedValue; }
            set { ddlMotivoCorreccion.SelectedValue = value; }
        }

        public ProductoCompleto Producto;
        public Stock Stock;
        public List<ProductoCompleto> ProductosDatasource { get; set; }

        #endregion

        #region Inicializar
        private void frmEditarCorreccionStock_Load(object sender, EventArgs e)
        {
            //DeshabilitarComponentes();
        }

        
        public frmDetalleCorreccionStock()
        {
            InitializeComponent();
           

            lblTitulo.Text = "Crear Correccion Stock";
            this.Text = "Crear Correccion Stock";
            DeshabilitarEdicion();
            
        }

        public frmDetalleCorreccionStock(int correccionId)
        {
            InitializeComponent();
            CargarMotivo();
            //var corr = CorreccionStockRepository.Obtener(c => c.CorreccionStockId == correccionId);
           var  correcion = CorreccionStockRepository.Obtener(c => c.CorreccionStockId == correccionId,p=>p.Producto,m=>m.MotivoCorreccion);
           lblTitulo.Text = "Detalle Correccion Stock";
           this.Text = "Detalle Correccion Stock";
           DeshabilitarEdicion();
           CargarCorreccion(correcion);
            pnlCorreccion.Enabled = true;

        }

      
        #endregion

        #region Metodos

        private void CargarCorreccion(CorreccionStock correccion)
        {
            Descripcion = correccion.Producto.Descripcion;
            Precio = correccion.Precio;
            CantidadActual = correccion.Cantidad.ToString();
            MotivoId = correccion.MotivoCorreccionId;
            DeshabilitarDetalle();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtCantidadActual,
                                                      ddlMotivoCorreccion
                                                  });
            if (valido)
            {
                AgregarCorreccion(Producto);
                ModificarStock(Producto);
                AgregarStockTransaccion(Stock);
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }



       

       

        private void CargarProducto(ProductoCompleto original)
        {
            //Busco el stock para traer la cantidad
            Stock = StockRepository.Obtener(s => s.ProductoId == original.ProductoId
                                              && s.MaxiKioscoId == AppSettings.MaxiKioscoId);
            
           
            Descripcion = original.Descripcion;
            Precio = original.PrecioConIVA;
            // controlo que haya stock de este producto
            if (Stock == null )  
            {
                MessageBox.Show("No existe stock de este producto");
                DeshabilitarEdicion();
                
            }
            else if (Stock.StockActual == 0)
            {
                MessageBox.Show("No hay stock del producto");
                DeshabilitarEdicion();
            }
            else
            {
                HabilitarEdicion();
            }
            CargarMotivo();
        }

        private  void CargarMotivo()
        {
            var motivos = MotivoRepository.Listado().OrderBy(m => m.Descripcion).ToList();
            ddlMotivoCorreccion.DisplayMember = "Descripcion";
            ddlMotivoCorreccion.ValueMember = "MotivoCorreccionId";
            ddlMotivoCorreccion.DataSource = motivos;
        }

        private void AgregarCorreccion(ProductoCompleto original)
        {
            var correccionstock = new CorreccionStock()

            //actualizar las propiedades
            {
                ProductoId = original.ProductoId,
                Cantidad = Convert.ToDecimal(CantidadActual),
                Precio = original.PrecioConIVA,
                MotivoCorreccionId = MotivoId,
                Desincronizado = true,
                FechaUltimaModificacion = DateTime.Now,
                Fecha =DateTime.Now,
                Identifier = Guid.NewGuid(),
                MaxiKioscoId = AppSettings.MaxiKioscoId,
            };
            CorreccionStockRepository.Agregar(correccionstock);
            CorreccionStockRepository.Commit();
        }

        private void DeshabilitarDetalle()
        {
            txtCantidadActual.Enabled = false;
            
            txtPrecio.Enabled = false;
            
            txtProductoNombre.Enabled= false;
            ddlMotivoCorreccion.Enabled = false;
            
            btnAceptar.Visible = false;

            btnCancelar.Focus();
        }
       private void DeshabilitarEdicion()
        {
            //Este procedimiento deshabilita los txt de cantidad de mercadería ya que la cantidad es 0 o no existe stock del producto
            pnlCorreccion.Enabled = false;
            btnAceptar.Enabled = false;
            }

        private void HabilitarEdicion()
        {
            //Este procedimiento habilita los txt de cantidad de mercadería ya que la cantidad es distinta de 0 
            pnlCorreccion.Enabled = true;
            btnAceptar.Enabled = true;
        }

        private void AgregarStockTransaccion(Stock stock)
        {
            var StockTransaccion = new StockTransaccion();
            StockTransaccion.StockId = stock.StockId;
            StockTransaccion.Identifier = Guid.NewGuid();
            StockTransaccion.Desincronizado = true;
            StockTransaccion.FechaUltimaModificacion = DateTime.Now;
            StockTransaccion.Eliminado = false;
            StockTransaccion.Cantidad = Convert.ToDecimal(CantidadActual);
            StockTransaccion.StockTransaccionTipoId = 3;
            StockTransaccionRepository.Agregar(StockTransaccion);
            StockTransaccionRepository.Commit();

        }

        private void ModificarStock(ProductoCompleto producto)
        {
         
            Stock.StockActual = Stock.StockActual - Convert.ToDecimal(CantidadActual);
            Stock.FechaUltimaModificacion = DateTime.Now;
            
            StockRepository.Modificar(Stock);
            StockRepository.Commit();
        }
        #endregion

        #region KeysBehaviour
       
        
        #endregion

        
    }
}

