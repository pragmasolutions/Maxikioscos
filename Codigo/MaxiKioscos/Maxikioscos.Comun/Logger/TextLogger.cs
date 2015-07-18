using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Maxikioscos.Comun.Logger
{
    /// <summary>
    /// Logs to a text file
    /// </summary>
    internal class TextLogger
    {
        private string _source; 

        private static List<TextLogger> _logs = null;

        private static string _LogFolder = null;

        /// <summary>
        /// Initialie an instance of TextLogger
        /// </summary>
        /// <param name="source"></param>
        private TextLogger(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Initialize log folder
        /// </summary>
        static TextLogger()
        {
            _logs = new List<TextLogger>();
            _LogFolder = ConfigurationManager.AppSettings["LogFolder"];
            if( _LogFolder == null )
                _LogFolder = @"C:\Logs";

            try
            {
                if (!Directory.Exists(_LogFolder))
                    Directory.CreateDirectory(_LogFolder);
            }
            catch { _LogFolder = null; } // Ignore all exceptions            
        }

        internal static void Log(string format, params object[] args)
        {
            try
            {
                // Create file path
                string filePath = _LogFolder + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".log";

                // Log message
                File.AppendAllText(filePath, string.Format(format + "\r\n",args));
            }
            catch { }// Ignorare all errors
        }

        /// <summary>
        /// A thread safe function to write to text logs
        /// </summary>
        /// <param name="source">Application source</param>
        /// <param name="message">Log message</param>
        internal static void Log(string message)
        {
            try
            {
                // Create file path
                string filePath = _LogFolder + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".log";

                // Log message
                string msg = DateTime.Now.ToLongTimeString().ToString() + " => " + message + "\r\n";
                File.AppendAllText(filePath, msg);
            }
            catch { }// Ignorare all errors
        }
    }
}
