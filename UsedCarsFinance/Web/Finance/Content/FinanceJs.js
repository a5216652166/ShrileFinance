// 获取Url参数
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

// 禁用
function Disabled(selector) {
    selector = selector || "fieldset";

    $(selector).attr("disabled", "disabled");

    $(selector).find(".easyui-combobox").combobox("disable");

    
    if ($(selector).hasClass(".easyui-combobox")) {
        $(selector).combobox("disable");
    }
}

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

// fieldset 数据序列化工厂（type: text or table）
function FieldsetSerializeFactory(name, type) {
    if (name == null || type == null || $.inArray(type, ["text", "table"]) == -1) {
        return null;
    }

    var json = new Object();

    if ($("fieldset[name=" + name + "]").length > 0) {
        if (type == "text") {
            // 序列化 text
            json = $("fieldset[name=" + name + "]").serializeJson();
        }
        else {
            // 序列化 table
            var json = $("fieldset[name=" + name + "]").find("[id=" + name + "_dg" + "]").datagrid("getRows");
        }
    }

    return json;
}

// fieldset 数据加载工厂（type: text or table）
function FieldsetLoadDateFactory(name, type, data) {
    if (name == null || type == null || $.inArray(type, ["text", "table"]) == -1 || !data) {
        return null;
    }

    if ($("fieldset[name=" + name + "]").length > 0) {
        if (type == "text") {
            // 加载数据 text
            $("fieldset[name=" + name + "]").form('load', data);
        }
        else {
            // 加载数据 table
            //$(data).each(function (index, item) {
            //    // 加载数据 table
            //    $("fieldset[name=" + name + "]").find("[id=" + name + "_dg" + "]").datagrid('appendRow', item);
            //});

            $("fieldset[name=" + name + "]").find("[id=" + name + "_dg" + "]").datagrid('loadData', data);
        }
    }

    return data;
}

// 部分映射工厂 （ RefObj：输入对象, OutObj：输出对象，isFunction(是否为方法)：true or false，array：属性数组，默认null（全属性映射））
function TraverseDateFactory(RefObj, OutObj, isFunction, array) {
    if (RefObj == null) {
        return OutObj;
    }

    if (OutObj == null)
    {
        OutObj = {};
    }
    
    if (isFunction == true) {
        for (var name in RefObj) {
            if (typeof (RefObj[name]) == "function" && (array == null || $.inArray(name, array))) {
                OutObj[name] = RefObj[name];
            }
        }
    }
    else {
        for (var name in RefObj) {
            if (typeof (RefObj[name]) != "function" && (array == null || $.inArray(name, array))) {
                OutObj[name] = RefObj[name];
            }
        }
    }

    return OutObj;
}

$.extend($.fn.validatebox.defaults.rules, {
    Money: {
        validator: function (value) {
            if (/^-?\d+\.\d{1}$/.test(value)) {
                return true;
            }

            if (/^-?\d+\.\d{2}$/.test(value) || /^-?\d+$/.test(value)) {
                if (value.length >= 2 && /^[0][0-9]*$/.test(value.substr(0, 2))) {
                    return false;
                }

                return true;
            }

            return false;
        },
        message: '请输入整数、一位小数或两位小数！'
    },
    IdCard: {// 身份证号码校验
        validator: function (value) {
            var regResult = false;

            // 15位身份证校验
            regResult = /^[1-9][0-9]{5}[0-9]{2}(0[1-9]|1[0-2])((0[1-9])|((1|2)[0-9])|3[0-1])[0-9]{3}$/.test(value);
            if (regResult) {
                return true;
            }

            // 基础校验（前17位为数字,后1位为校验码）
            regResult = /^[1-9][0-9]{5}[1-9][0-9]{3}(0[1-9]|1[0-2])((0[1-9])|((1|2)[0-9])|3[0-1])[0-9]{3}[0-9X]$/.test(value);

            // 校验码 C18=MOD(∑Ci(i=1→17)×Wi,11)%11
            if (regResult) {
                var W = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);

                var C18 = 0;
                $(W).each(function (index, itemValue) {
                    C18 += parseInt(value[index]) * W[index];
                });
                C18 = (12 - C18 % 11) % 11;

                // 校验  当C18的值为10时，校验码应用大写的拉丁字母X表示
                if (C18 == 10) {
                    regResult = value[17] == 'X';
                }
                else {
                    regResult = parseInt(value[17]) == C18;
                }
            }

            if (regResult) {
                return true;
            }

            return false;
        },
        message: '身份证号码不合法'
    },
    Rate: {
        validator: function (value) {
            if (/^-?\d+\.\d{1}$/.test(value)) {
                return true;
            }

            if (/^-?\d+\.\d{2}$/.test(value) || /^-?\d+$/.test(value)) {
                if (value.length >= 2 && /^[0][0-9]*$/.test(value.substr(0, 2))) {
                    return false;
                }

                return true;
            }

            return false;
        },
        message: '请输入整数、一位小数或两位小数！'
    },
});
