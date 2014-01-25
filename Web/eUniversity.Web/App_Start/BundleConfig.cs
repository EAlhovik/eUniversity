using System.Web.Optimization;

namespace eUniversity.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js",
                        "~/Scripts/jquery/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.unobtrusive*",
                        "~/Scripts/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Content/bootstrap/datepicker/datepicker3.css",
                "~/Content/bootstrap/bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/ace/css").Include(
                "~/Content/ace.min.css",
                "~/Content/ace.css"
                ));
            bundles.Add(new StyleBundle("~/ace/font").Include(
                "~/Content/font-awesome.min.css",
                "~/Content/google-webfont.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap/bootstrap.js",
                       "~/Scripts/bootstrap/datepicker/bootstrap-datepicker.js",
                       "~/Scripts/bootstrap/datepicker/bootstrap-datepicker.ru.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                "~/Scripts/ace/ace.min.js",
                "~/Scripts/ace/ace-extra.min.js",
                "~/Scripts/ace/ace-elements.min.js",
                "~/Scripts/ace/fuelux.spinner.min.js",
                "~/Scripts/ace/fuelux.wizard.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ko").Include(
                        "~/Scripts/ko/knockout-{version}.js",
                        "~/Scripts/ko/knockout.mapping-latest.debug.js",
                        "~/Scripts/ko/knockout.validation.debug.js",
                        "~/Scripts/ko/knockout.bindings.js",
                        "~/Scripts/ko/knockout.mixins.js"
                        ));


            #region chosen

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                "~/Scripts/select2/select2.min.js",
                "~/Scripts/select2/select2_locale_ru.js"
                ));

            bundles.Add(new StyleBundle("~/Content/chosen").Include(
                "~/Content/select2/select2.css"
                ));

            #endregion

        }
    }
}