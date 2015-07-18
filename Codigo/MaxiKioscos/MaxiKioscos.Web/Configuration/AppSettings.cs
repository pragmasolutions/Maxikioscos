using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Configuration
{
    public class AppSettings
    {
        public static int DefaultPageSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageSize"]); }
        }

        public static string UploadTempPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(String.Format("~/{0}", ConfigurationManager.AppSettings["UploadTempPath"]));
            }
        }

        public static string BaseURL
        {
            get
            {
                var request = HttpContext.Current.Request;
                var appUrl = HttpRuntime.AppDomainAppVirtualPath;

                if (!string.IsNullOrWhiteSpace(appUrl)) appUrl += "/";

                var baseUrl = string.Format("{0}://{1}", request.Url.Scheme, request.Url.Authority);

                return baseUrl;
            }
        }
    }
}