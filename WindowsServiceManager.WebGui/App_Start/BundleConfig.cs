using System.Web;
using System.Web.Optimization;

namespace WindowsServiceManager.WebGui
{
    using System.Collections.Generic;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = false;

            var a = new BundleFileSetOrdering("app");
            a.Files.Add("AjaxUrls.js");
            a.Files.Add("purl.js");
            a.Files.Add("ServiceAction.js");
            a.Files.Add("ServiceRow.js");
            a.Files.Add("EventMessages.js");
            a.Files.Add("Tags.js");
            a.Files.Add("HomeViewModel.js");
            bundles.FileSetOrderList.Add(a);



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery-ui.js",
                      "~/Scripts/knockout.3.3.0.js",
                      "~/Scripts/tag-it.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-extra.css",
                      "~/Content/tag-it.css",
                      "~/Content/site.css"));
        }
    }
}
