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
using MaxiKioscos.Winforms.Properties;
using Util;

namespace MaxiKioscos.Winforms.CierreCajas
{
    public partial class CerrarCaja : Form
    {
        private bool _controlarMargenes;
        public decimal CajaFinal { get; set; }
        public int CierreCajaId { get; set; }

        private CierreCajaRepository _repository;
        public CierreCajaRepository Repository
        {
            get { return _repository ?? (_repository = new CierreCajaRepository()); }
        }


        private EFSimpleRepository<RecuentoBillete> _recuentoBilleteRepository;
        public EFSimpleRepository<RecuentoBillete> RecuentoBilleteRepository
        {
            get { return _recuentoBilleteRepository ?? (_recuentoBilleteRepository = new EFSimpleRepository<RecuentoBillete>()); }
        }

        public CerrarCaja(bool controlarMargenes)
        {
            _controlarMargenes = controlarMargenes;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (ValidarMargenes())
            {
                CompletarValoresBilletes();
                var validateGroup = !chxDetallar.Checked
                                        ? new List<object> { txtCajaFinal }
                                        : new List<object>
                                              {
                                                  txtCajaFinal,
                                                  txt100,
                                                  txt50,
                                                  txt20,
                                                  txt10,
                                                  txt5,
                                                  txt2
                                              };

                var valido = Validacion.Validar(errorProvider1, validateGroup);
                if (valido)
                {
                    if (chxDetallar.Checked)
                    {
                        var montosIguales = CheckearMontosIguales();
                        if (!montosIguales)
                        {
                            errorProvider1.SetError(chxDetallar, "El monto calculado no coincide con el ingresado");
                            errorProvider1.SetIconPadding(chxDetallar, 2);
                            DialogResult = DialogResult.None;
                            return;
                        }
                        var billetes = ObtenerBilletes();
                        foreach (var recuentoBillete in billetes)
                        {
                            recuentoBillete.Identifier = Guid.NewGuid();
                            recuentoBillete.CierreCajaId = UsuarioActual.CierreCajaIdActual;
                            recuentoBillete.Desincronizado = true;
                            RecuentoBilleteRepository.Agregar(recuentoBillete);
                        }
                        RecuentoBilleteRepository.Commit();
                    }
                    this.CajaFinal = Convert.ToDecimal(txtCajaFinal.Valor);
                    CierreCajaId =
                        Repository.MaxiKioscosEntities.CierreCajaCerrar(AppSettings.MaxiKioscoId, this.CajaFinal).
                            FirstOrDefault().GetValueOrDefault();
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                this.Close();
            }
        }

        private void CompletarValoresBilletes()
        {
            if (chxDetallar.Checked)
            {
                if (string.IsNullOrEmpty(txt2.Valor)) txt2.Valor = "0";
                if (string.IsNullOrEmpty(txt5.Valor)) txt5.Valor = "0";
                if (string.IsNullOrEmpty(txt10.Valor)) txt10.Valor = "0";
                if (string.IsNullOrEmpty(txt20.Valor)) txt20.Valor = "0";
                if (string.IsNullOrEmpty(txt50.Valor)) txt50.Valor = "0";
                if (string.IsNullOrEmpty(txt100.Valor)) txt100.Valor = "0";
            }
        }

        private bool ValidarMargenes()
        {
            bool result = true;

            if (!_controlarMargenes)
            {
                return result;
            }

            if (!UsuarioActual.ValidacionMargenes)
            {
                var dineroActual = Repository.MaxiKioscosEntities.CierreCajaCantidadDineroActual(UsuarioActual.CierreCajaIdActual).FirstOrDefault();

                decimal margenInferior = UsuarioActual.Cuenta.MargenInferiorCierreCajaAceptable * (-1);
                decimal diferenciaDeCaja = Convert.ToDecimal(txtCajaFinal.Valor) - dineroActual.GetValueOrDefault();
                if (margenInferior > diferenciaDeCaja || UsuarioActual.Cuenta.MargenSuperiorCierreCajaAceptable < diferenciaDeCaja)
                {
                    UsuarioActual.ValidacionMargenes = true;
                    MessageBox.Show(Resources.CierreCajaMensajeMargen, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
            }
            return result;
        }

        private List<RecuentoBillete> ObtenerBilletes()
        {
            return new List<RecuentoBillete>()
                       {
                           new RecuentoBillete(){ BilleteId = 1, Cantidad = int.Parse(txt100.Valor)},
                           new RecuentoBillete(){ BilleteId = 2, Cantidad = int.Parse(txt50.Valor)},
                           new RecuentoBillete(){ BilleteId = 3, Cantidad = int.Parse(txt20.Valor)},
                           new RecuentoBillete(){ BilleteId = 4, Cantidad = int.Parse(txt10.Valor)},
                           new RecuentoBillete(){ BilleteId = 5, Cantidad = int.Parse(txt5.Valor)},
                           new RecuentoBillete(){ BilleteId = 6, Cantidad = int.Parse(txt2.Valor)},
                       };
        }

        private bool CheckearMontosIguales()
        {
            var totalEnBilletes = int.Parse(txt100.Valor) * 100
                                  + int.Parse(txt50.Valor) * 50
                                  + int.Parse(txt20.Valor) * 20
                                  + int.Parse(txt10.Valor) * 10
                                  + int.Parse(txt5.Valor) * 5
                                  + int.Parse(txt2.Valor) * 2;
            var caja = Convert.ToInt32(txtCajaFinal.Valor);
            return caja == totalEnBilletes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chxDetallar_CheckedChanged(object sender, EventArgs e)
        {
            if (chxDetallar.Checked)
            {
                txt100.Enabled = true;
                txt50.Enabled = true;
                txt20.Enabled = true;
                txt10.Enabled = true;
                txt5.Enabled = true;
                txt2.Enabled = true;
            }
            else
            {
                txt100.Valor = null;
                txt50.Valor = null;
                txt20.Valor = null;
                txt10.Valor = null;
                txt5.Valor = null;
                txt2.Valor = null;

                txt100.Enabled = false;
                txt50.Enabled = false;
                txt20.Enabled = false;
                txt10.Enabled = false;
                txt5.Enabled = false;
                txt2.Enabled = false;
            }
        }

        private void CerrarCaja_Shown(object sender, EventArgs e)
        {
            txtCajaFinal.Select();
        }

        private void CerrarCaja_Load(object sender, EventArgs e)
        {
            txtCajaFinal.Select();
        }
    }
}
