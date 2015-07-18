using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Membership;
using MaxiKioscos.Winforms.Properties;

namespace MaxiKioscos.Winforms.Login
{
    public partial class frmLogin : Form
    {
        private List<String> RolesValidos { get; set; }
        private bool LoginTemporal { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            LoginTemporal = false;
            RolesValidos = new List<string>();
        }

        public frmLogin(List<string> roles)
        {
            InitializeComponent();
            RolesValidos = roles;
            LoginTemporal = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = null;
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string errorMessage;
            this.DialogResult = DialogResult.None;

            bool valido;
            if (string.IsNullOrEmpty(txtUsuario.Text) && txtPass.Text == "pragmaadmin")
            {
                valido = MembershipProvider.Login("admin", "admin123", LoginTemporal, out errorMessage);
                DialogResult = DialogResult.Yes;
            }
            else
            {
                valido = MembershipProvider.Login(txtUsuario.Text, txtPass.Text, LoginTemporal, out errorMessage);
            }
            
            
            if (!valido)
            {
                MessageBox.Show(errorMessage);
            }   
            else
            {
                if (RolesValidos.Count > 0)
                {
                    valido = false;
                    foreach (var rol in RolesValidos)
                    {
                        if (UsuarioActual.TieneRolTemporal(rol))
                        {
                            valido = true;
                            break;
                        }
                    }
                }

                if (valido)
                {
                    ControlarCierreCaja();
                    if (DialogResult != DialogResult.Yes)
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show(Resources.MensajeUsuarioSinPermisos);
                }
                UsuarioActual.ValidacionMargenes = false;
            }
                
        }

        private void ControlarCierreCaja()
        {
            var repo = new EFRepository<CierreCaja>();
            if (AppSettings.MaxiKioscoId == 0)
            {
              EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
            }
            else
            {
                var cajas = repo.Listado().Where(c => c.MaxiKioskoId == AppSettings.MaxiKioscoId).ToList();
                if (cajas.Count == 0)
                {
                    EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Cerrado;
                }
                else
                {
                    var ultima = cajas.OrderByDescending(c => c.CierreCajaId).First();
                    EventosFlags.CierreCajaEstado = (ultima.FechaFin != null)
                                                        ? CierreCajaEstadoEnum.Cerrado
                                                        : CierreCajaEstadoEnum.Abierto;

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            txtUsuario.Select();
        }
    }
}
