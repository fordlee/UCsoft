//*平台公用函数
//*作者：唐有炜
//*时间：2014年08月23日

//兼容ie8支持trim 2014-08-25 By 唐有炜
//================================================================
String.prototype.trim = function() { return Trim(this); };
function LTrim(str) {
    var i;
    for (i = 0; i < str.length; i++) {
        if (str.charAt(i) != " " && str.charAt(i) != " ")break;
    }
    str = str.substring(i, str.length);
    return str;
}

function RTrim(str) {
    var i;
    for (i = str.length - 1; i >= 0; i--) {
        if (str.charAt(i) != " " && str.charAt(i) != " ")break;
    }
    str = str.substring(0, i + 1);
    return str;
}

function Trim(str) {
    return LTrim(RTrim(str));
}
//=========================================================================================

//======================================
//页面刷新 2014-09-10 By 唐有炜
function refresh(url) {
    if (arguments.length > 0) {
        location.href = url;
    } else {
        location.href = "./";
    }
}

//====================================

//弹出框封装结束开始
//需要引用
//<script src="/Themes/default/js/artDialog/lib/jquery-1.10.2.js"></script>
//<link rel="stylesheet" href="/Themes/default/js/artDialog/css/ui-dialog.css">
//<script src="/Themes/default/js/artDialog/dist/dialog-plus-min.js"></script>
//修正margin:10px 10px -10px 10px
function showMsg(msg, msgcss, callback) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
    case "Success":
        cssname = "pcent success";
        break;
    case "Error":
        cssname = "pcent error";
        break;
    case "Warn":
        cssname = "pcent error";
        break;
    default:
        cssname = "pcent warning";
        break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msg + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    //3秒后清除提示
    setTimeout(function() {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 2000);
    //执行回调函数
    if (typeof (callback) == "function") callback();
}

//iframe里面弹出对话框并自动关闭
function showTopMsg(msg, title, msgcss, w, h, t) {
    var cssname = "";
    switch (msgcss) {
    case "Success":
        cssname = "dialog_ok";
        break;
    case "Error":
        cssname = "dialog_error";
        break;
    case "Warn":
        cssname = "dialog_confirm";
        break;
    default:
        cssname = "dialog_alert";
        break;
    }
    var content = "<div class='" + cssname + "'>" + msg + "</div>";
    if (arguments.length == 6) {
        showTopContentDialog("show_top_msg", content, title, w, h);
        setTimeout(function() {
            if (undefined != top.dialog.list["show_top_msg"]) {
                top.dialog.list["show_top_msg"].close().remove();
            }
        }, t);
    } else {
        showTopContentDialog("show_top_msg", content, title, 400, 95);
        setTimeout(function() {
            if (undefined != top.dialog.list["show_top_msg"]) {
                top.dialog.list["show_top_msg"].close().remove();
            }
        }, 1000);
    }

}


//iframe里面弹出对话框
function showTopTips(msg, title, msgcss) {
    var cssname = "";
    switch (msgcss) {
    case "Success":
        cssname = "dialog_ok";
        break;
    case "Error":
        cssname = "dialog_error";
        break;
    case "Warn":
        cssname = "dialog_alert";
        break;
    default:
        cssname = "dialog_alert";
        break;
    }
    var content = "<div class='" + cssname + "'>" + msg + "</div>";
    showTopDialog("show_top_tip", content, title, 400, 95);
}


//弹出对话框，带阴影==============================================
function showDialog(msg, title, w, h, okCallback, cancelCallback) {
    var d = dialog({
        id: "show_dialog",
        title: title,
        content: msg,
        width: w,
        height: h,
        ok: okCallback,
        cancelValue: '取消',
        cancel: cancelCallback
    });
    d.showModal();
}

//顶层弹出对话框，带阴影==============================================
function showTopDialog(id, msg, title, w, h, okCallback, cancelCallback) {
    var d = top.dialog({
        id: id,
        title: title,
        content: msg,
        width: w,
        height: h,
        okValue: '确 定',
        ok: okCallback,
        cancelValue: '取消',
        cancel: cancelCallback
    });
    d.showModal();
}


