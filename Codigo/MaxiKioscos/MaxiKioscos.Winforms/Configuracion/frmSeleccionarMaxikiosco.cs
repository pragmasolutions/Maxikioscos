using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Sincronizacion;
using MaxiKioscos.Winforms.SincronizationService;

namespace MaxiKioscos.Winforms.Configuracion
{
    public partial class frmSeleccionarMaxikiosco : Form
    {
        public ISincronizacionService _sincronizacionService { get; set; }
        public IMaxiKioscosUow _uow { get; set; }
        public List<MaxiKioscoData> _kioscos { get; set; }
        
        

        #region Inicializar
        public frmSeleccionarMaxikiosco(ISincronizacionService service, IMaxiKioscosUow uow)
            : base()
        {
            InitializeComponent();
            _sincronizacionService = service;
            _uow = uow;
        }
        #endregion

        private void frmSeleccionarMaxikiosco_Load(object sender, EventArgs e)
        {
            try
            {
                var response = _sincronizacionService.InicializarKiosco();
                _kioscos = response.Kioscos.ToList();
                dgvListado.DataSource = _kioscos.Select(k => new MaxiKioscoGridStruct
                {
                    Nombre = k.Nombre,
                    Asignado = k.Asignado ? "SI" : "NO",
                    Identifier = k.Guid
                }).ToList();
                dgvListado.ClearSelection();
                dgvListado.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvListado.SelectedRows[0];
                var asignado = row.Cells[2].Value.ToString().Equals("SI");
                if (asignado)
                {
                    MessageBox.Show("El maxikiosco seleccionado ya ha sido seleccionado en otro kiosco");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    //Asigno mi appsetting
                    var identifier = Guid.Parse(row.Cells[0].Value.ToString());
                    AppSettings.MaxiKioscoIdentifier = identifier;

                    //Si tengo internet lo notifico la asignación al servidor
                    try
                    {
                        var response = _sincronizacionService.MarcarKioscoComoAsignado(identifier.ToString());
                        var maxi = new Entidades.MaxiKiosco()
                                   {
                                       Abreviacion = response.Abreviacion,
                                       Asignado = true,
                                       CuentaId = 1,
                                       Direccion = response.Direccion,
                                       EstaOnLine = true,
                                       Nombre = response.Nombre,
                                       Telefono = response.Telefono,
                                       Identifier = response.Identifier
                                   };
                        _uow.MaxiKioscos.Agregar(maxi);
                        _uow.Commit();
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un maxikiosco");
                DialogResult = DialogResult.None;
            }
        }

    }
}
