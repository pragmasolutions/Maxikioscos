using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ionic.Zip;
using MaxiKioscos.Web.Comun.ActionResults.utilsResult;

namespace MaxiKioscos.Web.Comun.Helpers
{
    public class ZipHelper
    {
        /// <summary>
        /// Key: nombre
        /// Value: xmlString
        /// </summary>
        /// <param name="listaXmls"></param>
        /// <returns></returns>
        public static ZipResult ZipResult(List<KeyValuePair<string, string>> listaXmls, string fileName)
        {
            var xml = new XmlDocument();
            xml.LoadXml(listaXmls.ElementAt(0).Value);
            var result = new ZipResult(String.Format("{0}.xml", listaXmls.ElementAt(0).Key), GetBytesFromXmlDocument(xml));

            for (int i = 1; i < listaXmls.Count; i++)
            {
                var elto = listaXmls.ElementAt(i);
                var nuevo = new XmlDocument();
                nuevo.LoadXml(elto.Value);
                result.AddFile(String.Format("{0}.xml", elto.Key), GetBytesFromXmlDocument(nuevo));
            }
            result.FileDownloadName = fileName;
            return result;
        }

        private static Byte[] GetBytesFromXmlDocument(XmlDocument document)
        {
            var ms = new MemoryStream();
            document.Save(ms);
            return ms.ToArray();
        }
    }
}
