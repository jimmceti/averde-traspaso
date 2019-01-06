using System.Web;
using System.Web.Optimization;

namespace TraspasoAcoVerde
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));


            /*
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-3.3.1.min.js"));
            */

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jsAppProject").Include(
                    "~/Scripts/jsgrid_1_5_3/jsgrid_1_5_3.min.js",
                    "~/Scripts/Project/Project.js",
                    "~/Scripts/Project/Admon/Users.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Bootstrap-4/bootstrap.css",
                      "~/Content/css/custom.css",
                      "~/Scripts/jsgrid_1_5_3/jsgrid_1_5_3.min.css",
                      "~/Scripts/jsgrid_1_5_3/jsgrid_1_5_3_theme.min.css"
            ));

        }
    }
}
