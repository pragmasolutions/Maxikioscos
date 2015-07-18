using System;
using System.Windows.Forms;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Winforms.IoC;

namespace MaxiKioscos.Winforms.Configuracion
{
    public partial class frmConfiguracion : Form
    {
        private IMaxiKioscosUow Uow { get; set; }

        public frmConfiguracion()
        {
            InitializeComponent();
            Uow = CompositionRoot.Resolve<IMaxiKioscosUow>();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ////Guardar las settings.
            var maxikisco = Uow.MaxiKioscos.Obtener(AppSettings.MaxiKioscoId);
            maxikisco.EstaOnLine = rbOnLine.Checked;
            Uow.Commit();
            AppSettings.RefreshSettings();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            var maxikisco = Uow.MaxiKioscos.Obtener(AppSettings.MaxiKioscoId);
            rbOnLine.Checked = maxikisco.EstaOnLine;
            rbOffLine.Checked = !maxikisco.EstaOnLine;
        }

        private void frmConfiguracion_Shown(object sender, EventArgs e)
        {
            rbOnLine.Select();
        }
    }
}
