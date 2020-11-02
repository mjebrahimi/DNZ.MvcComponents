using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;

namespace Microsoft.AspNetCore.Mvc
{
    public static class FueluxWizardHelper
    {
        //https://github.com/ExactTarget/fuelux
        //https://cdnjs.com/libraries/fuelux
        private const string fuelux_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/fuelux/3.17.2/css/fuelux.min.css\" integrity=\"sha512-AN1iV2l4d1FAL3flxsDzb9K8+x9iABSfEb4GBf0NBvXq75mvMvtpktIfwgqnaxGv9rIgU6ZSlt470mv8gBwV9w==\" crossorigin=\"anonymous\" />";
        private const string fuelux_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/fuelux/3.17.2/js/fuelux.min.js\" integrity=\"sha512-21OLwb8/CWrsmT1C774XOYhA8wPowgLC0KVNDBmeFnFnitc8jwTMlPBfKPOd+slm55lN8Iball8jgau83MO3vA==\" crossorigin=\"anonymous\"></script>";
        private const string fuelux_css = "DNZ.MvcComponents.Fuelux.css.fuelux.css";
        private const string wizard_rtl_css = "DNZ.MvcComponents.Fuelux.css.wizard.rtl.css";
        private const string fuelux_js = "DNZ.MvcComponents.Fuelux.js.fuelux.js";

        public static FueluxWizardOption FueluxWizard(this IHtmlHelper helper)
        {
            helper.StyleOnce(ComponentUtility.GetCssTag(fuelux_css, fuelux_css_cdn));
            helper.StyleOnce(ComponentUtility.GetCssTag(wizard_rtl_css, null));
            helper.ScriptOnce(ComponentUtility.GetJsTag(fuelux_js, fuelux_js_cdn));
            return new FueluxWizardOption(helper);
        }
    }
}