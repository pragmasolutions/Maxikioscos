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

namespace MaxiKioscos.Winforms.Marcas
{
    public partial class frmDetalleMarca : Form
        
    {
        private EFRepository<Marca> _repository;
        public EFRepository<Marca> Repository
        {
            get { return _repository ?? (_repository = new EFRepository<Marca>()); }
        }

        public Marca Marca { get; set; }


        public frmDetalleMarca(int marcaId)
        {
            InitializeComponent();
            Marca = Repository.Obtener(m => m.MarcaId == marcaId);

            txtDescripcion.Texto = Marca.Descripcion;
        }
    }
}
