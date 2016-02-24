using System.Web;
using System.Web.Optimization;


namespace AddTextToImage.WebUI
{
    /// <summary>
    /// This class registers script and style bundles.
    /// </summary>
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/spectrum").Include(
                        "~/Scripts/spectrum.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/spectrum.css",
                      "~/Content/Site.css"));
        }
    }
}