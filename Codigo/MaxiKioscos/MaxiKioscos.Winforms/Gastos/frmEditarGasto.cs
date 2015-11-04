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

namespace MaxiKioscos.Winforms.Gastos
{
    public partial class frmEditarGasto : Form
    {
        private EFSimpleRepository<Costo> _repository;
        public EFSimpleRepository<Costo> Repository
        {
            get { return _repository ?? (_repository = new EFSimpleRepository<Costo>()); }
        }

        private EFSimpleRepository<CategoriaCosto> _categoriaRepository;
        public EFSimpleRepository<CategoriaCosto> CategoriaRepository
        {
            get { return _categoriaRepository ?? (_categoriaRepository = new EFSimpleRepository<CategoriaCosto>()); }
        }

        private Costo _original { get; set; }
        
        public frmEditarGasto(int? costoId = null)
        {
            InitializeComponent();
            _original = Repository.Obtener(o => o.CostoId == costoId, x => x.CategoriaCosto);
            CargarCategorias(costoId == null);

            if (costoId != null)
            {
                lblTitulo.Text = "Editar Gasto";
                this.Text = "Editar Gasto";

                txtFecha.Texto = _original.Fecha.ToShortDateString() + " " + _original.Fecha.ToShortTimeString();
                txtMonto.Valor = _original.Monto;
                txtObservaciones.Text = _original.Observaciones;
                ddlCategorias.SelectedValue = _original.CategoriaCosto.PadreId.Value;
                ddlSubCategorias.SelectedValue = _original.CategoriaCostoId;
                txtNroComprobante.Valor = _original.NroComprobante;
            }
            else
            {
                lblTitulo.Text = "Nuevo Gasto";
                this.Text = "Nuevo Gasto";
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

        private void CargarCategorias(bool creando)
        {
            var padres = CategoriaRepository.Listado()
                                    .Where(c => !c.Eliminado && !c.OcultarEnDesktop
                                            && c.PadreId == null)
                                    .OrderBy(c => c.Descripcion).ToList();
            padres.Insert(0, new CategoriaCosto() { Descripcion = "Seleccione Categoría" });
            ddlCategorias.ValueMember = "CategoriaCostoId";
            ddlCategorias.DisplayMember = "Descripcion";
            ddlCategorias.DataSource = padres;
            

            var hijas = creando
                ? new List<CategoriaCosto>() { new CategoriaCosto() {  Descripcion = "Seleccione Sub-Categoría"} }
                : CategoriaRepository.Listado().Where(x => x.PadreId == _original.CategoriaCosto.PadreId
                                                        && !x.OcultarEnDesktop).ToList();
            ddlSubCategorias.ValueMember = "CategoriaCostoId";
            ddlSubCategorias.DisplayMember = "Descripcion";
            ddlSubCategorias.DataSource = hijas;
            
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
                _original.CategoriaCostoId = (int)ddlSubCategorias.SelectedValue;
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

        private void ddlCategorias_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            var padreId = (int)ddlCategorias.SelectedValue;
            var hijas = CategoriaRepository.Listado().Where(x => x.PadreId == padreId && !x.OcultarEnDesktop).ToList();
            hijas.Insert(0, new CategoriaCosto(){ Descripcion = "Seleccione Sub-Categoría"});
            ddlSubCategorias.DataSource = hijas;
            ddlSubCategorias.SelectedIndex = 0;
        }
    }
}
