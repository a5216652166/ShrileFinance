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

//信息记录类型
function InfoType() {
    var ID = $("#B_1 select:first").attr("id");//ID
    $.ajax({
        async: true,
        method: "GET",
        data: { infoTypeID: infoTypeId },
        url: "../api/InfoType/getList",
        statusCode: {
            200: function (data) {
                $("#B_1" + " #" + ID + "").combobox("loadData", data).combobox("setValue", data[0].value);
            }
        }
    })
}

function ChangeType(value) {
    var metaCode = value.attr("meta_code");
    var ID = value.attr("id");
    var parentCode = infoTypeId;
    $.ajax({
        async: true,
        method: "GET",
        data: { metaCode: metaCode, parentCode: parentCode },
        url: "../api/Method/ChangeType",
        statusCode: {
            200: function (data) {
                $("#C_1" + " #" + ID + "").combobox("loadData", data).combobox("setValue", data[0].value);
            }
        }
    })
}

//行业分类
function GetIndustry() {
    $.ajax({
        async: true,
        method: "GET",
        data: {},
        url: "../api/Method/GetIndustry",
        statusCode: {
            200: function (data) {
                $("#D_1 #D27").combotree("loadData", data);
            }
        }
    })
}
// comboxtree异步加载
function OnselectIndustry(node) {
    $('#D_1 #D27').combotree("tree").tree("options").url = "../api/Method/GetChildrenIndustry?ID=" + node.id;
}

//获取行政区划
function GetAdministration() {
    $.ajax({
        async: true,
        method: "GET",
        data: {},
        url: "../api/Method/GetAdministration",
        statusCode: {
            200: function (data) {
                $("#D_1 #D29").combotree("loadData", data);
            }
        }
    })
}
//贷款投向
function GetLoan() {
    $.ajax({
        async: true,
        method: "GET",
        data: {},
        url: "../api/Method/GetIndustry",
        statusCode: {
            200: function (data) {
                $("#F_1 #F530").combotree("loadData", data);
            }
        }
    })
}

//个人业务发生地点
function GetAddress() {
    if ($(".easyui-combotree").attr("meta_code") == 3141) {
        var id = $(".easyui-combotree").attr("id");
        $.ajax({
            async: true,
            method: "GET",
            data: {},
            url: "../api/Method/GetAdministration",
            statusCode: {
                200: function (data) {
                    $("#A_1 #" + id).combotree("loadData", data);
                }
            }
        })
    }
}
//判断是否是子类
function OnSelect(value) {
    if (value.children != undefined) {
        alert('请选择子类！');
        return false;
    }
}

// 不可编辑下拉框onChange事件
function SpecialOnSelect() {
    //当选择业务种类类型时候
    var count = $('fieldset .easyui-combobox');//下拉框个数
    var countData = $('fieldset .easyui-datebox');//时间控件个数
    var countInput = $('fieldset .easyui-textbox');//文本框个数
    var businessType = $(this).combobox('getValue');
    var PanretMetaCode = $(this).attr("meta_code")
    var OldID = "";
    var parentID = "";
    //状态为信用卡
    for (var i = 0; i < countData.length; i++) {
        if ($(countData[i]).attr("meta_code") == '2103') {
            if (businessType == 2) {
                $(countData[i]).textbox('setValue', '20991231').textbox("readonly", true);//选择信用卡时到期日期为20991231
            } else {
                $(countData[i]).textbox('setValue', '').textbox("readonly", false);
            }
        }
    }
    for (var i = 0; i < countInput.length; i++) {
        //选择信用卡时逾期31-60天未归还贷款本金 填0        //选择信用卡时逾期61-90天未归还贷款本金 填0     //选择信用卡时逾期91-180天未归还贷款本金 填0   //逾期180天以上未归还贷款本金 填0
        if ($(countInput[i]).attr("meta_code") == '1113' || $(countInput[i]).attr("meta_code") == '1115' || $(countInput[i]).attr("meta_code") == '1117' || $(countInput[i]).attr("meta_code") == '1119') {
            businessType == 2 ? $(countInput[i]).textbox('setValue', '0').textbox("readonly", true) : $(countInput[i]).textbox('setValue', '').textbox("readonly", false);
        }
        else if ($(countInput[i]).attr("meta_code") == '4101' || $(countInput[i]).attr("meta_code") == '4105') {
            businessType == 2 ? $(countInput[i]).textbox('setValue', 'C').textbox('readonly', true) : $(countInput[i]).textbox('setValue', '').textbox('readonly', false);
        }
        else { continue }
    }
    for (var i = 0; i < count.length; i++) {
        if ($(count[i]).attr("meta_code") == '7109') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else if ($(count[i]).attr("meta_code") == '7111') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else if ($(count[i]).attr("meta_code") == '4111') {
            OldID = $(count[i]).attr("id");
            parentID = $(count[i]).parents("fieldset").attr("id");
        }
        else {
            continue;
        }
        $.ajax({
            async: false,
            method: "GET",
            data: { MetaCode: $(count[i]).attr("meta_code"), PanretMetaCode: PanretMetaCode, BusinessType: businessType },
            url: "../api/Method/ComboLoad",
            statusCode: {
                200: function (data) {
                    $("#" + parentID + " #" + OldID + "").combobox("clear").combobox("loadData", data);
                }
            }
        })
    }

}

