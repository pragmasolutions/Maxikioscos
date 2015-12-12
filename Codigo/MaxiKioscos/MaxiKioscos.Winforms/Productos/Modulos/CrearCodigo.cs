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
using MaxiKioscos.Winforms.Helpers;
using Util;

namespace MaxiKioscos.Winforms.Productos.Modulos
{
    public partial class CrearCodigo : Form
    {
        private EFRepository<CodigoProducto> _repository;
        public EFRepository<CodigoProducto> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<CodigoProducto>()); }
        }

        public CodigoProducto CodigoProducto { get; set; }

        public CrearCodigo(CodigoProducto codigo)
        {
            InitializeComponent();
            CodigoProducto = codigo;
            txtCodigo.Valor = codigo.Codigo;
            txtCodigo.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object> { txtCodigo });
            if (valido)
            {
                if (CodigoProducto.CodigoProductoId == 0)
                {
                    var cod = Repository.Obtener(c => c.Codigo == txtCodigo.Valor
                                                && c.Producto.CuentaId == UsuarioActual.CuentaId);
                    if (cod != null)
                    {
                        MostrarError("Ya existe un producto con el código ingresado");
                    }
                    else
                    {
                        CodigoProducto.Codigo = txtCodigo.Valor;
                        CodigoProducto.Identifier = Guid.NewGuid();
                        Repository.Agregar(CodigoProducto);
                        Repository.Commit();
                        ActualizacionPantallasHelper.ActualizarPantallaVentas();
                    }
                }
                else
                {
                    var cod = Repository.Obtener(c => c.Codigo == txtCodigo.Valor
                                            && c.CodigoProductoId != CodigoProducto.CodigoProductoId    
                                            && c.Producto.CuentaId == UsuarioActual.CuentaId);
                    if (cod != null)
                    {
                        MostrarError("Ya existe un producto con el código ingresado");
                    }
                    else
                    {
                        CodigoProducto.Codigo = txtCodigo.Valor;
                        Repository.Modificar(CodigoProducto);
                        Repository.Commit();
                        ActualizacionPantallasHelper.ActualizarPantallaVentas();
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void MostrarError(string mensaje)
        {
            errorProvider1.SetError(txtCodigo, mensaje);
            errorProvider1.SetIconPadding(txtCodigo, 2);
            DialogResult = DialogResult.None;
        }

        private void CrearCodigo_Shown(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }
    }
}
