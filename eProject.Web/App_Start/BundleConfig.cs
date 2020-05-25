using System.Web.Optimization;

namespace eProject.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // application
            bundles.Add(new StyleBundle("~/bundles/app-min/css").Include(
                "~/Content/app.min.css", new CssRewriteUrlTransform()));

            // icons
            bundles.Add(new StyleBundle("~/bundles/icons-min/css").Include(
                "~/Content/icons.min.css", new CssRewriteUrlTransform()));

            //bootstrap
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Application
            bundles.Add(new ScriptBundle("~/bundles/app-min/js").Include(
                "~/Scripts/app.min.js"));

            // Vendor - animations
            bundles.Add(new ScriptBundle("~/bundles/vendor/js").Include(
                "~/Scripts/vendor.min.js"));
        }
    }
}