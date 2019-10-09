function json2edit(myjson) {
    myjson = [{
        "name": "房间名称",
        "code": "roomname",
        "type": "text",
        "value": "",
        "tip": "",
        "width": ""
    },
    {
        "name": "房间说明",
        "code": "room",
        "type": "textarea",
        "value": "",
        "tip": "",
        "width": ""
    },
    {
        "name": "房间开关",
        "code": "open",
        "type": "switch",
        "value": "",
        "tip": "",
        "width": ""
    },
    {
        "name": "房间类型",
        "code": "roomtype",
        "type": "checkbox",
        "tip": "",
        "items": [{
            "text": "金币场",
            "value": "jb",
            "check": true,
            "width": ""
        }, {
            "text": "体验场",
            "value": "ty",
            "check": false,
            "width": ""
        }]
    },
    {
        "name": "进入要求",
        "code": "enter",
        "type": "group",
        "tip": "范围1-100",
        "items": [{
            "type": "coin",
            "code": "min_enter",
            "value": "0",
            "width": "100",
            "tip":"￥"
        }, {
            "type": "mid",
            "name": "&nbsp;-",
            "value": " -",
            "width": ""
        }, {
            "type": "coin",
            "code": "max_enter",
            "value": "100",
            "width": "100",
            "tip": "￥"
        }]
    }
    ];

    var html = "";
    for (var p in myjson) {//遍历json数组时，这么写p为索引，0,1
        if (myjson[p].type == "group") {
            html += '<div class="layui-form-item"><div class="layui-inline"><label class="layui-form-label">' + myjson[p].name + '</label>';
            for (var ii in myjson[p].items) {
                if (myjson[p].items[ii].type == "mid") {
                    html += '<div class="layui-form-mid">' + myjson[p].items[ii].name + '</div>';
                }
                else {
                    if (myjson[p].items[ii].type == "text" || myjson[p].items[ii].type == "number" || myjson[p].items[ii].type == "coin") {
                        html += '<div class="layui-input-inline" ' + ((myjson[p].items[ii].width && myjson[p].items[ii].width != "") ? 'style="width:' + myjson[p].items[ii].width + 'px;"' : '') + '><input type="text" name="' + myjson[p].items[ii].code + '" lay-verify="required' + ((myjson[p].items[ii].type == "number" || myjson[p].items[ii].type == "coin") ? '|number' : '') + '" autocomplete="off" class="layui-input" placeholder="' + myjson[p].items[ii].tip + '"></div>';
                    }
                }
            }
            html += "</div>";
        }
        else {
            html += '<div class="layui-form-item"><label class="layui-form-label">' + myjson[p].name + '</label>'; 
        }

        
        if (myjson[p].type == "text" || myjson[p].type == "number" || myjson[p].type == "coin") {
            
            html += '<div class="layui-input-block"><input type="text" name="' + myjson[p].code + '" lay-verify="required' + ((myjson[p].type == "number" || myjson[p].type == "coin") ? '|number' : '') + '" autocomplete="off" class="layui-input" placeholder="' + myjson[p].tip + '" ' + ((myjson[p].width && myjson[p].width != "") ? 'style="width:' + myjson[p].width+'px;"':'') + '></div>';
        }

        if (myjson[p].type == "switch") {

            html += '<div class="layui-input-block"><input type="checkbox" name="' + myjson[p].code + '" lay-skin="switch" lay-text="开|关"></div>';
        }

        if (myjson[p].type == "textarea") {

            html += '<div class="layui-input-block"><textarea name="' + myjson[p].code + '" lay-verify="content" autocomplete="off" class="layui-textarea" placeholder="' + myjson[p].tip + '" ' + ((myjson[p].width && myjson[p].width != "") ? 'style="width:' + myjson[p].width + 'px;"' : '') + '>' + myjson[p].value + '</textarea></div>';
        }
        if (myjson[p].type == "select") {
            html += '<div class="layui-input-block"><select name="' + myjson[p].code + '" ' +( (myjson[p].width && myjson[p].width != "") ? 'style="width:' + myjson[p].width + 'px;"' : '') + '>';
            for (var ii in myjson[p].items) {
                html += '<option value="' + myjson[p].items[ii].value + '"  ' + ((myjson[p].items[ii].check==true) ? ' selected=""':'') + '>' + myjson[p].items[ii].text + '</option>';
            }
            html += '</select></div>';
        }

        if (myjson[p].type == "radio") {
            html += '<div class="layui-input-block">';
            for (var ii in myjson[p].items) {
                html += '<input type="radio" name="' + myjson[p].code + '" value="' + myjson[p].items[ii].value + '" title="' + myjson[p].items[ii].text + '"   ' + ((myjson[p].items[ii].check==true) ? ' checked=""' : '') + '>';            
            }
            html += '</div>';
        }

        if (myjson[p].type == "checkbox") {
            html += '<div class="layui-input-block">';
            for (var ii in myjson[p].items) {
                html += '<input type="checkbox" name="' + myjson[p].code + '" value="' + myjson[p].items[ii].value + '" title="' + myjson[p].items[ii].text + '"   ' + ((myjson[p].items[ii].check==true) ? ' checked=""' : '') + '>';
            }
            html += '</div>';
        }

        
        html += '</div>';
    }   
    return html;
}