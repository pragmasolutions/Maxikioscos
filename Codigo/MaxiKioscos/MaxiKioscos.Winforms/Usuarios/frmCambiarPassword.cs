using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKiosco.Win.Util;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Membership;
using Util;

namespace MaxiKioscos.Winforms.Usuarios
{
    public partial class frmCambiarPassword : Form
        
    {
        public frmCambiarPassword()
        {
            InitializeComponent();
        }

        private void frmCambiarPassword_Load(object sender, EventArgs e)
        {
            pswConfirmar.IgualAControl = pswNueva;
            txtUsuario.Texto = UsuarioActual.Usuario.NombreUsuario;
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = MembershipProvider.VerificarPassword(UsuarioActual.Usuario.NombreUsuario, pswAnterior.Password);

            if (!valido)
            {
                errorProvider1.SetError(pswAnterior, pswAnterior.ErrorMessage);
                errorProvider1.SetIconPadding(pswAnterior, 2);
                this.DialogResult = DialogResult.None;
                return;
            }

            valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      pswAnterior,
                                                      pswNueva,
                                                      pswConfirmar
                                                  });
            if (valido)
            {
                valido = MembershipProvider.ResetPassword(UsuarioActual.UsuarioId, pswNueva.Password);
                if (!valido)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Ha ocurrido un error al cambiar la contraseña");
                }
                else
                {
                    MessageBox.Show("La contraseña se cambió exitosamente");
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void frmCambiarPassword_Shown(object sender, EventArgs e)
        {
            pswAnterior.Select();
        }
    }
}
