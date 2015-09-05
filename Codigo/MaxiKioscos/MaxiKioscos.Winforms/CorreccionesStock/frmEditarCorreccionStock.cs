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
using MaxiKioscos.Winforms.Interfaces;
using MaxiKioscos.Winforms.Productos;
using MaxiKioscos.Winforms.UserControls;
using Util;

namespace MaxiKioscos.Winforms.CorreccionesStock
{
    public partial class frmEditarCorreccionStock : Form, IBuscadorParent
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


        private StockRepository _stockRepository;
        public StockRepository StockRepository
        {
            get
            {
                if (_stockRepository == null)
                    _stockRepository = new StockRepository();
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

        private EFSimpleRepository<Producto> _productosimpleRepository;
        public EFSimpleRepository<Producto> ProductoSimpleRepository
        {
            get
            {
                if (_productosimpleRepository == null)
                    _productosimpleRepository = new EFSimpleRepository<Producto>();
                return _productosimpleRepository;
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

        public bool Eliminado
        {
            get { return true; }
        }


        public string CantidadOriginal
        {
            //get { return txtCantidadOriginal.Valor; }
            set { txtCantidadOriginal.Valor = value;}
        }
        
        public string CantidadActual
        {
            get { return  txtCantidadActual.Valor; }
            set { txtCantidadActual.Valor = value; }
        }
        
        public int MotivoId
        {
            get { return 1; }
        }

        public ProductoCompleto Producto;
        public Stock Stock;
        public List<ProductoCompleto> ProductosDatasource { get; set; }

        #endregion

        public frmEditarCorreccionStock()
        {
            InitializeComponent();
            StockRepository.Actualizar();
            DeshabilitarEdicion();
            txtCodigo.Focus();
        }

        #region Inicializar

        private void frmEditarCorreccionStock_Load(object sender, EventArgs e)
        {
            ProductosDatasource = ProductoRepository.MaxiKioscosEntities.ProductoListadoCompleto(AppSettings.MaxiKioscoId, null, null).ToList();
        }
        
        public frmEditarCorreccionStock(int correccionId)
        {
            using (var frm = new ConfirmationForm("Desea eliminar la corrección?","Aceptar","Cancelar"))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Eliminar 
                    var correcion = CorreccionStockRepository.Obtener(correccionId);
                    var tipocorreccion = MotivoRepository.Obtener(t => t.MotivoCorreccionId == correcion.MotivoCorreccionId);
                    EliminarCorreccion(correccionId);
                    
                    Stock = StockRepository.Obtener(s => s.ProductoId == correcion.ProductoId
                                             && s.MaxiKioscoId == AppSettings.MaxiKioscoId);

                    ModificarStock((correcion.Cantidad * -1),tipocorreccion.SumarAStock);

                    AgregarStockTransaccion(Stock, correcion.Cantidad * -1);
                   
                    MessageBox.Show("La corrección ha sido eliminada");

                    this.Close();
                    
                }
            }
        }

       
        #endregion
        
        #region Metodos
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtCantidadActual
                                                  });
            
            if (valido) 
            {
                if (Stock == null)
                {
                    Stock = AgregarStock(Producto.ProductoId, Convert.ToDecimal(txtCantidadActual.Valor));
                    Stock = StockRepository.Obtener(s => s.ProductoId == Producto.ProductoId);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    ModificarStock(Convert.ToDecimal(CantidadActual), false);
                        
                AgregarCorreccion(Producto);

                var incremento = Convert.ToDecimal(CantidadActual)*-1;
                AgregarStockTransaccion(Stock, incremento);
                        
                this.DialogResult = DialogResult.OK;
            }
           
            else
                this.DialogResult = DialogResult.None;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(ProductoCriterioBusqueda.Codigo);
        }

        private void Buscar(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {
                var productos = ProductosDatasource.ToList();
                var frm = new Productos.BuscadorCompleto(txtCodigo.Text, productos, criterio);

                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;


                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Closing += FrmOnClosing;
                frm.Show();

                txtCodigo.Focus();
            }
        }
       

        private void CargarProducto(ProductoCompleto original)
        {
            txtCodigo.Text = original.Descripcion;
            //Busco el stock para traer la cantidad
            Stock = StockRepository.Obtener(s => s.ProductoId == original.ProductoId
                                              && s.MaxiKioscoId == AppSettings.MaxiKioscoId);

            Producto = original;
            Descripcion = original.Descripcion;
            Precio = original.PrecioConIVA;
            // controlo que haya stock de este producto

            CantidadOriginal = Stock == null ? "0" : Stock.StockActual.ToString();
            HabilitarEdicion();
        }

