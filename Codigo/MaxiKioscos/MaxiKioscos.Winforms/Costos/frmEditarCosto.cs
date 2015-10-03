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
using Util;

namespace MaxiKioscos.Winforms.Costos
{
    public partial class frmEditarCosto : Form
    {
        private EFSimpleRepository<Costo> _repository;
        public EFSimpleRepository<Costo> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<Costo>()); }
        }

        private EFSimpleRepository<CategoriaCosto> _categoriaRepository;
        public EFSimpleRepository<CategoriaCosto> CateforiaRepository
        {
            get { return _categoriaRepository ?? (_categoriaRepository = new EFSimpleRepository<CategoriaCosto>()); }
        }

        private Costo _original { get; set; }
        
        public frmEditarCosto(int? costoId = null)
        {
            InitializeComponent();

            var categorias = CateforiaRepository.Listado().OrderBy(c => c.Descripcion).ToList();
            ddlCategorias.DataSource = categorias;
            ddlCategorias.ValueMember = "CategoriaCostoId";
            ddlCategorias.DisplayMember = "Descripcion";

            if (costoId != null)
            {
                lblTitulo.Text = "Editar Costo";
                this.Text = "Editar Costo";
                var costo = Repository.Obtener(o => o.CostoId == costoId);
                txtFecha.Texto = costo.Fecha.ToShortDateString() + " " + costo.Fecha.ToShortTimeString();
                txtMonto.Valor = costo.Monto;
                txtObservaciones.Text = costo.Observaciones;
                ddlCategorias.Valor = costo.CategoriaCostoId;
                txtNroComprobante.Valor = costo.NroComprobante;
                _original = costo;
            }
            else
            {
                lblTitulo.Text = "Nuevo Costo";
                this.Text = "Nuevo Costo";
                _original = new Costo()
                                {
                                    CierreCajaId = UsuarioActual.CierreCajaIdActual,
                                    Identifier = Guid.NewGuid(),
                                    Desincronizado = true
                                };
                lblFecha.Visible = false;
                txtFecha.Visible = false;
            }
            
            btnCancelar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            this.DialogResult = DialogResult.None;
            var valido = Validacion.Validar(errorProvider1, new List<object>{txtMonto, ddlCategorias});
            if (valido)
            {
                decimal monto = Convert.ToDecimal(txtMonto.Valor);
                _original.Monto = monto;
                _original.Observaciones = txtObservaciones.Text;
                _original.CategoriaCostoId = ddlCategorias.Valor;
                _original.NroComprobante = txtNroComprobante.Valor;

                if (_original.CostoId == 0)
                {
                    _original.Fecha = DateTime.Now;
                    Repository.Agregar(_original);
                }
                else
                {
                    Repository.Modificar(_original);
                    _original.Desincronizado = true;
                }
                
                Repository.Commit();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmCostoEditar_Shown(object sender, EventArgs e)
        {
            txtMonto.Select();
        }
    }
}
