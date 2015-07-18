using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Clases;
using MaxiKioscos.Entidades;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.Productos
{
    public partial class frmAMCodigoProducto : Form
    {
        private int id = 0;
        private CodigoProducto codProducto;
        public frmAMCodigoProducto(int Id)
        {
            InitializeComponent();
            id = Id;
            this.Text = "Modificar Código";
        }
        public frmAMCodigoProducto()
        {
            InitializeComponent();
            this.Text = "Agregar Código";
        }

        #region  BarraHerramientas

        private void CrearBH()
        {
            bh.CrearItemBarraEspecifica("Aceptar", MaxiKioscos.Winforms.Properties.Resources.ok, Aceptar);
            bh.CrearItemBarraEspecifica("Cerrar", MaxiKioscos.Winforms.Properties.Resources.Cerrar, Cerrar);
        }
      
        private void Cerrar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptar(object sender, EventArgs e)
        {
            errorProvider.Dispose();

            var valido = Validacion.Validar(errorProvider, new List<object>
                                                               {
                                                                   txtCodigoBarras
                                                               });
            if (valido)
            {
                var repo = new CodigoProductoRepository();
                if (id==0)
                {
                    codProducto=new CodigoProducto();
                    CargarCodigo();
                    repo.Agregar(codProducto);
                }
                else
                {
                    CargarCodigo();
                    repo.Modificar(codProducto);
                }
                if (repo.Commit())
                {
                    Mensajes.Guardar(true);
                }
                else
                {
                    Mensajes.Guardar(false);
                }
            }
        }
        #endregion

        private void CargarCodigo()
        {
            codProducto.Codigo = txtCodigoBarras.Valor;
            codProducto.ProductoId = id;
        }

        private void frmAMCodigoProducto_Load(object sender, EventArgs e)
        {
            CrearBH();
            if (id!=0)
            {
                CargarControles();
            }
        }

        private void CargarControles()
        {
            var repo = new CodigoProductoRepository();
            codProducto = repo.Obtener(id);
            txtCodigoBarras.Valor = codProducto.Codigo;
        }

        private void frmAMCodigoProducto_Shown(object sender, EventArgs e)
        {
            txtCodigoBarras.Select();
        }
    }
}