//顶层弹出对话框，带阴影,不带按钮==============================================
function showTopContentDialog(id, msg, title, w, h) {
    var d = top.dialog({
        id: id,
        title: title,
        content: msg,
        width: w,
        height: h,
        ok: false,
        cancel: false
    });
    d.showModal();
}

//弹出对话框，不带按钮，不带阴影==============================================
function showContentDialog(msg, title, w, h) {
    var d = dialog({
        id: "show_dialog",
        title: title,
        content: msg,
        width: w,
        height: h
    });
    d.show();
}


//iframe里面弹出对话框并自动关闭
function showTopConfirm(msg, title, okCallback,cancelCallback) {
    var content = "<div class='dialog_confirm'>" + msg + "</div>";
    showTopDialog("show_top_confirm", content, title, 400, 95, okCallback, cancelCallback);
}


//============================================================================
//弹出iframe窗口，带阴影，用作表单===============================================
//2014-09-03 By 唐有炜
//Dialod id:id Iframe id:frm_{id}
function showWindow(id, url, title, w, h, okCallback) {
    var d = dialog({
        id: id,
        title: title,
        //url: url,//此方式不支持滚动条
        content: '<iframe src="' + url + '" id="frm_' + id + '" name="frm_' + id + '" style="border-bottom: 1px solid #E5E5E5;" width="100%" height="100%" width="100%" frameborder="0" scrolling="auto"></iframe>',
        width: w,
        height: h,
        okValue: '确 定',
        ok: okCallback,
        cancelValue: '取消',
        cancel: function() {
            d.close().remove();
        }
    });
    d.showModal();
}

//============================================================================
//顶层弹出iframe窗口，带阴影，用作表单===============================================
//2014-09-03 By 唐有炜
function showContentWindow(id, url, title, w, h) {
    var d = dialog({
        id: id,
        title: title,
        //url: url,//此方式不支持滚动条
        content: '<iframe src="' + url + '" id="frm_' + id + '" name="frm_' + id + '" style="border-bottom: 1px solid #E5E5E5;" width="100%" height="100%" width="100%" frameborder="0" scrolling="auto"></iframe>',
        width: w,
        height: h,
        left: 0,
        top: 0,
        fixed: true,
        resize: false,
        drag: true,
        lock: true,
        onshow: function() { showTopDialog("show_loading", "<div class='dialog_loading'>页面加载中，请稍后...</div>", "温馨提示", 400, 95); }
    });
    d.show();
}


//iframe里面弹出对话框并自动关闭
function showTopWindow(id, url, title, w, h, okCallback,cancelCallback) {
    //在iframe里面打开弹出框并自动关闭
    var d;
    if (undefined == cancelCallback) {
        d = top.dialog({
            id: id,
            title: title,
            //url: url,//此方式不支持滚动条
            content: '<iframe src="' + url + '" id="frm_' + id + '" name="frm_' + id + '" style="border-bottom: 1px solid #E5E5E5;" width="100%" height="100%" width="100%" frameborder="0" scrolling="auto"></iframe>',
            width: w,
            height: h,
            left: 0,
            top: 0,
            fixed: true,
            resize: false,
            drag: true,
            lock: true,
            okValue: '确 定',
            ok: okCallback,
            cancelValue: '取消',
            cancel: function(){},
            onshow: function () { showTopDialog("show_loading", "<div class='dialog_loading'>页面加载中，请稍后...</div>", "温馨提示", 400, 95); }

        });
    } else {
        d = top.dialog({
            id: id,
            title: title,
            //url: url,//此方式不支持滚动条
            content: '<iframe src="' + url + '" id="frm_' + id + '" name="frm_' + id + '" style="border-bottom: 1px solid #E5E5E5;" width="100%" height="100%" width="100%" frameborder="0" scrolling="auto"></iframe>',
            width: w,
            height: h,
            left: 0,
            top: 0,
            fixed: true,
            resize: false,
            drag: true,
            lock: true,
            okValue: '确 定',
            ok: okCallback,
            cancelValue: '取消',
            cancel: cancelCallback,
            onshow: function () { showTopDialog("show_loading", "<div class='dialog_loading'>页面加载中，请稍后...</div>", "温馨提示", 400, 95); }

        });
    }
    d.showModal();
}


