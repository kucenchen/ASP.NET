#pragma checksum "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\Paytest\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b03397ad502fe6e434e29d780458036372c4c6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Paytest_Edit), @"mvc.1.0.view", @"/Views/Paytest/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Paytest/Edit.cshtml", typeof(AspNetCore.Views_Paytest_Edit))]
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
#line 1 "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\_ViewImports.cshtml"
using PayProject.WebAdmin;

#line default
#line hidden
#line 2 "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\_ViewImports.cshtml"
using PayProject.WebAdmin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b03397ad502fe6e434e29d780458036372c4c6a", @"/Views/Paytest/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Paytest_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayProject.Entity.PayMch>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-form form-cus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\Paytest\Edit.cshtml"
  
    ViewBag.Title = "充值测试";
    Layout = "~/Views/_Layout.cshtml";

#line default
#line hidden
            BeginContext(109, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(115, 3020, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b03397ad502fe6e434e29d780458036372c4c6a4276", async() => {
                BeginContext(159, 507, true);
                WriteLiteral(@"
        <div class=""layui-form-item"">
            <div class=""layui-inline"">
                <label class=""layui-form-label"">所属渠道</label>
                <div class=""layui-input-block"" style=""width:280px;"">
                    <select id=""selectPlat"" name=""selectPlat"" lay-verify="""" lay-search></select>
                </div>
            </div>
            <div class=""layui-inline"">
                <label class=""layui-form-label"">充值金额:</label>
                <div class=""layui-input-block"">
");
                EndContext();
                BeginContext(856, 293, true);
                WriteLiteral(@"                    <input type=""number"" min=""100"" max=""1000"" step=""100"" value=""100"" id=""money"" name=""money"" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" placeholder=""请输入金额"" class=""layui-input"" style=""width: 100px;"">
                </div>
            </div>
        </div>
");
                EndContext();
                BeginContext(2007, 1076, true);
                WriteLiteral(@"        <div class=""layui-form-item"">
            <label class=""layui-form-label"">用户ID</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""userid"" id=""userid"" lay-verify=""required"" lay-verType=""tips"" autocomplete=""off"" placeholder=""请输入用户ID"" class=""layui-input"" style=""width:600px;"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">支持方式</label>
            <div class=""layui-input-block"" id=""payTypeAll"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn"" lay-submit="""" lay-filter=""submit"" id=""submit""><i class=""layui-icon layui-icon-loading layui-icon layui-anim layui-anim-rotate layui-anim-loop layui-hide""></i>立即提交</button>
                <button type=""reset"" class=""layui-btn layui-btn-primary btn-open-close"">取消</button>
            </div>
        </div>
        <input type=""hidden"" n");
                WriteLiteral("ame=\"HDopen_pay_type_list\" id=\"HDopen_pay_type_list\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3083, "\"", 3116, 1);
#line 57 "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\Paytest\Edit.cshtml"
WriteAttributeValue("", 3091, Model.Open_pay_type_list, 3091, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3117, 11, true);
                WriteLiteral(" />\r\n\r\n    ");
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
            BeginContext(3135, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3154, 5119, true);
                WriteLiteral(@"
    <script>
        layui.config({
            base: '/themes/js/modules/'
        }).use(['layer', 'jquery', 'common', 'form'], function () {
            var form = layui.form, $ = layui.$, os = layui.common;
            var index = parent.layer.getFrameIndex(window.name);
            var type = 0, active = {
                loadPayPlat: function () {
                    $.ajax({
                        headers: os.getToken(),
                        type: 'get',
                        //data: { page: 1,limit:1000 },
                        url: ""/api/payplat/all"",
                        success: function (res) {
                            var t = """";
                            if (res.statusCode === 200) {
                                $.each(res.data, function (i, val) {
                                    t += '<option value=""' + val.plat_id + '"" ' + (val.plat_id === parseInt($(""#HDPlat_id"").val()) ? ""selected"" : """") + '>' + val.plat_name + '</option>';
                         ");
                WriteLiteral(@"       });
                                $('#selectPlat').append(t);
                                form.render('select');
                            } else {
                                os.error(res.message);
                            }
                        }
                    })
                },

                initPayType: function () {
                    var paytypeArr = $(""#HDopen_pay_type_list"").val().split("","");
                    $.ajax({
                        type: 'get',
                        url: ""/api/paytype/getapipages"",
                        success: function (res) {
                            if (res.msg === ""success"") {
                                var t = """";
                                $.each(res.data, function (i, val) {
                                    if (paytypeArr.indexOf(val.type_id.toString()) != -1) {
                                        t += ""<input type=\""radio\"" name=\""paytype\"" value="" + val.type_id + "" title="" + val.ty");
                WriteLiteral(@"pe_name + "" lay-skin=\""primary\"" checked>"";
                                    } else {
                                        t += ""<input type=\""radio\"" name=\""paytype\"" value="" + val.type_id + "" title="" + val.type_name + "" lay-skin=\""primary\"">"";
                                    }
                                });
                                $('#payTypeAll').append(t);
                                form.render();
                            }
                        }
                    });

                },

                subs: function () {
                    var Platid = $(""#selectPlat"").val();
                    var Money = $(""#money"").val();
                    var Userid = $(""#userid"").val();
                    var strpayType = """";
                    $.each($("":radio[name='paytype']:checked""), function () {
                        strpayType += "","" + $(this).val();
                    });
                    if (strpayType != """") {
                        s");
                WriteLiteral(@"trpayType = strpayType.substr(1);
                    }
                    var Paytype = strpayType;
                    layui.common.ajax(
                        '/api/paytest/pay',
                        { Platid: Platid, Money: Money, Userid: Userid, Paytype: Paytype },
                        function (res) {

                        })
                }

            };
            active.loadPayPlat();
            active.initPayType();
            //监听提交
            form.on('submit(submit)', function (data) {
                $('#submit').attr('disabled', true).find('i').removeClass('layui-hide');
                var urls = 'api/paytest/pay';
                var Platid = $(""#selectPlat"").val();
                var Money = $(""#money"").val();
                var Userid = $(""#userid"").val();
                var strpayType = """";
                $.each($("":radio[name='paytype']:checked""), function () {
                    strpayType += "","" + $(this).val();
                });
      ");
                WriteLiteral(@"          if (strpayType != """") {
                    strpayType = strpayType.substr(1);
                }
                var Paytype = strpayType;
            
                os.ajax(urls, { Platid: Platid, Money: Money, Userid: Userid, Paytype: Paytype }, function (res) {
                    $('#submit').attr('disabled', false).find('i').addClass('layui-hide');
                    console.log(res.content);
                    window.open(res.content);
                    //if (res.statusCode === 200) {
                    //    var $$ = parent.layui.jquery;
                    //    $$(""#isSave"").val('1');
                    //    parent.layer.close(index);
                    //} else {
                    //    os.error(res.message);
                    //}
                });
                return false;
            });
            //$("".btn-open-close"").on('click', function () {
            //    parent.layer.close(index);
            //});


        });


    </script>
");
                EndContext();
            }
            );
            BeginContext(8276, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PayProject.Entity.PayMch> Html { get; private set; }
    }
}
#pragma warning restore 1591
