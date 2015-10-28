using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Maxikioscos.Comun.Extensions;
using MaxiKioscos.Web.Configuration;

namespace MaxiKioscos.Web.Helpers
{
    public static partial class Helper
    {
        public static MvcHtmlString MenuLateralItem(this HtmlHelper helper, string url, string iconClasses, string buttonText , bool showAlways = false)
        {
            var permiso = buttonText.Trim().ToUpper().RemoveWhiteSpace();

            if (!showAlways && !UsuarioActual.Usuario.TienePermiso(permiso))
            {
                return MvcHtmlString.Empty;
            }
            
            var html = String.Format("<li><a data-ajax=\"true\" data-ajax-begin=\"maxikioscoSpinner.startSpin\" data-ajax-failure=\"maxikioscoSpinner.stopSpin\"" 
                   + "data-ajax-method=\"Get\" data-ajax-mode=\"replace\" data-ajax-success=\"maxikioscoSpinner.stopSpin\""
                   + "data-ajax-update=\"#AdminContainer\" href=\"{0}\">"
                   + "<i class=\"{1}\"></i>&nbsp;&nbsp;{2}"
                   + "</a></li>",
                   url, iconClasses, buttonText);


            return MvcHtmlString.Create(html);
        }
        public static MvcHtmlString SetFocusTo<TModel, TProperty>(
                    this HtmlHelper<TModel> html,
                    Expression<Func<TModel, TProperty>> expression)
        {
            var prop = ExpressionHelper.GetExpressionText(expression);
            return html.setFocusTo(prop);
        }

        public static MvcHtmlString SetFocusTo(this HtmlHelper html,
                                               string propertyName)
        {
            var prop = ExpressionHelper.GetExpressionText(propertyName);
            return html.setFocusTo(prop);
        }

        private static MvcHtmlString setFocusTo(this HtmlHelper html,
                                                string property)
        {
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(property);
            var script = "<script type='text/javascript'>" +
                            "$(function() {" +
                                "$('#" + id + "').focus();" +
                            "});" +
                            "</script>";
            return MvcHtmlString.Create(script);
        }
      
    }
}