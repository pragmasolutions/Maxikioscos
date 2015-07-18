using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Web.Comun.ActionResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;
    using ICSharpCode.SharpZipLib.Zip;
    using System.Text;

    namespace utilsResult
    {
        public class ZipResult : FileResult
        {


            private Dictionary<string, byte[]> content = new Dictionary<string, byte[]>();
            public string FileNameZip;
            public ZipResult(string FileName, byte[] Contents)
                : base("application/octet-stream")
            {
                this.FileDownloadName = Path.GetFileNameWithoutExtension(FileName) + ".zip";
                AddFile(FileName, Contents);
            }
            public void AddFile(string FileName, byte[] Contents)
            {
                content.Add(FileName, Contents);
            }
            public void AddFile(string FileName, string Contents, Encoding e = null)
            {
                if (e == null)
                    e = ASCIIEncoding.ASCII;

                content.Add(FileName, e.GetBytes(Contents));
            }

            protected override void WriteFile(HttpResponseBase response)
            {

                using (ZipOutputStream zos = new ZipOutputStream(response.OutputStream))
                {
                    zos.SetLevel(3);
                    zos.UseZip64 = UseZip64.Off;

                    foreach (var item in content)
                    {
                        ZipEntry ze = new ZipEntry(item.Key);
                        ze.DateTime = DateTime.Now;
                        zos.PutNextEntry(ze);
                        int count = item.Value.Length;
                        zos.Write(item.Value, 0, count);


                    }
                }
            }
        }
    }
}
