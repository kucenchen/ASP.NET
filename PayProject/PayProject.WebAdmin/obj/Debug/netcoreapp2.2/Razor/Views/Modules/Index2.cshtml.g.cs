#pragma checksum "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\Modules\Index2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d12f59f9918cb2d9b74af58428d7c86785c4d847"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modules_Index2), @"mvc.1.0.view", @"/Views/Modules/Index2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Modules/Index2.cshtml", typeof(AspNetCore.Views_Modules_Index2))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d12f59f9918cb2d9b74af58428d7c86785c4d847", @"/Views/Modules/Index2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Modules_Index2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\DiamondTech\KucenChen\PayProject\PayProject.WebAdmin\Views\Modules\Index2.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(58, 425, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d12f59f9918cb2d9b74af58428d7c86785c4d8475254", async() => {
                BeginContext(64, 61, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n");
                EndContext();
                BeginContext(204, 272, true);
                WriteLiteral(@"    <title>导航菜单管理</title>
    <link href=""/build/admin/css/admin.css"" rel=""stylesheet"" type=""text/css"" />
    <script type=""text/javascript"" src=""/build/admin/js/jquery.min.js""></script>
    <script type=""text/javascript"" src=""/build/admin/js/forms.func.js""></script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(483, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(485, 19043, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d12f59f9918cb2d9b74af58428d7c86785c4d8476902", async() => {
                BeginContext(491, 136, true);
                WriteLiteral("\r\n    <div class=\"topToolbar\"> <span class=\"title\">模块管理</span> <a href=\"javascript:location.reload();\" class=\"reload\">刷新</a></div>\r\n    ");
                EndContext();
                BeginContext(627, 17479, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d12f59f9918cb2d9b74af58428d7c86785c4d8477432", async() => {
                    BeginContext(679, 17420, true);
                    WriteLiteral(@"
        <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
            <tr align=""left"" class=""head"">
                <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid"" onclick=""CheckAll(this.checked);"" /></td>
                <td width=""3%"">ID</td>
                <td width=""22%"">栏目名称</td>
                <td width=""5%"">控制器</td>
                <td width=""5%"">视图</td>
                <td width=""20%"" align=""center"">排序</td>
                <td width=""32%"" class=""endCol"">操作</td>
            </tr>
        </table>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""2"" /></td>
                    <td width=""3%"">2					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""2"" /></td>
                 ");
                    WriteLiteral(@"   <td width=""22%""><span class=""minusSign"" id=""rowid_2"" onclick=""DisplayRows(2);"">关于我们</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=2&parentid=0&orderid=1"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""1"" />
                        <a href=""infoclass_save.php?action=down&id=2&parentid=0&orderid=1"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=0&id=2"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=2&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=2"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=2"" onclick=""return ConfDel(2);"">删除</a></sp");
                    WriteLiteral(@"an></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_2"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""3"" /></td>
                    <td width=""3%"">3					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""3"" /></td>
                    <td width=""22%"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""subType"">关于我们摘要</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=3&parentid=2&orderid=3"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""3"" />
                        <a href=""infoclass_save.ph");
                    WriteLiteral(@"p?action=down&id=3&parentid=2&orderid=3"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=0&id=3"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=3&checkcheckinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=3"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=3"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""1"" /></td>
                    <td width=""3%"">1					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""1"" /></td>
                    <td width=""");
                    WriteLiteral(@"22%""><span class=""minusSign"" id=""rowid_1"" onclick=""DisplayRows(1);"">网站公告</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=1&parentid=0&orderid=2"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""2"" />
                        <a href=""infoclass_save.php?action=down&id=1&parentid=0&orderid=2"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=0&id=1"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=1&checkinfo=false"" title=""点击进行显示与隐藏操作"">隐藏</a></span> | <span><a href=""infoclass_update.php?id=1"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=1"" onclick=""return ConfDel(2);"">删除</a></span></td>
   ");
                    WriteLiteral(@"             </tr>
            </table>
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""4"" /></td>
                    <td width=""3%"">4					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""4"" /></td>
                    <td width=""22%""><span class=""minusSign"" id=""rowid_4"" onclick=""DisplayRows(4);"">新闻动态</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=4&parentid=0&orderid=4"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""4"" />
                        <a href=""infoclass_save.php?action=d");
                    WriteLiteral(@"own&id=4&parentid=0&orderid=4"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=1&id=4"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=4&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=4"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=4"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""5"" /></td>
                    <td width=""3%"">5					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""5"" /></td>
                    <td width=""22%""><span clas");
                    WriteLiteral(@"s=""minusSign"" id=""rowid_5"" onclick=""DisplayRows(5);"">产品展示</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=5&parentid=0&orderid=5"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""5"" />
                        <a href=""infoclass_save.php?action=down&id=5&parentid=0&orderid=5"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=2&id=5"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=5&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=5"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=5"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </t");
                    WriteLiteral(@"r>
            </table>
        </div>
        <div rel=""rowpid_5"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""6"" /></td>
                    <td width=""3%"">6					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""6"" /></td>
                    <td width=""22%"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""subType"">笔记本电脑</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=6&parentid=5&orderid=6"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""6"" />
                        <a href=""infoclass_save.php?action=down&id=6&parentid=5&");
                    WriteLiteral(@"orderid=6"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=2&id=6"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=6&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=6"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=6"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_5"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""7"" /></td>
                    <td width=""3%"">7					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""7"" /></td>
                    <td width=""22%"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    WriteLiteral(@"&nbsp;<span class=""subType"">智能手机</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=7&parentid=5&orderid=7"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""7"" />
                        <a href=""infoclass_save.php?action=down&id=7&parentid=5&orderid=7"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=2&id=7"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=7&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=7"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=7"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>");
                    WriteLiteral(@"
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""8"" /></td>
                    <td width=""3%"">8					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""8"" /></td>
                    <td width=""22%""><span class=""minusSign"" id=""rowid_8"" onclick=""DisplayRows(8);"">成功案例</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=8&parentid=0&orderid=8"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""8"" />
                        <a href=""infoclass_save.php?action=down&id=8&parentid=0&orderid=8"" class=""rig");
                    WriteLiteral(@"htArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=2&id=8"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=8&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=8"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=8"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""9"" /></td>
                    <td width=""3%"">9					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""9"" /></td>
                    <td width=""22%""><span class=""minusSign"" id=""rowid_9"" onclick=""Displ");
                    WriteLiteral(@"ayRows(9);"">联系我们</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=9&parentid=0&orderid=9"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""9"" />
                        <a href=""infoclass_save.php?action=down&id=9&parentid=0&orderid=9"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=0&id=9"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=9&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=9"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=9"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>");
                    WriteLiteral(@"
        <div rel=""rowpid_9"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""10"" /></td>
                    <td width=""3%"">10					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""10"" /></td>
                    <td width=""22%"">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""subType"">联系我们摘要</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=10&parentid=9&orderid=10"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""10"" />
                        <a href=""infoclass_save.php?action=down&id=10&parentid=9&orderid=10"" class=""rightArrow"" ti");
                    WriteLiteral(@"tle=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=0&id=10"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=10&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=10"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=10"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        </div>
        <div rel=""rowpid_0"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dataTable"">
                <tr align=""left"" class=""dataTr"">
                    <td width=""5%"" height=""36"" class=""firstCol""><input type=""checkbox"" name=""checkid[]"" id=""checkid[]"" value=""11"" /></td>
                    <td width=""3%"">11					<input type=""hidden"" name=""id[]"" id=""id[]"" value=""11"" /></td>
                    <td width=""22%""><span class=""minusSign"" id=""rowid_11"" onclick=""DisplayR");
                    WriteLiteral(@"ows(11);"">软件下载</span></td>
                    <td width=""5%"">控制器</td>
                    <td width=""5%"">视图</td>
                    <td width=""20%"" align=""center"">
                        <a href=""infoclass_save.php?action=up&id=11&parentid=0&orderid=11"" class=""leftArrow"" title=""提升排序""></a>
                        <input type=""text"" name=""orderid[]"" id=""orderid[]"" class=""inputls"" value=""11"" />
                        <a href=""infoclass_save.php?action=down&id=11&parentid=0&orderid=11"" class=""rightArrow"" title=""下降排序""></a>
                    </td>
                    <td width=""32%"" class=""action endCol""><span><a href=""infoclass_add.php?infotype=3&id=11"">添加子栏目</a></span> | <span><a href=""infoclass_save.php?action=check&id=11&checkinfo=true"" title=""点击进行显示与隐藏操作"">显示</a></span> | <span><a href=""infoclass_update.php?id=11"">修改</a></span> | <span class=""nb""><a href=""infoclass_save.php?action=delclass&id=11"" onclick=""return ConfDel(2);"">删除</a></span></td>
                </tr>
            </table>
        ");
                    WriteLiteral("</div>\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(18106, 1415, true);
                WriteLiteral(@"
    <div class=""bottomToolbar""> <span class=""selArea""><span>选择：</span> <a href=""javascript:CheckAll(true);"">全部</a> - <a href=""javascript:CheckAll(false);"">无</a> - <a href=""javascript:SubUrlParam('infoclass_save.php?action=delallclass');"" onclick=""return ConfDelAll(1);"">删除</a>　<span>操作：</span><a href=""javascript:UpOrderID('infoclass_save.php');"">排序</a> - <a href=""javascript:ShowAllRows();"">展开</a> - <a href=""javascript:HideAllRows();"">隐藏</a></span> <a href=""infoclass_add.php"" class=""dataBtn"">添加网站栏目</a> </div>
    <div class=""page"">
        <div class=""pageText"">共有<span>13</span>条记录</div>
    </div>
    <div class=""quickToolbar"">
        <div class=""qiuckWarp"">
            <div class=""quickArea"">
                <span class=""selArea""><span>选择：</span> <a href=""javascript:CheckAll(true);"">全部</a> - <a href=""javascript:CheckAll(false);"">无</a> - <a href=""javascript:SubUrlParam('infoclass_save.php?action=delallclass');"" onclick=""return ConfDelAll(1);"">删除</a>　<span>操作：</span><a href=""javascript:UpOrderID('info");
                WriteLiteral(@"class_save.php');"">排序</a> - <a href=""javascript:ShowAllRows();"">展开</a> - <a href=""javascript:HideAllRows();"">隐藏</a></span> <a href=""infoclass_add.php"" class=""dataBtn"">添加网站栏目</a><span class=""pageSmall"">
                    <div class=""pageText"">共有<span>13</span>条记录</div>
                </span>
            </div>
            <div class=""quickAreaBg""></div>
        </div>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(19528, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
