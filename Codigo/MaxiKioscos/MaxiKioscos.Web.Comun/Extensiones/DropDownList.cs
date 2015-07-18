using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaxiKioscos.Web.Comun.Extensiones
{
    public static partial class InputExtensions
    {
        public static MvcHtmlString MultiSelect(this HtmlHelper helper, string name, SelectList lista, List<int> valores, object htmlAttributes)
        {
            var html = new StringBuilder();

            var atributos = new StringBuilder();
            if (htmlAttributes != null)
            {
                var atributosFormateados =
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var atributo in atributosFormateados)
                {
                    atributos.AppendFormat("{0}=\"{1}\"", atributo.Key, atributo.Value);
                }

            }

            html.Append(String.Format("<select multiple=\"multiple\" name=\"{0}\" id=\"{0}\" {1}>", name, atributos));

            
            foreach (var item in lista)
            {
                if (valores != null && valores.IndexOf(Convert.ToInt32(item.Value)) != -1)
                    html.Append(String.Format("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text));
                else
                    html.Append(String.Format("<option value=\"{0}\">{1}</option>", item.Value, item.Text));
            }
           


            html.Append("</select>");
            
            return MvcHtmlString.Create(html.ToString());
        }
    }
}
