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
    public partial class OperacionCajaEliminar : Form
    {
        private EFSimpleRepository<OperacionCaja> _repository;
        public EFSimpleRepository<OperacionCaja> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<OperacionCaja>()); }
        }

        private int OperacionCajaId { get; set; }
        private int UsuarioId { get; set; }

        public OperacionCajaEliminar(int operacionCajaId, int usuarioId)
        {
            InitializeComponent();
            var operacionCaja = Repository.Obtener(o => o.OperacionCajaId == operacionCajaId,
                                                   o => o.MotivoOperacionCaja, o => o.UsuarioCreador);
            txtFecha.Texto = operacionCaja.FechaCompleta;
            txtMonto.Texto = String.Format("${0:f2}", Math.Abs(operacionCaja.Monto));
            txtUsuarioCreador.Texto = operacionCaja.UsuarioCreador.NombreUsuario;
            txtObservaciones.Text = operacionCaja.Observaciones;
            txtTipo.Texto = operacionCaja.MotivoOperacionCaja.Descripcion;
            OperacionCajaId = operacionCajaId;
            UsuarioId = usuarioId;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var operacionCaja = Repository.Obtener(o => o.OperacionCajaId == OperacionCajaId);
            operacionCaja.Eliminado = true;
            operacionCaja.FechaUltimaModificacion = DateTime.Now;
            operacionCaja.UltimoUsuarioModificacionId = UsuarioId;
            Repository.Modificar(operacionCaja);
            Repository.Commit();
        }

        private void OperacionCajaEliminar_Shown(object sender, EventArgs e)
        {
            btnAceptar.Select();
        }
    }
}
