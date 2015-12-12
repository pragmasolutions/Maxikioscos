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
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Winforms.Configuracion;
namespace MaxiKioscos.Winforms.RetirosPersonales
{
    public partial class frmConfirmarRetiroPersonal : Form
    {
        private decimal _importe;

        public frmConfirmarRetiroPersonal(decimal importe)
        {
            InitializeComponent();
            _importe = importe;
        }

        private void frmConfirmarRetiroPersonal_Load(object sender, EventArgs e)
        {
            txtImporte.Valor = _importe;
        }
    }
}