//iframe里面弹出对话框并自动关闭
function showTopContentWindow(id, url, title, w, h) {
    //在iframe里面打开弹出框并自动关闭
    var d = top.dialog({
        id: id,
        title: title,
        //url: url,//此方式不支持滚动条
        content: '<iframe src="' + url + '" id="frm_' + id + '" name="frm_' + id + '" style="border-bottom: 1px solid #E5E5E5;" width="100%" height="100%" width="100%" frameborder="0" scrolling="auto"></iframe>',
        width: w,
        height: h,
        left: 0,
        top: 0,
        fixed: true,
        resize: true,
        drag: true,
        lock: true,
        onshow: function() { showTopDialog("show_loading", "<div class='dialog_loading'>页面加载中，请稍后...</div>", "温馨提示", 400, 95); },
        oniframeload: function() {
            alert("ccc");
        }
    });
    d.showModal();
}

//===========================================================
//弹出框封装结束


//============================================
//formtip===================================
(function($) {
    $.fn.formtip = function(message, second, option) {
//        if (second == undefined)
//            {second = 1;}
        $(".tip-yellow").remove();
        $(this).removeClass("success").addClass("error");
        $(this).poshytip({
            className: 'tip-yellow',
            content: message,
            //timeOnScreen: second * 1000, 
            showOn: 'none',
            alignTo: 'target',
            alignX: 'inner-left',
            offsetX: 0,
            offsetY: 5
        }).poshytip("show");
        //$(this).focus();//注意，要结合jquery.validate必须取消
    };
})(jQuery);

//====================================


//==================================
//显示加载中 14-09-06 By 唐有炜
//需要 <div id="progressBar" class="progressBar" style="">数据加载中，请稍等...</div>
function showLoading() {
    //$(document.body).append("<div id=\"background\" class=\"background\" style=\"display: none; \"></div> <div id=\"progressBar\" class=\"progressBar\" style=\"display: none; \">数据加载中，请稍等...</div> ");
    var ajaxbg = $("#progressBar");
    ajaxbg.show();
}

function hideLoading() {
    var ajaxbg = $("#progressBar");
    ajaxbg.hide();
}

//===================================================


//=================================
//获取bootgrid选中id(兼容LierUI自定义checkbox) 14-09-18 By 唐有炜
function get_selected_ids(grid_id) {
    var c = document.getElementById(grid_id).getElementsByTagName("input");
    var ids = "";
    var rowIds = [];
    for (var i = 0; i < c.length; i++) {
        if (c[i].type == "checkbox" && c[i].checked && c[i].value != "all" && c[i].value != "on") {
            rowIds.push(c[i].value);
        }
    }
    ids = rowIds.join(",");
    return ids;
}

///////////////////////////////////////////////////////////

//====================================
//js字符省略显示 14-09-18 By 唐有炜
function shortString(s, l, tag) {
    if (s.length > l) {
        return s.substring(0, l) + tag;
    } else {
        return s;
    }
}

//======================================


//MyHtmlhelper.js======================================================================================
//用于页面展示使用====================================================================================
//14-09- 25 By 唐有炜
/// <summary>
/// 根据id获取制定下拉框的值
/// </summary>
/// <param name="htmlHelper"></param>
/// <param name="options">选项</param>
/// <param name="key"></param>
/// <param name="replaceValue"></param>
/// <returns></returns>
function GetOptionValue(key, options) {
    var str_arr = options.split(',');
    for (var i = 0; i < str_arr.length; i++) {
        var str = str_arr[i];
        var k = str.split('|')[0];
        var v = str.split('|')[1];
        if (key == k) {
            return v;
        }
    }
    return "暂未填写";

}

