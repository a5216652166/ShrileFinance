// Json序列化
$.fn.serializeJson = function () {
    var obj = {};
    var array = this.serializeArray();

    var selector = this.selector;

    if (!!window.ActiveXObject || "ActiveXObject" in window) {
        array = $(this).parents("form").serializeArray();

        array = $.map(array, function (val) {
            if ($("[name=" + val.name + "]").parents(selector).length)
                return val;
        });
    }

    $.each(array, function (i, e) {
        if (obj[e.name] !== undefined) {
            if (!obj[e.name].push) {
                obj[e.name] = [obj[e.name]];
            }
            obj[e.name].push(e.value || '');
        } else {
            obj[e.name] = e.value || '';
        }
    });

    return obj;
};

// 错误提示
function ShowError(msg) {
    $.messager.show({ title: "错误提示", msg: msg });
}

var _A = 0;
var _B = 0;
var _C = 0;
var _D = 0;
var _E = 0;
var _F = 0;
var _G = 0;
var _H = 0;
var _I = 0;
var _J = 0;
var _K = 0;
var _L = 0;

//减
function Minus(value) {
    var temp = "";
    var parent = $(value).parents("section")
    if (parent.attr("id") == "B" && _B >= 0) { _B--; temp = _B }
    else if (parent.attr("id") == "C" && _C >= 0) { _C--; temp = _C }
    else if (parent.attr("id") == "D" && _D >= 0) { _D--; temp = _D }
    else if (parent.attr("id") == "E" && _E >= 0) { _E--; temp = _E }
    else if (parent.attr("id") == "F" && _F >= 0) { _F--; temp = _F }
    else if (parent.attr("id") == "G" && _G >= 0) { _G--; temp = _G }
    else if (parent.attr("id") == "H" && _H >= 0) { _H--; temp = _H }
    else if (parent.attr("id") == "I" && _I >= 0) { _I--; temp = _I }
    else return;

    $(value).parents("section").children("fieldset:last").remove()

    //控制 - + 号按钮显示隐藏
    if ($(parent).attr("min") <= temp && $(parent).attr("max") == 1) {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") >= temp && $(parent).attr("max") == "n") {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") == 0 && $(parent).attr("max") == 1 && temp >= $(parent).attr("max")) {
        $(parent).children("div:first").find("a:first").show();
        $(parent).children("div:first").find("a:last").hide();
    }
    else if ($(parent).attr("min") == 1 && $(parent).attr("max") == "n" && temp <= $(parent).attr("min")) {
        $(parent).children("div:first").find("a:last").hide();
    }
}

//增加
function Add(templateId) {
    var temp = "";
    var parent = $("#" + templateId).parents('section')
    if (parent.attr("id") == "A") { _A++; temp = _A }
    if (parent.attr("id") == "B") { _B++; temp = _B }
    if (parent.attr("id") == "C") { _C++; temp = _C }
    if (parent.attr("id") == "D") { _D++; temp = _D }
    if (parent.attr("id") == "E") { _E++; temp = _E }
    if (parent.attr("id") == "F") { _F++; temp = _F }
    if (parent.attr("id") == "G") { _G++; temp = _G }
    if (parent.attr("id") == "H") { _H++; temp = _H }
    if (parent.attr("id") == "I") { _I++; temp = _I }
    if (parent.attr("id") == "J") { _J++; temp = _J }
    if (parent.attr("id") == "K") { _K++; temp = _K }

    //0~1次当次数大于1次时不在显示
    if ($(parent).attr("max") == 1 && $(parent).attr("max") < temp) {
        return;
    }

    //temp>0显示-
    if (temp > 0) {
        if ($(parent).attr("min") < temp && $(parent).attr("max") == "n") {
            $(parent).children("div:first").find("a:last").show();
        }
        if ($(parent).attr("min") == 0 && $(parent).attr("max") == 1 && temp >= $(parent).attr("max")) {
            $(parent).children("div:first").find("a:first").hide();
            $(parent).children("div:first").find("a:last").show();
        }
    }

    var template = document.querySelector("#" + parent.children("template").attr("id"));
    if (template) {
        var clone = document.importNode(template, true);
    }

    $('<fieldset>').attr({ "id": parent.attr("id") + "_" + temp }).append($(clone).html()).appendTo("#" + parent.attr("id"))

    // jQuery解析
    $.parser.parse("#" + parent.attr("id") + "_" + temp);
}

// 获取Url参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

// 禁用
function Disabled(selector) {
    selector = selector || "fieldset";

    //$(selector).attr("disabled", "disabled");
    $(selector + " select.easyui-combobox").combobox("disable");
    $(selector + " input.easyui-combobox").combobox("disable");
    $(selector + " input.easyui-datebox").combobox("disable");
    $(selector + " input.easyui-textbox").combobox("disable");
    $(selector + " input.easyui-combotree").combobox("disable");
    $(selector + " select.easyui-combotree").combobox("disable");
}

// 最多保留2位小数
function Fixed(num) {
    if (isNaN(num)) {
        return 0;
    }

    if (num.toString().indexOf('.') == -1) {
        return parseFloat(num);
    }
    else if (/^-?\d+\.\d{1}[0]$/.test(parseFloat(num).toFixed(2).toString())) {
        return parseFloat(num).toFixed(1);
    }
    else{
        return parseFloat(num).toFixed(2);
    }
}

// 计算
function Calculate(array, ch, result) {
    var r = 0;
    if (array == null || array.length == 0 || $.inArray(ch, ['+', '-']) == -1) {
        return r;
    }
    else {
        $(array).each(function (i, e) {
            if (!isNaN(parseFloat($("section input[id=" + e + "]").textbox('getValue')))) {
                if (i == 0) {
                    r = parseFloat($("section input[id=" + e + "]").textbox('getValue'));
                }
                else {
                    if (ch == '+') {
                        r += parseFloat($("section input[id=" + e + "]").textbox('getValue'));
                    }
                    else if (ch == '-') {
                        r -= parseFloat($("section input[id=" + e + "]").textbox('getValue'));
                    }
                }
            }
        });
    }

    $("section input[id=" + result + "]").textbox('setValue', Fixed(parseFloat(r)));

    return r;
}

