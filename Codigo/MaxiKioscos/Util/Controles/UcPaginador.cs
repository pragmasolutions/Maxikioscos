using System;
using System.Windows.Forms;

namespace MaxiKioscos.Winforms.Controles
{
    public partial class UcPaginador : UserControl
    {
        #region Propiedades

        public int? PageTotal
        {
            get
            {
                if (string.IsNullOrEmpty(txtTotalPaginas.Text))
                    return null;
                return Convert.ToInt32(txtTotalPaginas.Text);
            }
            set { txtTotalPaginas.Text = value.ToString(); }
        }

        public int CurrentPage
        {
            get
            {
                if (string.IsNullOrEmpty(txtPaginaActual.Text))
                    return 1;
                return Convert.ToInt32(txtPaginaActual.Text);
            }
            set { txtPaginaActual.Text = value.ToString(); }
        }

        public int PageSize
        {
            get
            {
                if (string.IsNullOrEmpty(cmbPageSize.Text))
                    return 10;
                return Convert.ToInt32(cmbPageSize.Text);
            }
            set { cmbPageSize.Text = value.ToString(); }
        }

        public Button Next
        {
            get { return btnSiguiente; }
        }

        public Button Previous
        {
            get { return btnAnterior; }
        }

        public Button First
        {
            get { return btnPrimero; }
        }

        public Button Last
        {
            get { return btnUltimo; }
        }

        public ComboBox PageSizeControl
        {
            get { return cmbPageSize; }
        }

        public bool PuedeAvanzar
        {
            get { return PageTotal > CurrentPage; }
        }
        
        public bool PuedeRetroceder
        {
            get { return CurrentPage > 1; }
        }

        #endregion

        public UcPaginador()
        {
            InitializeComponent();
        }

        public void ActualizarBotones(int totalRegistros)
        {
            var diferencia = Decimal.Parse(totalRegistros.ToString()) / Decimal.Parse(PageSize.ToString());
            PageTotal = Convert.ToInt32(Math.Ceiling(diferencia));
            Previous.Enabled = CurrentPage != 1;
            First.Enabled = CurrentPage != 1;
            Next.Enabled = CurrentPage < PageTotal;
            Last.Enabled = CurrentPage < PageTotal;
        }
    }

}
