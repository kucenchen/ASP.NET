#pragma checksum "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PayMch\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5c3518f0ddcf8dd8b3bfdeadd6e7b5c5da6293a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PayMch_Index), @"mvc.1.0.view", @"/Views/PayMch/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PayMch/Index.cshtml", typeof(AspNetCore.Views_PayMch_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5c3518f0ddcf8dd8b3bfdeadd6e7b5c5da6293a", @"/Views/PayMch/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae8485cd9f822422ef74d5ef8a2d0b24daf65d2", @"/Views/_ViewImports.cshtml")]
    public class Views_PayMch_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayProject.Entity.PayMch>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\work\PayProject\PayProject\PayProject\PayProject.WebAdmin\Views\PayMch\Index.cshtml"
  
    ViewBag.Title = "商户管理";
    Layout = PayProject.Common.Utils.Pjax();

#line default
#line hidden
            BeginContext(115, 11856, true);
            WriteLiteral(@"<div id=""container"">
    <style>
        /*.layui-inline {width: 20%;}*/
    </style>
    <script>
        var isLoadPayType = false;
        var isLoadPayPlat = false;
        var paytypeArr = new Array();
        var payplatArr = new Array();
        layui.use('layer', function () {
            var $ = layui.$
                , layer = layui.layer;
            $.ajax({
                type: 'get',
                url: ""/api/paytype/getapipages"",
                success: function (res) {
                    if (res.msg === ""success"") {
                        $.each(res.data, function (i, val) {
                            paytypeArr[val.type_id] = val.type_name;
                        });
                        isLoadPayType = true;
                    }
                }
            });
            $.ajax({
                type: 'get',
                url: ""/api/payplat/all"",
                success: function (res) {
                    if (res.statusCode === 200) {
         ");
            WriteLiteral(@"               $.each(res.data, function (i, val) {
                            payplatArr[val.plat_id] = val.plat_name;
                        });
                        isLoadPayPlat = true;
                    }
                }
            });
        });
    </script>
    <div class=""list-wall"">
        <div class=""layui-form list-search"" style=""margin-top:10px;"">
            <div class=""layui-inline"">
                <input class=""layui-input"" id=""mch_id"" autocomplete=""off"" placeholder=""输入商户号查询"">
            </div>
            <div class=""layui-inline"">
                <input class=""layui-input"" id=""mch_name"" autocomplete=""off"" placeholder=""输入商户名称查询"">
            </div>
            <div class=""layui-inline"">
                <select id=""selectPlantId"" lay-filter=""selectPlantId"" lay-verify="""" lay-search></select>
            </div>
            
            <button type=""button"" id=""search"" class=""layui-btn layui-btn-sm"" data-type=""toolSearch""><i class=""layui-icon layui-icon-search""");
            WriteLiteral(@"></i> 搜索</button>
            <br />
        </div>
        <table class=""layui-hide"" id=""tablist"" lay-filter=""tool""></table>
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
                form.render()");
            WriteLiteral(@";
                laydate.render({
                    elem: '#queryValue3'
                    , theme: '#393D49'
                    , type: 'datetime'
                    , format: 'yyyy/MM/dd HH:mm:ss'
                    , range: true
                });

                table.render({
                    toolbar: '#toolbar',
                    elem: '#tablist',
                    headers: os.getToken(),
                    url: '/api/paymch/getpages',
                    cols: [
                        [
                            { type: 'checkbox', fixed: 'left' },
                            { field: 'id', title: 'ID', width: 90, sort: true, fixed: 'left' },
                            { field: 'mch_id', title: '商户号', width: 130 },
                            { field: 'mch_name', title: '商户名称', width: 110 },
                            { field: 'plat_id', title: '所属平台', width: 100, templet: '<div>{{ ShowPayPlat(d.plat_id)}}</div>' },
                            { field: 'open_");
            WriteLiteral(@"pay_type_list', title: '支持类型', width: 200, templet: '<div>{{ ShowPayType(d.open_pay_type_list)}}</div>' },
                            { field: 'nullity', title: '是否开启', width: 100, templet: '#switchOpen' },
                            { field: 'create_time', title: '创建时间', width: 155, sort: true, templet: '<div>{{ Util.timestampToTime(d.create_time)}}</div>' },
                            { field: 'update_time', title: '更新时间', width: 155, sort: true, templet: '<div>{{ Util.timestampToTime(d.update_time)}}</div>' },
                            { width: 100, title: '操作', templet: '#tool' }
                        ]
                    ],
                    page: { limits: [10, 20, 50, 100, 500, 1000, 5000, 10000], groups: 8 },
                    id: 'tables',
                    initSort: {
                        field: 'id',
                        order: 'desc'
                    },
                    sort: true,
                    where: {
                        field: 'id',
         ");
            WriteLiteral(@"               order: 'desc'
                    }
                });
                var _order = ""desc"";
                var guid = '', active = {
                    reload: function () {
                        table.reload('tables',
                            {
                                page: {
                                    curr: 1
                                },
                                where: {
                                    mch_id: $(""#mch_id"").val(),
                                    mch_name: $(""#mch_name"").val(),
                                    plat_id: $(""#selectPlantId"").val(),
                                    field: 'id',
                                    order: _order
                                }
                            });
                    },
                    loadPlatInfo: function () {
                        $.ajax({
                            headers: os.getToken(),
                            type: 'get',
     ");
            WriteLiteral(@"                       //data: { page: 1,limit:1000 },
                            url: ""/api/payplat/all"",
                            success: function (res) {
                                var t = """";
                                if (res.statusCode === 200) {
                                    t = '<option value=""0"" selected=""selected"">请选择所属平台</option>';
                                    $.each(res.data, function (i, val) {
                                        t += '<option value=""' + val.plat_id + '"" >' + val.plat_name + '</option>';
                                    });
                                    $('#selectPlantId').append(t);
                                    form.render('select');
                                } else {
                                    os.error(res.message);
                                }
                            }
                        })
                    },
                    toolAdd: function () {
                        os.O");
            WriteLiteral(@"pen('添加商户', '/paymch/edit?id=-1', '850px', '750px', function () {
                            if (parseInt($(""#isSave"").val()) === 1) {
                                $(""#isSave"").val('0');
                                active.reload();
                            }
                        });
                    },
                    toolDel: function () {
                        var checkStatus = table.checkStatus('tables')
                            , data = checkStatus.data;
                        if (data.length === 0) {
                            os.error(""请选择要删除的项目~"");
                            return;
                        }
                        var str = '', strCount = 0;
                        $.each(data, function (i, item) {
                            str += item.id + "","";
                            strCount++;
                        });
                        title = '确定要删除所选的' + strCount + '项?';
                        layer.confirm(title, function (index) ");
            WriteLiteral(@"{
                            layer.close(index);
                            var loadindex = layer.load(1, {
                                shade: [0.1, '#000']
                            });
                            os.ajax('api/paymch/delete/', { parm: str }, function (res) {
                                layer.close(loadindex);
                                if (res.statusCode === 200) {
                                    active.reload();
                                    os.success('删除成功！');
                                } else {
                                    os.error(res.message);
                                }
                            });
                        });

                    },
                    paymchEdit: function (id) {
                        os.Open('编辑商户', '/paymch/edit?id=' + id, '850px', '750px', function () {
                            if (parseInt($(""#isSave"").val()) === 1) {
                                $(""#isSave"").val('0');
  ");
            WriteLiteral(@"                              active.reload();
                            }
                        })
                    },
                    toolSearch: function () {
                        active.reload();
                    }
                };
                active.loadPlatInfo();
                table.on('toolbar(tool)', function (obj) {
                    active[obj.event] ? active[obj.event].call(this) : '';
                });
                table.on('tool(tool)', function (obj) {
                    var data = obj.data;
                    if (obj.event === 'edit') {
                        active.paymchEdit(data.id);
                    }
                });
                $('.list-search .layui-btn').on('click', function () {
                    var type = $(this).data('type');
                    active[type] ? active[type].call(this) : '';
                });
                table.on('sort(tool)', function (obj) {
                    _order = obj.type;
         ");
            WriteLiteral(@"           table.reload('tables', {
                        initSort: obj,
                        where: {
                            field: obj.field,
                            order: obj.type
                        }
                    });
                });
                window.active = active;
            });
        function ShowPayType(typeli) {
            if (isLoadPayType) {
                if (typeof (typeli) == ""undefined"") {
                    return typeli;
                }
                var typeArr = typeli.split("","");
                var str = """";
                for (var i = 0; i < typeArr.length; i++) {
                    str += "","" + paytypeArr[typeArr[i]];
                }
                str = str.substr(1);
                return str;
            }
            else {
                return typeli;
            }
        }
        function ShowPayPlat(playid) {
            if (isLoadPayPlat) {
                if (typeof (playid) == ""undefined"") {
            WriteLiteral(@"
                    return playid;
                }
                return payplatArr[playid];
            }
            else {
                return playid;
            }
        }
    </script>
    <script type=""text/html"" id=""switchOpen"">
        <input type=""checkbox"" name=""status"" disabled value=""{{d.userid}}"" lay-skin=""switch"" lay-text=""正常|禁用"" {{ d.nullity==0?'checked':''}}>
    </script>
    <script type=""text/html"" id=""tool"">
        <a class=""layui-btn layui-btn-primary layui-btn-xs"" lay-event=""edit""><i class=""layui-icon""></i> 修改</a>
    </script>
</div>

");
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