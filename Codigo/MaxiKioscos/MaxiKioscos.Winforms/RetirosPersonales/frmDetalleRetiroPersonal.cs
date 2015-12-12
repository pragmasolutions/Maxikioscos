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
using MaxiKioscos.Winforms.Configuracion;

namespace MaxiKioscos.Winforms.RetirosPersonales
{
    public partial class frmDetalleRetiroPersonal : Form
    {
        private EFSimpleRepository<RetiroPersonal> _repository;
        public EFSimpleRepository<RetiroPersonal> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<RetiroPersonal>()); }
        }

        public frmDetalleRetiroPersonal(int retiroPersonalId)
        {
            InitializeComponent();
            var retiroPersonal = Repository.Obtener(v => v.RetiroPersonalId == retiroPersonalId,
                                           v => v.RetiroPersonalProductos,
                                           v => v.RetiroPersonalProductos.Select(vp => vp.Producto),
                                           v => v.RetiroPersonalProductos.Select(vp => vp.Producto.CodigosProductos));
                                                 
            txtFecha.Texto = String.Format("{0} {1}", 
                                            retiroPersonal.FechaRetiroPersonal.ToShortDateString(),
                                            retiroPersonal.FechaRetiroPersonal.ToShortTimeString());
            txtImporteTotal.Texto = String.Format("${0:f2}", retiroPersonal.ImporteTotal);
            dgvRetiroPersonalProductos.DataSource = retiroPersonal.RetiroPersonalProductos.ToList();
            dgvRetiroPersonalProductos.Columns[4].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            btnAceptar.Focus();
        }

        private void frmDetalleRetiroPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }
    }
}
