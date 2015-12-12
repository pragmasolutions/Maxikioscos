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
using Util;

namespace MaxiKioscos.Winforms.OperacionesCaja
{
    public partial class OperacionCajaEditar : Form
    {
        private EFSimpleRepository<OperacionCaja> _repository;
        public EFSimpleRepository<OperacionCaja> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<OperacionCaja>()); }
        }

        private EFSimpleRepository<MotivoOperacionCaja> _motivoRepository;
        public EFSimpleRepository<MotivoOperacionCaja> MotivoRepository
        {
            get { return _motivoRepository ?? (_motivoRepository = new EFSimpleRepository<MotivoOperacionCaja>()); }
        }

        public string CajaActual
        {
            get
            {return lblDineroEnCaja.Text;}
            set
            { lblDineroEnCaja.Text =value; }
        }

        private OperacionCaja _original { get; set; }

        private int UsuarioId { get; set; }

        public OperacionCajaEditar(int operacionCajaId, int usuarioId, string tipo)
        {
            InitializeComponent();

            UsuarioId = usuarioId;

            if (operacionCajaId > 0)
            {
                lblTitulo.Text = String.Format("Editar {0}", tipo);
                var operacionCaja = Repository.Obtener(o => o.OperacionCajaId == operacionCajaId,
                                                       o => o.MotivoOperacionCaja,
                                                       o => o.UsuarioCreador);
                txtFecha.Texto = operacionCaja.FechaCompleta;
                txtMonto.Valor = Math.Abs(operacionCaja.Monto);
                txtObservaciones.Text = operacionCaja.Observaciones;
                txtTipo.Texto = operacionCaja.MotivoOperacionCaja.Descripcion;
                txtUsuarioCreador.Texto = operacionCaja.UsuarioCreador.NombreUsuario;
                _original = operacionCaja;
            }
            else
            {
                lblTitulo.Text = String.Format("Agregar {0}", tipo);
                txtFecha.Texto = String.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                txtTipo.Texto = tipo;
                var usuario = UsuarioActual.UsuarioTemporal ?? UsuarioActual.Usuario;
                txtUsuarioCreador.Texto = usuario.NombreUsuario;
                MotivoOperacionCaja extraccionMotivo = tipo == "Extracción"
                                         ? MotivoRepository.Obtener(m => m.Descripcion == "Extracción")
                                         : MotivoRepository.Obtener(m => m.Descripcion == "Refuerzo");
                _original = new OperacionCaja()
                                {
                                    CierreCajaId = UsuarioActual.CierreCajaIdActual,
                                    Fecha = DateTime.Now,
                                    MotivoId = extraccionMotivo.MotivoOperacionCajaId,
                                    MotivoOperacionCaja = extraccionMotivo,
                                    UsuarioCreadorId = usuarioId,
                                    Identifier = Guid.NewGuid(),
                                    Desincronizado = true
                                };
            }
            
            btnCancelar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            this.DialogResult = DialogResult.None;
            var valido = Validacion.Validar(errorProvider1, new List<object>{txtMonto});
            if (valido)
            {
                decimal monto = Math.Abs(Convert.ToDecimal(txtMonto.Valor));
                if (!_original.MotivoOperacionCaja.SumarACierreCaja)
                    monto = -monto;
                _original.Monto = monto;
                _original.Observaciones = txtObservaciones.Text;

                if (_original.OperacionCajaId == 0)
                {
                    _original.UsuarioCreadorId = UsuarioId;
                    _original.MotivoOperacionCaja = null;
                    Repository.Agregar(_original);
                }
                else
                {
                    _original.UltimoUsuarioModificacionId = UsuarioId;
                    Repository.Modificar(_original);
                }
                
                Repository.Commit();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void OperacionCajaEditar_Shown(object sender, EventArgs e)
        {
            txtMonto.Select();
        }

        private void OperacionCajaEditar_Load(object sender, EventArgs e)
        {
            var dineroActual = Repository.MaxiKioscosEntities.CierreCajaCantidadDineroActual(UsuarioActual.CierreCajaIdActual).FirstOrDefault();
            lblDineroEnCaja.Text = String.Format("${0}", dineroActual.GetValueOrDefault().ToString("N2"));

        }
    }
}
