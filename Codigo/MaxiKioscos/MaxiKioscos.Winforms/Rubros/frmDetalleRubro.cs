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

namespace MaxiKioscos.Winforms.Rubros
{
    public partial class frmDetalleRubro : Form
        
    {
        private EFRepository<Rubro> _repository;
        public EFRepository<Rubro> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Rubro>()); }
        }

        public Rubro Rubro { get; set; }


        public frmDetalleRubro(int rubroId)
        {
            InitializeComponent();
            Rubro = Repository.Obtener(r => r.RubroId == rubroId, r => r.ExcepcionRubros);

            txtDescripcion.Texto = Rubro.Descripcion;

            dgvExcepciones.Columns[3].DefaultCellStyle.Format = AppSettings.CurrencyColumnFormat;
            dgvExcepciones.DataSource = Rubro.ExcepcionRubros.ToList();
        }
    }
}
