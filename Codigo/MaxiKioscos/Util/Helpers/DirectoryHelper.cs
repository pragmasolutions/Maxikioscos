using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKiosco.Win.Util.Helpers
{
    public static class DirectoryHelper
    {
        public static bool LimpiarDirectorio(string path)
        {
            try
            {
                var downloadedMessageInfo = new DirectoryInfo(path);
                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    file.Delete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool LimpiarDirectorio(string path, string extension)
        {
            try
            {
                var downloadedMessageInfo = new DirectoryInfo(path);
                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    if (file.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
                    {
                        file.Delete();
                    }
                }
                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<string> ObtenerArchivos(string path, string extension)
        {
            return Directory.GetFiles(path, String.Format("*.{0}", extension)).ToList();
        }
    }
}
