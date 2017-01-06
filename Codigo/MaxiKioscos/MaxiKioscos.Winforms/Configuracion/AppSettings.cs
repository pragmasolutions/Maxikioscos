using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Winforms.Configuracion
{
    public class AppSettings
    {
        public static Entidades.MaxiKiosco _maxikiosco;
        public static Entidades.MaxiKiosco Maxikiosco
        {
            get
            {
                if (_maxikiosco == null)
                {
                    if (MaxiKioscoIdentifier != Guid.Empty)
                        _maxikiosco = new EFRepository<Entidades.MaxiKiosco>().Obtener(m => m.Identifier == MaxiKioscoIdentifier);
                }   
                return _maxikiosco;
            }
        }

        public static void RefreshSettings()
        {
            _maxikiosco = null;
        }

        private static Guid _maxikioscoIdentifier;
        public static Guid MaxiKioscoIdentifier
        {
            get
            {
                if (_maxikioscoIdentifier == Guid.Empty)
                {
                    var repo = new EFSimpleRepository<ConfiguracionLocal>();
                    var config = repo.Listado().FirstOrDefault();
                    _maxikioscoIdentifier = config != null ? config.MaxikioscoIdentifier : Guid.Empty;
                }
                return _maxikioscoIdentifier;
            }
            set
            {
                _maxikioscoIdentifier = value;
                var repo = new EFSimpleRepository<ConfiguracionLocal>();
                var configuracionLocal = new ConfiguracionLocal()
                                             {
                                                 ConfiguracionLocalId = 1,
                                                 MaxikioscoIdentifier = value
                                             };
                repo.Agregar(configuracionLocal);
                repo.Commit();
            }
        }

        public static int MaxiKioscoId
        {
            get
            {
                if (Maxikiosco == null)
                    return 0;
                return Maxikiosco.MaxiKioscoId;
            }
        }

        public static bool MaxiKioscoEstaOnline
        {
            get
            {
                if (Maxikiosco == null)
                    return true;
                return Maxikiosco.EstaOnLine;
            }
        }

        public static string CurrencyColumnFormat
        {
            get { return ConfigurationManager.AppSettings["CurrencyColumnFormat"]; }
        }

        public static short PrinterComPort
        {
            get { return Convert.ToInt16(ConfigurationManager.AppSettings["PrinterComPort"]); }
        }

        public static string PrinterBaudRate
        {
            get { return ConfigurationManager.AppSettings["PrinterBaudRate"]; }
        }
        
        public static string PercentageColumnFormat
        {
            get { return ConfigurationManager.AppSettings["PercentageColumnFormat"]; }
        }

        public static string CompleteDateColumnFormat { 
            get { return ConfigurationManager.AppSettings["CompleteDateColumnFormat"]; }
        }

        public static string ApplicationPath
        {
            get
            {
                return Application.StartupPath.Replace("\\bin\\Debug", "").Replace("\\bin\\Release", "");
            }
        }

        public static string HubServiceUrl
        {
            get { return ConfigurationManager.AppSettings["HubServiceUrl"]; }
        }

        public static string SincronizacionTemporalFolder
        {
            get 
            { 
                var relativePath = ConfigurationManager.AppSettings["SincronizacionTemporalFolder"];
                return Path.Combine(ApplicationPath, relativePath);
            }
        }

        public static string WebBaseUrl
        {
            get { return ConfigurationManager.AppSettings["WebBaseUrl"]; }
        }

        public static Form MainForm { get; set; }
    }
}
