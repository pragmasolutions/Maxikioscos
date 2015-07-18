using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace MaxiKioscos.Winforms.Productos.Modulos
{
    public partial class IngresarUnidades : Form
    {
        public Decimal Unidades { get; set; }
        
        public IngresarUnidades(string producto, decimal unidades, bool aceptaDecimales, bool aceptaNegativos)
        {
            InitializeComponent();
            txtUnidades.AceptaDecimales = aceptaDecimales;
            txtUnidades.Valor = unidades.ToString();
            txtProducto.Texto = producto;
            
            txtUnidades.MinimoValor = aceptaNegativos ? decimal.MinValue : 0.1m;
            txtUnidades.Focus();
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>{txtUnidades});
            if (valido)
            {
                Unidades = txtUnidades.ValorDecimal.GetValueOrDefault();
                if (Unidades == 0)
                {
                    errorProvider1.SetError(txtUnidades, "El valor debe ser distinto de 0");
                    errorProvider1.SetIconPadding(txtUnidades, 2);
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void IngresarUnidades_Shown(object sender, EventArgs e)
        {
            txtUnidades.Select();
        }
    }
}
