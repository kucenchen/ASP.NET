#pragma checksum "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85145168ec1c79adf5791776edeae30841ac0dfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SettlePlat_Edit), @"mvc.1.0.view", @"/Views/SettlePlat/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SettlePlat/Edit.cshtml", typeof(AspNetCore.Views_SettlePlat_Edit))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\_ViewImports.cshtml"
using PayProject.WebAdmin;

#line default
#line hidden
#line 2 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\_ViewImports.cshtml"
using PayProject.WebAdmin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85145168ec1c79adf5791776edeae30841ac0dfa", @"/Views/SettlePlat/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_SettlePlat_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayProject.Entity.SettlePlat>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-form form-cus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/themes/ztree/css/metroStyle/metroStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
  
    ViewData["Title"] = "代付渠道管理";
    Layout = "~/Views/_Layout.cshtml";

#line default
#line hidden
            BeginContext(119, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(121, 2922, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85145168ec1c79adf5791776edeae30841ac0dfa5562", async() => {
                BeginContext(165, 179, true);
                WriteLiteral("\r\n    <div class=\"layui-form-item\">\r\n        <label class=\"layui-form-label\">渠道名称</label>\r\n        <div class=\"layui-input-block\">\r\n            <input type=\"text\" name=\"Plat_name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 344, "\"", 368, 1);
#line 11 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 352, Model.Plat_name, 352, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(369, 304, true);
                WriteLiteral(@" maxlength=""20"" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" class=""layui-input"">
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label"">渠道类名</label>
        <div class=""layui-input-block"">
            <input type=""text"" name=""Plat_class""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 673, "\"", 698, 1);
#line 17 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 681, Model.Plat_class, 681, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(699, 290, true);
                WriteLiteral(@" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" class=""layui-input"">
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label"">支付网关</label>
        <div class=""layui-input-block"">
            <input type=""text"" name=""Pay_gateway""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 989, "\"", 1015, 1);
#line 23 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 997, Model.Pay_gateway, 997, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1016, 290, true);
                WriteLiteral(@" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" class=""layui-input"">
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label"">查询网关</label>
        <div class=""layui-input-block"">
            <input type=""text"" name=""Req_gateway""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1306, "\"", 1332, 1);
#line 29 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 1314, Model.Req_gateway, 1314, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1333, 375, true);
                WriteLiteral(@" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" class=""layui-input"">
        </div>
    </div>
    <div class=""layui-form-item"">
        <div class=""layui-inline"">
            <label class=""layui-form-label"">金额范围</label>
            <div class=""layui-input-inline"" style=""width: 100px;"">
                <input type=""text"" name=""Min_money"" placeholder=""￥""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1708, "\"", 1732, 1);
#line 36 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 1716, Model.Min_money, 1716, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1733, 269, true);
                WriteLiteral(@" lay-verify=""required""  autocomplete=""off"" class=""layui-input"">
            </div>
            <div class=""layui-form-mid"">-</div>
            <div class=""layui-input-inline"" style=""width: 100px;"">
                <input type=""text"" name=""Max_money"" placeholder=""￥""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2002, "\"", 2026, 1);
#line 40 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 2010, Model.Max_money, 2010, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2027, 894, true);
                WriteLiteral(@" lay-verify=""required""  autocomplete=""off"" class=""layui-input"">
            </div>
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label"">支持银行</label>
        <div class=""layui-input-block"" id=""bankTypeAll"">
            <input type=""checkbox"" lay-filter=""checkAllBankType"" name=""checkAllBankType"" title=""全选"" lay-skin=""primary"">
            <br />
        </div>
    </div>
    <div class=""layui-form-item"">
        <div class=""layui-input-block"">
            <button class=""layui-btn"" lay-submit="""" lay-filter=""submit"" id=""submit""><i class=""layui-icon layui-icon-loading layui-icon layui-anim layui-anim-rotate layui-anim-loop layui-hide""></i>立即提交</button>
            <button type=""button"" class=""layui-btn layui-btn-primary btn-open-close"">取消</button>
        </div>
    </div>
    <input type=""hidden"" name=""Plat_id"" id=""Plat_id""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2921, "\"", 2943, 1);
#line 57 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 2929, Model.Plat_id, 2929, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2944, 63, true);
                WriteLiteral(" />\r\n    <input type=\"hidden\" name=\"HDBanklist\" id=\"HDBanklist\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3007, "\"", 3030, 1);
#line 58 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\SettlePlat\Edit.cshtml"
WriteAttributeValue("", 3015, Model.Banklist, 3015, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3031, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3043, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3045, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "85145168ec1c79adf5791776edeae30841ac0dfa13464", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3136, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3155, 4228, true);
                WriteLiteral(@"
    <script>
        layui.config({
            base: '/themes/js/modules/'
        }).use(['layer', 'jquery', 'common', 'form'], function () {
            var form = layui.form, $ = layui.jquery, os = layui.common;
            var index = parent.layer.getFrameIndex(window.name);
            var active = {
                initPayType: function () {
                    var paytypeArr = $(""#HDBanklist"").val().split("","");
                    $.ajax({
                        type: 'get',
                        url: ""/api/settlebanktype/getapipages"",
                        success: function (res) {
                            if (res.msg === ""success"") {
                                var t = """";
                                $.each(res.data, function (i, val) {
                                    if (paytypeArr.indexOf(val.type_alias.toString()) != -1) {
                                        t += ""<input type=\""checkbox\"" lay-filter=\""banktype\"" name=\""banktype\"" value="" + val.type_alias");
                WriteLiteral(@" + "" title="" + val.type_name + "" lay-skin=\""primary\"" checked>"";
                                    } else {
                                        t += ""<input type=\""checkbox\"" lay-filter=\""banktype\"" name=\""banktype\"" value="" + val.type_alias + "" title="" + val.type_name + "" lay-skin=\""primary\"">"";
                                    }
                                    if ((i + 1) % 5 == 0) {
                                        t += ""<br />"";
                                    }
                                });
                                $('#bankTypeAll').append(t);
                                if ($("":checkbox[name=banktype]:not(:checked)"").length > 0) {
                                    $("":checkbox[name=checkAllBankType]"").prop(""checked"", """");
                                } else {
                                    $("":checkbox[name=checkAllBankType]"").prop(""checked"", ""checked"");
                                }
                                form.render();
    ");
                WriteLiteral(@"                        }
                        }
                    });
                }
            };
            active.initPayType();
            //监听提交
            form.on('submit(submit)', function (data) {
                $('#submit').attr('disabled', true).find('i').removeClass('layui-hide');
                var urls = ""api/settleplat/add"";
                if ($(""#Plat_id"").val() !== '0') {
                    urls = ""api/settleplat/edit"";
                }
                var strpayType = """";
                $.each($("":checkbox[name='banktype']:checked""), function () {
                    strpayType += "","" + $(this).val();
                });
                if (strpayType != """") {
                    strpayType = strpayType.substr(1);
                }
                data.field.banklist = strpayType;
                os.ajax(urls, data.field, function (res) {
                    $('#submit').attr('disabled', false).find('i').addClass('layui-hide');
                    if ");
                WriteLiteral(@"(res.statusCode == 200) {
                        var $$ = parent.layui.jquery;
                        $$(""#isSave"").val('1');
                        parent.layer.close(index);
                    }
                    else {
                        os.error(res.message);
                    }
                });
                return false;
            });
            form.on('checkbox(checkAllBankType)', function (data) {
                if (data.elem.checked) {
                    $("":checkbox[name='banktype']"").prop(""checked"", ""checked"");
                } else {
                    $("":checkbox[name='banktype']"").prop(""checked"", """");
                }
                form.render('checkbox');
            });
            form.on('checkbox(banktype)', function (data) {
                if (!data.elem.checked) {
                    $("":checkbox[name='checkAllBankType']"").prop(""checked"", """");
                    form.render('checkbox');
                }
            }); 
           ");
                WriteLiteral(" $(\".btn-open-close\").on(\'click\', function () {\r\n                parent.layer.close(index);\r\n            });\r\n        });</script>\r\n");
                EndContext();
            }
            );
            BeginContext(7386, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PayProject.Entity.SettlePlat> Html { get; private set; }
    }
}
#pragma warning restore 1591
