using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using Util;

namespace MaxiKioscos.Winforms.Productos.Modulos
{
    public partial class IngresarCosto : Form
    {
        public decimal? Costo { get; set; }
        public string Descripcion { get; set; }

        public IngresarCosto(ProductoCompleto producto)
        {
            InitializeComponent();
            Descripcion = producto.Descripcion;
        }

        public IngresarCosto(string productoDescripcion)
        {
            InitializeComponent();
            Descripcion = productoDescripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object> { txtCosto });
            if (valido)
            {
                Costo = txtCosto.Valor;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void IngresarCosto_Shown(object sender, EventArgs e)
        {
            txtCosto.Select();
        }

        private void IngresarCosto_Load(object sender, EventArgs e)
        {
            txtProducto.Texto = Descripcion;
            txtCosto.FocusOnTextbox();
        }
    }
}
