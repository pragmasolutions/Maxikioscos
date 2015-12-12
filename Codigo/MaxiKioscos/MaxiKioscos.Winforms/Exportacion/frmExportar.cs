using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Ionic.Zip;
using MaxiKiosco.Win.Util;
using MaxiKiosco.Win.Util.Helpers;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Winforms.Configuracion;
using Util;

namespace MaxiKioscos.Winforms.Exportacion
{
    public partial class frmExportar : Form
    {
        private ExportacionRepository _exportacionRepository;
        public ExportacionRepository ExportacionRepository
        {
            get { return _exportacionRepository ?? (_exportacionRepository = new ExportacionRepository()); }
        }
        
        public frmExportar()
        {
            InitializeComponent();
        }

        private void frmExportar_Load(object sender, EventArgs e)
        {
            dtpFecha.FechaMaxima = DateTime.Now;
        }

        private void btnSeleccionarDestino_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestino.Text = String.Format(@"{0}", folderBrowserDialog1.SelectedPath);
            }
        }

        private void radOpcion_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton) sender;
            if (radio.Checked)
                dtpFecha.Enabled = radio.Name == "radDesdeFecha";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDestino.Text))
            {
                MessageBox.Show("Debe seleccionar una carpeta de destino.");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (ExportacionRepository.PuedeExportarKiosco())
            {
                ExportacionRepository.ExportarKiosco(AppSettings.MaxiKioscoIdentifier, 
                                                     UsuarioActual.UsuarioId);
            }

            //Obtengo los archivos
            List<Entidades.Exportacion> exportaciones = ObtenerExportaciones();

            if (exportaciones.Any())
            {
                CrearArchivosEnCarpetaTemporal(exportaciones);
                var fileName = String.Format("{0} [{1}].zip", Guid.NewGuid(), DateTime.Now.ToString("dd-MM-yyyy"));
                var pathDestino = Path.Combine(txtDestino.Text, fileName);
                var nombresArchivos = exportaciones.Select(exp => exp.ArmarNombreParaKiosco(AppSettings.MaxiKioscoIdentifier)).ToList();
                var paths = nombresArchivos.Select(n => Path.Combine(AppSettings.SincronizacionTemporalFolder, n)).ToList();
                CrearZip(pathDestino, paths);
                MessageBox.Show("Los datos han sido exportados correctamente");
            }
            else
            {
                MessageBox.Show("No existen datos por exportar");
            }
            
        }

        private void CrearArchivosEnCarpetaTemporal(IEnumerable<Entidades.Exportacion> exportaciones)
        {
            var carpetaTemporal = AppSettings.SincronizacionTemporalFolder;
            DirectoryHelper.LimpiarDirectorio(carpetaTemporal);

            foreach (var exp in exportaciones)
            {
                var xml = new XmlDocument();
                xml.LoadXml(exp.ExportacionArchivo.Archivo);

                xml.Save(Path.Combine(carpetaTemporal, 
                    exp.ArmarNombreParaKiosco(AppSettings.MaxiKioscoIdentifier)));
            }
            
        }

        private List<Entidades.Exportacion> ObtenerExportaciones()
        {
            var exportaciones = new List<Entidades.Exportacion>();
            var ultimaAcusada = AppSettings.Maxikiosco.UltimaSecuenciaAcusada;


            if (radDesincronizados.Checked)
            {
                exportaciones = ExportacionRepository.ListadoConArchivos(exp => ultimaAcusada == null
                                                        || exp.Secuencia > ultimaAcusada).ToList();
            }
            if (radDesdeFecha.Checked)
            {
                var fecha = dtpFecha.Fecha;
                exportaciones = ExportacionRepository.ListadoConArchivos(exp =>
                            ultimaAcusada == null ||
                            (exp.Fecha > fecha
                            || exp.Secuencia > ultimaAcusada)).ToList();
            }
            if (radCompleta.Checked)
            {
                exportaciones = ExportacionRepository.Listado(exp => exp.ExportacionArchivo).ToList();
            }
            return exportaciones;
        }

        public bool CrearZip(string pathDestino, IList<string> pathsArchivos)
        {
            bool zipped = false;

            if (pathsArchivos.Count > 0)
            {
                using (var loanZip = new ZipFile())
                {
                    //var filePath = Path.Combine()
                    loanZip.AddFiles(pathsArchivos, false, "");
                    loanZip.Save(pathDestino);
                    zipped = true;
                }
            }

            return zipped;
        }

        private void frmExportar_Shown(object sender, EventArgs e)
        {
            radDesincronizados.Select();
        }
    }
}
