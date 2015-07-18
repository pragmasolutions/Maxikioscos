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
namespace MaxiKioscos.Winforms.Ventas
{
    public partial class frmConfirmarVenta : Form
    {
        private decimal _importe;

        public frmConfirmarVenta(decimal importe)
        {
            InitializeComponent();
            _importe = importe;
        }

        private void txtPagaCon_Cambio()
        {
            var pagacon = txtPagaCon.Valor;
            txtCambio.Valor = pagacon == null 
                                    ? null 
                                    : (pagacon > txtImporte.Valor 
                                                ? pagacon - txtImporte.Valor 
                                                : null);
        }

        private void frmConfirmarVenta_Load(object sender, EventArgs e)
        {
            txtImporte.Valor = _importe;
            txtPagaCon.FocusOnTextbox();
        }

        private void txtPagaCon_TeclaApretada(Keys tecla)
        {
            if (tecla == Keys.Enter)
            {
                this.DialogResult = DialogResult.None;
                btnAceptar.Focus();
            }
        }
    }
}