//========================================================================================
//=====================================================================================

/*
   日期格式2010-10-13
*/
//计算两个日期的相差天数
function DateDiff(startDate, endDate) {
    var aDate, oDate1, oDate2, iDays;
    aDate = startDate.split('-');
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
    aDate = endDate.split('-');
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24); //把相差的毫秒数转换为天数
    return iDays;
}



/*
   日期格式2010-10-13
*/
//计算两个日期的相差天数
//默认格式为"2014-11-03",根据自己需要改格式和方法 141103 By 唐有炜
//date1 起始日期
//date2 终止日期
function MonthDiff(date1, date2) {
    var year1 = date1.substr(0, 4);
    var year2 = date2.substr(0, 4);
    var month1 = date1.substr(5, 2);
    var month2 = date2.substr(5, 2);
    var len = (year2 - year1) * 12 + (month2 - month1);
    //alert(len);

    var day = date2.substr(8, 2) - date1.substr(8, 2);
    //alert(day);

    if (day > 0) {
        len += 1;
    }
    else if (day < 0) {
        len -= 1;
    }
    return len;
}

/*
   日期格式2010-10-13
*/
//计算两个日期的相差年数
function YearDiff(startDate, endDate) {
    var syear, eyear, iYears;
    //console.log(startDate.split('-'));
    //console.log(endDate.split('-'));
    syear = startDate.split('-')[0];
    eyear = endDate.split('-')[0];
    iYears = eyear - syear; //相差年数
    return iYears;
}

//获取客户端时间
function get_client_time() {
    var now = new Date();
    var curr_datetime = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate() + ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
    return curr_datetime;
}


//根据身份证返回生日
function get_birthday_by_idcard(StrNo) {
    var bir;
    switch (StrNo.length) {
    case 15:
        bir = StrNo.substr(6, 2) + "-" + StrNo.substr(8, 2) + "-" + StrNo.substr(10, 2);
        break;
    case 18:
        bir = StrNo.substr(6, 4) + "-" + StrNo.substr(10, 2) + "-" + StrNo.substr(12, 2);
        break;
    default:
        bir = get_current_date();
    }
    return bir;
}


function get_current_date() {
    var now_date = new Date();
    var now = now_date.getFullYear() + "-" + now_date.getMonth() + "-" + now_date.getDate();
    return now;
}

//根据生日获取星座
function get_xingzuo_by_bir(bir) {
    var m = parseInt(bir.split("-")[1]);
    var d = parseInt(bir.split("-")[2]);
    var XZDict = '摩羯水瓶双鱼白羊金牛双子巨蟹狮子处女天秤天蝎射手';
    var Zone = new Array(1222, 122, 222, 321, 421, 522, 622, 722, 822, 922, 1022, 1122);

    var i = 0;
    if (((100 * m + d) > Zone[0]) || (100 * m + d) < Zone[1]) {
        i = 0;
    } else {
        for (i = 1; i < 12; i++) {
            if ((100 * m + d) >= Zone[i] && (100 * m + d) < Zone[i + 1]) {
                break;
            }
        }
    }
    result = XZDict.substring(2 * i, 2 * i + 2) + "座";
    return result;
}

//根据生日获取属相
function get_shuxiang_by_bir(bir) {
    var year = bir.split("-")[0];
    var sxnames = ["鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪"];
    var sx = year % 12 - 3;
    if (sx <= 0) {
        sx += 12;
    }
    //alert(sx);
    return "属" + sxnames[sx - 1];
}

