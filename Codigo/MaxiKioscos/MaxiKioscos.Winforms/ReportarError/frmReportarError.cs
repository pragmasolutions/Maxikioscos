using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.NotificationService;
using Util;

namespace MaxiKioscos.Winforms.ReportarError
{
    public partial class frmReportarError : Form
    {
        public frmReportarError()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtDescripcion,
                                                      txtEmail,
                                                      txtTitulo
                                                  });
            if (valido)
            {
                var request = new ReportarErrorRequest
                                 {
                                     Nombre = UsuarioActual.Usuario.Nombre,
                                     Apellido = UsuarioActual.Usuario.Apellido,
                                     Email = txtEmail.Text.Trim(),
                                     Mensaje = txtDescripcion.Text,
                                     Titulo = txtTitulo.Text,
                                     WebUrl = AppSettings.WebBaseUrl,
                                     UsuarioIdentifier = UsuarioActual.Usuario.Identifier
                                 };
                var service = new NotificacionServiceClient();
                var result = service.ReportarErrorAsync(request);
                if (result.Result)
                    MessageBox.Show("El error se ha reportado correctamente. Recibirá un mail para hacer el seguimiento en los próximos minutos");
                else
                {
                    MessageBox.Show("Ha ocurrido un error al reportar el error. Verifique su conexión a internet e inténtelo nuevamente");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void frmReportarError_Shown(object sender, EventArgs e)
        {
            txtEmail.Select();
        }

    }
}
