using System.Web;
using System.Web.Optimization;

namespace AirSense
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Content/theme/js/jquery.js",
                      "~/Content/theme/js/jquery.easing.min.js",
                      "~/Content/theme/js/grayscale.js",
                      "~/Content/theme/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/theme/css/bootstrap.css",
                      "~/Content/theme/css/grayscale.css",
                      "~/Content/theme/font-awesome/css/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
