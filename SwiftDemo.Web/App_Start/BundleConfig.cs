using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SwiftDemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootswatch/united/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/angular-block-ui.min.css",
                      "~/Content/animate.css"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                       "~/scripts/jquery-{version}.js",
                       "~/scripts/bootstrap.min.js",
                       "~/scripts/angular.min.js",
                       "~/scripts/angular-block-ui.min.js",
                       "~/scripts/angular-ui-router.min.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/scripts/app/MainModule.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/client").Include(
                        "~/scripts/app/client/controllers/MaintainClientController.js"
                        ));

            //ClientModule
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;

        }
    }
}