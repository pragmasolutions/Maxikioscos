using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Ionic.Zip;
using MaxiKiosco.Win.Util.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.DataStruct;
using MaxiKioscos.Winforms.Exportacion;
using MaxiKioscos.Winforms.Properties;
using MaxiKioscos.Winforms.SincronizationService;
using MaxiKioscos.Winforms.UserControls;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Maxikioscos.Comun.Helpers;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Helpers;
using MaxiKioscos.Winforms.Principal;

namespace MaxiKioscos.Winforms.Sincronizacion
{
    public class SincronizacionManager : ISincronizacionManager
    {
        public static bool Sincronizando = false;
        private readonly ISincronizacionService _sincronizacionService;
        private IMaxiKioscosUow Uow { get; set; }
        private mdiPrincipal CurrentForm { get; set; }
        private ToolStripStatusLabel TssProgreso { get; set; }
        private bool _huboError = false;
        private static Timer Timer { get; set; }
        private static Timer SyncTimer { get; set; }

        public delegate void SyncExitosaEventHandler();
        private SyncExitosaEventHandler SyncExitosaEvent;

        public event SyncExitosaEventHandler SyncExitosa
        {
            add
            {
                SyncExitosaEvent = (SyncExitosaEventHandler)System.Delegate.Combine(SyncExitosaEvent, value);
            }
            remove
            {
                SyncExitosaEvent = (SyncExitosaEventHandler)System.Delegate.Remove(SyncExitosaEvent, value);
            }
        }

        public SincronizacionManager(ISincronizacionService sincronizacionService, IMaxiKioscosUow uow)
        {
            Uow = uow;
            _sincronizacionService = sincronizacionService;
        }
        
        public async Task SincronizacionSecuencial()
        {
            if (!Sincronizando)
            {
                Sincronizando = true;
                var dialog = new frmSincronizacionFeedback(_sincronizacionService, Uow, TipoSincronizacion.WebSecuencial);
                dialog.ShowDialog();
            }
            else
                MessageBox.Show(CurrentForm, "Debe esperar a que finalice el proceso actual de sincronización");
        }

        public void ActualizarKioscoDesdeArchivo(OpenFileDialog openFileDialogSincronizacion)
        {
            //Abrimos dialogo para buscar el archivo de actualizacion.
            var openFileResult = openFileDialogSincronizacion.ShowDialog();

            if (openFileResult == DialogResult.OK)
            {
                //Creamos ventana de confirmacion de actualizacion.
                var confirmation =
                    new ConfirmationForm(Resources.SincronizacionConfirmacionActualizarDesdeArchivo,
                                         Resources.TextoAceptar, Resources.TextoCancelar);

                var confirmationResult = confirmation.ShowDialog();

                if (confirmationResult == DialogResult.OK)
                {
                    var dialog = new frmSincronizacionFeedback(_sincronizacionService, Uow, openFileDialogSincronizacion.FileName);
                    dialog.ShowDialog();
                }
            }
        }

        #region ISincronizacionManager Members

        
        public async Task InicializarKiosco()
        {
            new frmSeleccionarMaxikiosco(_sincronizacionService, Uow).ShowDialog();
        }

