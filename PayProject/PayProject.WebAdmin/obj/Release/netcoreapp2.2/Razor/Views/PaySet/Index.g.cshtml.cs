#pragma checksum "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PaySet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8b76ef87c206b90e057248969cda4b7e236e771"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaySet_Index), @"mvc.1.0.view", @"/Views/PaySet/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PaySet/Index.cshtml", typeof(AspNetCore.Views_PaySet_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b76ef87c206b90e057248969cda4b7e236e771", @"/Views/PaySet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_PaySet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PaySet\Index.cshtml"
  
    ViewBag.Title = "支付设置";
    Layout = PayProject.Common.Utils.Pjax();

#line default
#line hidden
            BeginContext(84, 518, true);
            WriteLiteral(@"
<div class=""layui-tab"">
    <ul class=""layui-tab-title"">
        <li class=""layui-this"">网站设置</li>
        <li>用户管理</li>
        <li>权限分配</li>
        <li>商品管理</li>
        <li>订单管理</li>
    </ul>
    <div class=""layui-tab-content"">
        <div class=""layui-tab-item layui-show"">内容1</div>
        <div class=""layui-tab-item"">内容2</div>
        <div class=""layui-tab-item"">内容3</div>
        <div class=""layui-tab-item"">内容4</div>
        <div class=""layui-tab-item"">
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(6865, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