//图片上传js===========================================================================================
//2014-10-17 修改 By 唐有炜
//参数说明：
//         formId:表单id
//         uppath:typpe="file"的id
//         hidvalue:保存路径的input：text="hidden"的id
//         pre:图片预览的img
function PicUpload(formId, uppath, hidvalue, pre) {
    var submitUrl = "/UploadApi/?action=AttachFile&UpFilePath=" + uppath + "&IsWater=1&IsThumbnail=1";
    $("#" + formId).ajaxSubmit({
        type: "POST",
        cache: false,
        url: submitUrl,
        dataType: "json",
        beforeSend: function() {
            showTopDialog("show_upload_loding", "<div class='dialog_loading'>图片上传中，请稍后...</div>", "温馨提示", 400, 95);
        },
        complete: function() {
        },
        success: function(result, textStatus) {
            top.dialog.list["show_upload_loding"].close().remove();
            var data = eval("(" + result + ")");
            if (data.msg == 1) {
                $("#" + hidvalue).val(data.msgbox); //注意：这里保存的是完整路径
                //alert($("#" + value).val());
                $("#" + pre).attr("src", data.msgbox);
                //alert(data.msgbox);
            } else {
                showMsg("系统异常，上传失败。", "Error");
                //alert(data.msgbox);
            }
        },
        error: function(e) {
            top.dialog.list["show_upload_loding"].close().remove();
            showMsg("上传失败，错误信息：" + e.message, "Error");
        },
        timeout: 600000
    });

}

//==========================================================================

//复选框读取与交互js===========================================================================================
//2014-10-20 修改 By 黄栾
//参数说明：
//c_id:复选框隐藏与服务器交互ID值
//c_name:复选框页面显示name组名称
function selected_show(c_id, c_name) {
    var xx = $("#" + c_id).val().split(",");
    $.each(xx, function(i, val) {
        $("input[name=" + c_name + "]").each(function() {
            if ($(this).val() == val) {
                $(this).attr("checked", 'true');
            }
        });
    });
}

function selected_add(c_id, c_name) {
    $("input[name=" + c_name + "]").click(function() {
        var chk_value = [];
        $("input[name=" + c_name + "]:checked").each(function() {
            chk_value.push($(this).val());
        });
        $("#" + c_id).val(chk_value);
    });
}

//==========================================================================


//检测表单是否提交js===========================================================================================
//2014-10-23 修改 By 唐有炜
//参数说明：
/**
* This function is to check if a form has been changed.
* JK 2004-01-05
* formObj:the checked form
* exceptObjName:the name of whitch need not be checked;
* For example:isFormChangedFun(document.frm,"ACheckbox,BRadio,CSelect");
*/
function isFormChanged(formObj, exceptObjName) {
    if (formObj == null) formObj = document.forms[0];
    if (exceptObjName == null) exceptObjName == "";
    var selectObjs = formObj.getElementsByTagName("SELECT"); //For Select Obj
    for (var i = 0; i < selectObjs.length; i++) {
        if ((selectObjs[i].name == "") || (eval("/(^|,)" + selectObjs[i].name + "(,|$)/g").test(exceptObjName))) continue;
        for (var j = 1; j < selectObjs[i].length; j++) {
            if (selectObjs[i].options[j].defaultSelected != selectObjs[i].options[j].selected)
                return true;
        }
    }

    var inputObjs = formObj.getElementsByTagName("INPUT"); //For Input Obj
    for (var i = 0; i < inputObjs.length; i++) {
        if ((inputObjs[i].name == "") || (eval("/(^|,)" + inputObjs[i].name + "(,|$)/g").test(exceptObjName))) continue;
        if ((inputObjs[i].type.toUpperCase() == "TEXT") && (inputObjs[i].defaultValue != inputObjs[i].value))
            return true;

        else if (((inputObjs[i].type.toUpperCase() == "RADIO") || (inputObjs[i].type.toUpperCase() == "CHECKBOX"))
&& (inputObjs[i].defaultChecked != inputObjs[i].checked))
            return true;

    }

    var textareaObjs = formObj.getElementsByTagName("TEXTAREA"); //For Textarea Obj
    for (var i = 0; i < textareaObjs.length; i++) {
        if ((textareaObjs[i].name == "") || (eval("/(^|,)" + textareaObjs[i].name + "(,|$)/g").test(exceptObjName))) continue;
        if (textareaObjs[i].defaultValue != textareaObjs[i].value)
            return true;

    }
    return false;
}