        public async Task SincronizarEnSegundoPlano(mdiPrincipal form, BackgroundWorker worker, 
                                                    ToolStripStatusLabel label)
        {
            if (!Sincronizando)
            {
                Sincronizando = true;
                if (worker.IsBusy != true)
                {
                    CurrentForm = form;
                    TssProgreso = label;
                    
                    worker = new BackgroundWorker();
                    worker.DoWork += WorkerOnDoWork;
                    worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
                    worker.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show(CurrentForm, "Debe esperar a que finalice el proceso actual de sincronización");
        }

        delegate void ActualizarMensajeDelegate(string mensaje);
        public void ActualizarMensaje(string mensaje)
        {
            TssProgreso.Text = mensaje;
        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            WorkActualizacionSecuencial();
        }

        private void WorkActualizacionSecuencial()
        {
            try
            {
                _huboError = false;

                CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando base de datos principal...");
                var secuencias = _sincronizacionService.ObtenerSecuencias(AppSettings.MaxiKioscoIdentifier.ToString());
                var exportacionesLocales = SincronizacionHelper.ObtenerDatosSinExportar(AppSettings.MaxiKioscoIdentifier,
                                                                                       UsuarioActual.UsuarioId,
                                                                                       secuencias.UltimaSecuenciaAcusada);

                var count = 1;
                foreach (var exportacion in exportacionesLocales)
                {
                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje),
                        String.Format("Actualizando Servidor ({0} de {1} archivos)", count, exportacionesLocales.Count));
                    var actualizarDatosRequest = new ActualizarDatosRequest
                    {
                        Exportaciones = new List<ExportacionData> { 
                            new ExportacionData
                            {
                                Archivo = exportacion.ExportacionArchivo.Archivo,
                                Secuencia = exportacion.Secuencia
                            }
                        }.ToArray(),
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

                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Obteniendo datos de servidor...");
                    var request = new ObtenerDatosRequest
                    {
                        MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                        UsuarioIdentifier = UsuarioActual.Usuario.Identifier,
                        UltimaSecuenciaExportacion = secuencias.UltimaSecuenciaExportacion
                    };

                    //Esperar respuesta del server.
                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando datos de kiosco...");


                    var faltan = 10; //no importa este valor (tiene que ser mayor a cero nomas)

                    _sincronizacionService.ForzarArmadoDeArchivoExportacion(UsuarioActual.Usuario.Identifier);
                    while (faltan > 0)
                    {
                        var response = _sincronizacionService.ObtenerDatosSecuencial(request);
                        faltan = response.ArchivosRestantes;

                        if (response.Exportacion != null)
                        {
                            ultimaSecuencia = response.Exportacion.Secuencia;

                            CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje),
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
                        CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Informando al servidor...");
                        var acuseRequest = new AcusarExportacionRequest()
                        {
                            MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                            UltimaSecuenciaExportacion = ultimaSecuencia,
                            HoraLocalISO = DateHelper.DateAndTimeToISO(DateTime.Now)
                        };
                        _sincronizacionService.AcusarExportacion(acuseRequest);
                    }

                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando stock...");
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

        private void WorkActualizacionMasiva()
        {
            try
            {
                _huboError = false;
                //Obtener datos a actualizar desde la base de datos local
                CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando base de datos principal...");

                var secuencias = _sincronizacionService.ObtenerSecuencias(AppSettings.MaxiKioscoIdentifier.ToString());
                var exportacionesLocales = SincronizacionHelper.ObtenerDatosSinExportar(AppSettings.MaxiKioscoIdentifier,
                                                                                       UsuarioActual.UsuarioId,
                                                                                       secuencias.UltimaSecuenciaAcusada);
                var actualizarDatosRequest = new ActualizarDatosRequest
                {
                    Exportaciones = exportacionesLocales.Select(exp => new ExportacionData
                    {
                        Archivo = exp.ExportacionArchivo.Archivo,
                        Secuencia = exp.Secuencia
                    }).ToArray(),
                    MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier
                };
                //actualizarDatosRequest.Exportaciones = new[] {actualizarDatosRequest.Exportaciones.First()};
                var actualizarResponse = _sincronizacionService.ActualizarDatos(actualizarDatosRequest);
                if (!actualizarResponse.Exito)
                {
                    _huboError = true;
                    MessageBox.Show(CurrentForm, actualizarResponse.MensageError);
                }
                else
                {
                    AppSettings.RefreshSettings();
                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Obteniendo datos de servidor...");
                    var request = new ObtenerDatosRequest
                    {
                        MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                        UsuarioIdentifier = UsuarioActual.Usuario.Identifier,
                        UltimaSecuenciaExportacion = AppSettings.Maxikiosco == null ? null : AppSettings.Maxikiosco.UltimaSecuenciaExportacion
                    };

                    //Esperar respuesta del server.

                    var response = _sincronizacionService.ObtenerDatos(request);

                    //Actualizar base de datos local.
                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando datos de kiosco...");

                    AppSettings.RefreshSettings();

                    var pendientes = response.Exportaciones.Where(e => e.Secuencia > secuencias.UltimaSecuenciaExportacion).ToList();
                    for (var i = 0; i < pendientes.Count(); i++)
                    {
                        CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje),
                            String.Format("Actualizando datos de kiosco  [{0} de {1}]", i + 1, pendientes.Count()));
                        var exportacion = pendientes[i];
                        var result = Uow.Exportaciones.ActualizarKiosco(exportacion.Archivo, AppSettings.MaxiKioscoIdentifier, exportacion.Secuencia);
                        if (!result)
                        {
                            _huboError = true;
                            AppSettings.RefreshSettings();
                            return;
                        }
                    }

                    if (response.Exportaciones.Any())
                    {
                        CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Informando al servidor...");
                        var acuseRequest = new AcusarExportacionRequest()
                        {
                            MaxiKioscoIdentifier = AppSettings.MaxiKioscoIdentifier,
                            UltimaSecuenciaExportacion = response.Exportaciones.Last().Secuencia,
                            HoraLocalISO = DateHelper.DateAndTimeToISO(DateTime.Now)
                        };
                        _sincronizacionService.AcusarExportacion(acuseRequest);

                        if (SyncExitosaEvent != null)
                            SyncExitosaEvent();
                    }


                    CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Actualizando stock...");
                    Uow.Stocks.Actualizar();


                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.LogWithFormat(ex);
                MessageBox.Show(CurrentForm, ExceptionHelper.GetInnerException(ex).Message);
                _huboError = true;
            }
        }
        
        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            AppSettings.RefreshSettings();
            UsuarioActual.ResetearValoresCacheados();
            if (_huboError)
            {
                CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Sincronización finalizada con errores");
            }
            else
            {
                CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "Sincronización finalizada");
                ActualizacionPantallasHelper.ActualizarPantallaVentas();

                if (SyncExitosaEvent != null)
                    SyncExitosaEvent();
            }

            if (SyncTimer != null)
                SyncTimer.Stop();
            else
            {
                SyncTimer = new Timer();
                SyncTimer.Tick += SyncTimerOnTick;
            }

            if (UsuarioActual.Cuenta.SincronizarAutomaticamente.GetValueOrDefault())
            {
                SyncTimer.Interval = UsuarioActual.Cuenta.IntervaloSincronizacion.GetValueOrDefault() * 60000;
                SyncTimer.Start();
            }
            Sincronizando = false;

            Timer = new Timer {Interval = 5000};
            Timer.Tick += TimerOnTick;
            Timer.Start();
        }

        private void SyncTimerOnTick(object sender, EventArgs eventArgs)
        {
            SincronizarEnSegundoPlano(CurrentForm, new BackgroundWorker(), TssProgreso);
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            Timer.Stop();
            CurrentForm.Invoke(new ActualizarMensajeDelegate(ActualizarMensaje), "");
        }

        #endregion


        public void ExportarDatosDesincronizados()
        {
            var repository = new ExportacionRepository();
            var puedeExportar = repository.PuedeExportarKiosco();
            if (puedeExportar)
            {
                //Generamos la exportacion para usuario que realizo la solicitud.
                repository.ExportarKiosco(AppSettings.MaxiKioscoIdentifier, UsuarioActual.UsuarioId);
            }
        }

        public static bool _isConnected = false;
        public bool IsConnected
        {
            get { return _isConnected; }
        }

        public async Task PingServer()
        {
            if (AppSettings.MaxiKioscoIdentifier != Guid.Empty)
            {
                _isConnected = _sincronizacionService.AcusarEstadoConexion(AppSettings.MaxiKioscoIdentifier);
            }
        }
    }
}
