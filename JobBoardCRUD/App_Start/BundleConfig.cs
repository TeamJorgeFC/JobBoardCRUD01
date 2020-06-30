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
                      "~/Content/sweatAlert/dist/sweetalert2.all.min.js",
                      "~/Content/datepicker-master/dist/datepicker.css"));
        }
    }
}
