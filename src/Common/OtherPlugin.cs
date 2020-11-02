using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;

namespace Microsoft.AspNetCore.Mvc
{
    public static class OtherPlugin
    {
        //https://cdnjs.com/libraries/bootstrap-maxlength
        //http://mimo84.github.io/bootstrap-maxlength/
        private const string bootstrap_maxlength_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-maxlength/1.10.0/bootstrap-maxlength.min.js\" integrity=\"sha512-04L+TAgzlDAaUpaEGriEBg/qEryUjw4GNL/FkxA3h621EFPycccO2Y8vNhvid9UhgGC/9+MHLAFwGythpvOAAQ==\" crossorigin=\"anonymous\"></script>";
        private const string bootstrap_maxlength_js = "DNZ.MvcComponents.MaxLenght.bootstrap-maxlength.js";

        public static IHtmlContent AddMaxLenghtPlugin(this IHtmlHelper helper)
        {
            helper.ScriptOnce(ComponentUtility.GetJsTag(bootstrap_maxlength_js, bootstrap_maxlength_js_cdn)).ToHtmlString();
            helper.ScriptOnce(@"
<script>
    $(function(){
        $(""[data-val-length-max]"").each(function () {
            var element = $(this);
            element.attr(""maxlength"", element.attr(""data-val-length-max""));
        });
        $(""[data-val-maxlength-max]"").each(function () {
            var element = $(this);
            element.attr(""maxlength"", element.attr(""data-val-maxlength-max""));
        });
        $(""[maxlength]"").maxlength();
    });
</script>");

            return HtmlString.Empty;
        }

        public static IHtmlContent AddValidationPlugin(this IHtmlHelper helper)
        {
            helper.StyleOnce(@"
<style>
.with-feedback.component-rtl .form-control-feedback {
    left: 39px;
}
.no-feedback.component-rtl .form-control-feedback {
    left: 19px;
}
.with-feedback.component-ltr .form-control-feedback {
    right: 0;
}
.no-feedback.component-ltr .form-control-feedback {
    right: 0;
}
</style>");

            helper.ScriptOnce(@"
<script>
    $.validator.setDefaults({
        ignore: """",
        //showErrors: function (errorMap, errorList) {
        //    this.defaultShowErrors();
        //    $(""."" + this.settings.validClass).tooltip(""destroy"");
        //    for (var i = 0; i < errorList.length; i++) {
        //        var error = errorList[i];
        //        $(error.element).tooltip({ trigger: ""focus"" }).attr(""data-original-title"", error.message);
        //    }
        //},
        highlight: function (element) {
            var attr = $(element).attr('data-val');
            if (typeof attr !== typeof undefined && attr !== false) {
                $(element).closest('.form-group').addClass('has-error');
                $(element).closest("".input-group"").find('.form-control-feedback.glyphicon.glyphicon-remove').remove()
                $(element).closest("".input-group"").find('.form-control-feedback.glyphicon.glyphicon-ok').remove()
                $(""<i class='form-control-feedback glyphicon glyphicon-remove'></i>"").appendTo($(element).closest("".input-group""))
            }
        },
        unhighlight: function (element) {
            var attr = $(element).attr('data-val');
            if (typeof attr !== typeof undefined && attr !== false) {
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
                $(element).closest("".input-group"").find('.form-control-feedback.glyphicon.glyphicon-remove').remove()
                $(element).closest("".input-group"").find('.form-control-feedback.glyphicon.glyphicon-ok').remove()
                $(""<i class='form-control-feedback glyphicon glyphicon-ok'></i>"").appendTo($(element).closest("".input-group""))
            }
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });
    $(function(){
        $("".field-validation-valid"").addClass(""text-danger"")
        $('form').each(function () {
            $(this).find('div.form-group').each(function () {
                if ($(this).find('span.field-validation-error').length > 0) {
                    $(this).addClass('has-error');
                }
            });
        });
    });
</script>");

            return HtmlString.Empty;
        }
    }
}
