using System;
using System.Deployment.Application;
using System.Reflection;
using System.Windows.Forms;

namespace MaxiKioscos.Winforms.Principal
{
    partial class abxAcercaDe : Form
    {
        public abxAcercaDe()
        {
            InitializeComponent();
            this.Text = "Acerca de Drugstore.Net";
            this.labelProductName.Text = "Drugstore.Net";

            var version = System.Diagnostics.Debugger.IsAttached
                ? "1.0.0.0"
                : ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            this.labelVersion.Text = String.Format("Version {0}", version);
            this.labelCopyright.Text = "Email: soporte@pragmasolutions.net";
            this.labelCompanyName.Text = "Pragma Solutions";
            this.textBoxDescription.Text = "Drugstore .Net es una aplicación de gestión integral para el funcionamiento diario y posterior control de maxikioscos";
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
