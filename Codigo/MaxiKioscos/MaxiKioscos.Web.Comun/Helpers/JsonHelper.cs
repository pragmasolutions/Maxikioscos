using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MaxiKioscos.Web.Comun.ActionResults.utilsResult;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MaxiKioscos.Web.Comun.Helpers
{
    public class JsonHelper
    {
        /// <summary>
        /// Serializa un objeto como json
        /// </summary>
        /// <param name="obj">Objeto a serialziar</param>
        /// <returns>Json String</returns>
        public static string ToJson(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
