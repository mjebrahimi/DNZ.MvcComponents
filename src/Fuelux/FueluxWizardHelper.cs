using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;

namespace Microsoft.AspNetCore.Mvc
{
    public static class FueluxWizardHelper
    {
        private const string fuelux_css = "DNZ.MvcComponents.Fuelux.css.fuelux.css";
        private const string wizard_rtl_css = "DNZ.MvcComponents.Fuelux.css.wizard.rtl.css";
        private const string fuelux_js = "DNZ.MvcComponents.Fuelux.js.fuelux.js";

        public static FueluxWizardOption FueluxWizard(this IHtmlHelper helper)
        {
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(fuelux_css) + @""" rel=""stylesheet"" />");
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(wizard_rtl_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fuelux_js) + @"""></script>");
            return new FueluxWizardOption(helper);
        }
    }
}