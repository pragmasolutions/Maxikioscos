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

namespace MaxiKioscos.Winforms.OperacionesCaja
{
    public partial class OperacionCajaDetalle : Form
    {
        private EFSimpleRepository<OperacionCaja> _repository;
        public EFSimpleRepository<OperacionCaja> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<OperacionCaja>()); }
        }

        public OperacionCajaDetalle(int operacionCajaId)
        {
            InitializeComponent();
            var operacionCaja = Repository.Obtener(o => o.OperacionCajaId == operacionCajaId,
                                                   o => o.MotivoOperacionCaja, o => o.UsuarioCreador);
            txtFecha.Texto = operacionCaja.FechaCompleta;
            txtMonto.Texto = String.Format("${0:f2}", Math.Abs(operacionCaja.Monto));
            txtUsuarioCreador.Texto = operacionCaja.UsuarioCreador.NombreUsuario;
            txtObservaciones.Text = operacionCaja.Observaciones;
            txtTipo.Texto = operacionCaja.MotivoOperacionCaja.Descripcion;
            btnAceptar.Focus();
        }

        private void OperacionCajaDetalle_Shown(object sender, EventArgs e)
        {
            btnAceptar.Select();
        }
    }
}
