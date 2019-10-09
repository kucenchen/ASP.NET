#pragma checksum "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PayType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62cfc8f2f37073100714c78156f836b692e36dfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PayType_Index), @"mvc.1.0.view", @"/Views/PayType/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PayType/Index.cshtml", typeof(AspNetCore.Views_PayType_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62cfc8f2f37073100714c78156f836b692e36dfc", @"/Views/PayType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_PayType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayProject.Entity.PayType>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PayType\Index.cshtml"
  
    ViewBag.Title = "类型管理";
    Layout = PayProject.Common.Utils.Pjax();

#line default
#line hidden
            BeginContext(116, 121, true);
            WriteLiteral("\r\n<div id=\"container\">\r\n    <style>\r\n        /*.layui-inline {width: 20%;}*/\r\n    </style>\r\n    <div class=\"list-wall\">\r\n");
            EndContext();
            BeginContext(2457, 7327, true);
            WriteLiteral(@"        <table class=""layui-hide"" id=""tablist"" lay-filter=""tool""></table>
    </div>
    <input type=""hidden"" id=""isSave"" value=""0"" />
    <script type=""text/html"" id=""toolbar"">
        <div class=""layui-btn-container"">
            <button type=""button"" class=""layui-btn layui-btn-sm"" lay-event=""toolAdd""><i class=""layui-icon""></i> 新增</button>
            <button type=""button"" class=""layui-btn layui-btn-sm"" lay-event=""toolDel""><i class=""layui-icon""></i> 删除</button>
        </div>
    </script>
    <script>

        layui.config({
            base: '/themes/js/modules/'
        }).use(['table', 'layer', 'jquery', 'laydate', 'common', 'form'],
            function () {
                var table = layui.table,
                    layer = layui.layer,
                    $ = layui.jquery,
                    os = layui.common,
                    laydate = layui.laydate,
                    form = layui.form;
                form.render();
                laydate.render({
                  ");
            WriteLiteral(@"  elem: '#queryValue3'
                    , theme: '#393D49'
                    , type: 'datetime'
                    , format: 'yyyy/MM/dd HH:mm:ss'
                    , range: true
                });

                table.render({
                    toolbar: '#toolbar',
                    elem: '#tablist',
                    headers: os.getToken(),
                    url: '/api/paytype/getapipages',
                    cols: [
                        [
                            { type: 'checkbox', fixed: 'left' },
                            { field: 'type_id', title: 'ID', width: 90, sort: true, fixed: 'left' },
                            { field: 'type_name', title: '类型', width: 130 },
                            { field: 'type_alias', title: '英文名', width: 110 },
                            { field: 'type_note', title: '备注', width: 100 },
                            { field: 'create_time', title: '创建时间', width: 155, sort: true, templet: '<div>{{ Util.timestampToTime(d.creat");
            WriteLiteral(@"e_time)}}</div>' },
                            { field: 'update_time', title: '更新时间', width: 155, sort: true, templet: '<div>{{ Util.timestampToTime(d.update_time)}}</div>' },
                            { width: 100, title: '操作', templet: '#tool' }
                        ]
                    ],
                    page: { limits: [10, 20, 50, 100, 500, 1000, 5000, 10000], groups: 8 },
                    id: 'tables',
                    initSort: {
                        field: 'type_id',
                        order: 'desc'
                    },
                    sort: true,
                    where: {
                        field: 'type_id',
                        order: 'desc'
                    }
                });

                var guid = '', active = {
                    reload: function () {
                        table.reload('tables',
                            {
                                page: {
                                    curr: 1
          ");
            WriteLiteral(@"                      },
                                where: {
                                    
                                    field: 'userid',
                                    order: 'desc'
                                },
                                done: function () {
                                    Util.setMenuBtnRignt(4002);
                                }
                            });
                    },
                    toolAdd: function () {
                        os.Open('添加', '/paytype/edit', '600px', '300px', function () {
                            if (parseInt($(""#isSave"").val()) === 1) {
                                $(""#isSave"").val('0');
                                active.reload();
                            }
                        });
                    },
                    toolDel: function () {
                        var checkStatus = table.checkStatus('tables')
                            , data = checkStatus.data;
   ");
            WriteLiteral(@"                     if (data.length === 0) {
                            os.error(""请选择要删除的项目~"");
                            return;
                        }
                        var str = '', strCount = 0;
                        $.each(data, function (i, item) {
                            str += item.type_id + "","";
                            strCount++;
                        });
                        title = '确定要删除所选的' + strCount + '项?';
                        layer.confirm(title, function (index) {
                            layer.close(index);
                            var loadindex = layer.load(1, {
                                shade: [0.1, '#000']
                            });
                            os.ajax('api/paytype/delete/', { parm: str }, function (res) {
                                layer.close(loadindex);
                                if (res.statusCode === 200) {
                                    active.reload();
                               ");
            WriteLiteral(@"     os.success('删除成功！');
                                } else {
                                    os.error(res.message);
                                }
                            });
                        });

                    },
                    toolEdit: function (id) {
                        os.Open('编辑', '/paytype/edit?id=' + id, '600px', '300px', function () {
                            if (parseInt($(""#isSave"").val()) === 1) {
                                $(""#isSave"").val('0');
                                active.reload();
                            }
                        })
                    },
                    toolSearch: function () {
                        active.reload();
                    }
                };
                table.on('toolbar(tool)', function (obj) {
                    active[obj.event] ? active[obj.event].call(this) : '';
                });
                table.on('tool(tool)', function (obj) {
                    va");
            WriteLiteral(@"r data = obj.data;
                    if (obj.event === 'edit') {
                        active.toolEdit(data.type_id);
                    }
                });
                $('.list-search .layui-btn').on('click', function () {
                    var type = $(this).data('type');
                    active[type] ? active[type].call(this) : '';
                });
                table.on('sort(tool)', function (obj) {

                    table.reload('tables', {
                        initSort: obj,
                        where: {
                            field: obj.field,
                            order: obj.type
                        }
                    });
                });
                window.active = active;
            });
    </script>
    <script type=""text/html"" id=""switchOpen"">
        <input type=""checkbox"" name=""status"" disabled value=""{{d.userid}}"" lay-skin=""switch"" lay-text=""正常|禁用"" {{ d.nullity==0?'checked':''}}>
    </script>
    <script type=""te");
            WriteLiteral("xt/html\" id=\"tool\">\r\n        <a class=\"layui-btn layui-btn-primary layui-btn-xs\" lay-event=\"edit\"><i class=\"layui-icon\"></i> 修改</a>\r\n    </script>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PayProject.Entity.PayType> Html { get; private set; }
    }
}
#pragma warning restore 1591
