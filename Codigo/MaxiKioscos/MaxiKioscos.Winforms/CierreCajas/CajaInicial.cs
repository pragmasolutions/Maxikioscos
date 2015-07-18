using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.CierreCajas
{
    public partial class CajaInicial : Form
    {
        private EFRepository<CierreCaja> _repository;
        public EFRepository<CierreCaja> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<CierreCaja>()); }
        }
        
        public CajaInicial()
        {
            InitializeComponent();
        }

        private void CajaInicial_Load(object sender, EventArgs e)
        {
            txtUsuario.Texto = UsuarioActual.Usuario.NombreUsuario;
            txtCajaInicial.Select();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            var valido = Validacion.Validar(errorProvider1, new List<object>
                                                  {
                                                      txtCajaInicial
                                                  });
            if (valido)
            {
                var caja = new CierreCaja
                               {
                                   CajaInicial = Convert.ToDecimal(txtCajaInicial.Valor),
                                   FechaInicio = DateTime.Now,
                                   Identifier = Guid.NewGuid(),
                                   MaxiKioskoId = AppSettings.MaxiKioscoId,
                                   UsuarioId = UsuarioActual.UsuarioId
                               };
                
                Repository.Agregar(caja);
                Repository.Commit();
                UsuarioActual.CierreCajaIdActual = caja.CierreCajaId;
                EventosFlags.CierreCajaEstado = CierreCajaEstadoEnum.Abierto;
                MessageBox.Show("La caja se ha abierto correctamente");
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void CajaInicial_Shown(object sender, EventArgs e)
        {
            txtCajaInicial.Select();
        }
    }
}
