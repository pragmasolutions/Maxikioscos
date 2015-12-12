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

namespace MaxiKioscos.Winforms.Gastos
{
    public partial class frmDetalleEliminarGasto : Form
        
    {
        private EFRepository<Costo> _costoRepository;
        public EFRepository<Costo> CostoRepository
        {
            get
            {
                if (_costoRepository == null)
                    _costoRepository = new EFRepository<Costo>();
                return _costoRepository;
            }
        }

        public Costo Costo { get; set; }

        public string Operacion { get; set; }


        public frmDetalleEliminarGasto(int costoId, string operacion)
        {
            InitializeComponent();
            CargarCosto(costoId);

            Operacion = operacion;
            if (operacion == "Eliminar")
            {
                lblTitulo.Text = "Eliminar Gasto";
                this.Text = "Eliminar Gasto";
                btnCancelar.Visible = true;
                btnAceptar.Text = "Aceptar";
            }
            else
            {
                lblTitulo.Text = "Detalle de Gasto";
                this.Text = "Detalle de Gasto";
                btnCancelar.Visible = false;
            }
        }

        private void CargarCosto(int costoId)
        {
            Costo = CostoRepository.Obtener(f => f.CostoId == costoId, f => f.CierreCaja,  f => f.CategoriaCosto);

            txtFecha.Texto = Costo.Fecha.ToShortDateString() + " " + Costo.Fecha.ToShortTimeString();
            txtCategoria.Texto = Costo.CategoriaCosto.Descripcion;
            txtEstado.Texto = Costo.Aprobado ? "Aprobado" : "No aprobado";
            txtMonto.Texto = String.Format("${0}", Costo.Monto.ToString("N2"));
            txtNroComprobante.Texto = Costo.NroComprobante;
            txtObservaciones.Text = Costo.Observaciones;
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Eliminar")
            {
                //verifico si ya tiene productos asociados
                if (Costo.Aprobado)
                {
                    MessageBox.Show("No puede eliminarse esta costo porque ya ha sido aprobado");
                    this.DialogResult = DialogResult.None;
                }
                else if (Costo.CierreCaja.FechaFin != null)
                {
                    MessageBox.Show("No puede eliminarse esta costo porque su caja ya se encuentra cerrada");
                    this.DialogResult = DialogResult.None;
                }
            }
        }
    }
}
