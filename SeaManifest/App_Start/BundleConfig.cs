using System.Web;
using System.Web.Optimization;

namespace SeaManifest
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/plugins/fastclick/fastclick.js",
                        "~/plugins/sparkline/jquery.sparkline.min.js",
                         "~/plugins/slimScroll/jquery.slimscroll.min.js",
                         "~/plugins/chartjs/Chart.min.js",
                         "~/dist/js/app.min.js",
                         "~/dist/js/demo.js",
                         "~/Scripts/jquery-3.3.1.min.js",
                         "~/Scripts/alertify.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*", "~/Scripts/common.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.responsive.min.js",
                        "~/Scripts/DataTables/dataTables.buttons.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/DataTables/dataTables.select.min.js",
                        "~/Scripts/DataTables/dataTables.checkboxes.min.js"));
            //gyrocode.github.io/jquery-datatables-checkboxes/1.2.10/js/dataTables.checkboxes.min.js
            //bundles.Add(new StyleBundle("~/Content/datatables").Include(

            //          "~/Content/DataTables/css/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/csss").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/IGS_style.css",
                       "~/Content/alertifycss/alertify.css",
                      "~/Content/alertifycss/themes/default.css",
                    "~/dist/css/AdminLTE.min.css"
                      ));// "~/plugins/jvectormap/jquery-jvectormap-1.2.2.css"));
            bundles.Add(new StyleBundle("~/dist/csss").Include(
            "~/Content/DataTables/css/dataTables.checkboxes.css",
                    "~/Content/DataTables/css/dataTables.bootstrap.css",
                    "~/Content/DataTables/css/responsive.bootstrap.min.css",
                    "~/Content/DataTables/css/buttons.dataTables.min.css",
                    "~/Content/DataTables/css/select.dataTables.min.css"));

            //       < link rel = "stylesheet" type = "text/css" href =  >

            //< link rel = "stylesheet" type = "text/css" href =  >

            //     < link rel = "stylesheet" type = "text/css" href = "../../extensions/Editor/css/editor.dataTables.min.css" >

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
