using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Windows.Forms;
using System.Xml.Linq;
using Ionic.Zip;
using log4net;
using log4net.Repository.Hierarchy;
using Maxikioscos.Comun.Helpers;
using MaxiKiosco.Win.Util.Helpers;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Membership;
using MaxiKioscos.Winforms.Properties;
using MaxiKioscos.Winforms.Sincronizacion;
using MaxiKioscos.Winforms.SincronizationService;
using MaxiKioscos.Winforms.UserControls;

namespace MaxiKioscos.Winforms.Exportacion
{
    public enum TipoSincronizacion
    {
        Local,
        WebSecuencial
    }
    
    public partial class frmSincronizacionFeedback : Form
    {
        delegate void RefrescarProgresoDelegate(int valor);
        delegate void FinalizarProgresoDelegate();
        delegate void SetearMaximoProgresoDelegate(int valor);
        delegate void ActualizarMensajeDelegate(string mensaje);

        private readonly ISincronizacionService _sincronizacionService;
        public IMaxiKioscosUow Uow { get; set; }

        private string _zipFileName { get; set; }

        private bool _huboError = false;
        
        public TipoSincronizacion TipoSincronizacion { get; set; }

        //constructor para sincronizacion web
        public frmSincronizacionFeedback(ISincronizacionService sincronizacionService, IMaxiKioscosUow uow, TipoSincronizacion tipo)
        {
            InitializeComponent();
            Uow = uow;
            _sincronizacionService = sincronizacionService;
            TipoSincronizacion = tipo;
        }

        //constructor para sincronizacion local
        public frmSincronizacionFeedback(ISincronizacionService sincronizacionService, IMaxiKioscosUow uow, string zipFileName)
        {
            InitializeComponent();
            Uow = uow;
            _sincronizacionService = sincronizacionService;
            TipoSincronizacion = TipoSincronizacion.Local;
            _zipFileName = zipFileName;
        }


        
        public void RefrescarProgreso(int valor)
        {
            progressBar.Value = valor;
        }

        public void SetearMaximoProgreso(int valor)
        {
            progressBar.Maximum = valor;
        }

        public void FinalizarProgreso()
        {
            progressBar.Value = progressBar.Maximum;
        }

        public void ActualizarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }

        private void frmSincronizacionFeedback_Load(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (TipoSincronizacion)
            {
                case Exportacion.TipoSincronizacion.Local:
                    SincronizacionLocal();
                    break;
                case Exportacion.TipoSincronizacion.WebSecuencial:
                    SincronizacionSecuencial();
                    break;
            }
        }

