using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKioscos.Winforms.Ventas
{
    public partial class frmModificarCantidad : Form
    {
        private string producto = "";
        private int cantidad ;
        public delegate void CambioEventHandler(int cantidad);
        private CambioEventHandler CambioEvent;

        public event CambioEventHandler Cambio
        {
            add
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Combine(CambioEvent, value);
            }
            remove
            {
                CambioEvent = (CambioEventHandler)System.Delegate.Remove(CambioEvent, value);
            }
        }

        public frmModificarCantidad(string productoDescripcion, int productoCantidad)
        {
            InitializeComponent();
            producto = productoDescripcion;
            cantidad = productoCantidad;
        }

        private void frmModificarCantidad_Load(object sender, EventArgs e)
        {
            lblProducto.Text = producto;
            txtCantidad.Valor = cantidad.ToString();
            txtCantidad.Focus();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                 case Keys.Escape:
                    this.Close();break;
                case Keys.Enter:
                     if (Validar())
                    {
                        CambioEvent(Convert.ToInt32(txtCantidad.Valor));
                    }
                     this.Close();
                    break;
            }
        }

        private void frmModificarCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close(); break;
                case Keys.Enter:
                    if (Validar())
                    {
                        CambioEvent(Convert.ToInt32(txtCantidad.Valor));
                    }
                    this.Close();
                    break;
            }
        }
        private bool Validar()
        {
            if (txtCantidad.Valor.Length == 0 || int.Parse(txtCantidad.Valor) == 0)
            {
                errorProvider.SetError(txtCantidad,"Debe completar con un valor mayor a cero.");
                errorProvider.SetIconPadding(txtCantidad, 2);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmModificarCantidad_Shown(object sender, EventArgs e)
        {
            txtCantidad.Select();
        }
    }
}