//动态加载下拉框中的数据
function ComboOnselect() {
    var OldID = this.id;//ID
    var ID = this.id.substring(1, this.id.length);//去掉段标识的ID
    var ParentID = $(this).parents("fieldset").attr("id")
    $.ajax({
        async: true,
        method: "GET",
        data: { SegmentRulesID: ID },
        url: "../api/Method/ComboInfoLoad",
        statusCode: {
            200: function (data) {
                $("#" + ParentID + " #" + OldID + "").combobox("loadData", data);
            }
        }
    })
}
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
    else if (parent.attr("id") == "J" && _J >= 0) { _J--; temp = _J }
    else if (parent.attr("id") == "K" && _K >= 0) { _K--; temp = _K }
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
    $('<fieldset>').attr({ "id": parent.attr("id") + "_" + temp }).append(clone.children).appendTo("#" + parent.attr("id"))
    $.parser.parse("#" + parent.attr("id") + "_" + temp);
    var aa = $("#" + parent.attr("id") + "_" + temp + " select");
    for (var i = 0; i < aa.length; i++) {
        if (aa[i].id == "D29" || aa[i].id == "D27" || aa[i].id == "F530" || $(aa[i]).attr("meta_code") == '3141' || $(aa[i]).attr("meta_code") == '7111' || $(aa[i]).attr("meta_code") == '7109') { }//去掉combotree的选项以及去掉个人中的带条件筛选的
        else if ($(aa[i]).attr("meta_code") == '7515') {
            ChangeType($(aa[i]))
        }
        else {
            ComboboxLoad(parent.attr("id") + "_" + temp, aa[i].id);
        }
    }
}

//通用的下拉框加载
function ComboboxLoad(fleidsetID, segmentRulesID) {
    $("#" + fleidsetID + " #" + segmentRulesID + "").combobox({
        method: "GET",
        queryParams: { SegmentRulesID: segmentRulesID.substring(1, segmentRulesID.length) },
        url: '../api/Method/ComboInfoLoad',
        valueField: 'value',
        textField: 'text'
    });
}
//借款人概要信息记录
function InfoType1() {
    if ($("#D_1 #D14").combobox("getValue") == "CHN" && $("#D_1 #D15").textbox("getValue") == "" && $("#D_1 #D16").textbox("getValue") == "") {
        top.$.messager.show({ msg: "当为境内注册时，借款人中文描叙和外文描叙必须填一项！" });
        return false;
    }
    else if ($("#D_1 #D14").combobox("getValue") == "CHN" && $("#D_1 #D17").textbox("getValue") == "") {
        top.$.messager.show({ msg: "当借款人国别为境内时候组织机构代码必填！" });
        return false;
    }
    else {
        return true;
    }
}
//借款人资本构成信息记录
function InfoType2(i) {
    if ($("#G_" + i).children("div").find("#G89").textbox('getValue') == "" && $("#G_" + i).children("div").find("#G90").textbox('getValue') == "") {
        top.$.messager.show({ msg: "贷款卡编号和组织机构代码不能同时为空" });
        return false;
    }
    else {
        return true;
    }
}