        private void SincronizacionLocal()
        {
            this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Leyendo archivos...");
            //Limpio la carpeta temporal
            var carpetaTemporal = AppSettings.SincronizacionTemporalFolder;
            DirectoryHelper.LimpiarDirectorio(carpetaTemporal);

            //Extraigo todos los archivos
            var rarFile = new ZipFile(_zipFileName);
            rarFile.ExtractAll(carpetaTemporal);

            //Obtengo los nuevos archivos descomprimidos
            var nombresArchivos = DirectoryHelper.ObtenerArchivos(carpetaTemporal, "xml");

            //Obtengo la ultima secuencia importada desde el principal
            var ultimaSecuencia = Uow.MaxiKioscos.Obtener(AppSettings.MaxiKioscoId).UltimaSecuenciaExportacion ?? 0;
                    
            //Corro los nuevos scripts
            var nuevos = nombresArchivos.Select(a => new ArchivoPrincipalStruct(a))
                        .Where(f => f.Secuencia > ultimaSecuencia).OrderBy(f => f.Secuencia).ToList();

            if (nuevos.Any() && nuevos.FirstOrDefault().Secuencia > ultimaSecuencia + 1)
            {
                _huboError = true;
                MessageBox.Show(String.Format("Error: faltan archivos de exportación. La secuencia mínima esperada es: {0}, y la pasada fue: {1}",
                                ultimaSecuencia + 1, nuevos.FirstOrDefault().Secuencia));
                return;
            }

            this.Invoke(new SetearMaximoProgresoDelegate(SetearMaximoProgreso), nuevos.Count + 1);
            for (var i = 0; i < nuevos.Count(); i++)
            {
                this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), 
                    String.Format("Corriendo script {0} de {1}...", i + 1, nuevos.Count));
                var archivo = nuevos.ElementAt(i);
                string path = Path.Combine(carpetaTemporal, archivo.NombreArchivo);
                XDocument doc = XDocument.Load(path);
                var result = Uow.Exportaciones.ActualizarKiosco(doc.ToString(),
                                                                AppSettings.MaxiKioscoIdentifier,
                                                                archivo.Secuencia);
                if (!result)
                {
                    _huboError = true;
                    break;
                }
                this.Invoke(new RefrescarProgresoDelegate(RefrescarProgreso), i + 1);
            }

            this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando stock...");
            Uow.Stocks.Actualizar();
        }
        
        private void SincronizacionSecuencial()
        {
            try
            {
                //Obtener datos a actualizar desde la base de datos local
                this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando base de datos principal...");
                var secuencias = _sincronizacionService.ObtenerSecuencias(AppSettings.MaxiKioscoIdentifier.ToString());
                var exportacionesLocales = SincronizacionHelper.ObtenerDatosSinExportar(AppSettings.MaxiKioscoIdentifier,
                                                                                       UsuarioActual.UsuarioId,
                                                                                       secuencias.UltimaSecuenciaAcusada);

                var count = 1;
                foreach (var exportacion in exportacionesLocales)
                {
                    this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), 
                        String.Format("Actualizando Servidor ({0} de {1} archivos)", count, exportacionesLocales.Count));
                    var actualizarDatosRequest = new ActualizarDatosRequest
                    {
                        Exportacion = new ExportacionData
                        {
                            Archivo = exportacion.ExportacionArchivo.Archivo,
                            Secuencia = exportacion.Secuencia
                        },
                        MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier
                    };
                    var actualizarResponse = _sincronizacionService.ActualizarDatos(actualizarDatosRequest);
                    if (!actualizarResponse.Exito)
                    {
                        AppSettings.RefreshSettings();
                        _huboError = true;
                        MessageBox.Show(actualizarResponse.MensageError);
                        break;
                    }
                    count++;
                }

                if (!_huboError)
                {
                    var hubieronNuevosDatos = false;
                    int ultimaSecuencia = 0;

                    this.Invoke(new RefrescarProgresoDelegate(RefrescarProgreso), 25);
                    this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Obteniendo datos de servidor...");
                    var request = new ObtenerDatosRequest
                    {
                        MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                        UsuarioIdentifier = UsuarioActual.Usuario.Identifier,
                        UltimaSecuenciaExportacion = secuencias.UltimaSecuenciaExportacion
                    };

                    //Esperar respuesta del server.
                    this.Invoke(new RefrescarProgresoDelegate(RefrescarProgreso), 50);
                    this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando datos de kiosco...");


                    var faltan = 10; //no importa este valor (tiene que ser mayor a cero nomas)

                    while (faltan > 0)
                    {
                        var response = _sincronizacionService.ObtenerDatosSecuencial(request);
                        faltan = response.ArchivosRestantes;

                        if (response.Exportacion != null)
                        {
                            ultimaSecuencia = response.Exportacion.Secuencia;

                            this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje),
                                String.Format("Actualizando datos de kiosco  [Archivos restantes: {0}]", response.ArchivosRestantes));
                            var result = Uow.Exportaciones.ActualizarKiosco(response.Exportacion.Archivo, AppSettings.MaxiKioscoIdentifier, response.Exportacion.Secuencia);
                            request.UltimaSecuenciaExportacion++;
                            hubieronNuevosDatos = true;
                            if (!result)
                            {
                                _huboError = true;
                                AppSettings.RefreshSettings();
                                return;
                            }
                        }
                    }

                    if (hubieronNuevosDatos)
                    {
                        this.Invoke(new RefrescarProgresoDelegate(RefrescarProgreso), 70);
                        this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Informando al servidor...");
                        var acuseRequest = new AcusarExportacionRequest()
                        {
                            MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                            UltimaSecuenciaExportacion = ultimaSecuencia,
                            HoraLocalISO = DateHelper.DateAndTimeToISO(DateTime.Now)
                        };
                        _sincronizacionService.AcusarExportacion(acuseRequest);
                    }


                    this.Invoke(new RefrescarProgresoDelegate(RefrescarProgreso), 85);
                    this.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando stock...");
                    Uow.Stocks.Actualizar();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(Maxikioscos.Comun.Helpers.ExceptionHelper.GetInnerException(ex).Message);
                _huboError = true;
                AppSettings.RefreshSettings();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AppSettings.RefreshSettings();
            btnAceptar.Enabled = true;
            this.Invoke(new FinalizarProgresoDelegate(FinalizarProgreso));
            UsuarioActual.ResetearValoresCacheados();
            if (_huboError)
            {
                lblMensaje.Text = "Sincronización finalizada con errores";
            }
            else
            {
                lblMensaje.Text = "Sincronización finalizada";
                ActualizacionPantallasHelper.ActualizarPantallaVentas();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
