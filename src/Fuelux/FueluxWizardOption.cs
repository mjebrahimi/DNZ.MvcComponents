using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class FueluxWizardOption : IOptionBuilder, IHtmlContent
    {
        private int step;
        private readonly IHtmlHelper htmlHelper;

        public Dictionary<string, object> Attributes { get; set; }

        public FueluxWizardOption(IHtmlHelper helper)
        {
            Attributes = new Dictionary<string, object>();
            htmlHelper = helper;
            BadgeNumber(true);
            ValidateOnStep(true);
            PreviousText("قبلی");
            NextText("بعدی");
            CompleteText("اتمام");
            PreviousIcon("glyphicon glyphicon-arrow-right");
            NextIcon("glyphicon glyphicon-arrow-left");
        }

        public FueluxWizardOption PreviousText(string value)
        {
            Attributes["defin_previous_text"] = value;
            return this;
        }

        public FueluxWizardOption NextText(string value)
        {
            Attributes["defin_next_text"] = value;
            return this;
        }

        public FueluxWizardOption CompleteText(string value)
        {
            Attributes["defin_complete_text"] = value;
            return this;
        }

        public FueluxWizardOption PreviousIcon(string value)
        {
            Attributes["defin_previous_icon"] = value;
            return this;
        }

        public FueluxWizardOption NextIcon(string value)
        {
            Attributes["defin_next_icon"] = value;
            return this;
        }

        public FueluxWizardOption ValidateOnStep(bool value)
        {
            Attributes["validateOnStep"] = value;
            return this;
        }

        public FueluxWizardOption BadgeNumber(bool value)
        {
            Attributes["badgeNumber"] = value;
            return this;
        }

        public FueluxWizardOption DisablePreviousStep()
        {
            Attributes["disablePreviousStep"] = true;
            return this;
        }

        public FueluxWizardOption CurrentStep(int step)
        {
            Attributes["selectedItem"] = string.Format("{{ step: {0} }}", step);
            return this;
        }

        public FueluxWizardOption AddStep(string title, Func<object, HelperResult> template)
        {
            step++;
            Attributes["step_" + step] = new Tuple<int, string, string>(step, title, template(null).ToHtmlString());
            return this;
        }

        public FueluxWizardOption AddStepInlineHelper(string title, HelperResult template)
        {
            step++;
            Attributes["step_" + step] = new Tuple<int, string, string>(step, title, template.ToHtmlString());
            return this;
        }

        public string ToHtmlString()
        {
            string id = Guid.NewGuid().ToString();
            string options = "{\n" + string.Join(", \n", Attributes.Where(p => !p.Key.StartsWith("step_") && !p.Key.StartsWith("defin_") && p.Key != "validateOnStep" && p.Key != "badgeNumber").Select(p => p.Key + ": " + p.Value)) + "\n}";
            htmlHelper.Script(@"
            <script>
                $(function(){
                    $("".actions button"").click(function (e) {
                        e.preventDefault();
                    })
                    $(""#" + id + @""").wizard(" + options + @")
                    " +
                        (Convert.ToBoolean(Attributes["validateOnStep"]) ?
                        @".on(""actionclicked.fu.wizard"", function (event, data) {
                            if (data.direction == ""next"") {
                                $(""div.step-pane[data-step='"" + data.step + ""']"").find('input[data-val], select[data-val]').each(function () {
                                    if ($(this).valid() == false)
                                        event.preventDefault()
                                });
                            }
                        })" : "")
                        + @"
                      .on(""finished.fu.wizard"", function (event, data) {
                           $(this).closest('form').submit();
                      })
                });
            </script>");

            string html = @"<div class=""fuelux"" id=""" + id + @""" >
                        <div class=""thin-box"">
                            <div class=""wizard rtl "" data-initialize=""wizard"" style=""border-bottom-right-radius: 0; border-bottom-left-radius: 0;"">
                                <ul class=""steps"">";
            foreach (KeyValuePair<string, object> item in Attributes.Where(p => p.Key.StartsWith("step_")))
            {
                Tuple<int, string, string> tuple = item.Value as Tuple<int, string, string>;
                int stepNumber = tuple.Item1;
                Attributes.TryGetValue("selectedItem", out object selectedItem);
                int currentStep = 1;
                if (selectedItem != null)
                {
                    currentStep = Convert.ToInt32(selectedItem.ToString().Replace("{ step: ", "").Replace(" }", ""));
                }

                html += @"<li " + (stepNumber == currentStep ? @"class=""active""" : "") + @" data-step=""" + stepNumber + @""">
                          <span class=""chevron""></span>
                          " + (Convert.ToBoolean(Attributes["badgeNumber"]) ? (@" <span class=""badge"">" + stepNumber + "</span>") : "") + @"
                          " + tuple.Item2 + @"
                      </li>";
            }
            html += @"</ul>
                  <div class=""step-content"">";
            foreach (KeyValuePair<string, object> item in Attributes.Where(p => p.Key.StartsWith("step_")))
            {
                Tuple<int, string, string> tuple = item.Value as Tuple<int, string, string>;
                int stepNumber = tuple.Item1;
                Attributes.TryGetValue("selectedItem", out object selectedItem);
                int currentStep = 1;
                if (selectedItem != null)
                {
                    currentStep = Convert.ToInt32(selectedItem.ToString().Replace("{ step: ", "").Replace(" }", ""));
                }

                html += @"<div class=""step-pane " + (stepNumber == currentStep ? "active" : "") + @" sample-pane"" data-step=""" + stepNumber + @""" " + (step == stepNumber ? @"data-name=""distep""" : "") + @">
                          " + tuple.Item3 + @"
                      </div>";
            }
            html += @"</div>
            </div>
            <div class=""actions"" style=""width: 100%; display: inline-block;background: #eeeeee;padding: 10px;border: 1px solid #d4d4d4;border-radius: 4px;border-top: none;border-top-right-radius:0; border-top-left-radius:0"">
                <button class=""btn btn-primary btn-prev btn-lg col-xs-2"">
                    <span class=""" + Attributes["defin_previous_icon"] + @""" style=""margin-left: 10px;""></span>" + Attributes["defin_previous_text"] + @"
                </button>
                <button class=""btn btn-primary btn-next pull-left btn-lg col-xs-2"" data-last=""" + Attributes["defin_complete_text"] + @""">
                    " + Attributes["defin_next_text"] + @"<span class=""" + Attributes["defin_next_icon"] + @""" style=""margin-right: 10px;""></span>
                </button>
            </div>
        </div>
    </div>";

            return html;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write(ToHtmlString());
        }
    }
}