// "还款频率" onSelect事件
function TermsFrequency() {
    if ($("select[meta_code=4111]")[1] != undefined) {
        var value = $("select[meta_code=4111]").eq(1).combobox('getValue');
        var value1 = $("input[meta_code=4101]").eq(1).textbox('getValue');
        var value2 = $("input[meta_code=4105]").eq(1).textbox('getValue');

        // "还款频率"注册onSelect事件
        $("select[meta_code=4111]").eq(1).combobox({
            onSelect: function (record) {
                // [还款频率] = '07-一次性', [还款月数] = 'O' [剩余还款月数] = 'O'
                if (record.value == "07") {
                    $("input[meta_code=4101]").eq(1).textbox('setValue', 'O').textbox('readonly', true);
                    $("input[meta_code=4105]").eq(1).textbox('setValue', 'O').textbox('readonly', true);
                }
                    // [还款频率] = '08-不定期',[还款月数] = 'U' [剩余还款月数] = 'U'
                else if (record.value == "08") {
                    $("input[meta_code=4101]").eq(1).textbox('setValue', 'U').textbox('readonly', true);
                    $("input[meta_code=4105]").eq(1).textbox('setValue', 'U').textbox('readonly', true);
                }
                    // [还款频率] = '99-不定期',[还款月数] = 'X' [剩余还款月数] = 'X'
                else if (record.value == "99") {
                    $("input[meta_code=4101]").eq(1).textbox('setValue', 'X').textbox('readonly', true);
                    $("input[meta_code=4105]").eq(1).textbox('setValue', 'X').textbox('readonly', true);
                }
                else if (record.value == 'C') {
                    $("input[meta_code=4101]").eq(1).textbox('setValue', 'C').textbox('readonly', true);
                    $("input[meta_code=4105]").eq(1).textbox('setValue', 'C').textbox('readonly', true);
                }
                else {
                    $("input[meta_code=4101]").eq(1).textbox('setValue', '').textbox('readonly', false);
                    $("input[meta_code=4105]").eq(1).textbox('setValue', '').textbox('readonly', false);
                }
            }
        });

        setTimeout(function () {
            var businessType = $("select[meta_code=7117]").eq(1).combobox('getValue');
            if (businessType.length > 0) {
                $.ajax({
                    async: false,
                    method: "GET",
                    data: { MetaCode: '4111', PanretMetaCode: '7117', BusinessType: businessType },
                    url: "../api/Method/ComboLoad",
                    statusCode: {
                        200: function (data) {
                            $("select[meta_code=4111]").eq(1).combobox("clear").combobox("loadData", data);
                        }
                    }
                });
            }

            $("select[meta_code=4111]").eq(1).combobox('select', value);

            if (value == '07' || value == '08') {
                $("input[meta_code=4101]").eq(1).textbox('setValue', value1).textbox('readonly', true);
                $("input[meta_code=4105]").eq(1).textbox('setValue', value2).textbox('readonly', true);
            }
            else {
                $("input[meta_code=4101]").eq(1).textbox('setValue', value1);
                $("input[meta_code=4105]").eq(1).textbox('setValue', value2);
            }
        }, 500)
    }
}

// “账户拥有者信息提示” onSelect事件
function AcountMasterTip() {
    $("section[id=F]").find("a#Fminus").click();
    $("section[id=F]").hide();

    $("section[id=B]").find("a#Fminus").click();
    $("section[id=B]").hide();

    $("section[id=C]").find("a#Fminus").click();
    $("section[id=C]").hide();

    $("section[id=D]").find("a#Fminus").click();
    $("section[id=D]").hide();

    var value = $("select[meta_code=7121]").eq(1).combobox('getValue');
    if (value == 2) {
        $("section[id=B]").find("a#Fminus").click();
        $("section[id=B]").show();

        $("section[id=C]").find("a#Fminus").click();
        $("section[id=C]").show();

        $("section[id=D]").find("a#Fminus").click();
        $("section[id=D]").show();
    }
    else if (value == 1)
    {
        $("section[id=F]").find("a#Fminus").click();
        $("section[id=F]").show();
    }


    // "还款频率"注册onSelect事件
    $("select[meta_code=7121]").eq(1).combobox({
        onSelect: function (record) {
            // 当基础段中的账户拥有者信息提示为“2-新账户开立”时，不能包含交易标识变更段
            if (record.value == "2") {
                $("section[id=F]").find("a#Fminus").click();
                $("section[id=F]").hide();

                $("section[id=B]").show();
                $("section[id=B]").find("a#Fminus").click();

                $("section[id=C]").show();
                $("section[id=C]").find("a#Fminus").click();

                $("section[id=D]").show();
                $("section[id=D]").find("a#Fminus").click();
            }
            else {
                // 当基础段中的账户拥有者信息提示为“1-已开立账户”时，不能包含身份信息段、职业信息段、居住地址段
                $("section[id=F]").show();
                $("section[id=F]").find("a#Fminus").click();

                $("section[id=B]").find("a#Fminus").click();
                $("section[id=B]").hide();

                $("section[id=C]").find("a#Fminus").click();
                $("section[id=C]").hide();

                $("section[id=D]").find("a#Fminus").click();
                $("section[id=D]").hide();
            }
        }
    });

    $("select[meta_code=7121]").eq(1).combobox('setValue',value);
}


