var Util = new Object({
    timestampToTime: function (timestamp) {
        if (timestamp == 0) return "";
        var date = new Date(timestamp * 1000);//时间戳为10位需*1000，时间戳为13位的话不需乘1000
        var Y = date.getFullYear() + '-';
        var M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-';
        var D = parseInt(date.getDate()) < 10 ? '0' + date.getDate() + ' ' : date.getDate() + ' ';
        var h = date.getHours() < 10 ? '0' + date.getHours() + ':' : date.getHours() + ':';
        var m = date.getMinutes() < 10 ? '0' + date.getMinutes() + ':' : date.getMinutes() + ':';
        var s = date.getSeconds() < 10 ? '0' + date.getSeconds() + '' : date.getSeconds();
        var d = Y + M + D + h + m + s;
        return d;
    },
    TimeTotimestamp: function (time) {
        if (time == "") return 0;
        var T = new Date(time); 
        return T.getTime()/1000;
    },
    ShowAccountStatu: function (statu) {
        if (statu == 0) {
            return '<span style="color: #00CD00">正常</span>';
        } else {
            return '<span style="color: #FF0000">禁用</span>';
        }
    },
    Fen2Yuan: function (s) {
        var sign = "";
        var s1 = String(s).substring(0, 1);
        if (s1 === "-") {
            s = String(s).substring(1);
            sign = "-";
        }
        n = 2;
        s = (parseFloat((s + "").replace(/[^\d\.-]/g, "")) / 100).toFixed(n) + "";
        var l = s.split(".")[0].split("").reverse(),
            r = s.split(".")[1];
        t = "";
        for (i = 0; i < l.length; i++) {
            t += l[i] + ((i + 1) % 4 == 0 && (i + 1) != l.length ? "," : "");
        }
        return sign + t.split("").reverse().join("") + "." + r;
    },
    ShowOrderStatu: function (statu) {
        if (statu == 0) {
            return '<span style="color: #FF0000">失败</span>';
        } else {
            return '<span style="color: #00CD00">成功</span>';
        }
    },
    ShowleaveType(leave_reason) {
        var str = leave_reason;
        switch (leave_reason) {
            case 0:
                str = '<span style="color: #00CD00">正常离开</span>';
                break;
            case 1:
                str = '<span style="color: #FF0000">人满为患</span>';
                break;
            case 2:
                str = '<span style="color: #FF0000">断线超时</span>';
                break;
            case 3:
                str = '<span style="color: #FF0000">金币不足</span>';
                break;
            case 4:
                str = '<span style="color: #FF0000">管理踢出</span>';
                break;
            default:
        }
        return str;
    },
    GetUserOpTypeName: function (value) {
        return recordConfig.userChangeType[value];
    },
    getAuditStatusWithColor: function (value) {
        //return '<span style="color: #00CD00">未审核</span>';
        return '<span style="color: ' + recordConfig.auditStatusColor[value] + '">' + recordConfig.auditStatus[value] + '</span>';
    },
    getTxAuditStatusWithColor: function (value) {
        return '<span style="color: ' + recordConfig.txAuditStatusColor[value] + '">' + recordConfig.txAuditStatus[value] + '</span>';
    },
    setMenuBtnRignt: function (value) {
        layui.use(['jquery'], function () {
            $ = layui.jquery,
                $.ajax({
                    url: '/api/rolemenu/menubtnpermissions?namecode=' + value,
                    headers: os.getToken(),
                    type: 'get',
                    dataType: 'json',
                    success: function (result) {
                        if (result.data.length > 0) {
                            var packJson1 = result.data;
                            for (var p in packJson1) {
                                $("[lay-action='" + packJson1[p].funType + "']").removeClass('layui-hide');
                            }
                        }
                    }
                });
        });
    }
});
//用户日志类型
var recordConfig = (function ($) {
    $.shortMessageType = {
        0: "注册",
        1: "登录",
        2: "绑定手机",
        3: "找回登录",
        4: "找回保险箱"
    }
    $.userChangeType = {
        0: "冻结",
        1: "解冻",
        2: "转账设置",
        3: "昵称变更",
        4: "节点设置",
        5: "靓号赠送"
    }
    $.userLoginType = {
        0: "大厅",
        1: "游戏"
    }
    $.goldChangeType = {
        0: "存取",
        1: "游戏",
        2: "奖励",
        3: "划拔"
    }
    $.bankGoldChangeType = {
        0: "存取",
        1: "充值",
        2: "转账",
        3: "提现",
        4: "奖励",
        5: "划拨",
        6: "代理提现"
    }
    $.transSceneType = {
        0: "大厅",
        1: "网站",
        2: "其他"
    }
    $.transStatusType = {
        0: "等待处理",
        1: "处理中",
        2: "交易冻结",
        3: "交易取消",
        4: "交易成功"
    }
    $.auditStatus = {
        0: "未审核",
        1: "审核中",
        2: "通过",
        3: "冻结",
        4: "拒绝",
        5: "打款中",
        6: "打款失败",
        7: "打款完成"
    }
    $.auditStatusColor = {
        0: "#919191",
        1: "#7AC5CD",
        2: "#32CD32",
        3: "#FF5722",
        4: "#DEB887",
        5: "#5FB878",
        6: "#FFB800",
        7: "#32CD32"
    }
    $.txAuditStatus = {
        0: "客服待审核",
        1: "客服审核中",
        2: "客服冻结",
        3: "客服拒绝",
        4: "客服通过",
        5: "财务待审核",
        6: "财务审核中",
        7: "财务冻结",
        8: "财务拒绝",
        9: "财务通过",
        10: "等待打款",
        11: "打款中",
        12: "打款失败",
        13: "打款完成"
    }
    $.txAuditStatusColor = {
        0: "#BABABA",
        1: "#7AC5CD",
        2: "#FF5722",
        3: "#DEB887",
        4: "#32CD32",
        5: "#919191",
        6: "#7AC5CD",
        7: "#FF5722",
        8: "#DEB887",
        9: "#5FB878",
        10: "#5FB878",
        11: "#FFB800",
        12: "#FFB800",
        13: "#32CD32"
    }
    $.leaveType = {
        0: "正常离开",
        1: "人满为患",
        2: "断线超时",
        3: "金币不足",
        4: "管理踢出"
    }
    return $;
})(window.config || {});