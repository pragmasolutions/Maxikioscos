using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKioscos.Winforms.UserControls
{
    public partial class ConfirmationForm : Form
    {   
        public ConfirmationForm(string mensaje, string botonAceptarTexto, string botonCancelarTexto)
        {
            InitializeComponent();

            btnAceptar.Text = botonAceptarTexto;
            btnCancelar.Text = botonCancelarTexto;
            lblMensaje.Text = mensaje;

            var alturaBotones = 45 + lblMensaje.Size.Height;
            btnAceptar.Location = new Point(btnAceptar.Location.X, alturaBotones);
            btnCancelar.Location = new Point(btnCancelar.Location.X, alturaBotones);
            this.Height = alturaBotones + 92;
        }
    }
}
