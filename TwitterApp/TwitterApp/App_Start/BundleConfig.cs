using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TwitterApp.Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Jquery").Include("~/Scripts/jquery-1.9.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/Bootstrajs").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/Main").Include("~/Scripts/Main.js"));
            bundles.Add(new StyleBundle("~/content/Bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/content/main").Include("~/Content/main.css"));
        }
    }
}