using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKiosco.Win.Util.Controles
{
    public partial class ucTextBoxGris : UserControl
    {
        public ucTextBoxGris()
        {
            InitializeComponent();
        }

        public string Texto
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }
}
