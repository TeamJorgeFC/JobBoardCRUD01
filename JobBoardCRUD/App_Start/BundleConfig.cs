using System.Web;
using System.Web.Optimization;

namespace JobBoardCRUD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/plugins/fontawesome-free/css/all.min.css",
                      "~/Content/plugins/toastr/toastr.min.css",
                      "~/Content/dist/css/adminlte.min.css",
                      "~/Content/fontawesome-free-5.13.0-web/css/all.css",
                      "~/Content/DataTable/datatables.min.css",
                      "~/Content/bootstrap-4.3.1-dist/css/bootstrap.min.css",                      
                      "~/Content/datepicker-master/dist/datepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
                        "~/Content/plugins/jquery/jquery.min.js",
                        "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/plugins/toastr/toastr.min.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/dist/js/demo.js",
                        "~/Content/fontawesome-free-5.13.0-web/js/all.js",
                        "~/Content/DataTable/datatables.min.js",
                        "~/Content/bootstrap-notify-master/bootstrap-notify.min.js",
                        "~/Content/datepicker-master/dist/datepicker.js",
                        "~/Content/jquery-inputmask/jquery.inputmask.bundle.js",
                        "~/Content/sweatAlert/dist/sweetalert2.all.min.js"));
        }
    }
}
