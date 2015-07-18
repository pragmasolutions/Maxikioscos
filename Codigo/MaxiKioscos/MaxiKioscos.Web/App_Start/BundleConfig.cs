using System.Web;
using System.Web.Optimization;

namespace MaxiKioscos.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();
            bundles.ResetAll();

            bundles.Add(new ScriptBundle("~/Scripts/lib/jquery").Include(
                        "~/Scripts/lib/jquery-{version}.js",
                        "~/Scripts/lib/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/Scripts/lib/bootstrap").Include(
                        "~/Scripts/lib/bootstrap.js",
                        "~/Scripts/lib/plugins/datepicker/js/boostrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/Scripts/lib/globalize/js")
                         .Include(
                             "~/Scripts/lib/globalize/globalize.js",
                             "~/Scripts/lib/globalize/globalize.culture.es-AR.js",
                             "~/Scripts/lib/globalize/globalize.init.js"));

            bundles.Add(new ScriptBundle("~/Scripts/lib/jqueryval").Include(
                        "~/Scripts/lib/jquery.validate.js",
                        "~/Scripts/lib/jquery.validate.unobtrusive.js",
                        "~/Scripts/lib/jquery.validate.unobtrusive.extensions.js",
                        "~/Scripts/lib/jquery.validate.unobtrusive.custom.js",
                        "~/Scripts/lib/jquery.validate.fixes.js"));

            bundles.Add(new ScriptBundle("~/Scripts/lib/bootstrap/plugins").Include(
                        "~/Scripts/lib/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Scripts/lib/plugins/morris/raphael-2.1.0.min.js",
                        "~/Scripts/lib/plugins/morris/morris.js",
                        "~/Scripts/lib/plugins/autoNumeric.js",
                        "~/Scripts/lib/plugins/spin.js",
                        "~/Scripts/lib/plugins/bootstrap-timepicker.js",
                        "~/Scripts/lib/plugins/bootstrap-datepicker.js",
                        "~/Scripts/lib/plugins/bootstrap-datepicker.es.js",
                        "~/Scripts/lib/plugins/bootstrap-bootbox.js",
                        "~/Scripts/lib/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/Scripts/lib/comun").Include(
                        "~/Scripts/lib/javascript.object.extension.js",
                        "~/Scripts/lib/maxikiosco-util.js",
                        "~/Scripts/app/maxikiosco-spinner.js",
                        "~/Scripts/lib/plugins/select2-3.4.5/select2.min.js",
                        "~/Scripts/lib/plugins/select2-3.4.5/select2_locale_es.js",
                        "~/Scripts/lib/plugins/bootstrap-multiselect/js/prettify.js",
                        "~/Scripts/lib/plugins/bootstrap-multiselect/js/bootstrap-multiselect.js",
                        "~/Scripts/lib/plugins/shortcut.js",
                        "~/Scripts/lib/jquery.hotkeys.js",
                        "~/Scripts/lib/jquery.confirm.js",
                        "~/Scripts/lib/jsrender.js",
                        "~/Scripts/lib/jquery.cursortable.js",
                         "~/Scripts/app/bootstrapAlerts.js"));

            bundles.Add(new ScriptBundle("~/Scripts/app/admin").Include(
                       "~/Scripts/app/sb-admin.js",
                       "~/Scripts/app/maxikiosco.unobtrusive.js",
                       "~/Scripts/app/dataservices/*.js",
                       "~/Scripts/app/maxikiosco-reportar-error.js",
                       "~/Scripts/app/maxikiosco-util.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Scripts/lib/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/spin.css",
                "~/Content/maxikiosco-form.css",
                "~/Content/maxikiosco-table.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css/styles")
                            .Include("~/Content/bootstrap/css/bootstrap.css",
                                     "~/Content/bootstrap/css/bootstrap-theme.css",
                                     "~/Content/bootstrap/css/select2.css",
                                     "~/Content/bootstrap/css/select2-bootstrap.css",
                                     "~/Content/bootstrap/css/boostrap-multiselect.css",
                                     "~/Content/bootstrap/css/bootstrap-timepicker.css",
                                     "~/Content/bootstrap/css/bootstrap-datepicker.css",
                                     "~/Content/bootstrap/css/typeaheadjs.css"));

            bundles.Add(new StyleBundle("~/Content/admin/css/styles")
                           .Include("~/Content/admin/css/font-awesome.css",
                                    "~/Content/admin/css/morris-0.4.3.min.css",
                                    "~/Content/admin/css/timeline.css",
                                    "~/Content/admin/css/sb-admin.css"));
        }
    }
}