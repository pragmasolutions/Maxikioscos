using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MaxiKioscos.Web.Comun.Extensiones
{
    public static partial class Helper
    {
        public static MvcHtmlString PopupTitulo(this HtmlHelper helper, string titulo)
        {
            var html = String.Format("<div class=\"modal-header\"><button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button><h4 class=\"modal-title\" id=\"myModalLabel\">{0}</h4></div>",
                                        titulo);


            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString PaginaTitulo(this HtmlHelper helper, string titulo, string iconClass = null)
        {
            string iconHtml = string.Empty;
            if (!string.IsNullOrEmpty(iconClass))
            {
                iconHtml = string.Format("<i class=\"fa {0} fa-fw\" style=\"font-size: xx-large;\"></i>",
                                         iconClass);
            }
            var html = String.Format("<div class=\"row\"><div class=\"col-lg-12\"><h1 class=\"page-header\">{0}{1}</h1></div></div>", iconHtml, titulo);
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString Modal(this HtmlHelper helper, string titulo, ModalSize size = ModalSize.Normal)
        {
            var html = String.Format("<div id=\"{0}\" class=\"modal fade\" id=\"myModal\" role=\"dialog\" aria-labelledby=\"{0}\" aria-hidden=\"true\">"
                                      + "<div class=\"modal-dialog " + GetModalSizeClass(size) + "\" >"
                                         + "<div class=\"modal-content\"></div>"
                                      + "</div>"
                                    + "</div>", titulo);
            return MvcHtmlString.Create(html);
        }

        private static string GetModalSizeClass(ModalSize size)
        {
            switch (size)
            {
                case ModalSize.Small:
                    return "modal-sm";
                case ModalSize.Large:
                    return "modal-lg";
                default:
                    return string.Empty;
            }
        }

        public static MvcHtmlString CheckBoxForJson<
            TModel, TValue>(this HtmlHelper<TModel> helper,
                Expression<Func<TModel, TValue>> expression)
        {
            string propName = GetPropertyName(expression);
            string html = "<input type=\"checkbox\" name=\""
                          + propName + "\" id=\""
                          + propName + "\" value=\"true\" />";
            return MvcHtmlString.Create(html);
        }

        private static string GetPropertyName<TModel, TValue>(Expression<Func<TModel, TValue>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }
            return body.Member.Name;
        }
    }

    public enum ModalSize
    {
        Normal,
        Small,
        Large
    }
}