        private void EliminarCorreccion(int idCorreccion)
        {
            //var correccionstock = new CorreccionStock();
            {
                var correccion = CorreccionStockRepository.Obtener(c => c.CorreccionStockId == idCorreccion);
                correccion.Eliminado = true;
                
                
                CorreccionStockRepository.Modificar(correccion);
                try
                {
                    CorreccionStockRepository.Commit();
                   
                }
                catch (Exception e)
                {
                    
                    throw e;
                }
               
            }

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

        private void DeshabilitarEdicion()
        {
            //Este procedimiento deshabilita los txt de cantidad de mercadería ya que la cantidad es 0 o no existe stock del producto
            pnlCorreccion.Enabled = false;
            btnAceptar.Enabled = false;
            txtCodigo.Focus();
        }

        private void HabilitarEdicion()
        {
            //Este procedimiento habilita los txt de cantidad de mercadería ya que la cantidad es distinta de 0 
            pnlCorreccion.Enabled = true;
            btnAceptar.Enabled = true;
        }

        private void AgregarStockTransaccion(Stock stock,decimal cantidad)
        {
            var stockTransaccion = new StockTransaccion
                                       {
                                           StockId = stock.StockId,
                                           Identifier = Guid.NewGuid(),
                                           Desincronizado = true,
                                           FechaUltimaModificacion = DateTime.Now,
                                           Eliminado = false,
                                           Cantidad = cantidad,
                                           StockTransaccionTipoId = 3
                                       };
            StockTransaccionRepository.Agregar(stockTransaccion);
            StockTransaccionRepository.Commit();

        }

        private Stock AgregarStock(int productoid, decimal stockactual)
        {
            var stock = new Stock
                            {
                                ProductoId = productoid,
                                MaxiKioscoId = AppSettings.MaxiKioscoId,
                                Identifier = Guid.NewGuid(),
                                StockActual = stockactual,
                                Desincronizado = true,
                                FechaUltimaModificacion = DateTime.Now,
                                Eliminado = false,
                                OperacionCreacion = "Correccion de stock DESKTOP",
                                FechaCreacion = DateTime.Now
                            };
            StockRepository.Agregar(stock);
            StockRepository.Commit();
            return stock;

        }

        private void ModificarStock(decimal cantidad,Boolean sumarastock)
        {
            
            if (sumarastock)
                cantidad = cantidad * -1;

            Stock.StockActual = Stock.StockActual - cantidad;
            Stock.FechaUltimaModificacion = DateTime.Now;
            
            StockRepository.Modificar(Stock);
            StockRepository.Commit();
        }
        #endregion

        #region KeysBehaviour

        private void frmEditarCorreccionStock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                txtCodigo.Focus();
            }
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmEditarCorreccionStock_Shown(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            CerrarBuscador();
        }

        private void CerrarBuscador()
        {
            if (this.OwnedForms.Any())
            {
                this.OwnedForms.First().Close();
            }
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            var texto = txtCodigo.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(e.KeyCode);
            }
            else
            {
                TratarTextoDistintoVacio(e.KeyCode);
            }
        }

        private void TratarTextoDistintoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.Down:
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        BuscadorSubir();
                        break;
                    case Keys.Enter:
                        Seleccionar();
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                }
            }
            else
            {
                AbrirBuscador(ProductoCriterioBusqueda.Codigo);
                txtCodigo.Focus();
            }
        }

        private void TratarTextoVacio(Keys keyCode)
        {
            var especiales = new[] { Keys.F5, Keys.F6, Keys.Escape, Keys.Back, Keys.Enter, Keys.Down, Keys.Up };
            if (especiales.Contains(keyCode))
            {
                switch (keyCode)
                {
                    case Keys.F5:
                        AbrirBuscador(ProductoCriterioBusqueda.Marca);
                        break;
                    case Keys.F6:
                        AbrirBuscador(ProductoCriterioBusqueda.Descripcion);
                        break;
                    case Keys.Escape:
                        CerrarBuscador();
                        break;
                    case Keys.Back:
                        CerrarBuscador();
                        break;
                    case Keys.Enter:
                        Seleccionar();
                        break;
                    case Keys.Down:
                        BuscadorBajar();
                        break;
                    case Keys.Up:
                        BuscadorSubir();
                        break;
                }
            }
        }

        private void Seleccionar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                var producto = buscador.ObtenerProducto();
                CargarProducto(producto);
                buscador.Close();
                txtCantidadActual.Focus();
            }
        }

        private void BuscadorSubir()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Subir();
            }
        }

        private void BuscadorBajar()
        {
            if (this.OwnedForms.Any())
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Bajar();
            }
        }

        private void AbrirBuscador(ProductoCriterioBusqueda criterio)
        {
            if (!this.OwnedForms.Any())
            {

                var frm = new BuscadorCompleto(txtCodigo.Text, ProductosDatasource.ToList(), criterio);
                frm.TeclaApretada += FrmOnTeclaApretada;
                frm.Owner = this;
                Point locationOnForm = txtCodigo.PointToScreen(Point.Empty);
                //frm.ShowDialog();
                frm.Top = locationOnForm.Y + 24;
                frm.Left = locationOnForm.X;
                frm.Closing += FrmOnClosing;
                frm.Show();
                frm.Texto = txtCodigo.Text;
                txtCodigo.Focus();
            }
            else
            {
                var buscador = this.OwnedForms.First() as BuscadorCompleto;
                buscador.Texto = txtCodigo.Text;
                buscador.AplicarFiltros();
            }
        }

        private void FrmOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            var frm = sender as BuscadorCompleto;
            if (!frm.CerradoDesdeTextbox && frm.ProductoSeleccionado != null)
            {
                CargarProducto(frm.ProductoSeleccionado);
                txtCantidadActual.Focus();
            }
        }

        private void FrmOnTeclaApretada(Keys key)
        {
            var texto = txtCodigo.Text;
            if (string.IsNullOrEmpty(texto))
            {
                TratarTextoVacio(key);
            }
            else
            {
                TratarTextoDistintoVacio(key);
            }
        }

        public void FocusOnCodeTextbox()
        {
            txtCodigo.Focus();
        }

        private void txtCantidadActual_TeclaApretada(Keys tecla)
        {
            if (tecla == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }
    }
}

