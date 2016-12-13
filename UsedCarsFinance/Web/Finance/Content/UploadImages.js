var tempfs;

// 担保人模版
var GuaranteeTemp = "";

// 联系人模版
var ContactsTemp = "";

//全选、反选功能
function checkall(Obj) {
    $("input[name=cb]").each(function (i, e) {
        $(e)[0].checked = Obj.checked;
    });
}

//下载全部
function downLoadall() {
    var cbval = "";
    var tdval = "";
    var objectReferenceId = $("input[name='ReferenceId']");

    for (var i = 0; i < objectReferenceId.length; i++) {
        cbval += objectReferenceId[i].value + ",";
        var thistb = $(objectReferenceId[i]).parent().next().next();
        if (thistb.html() != "") {
            tdval += thistb.html();
        }
    }

    if (tdval == "") {
        $.messager.show({ msg: "无上传文件!" });
        return;
    }

    var form = $("<form>");   //定义一个form表单
    form.attr('style', 'display:none');   //在form表单中添加查询参数
    form.attr('target', '');
    form.attr('method', 'get');
    form.attr('action', "../api/ImageUpload/Download");

    var input1 = $('<input>');
    input1.attr('type', 'hidden');
    input1.attr('name', 'references');
    input1.attr('value', cbval);
    $('body').append(form);  //将表单放置在web中
    form.append(input1);   //将查询参数控件提交到表单上
    form.submit();
}

//根据融资id 加载有哪些类型申请人
function LoadFinanceList() {
    var GuaranteeCount = 0;
    var ContactsConut = 0;
    $.ajax({
        async: false,
        type: "Get",
        data: { financeId: query.FinanceId },
        url: "../api/Finance/Get",
        success: function (data) {
            var getdata = data.Applicants;
            for (var i = 0 ; i < data.Applicants.length; i++) {
                if (getdata[i].TypeDesc == "主要申请人") {
                    $("#MainApplicant").show();
                    $("#MainApplicant").find("input[name='ApplicantId']").val(getdata[i].ApplicantId)
                }
                if (getdata[i].TypeDesc == "共同申请人") {
                    $("#JointApplicant").show();
                    $("#JointApplicant").find("input[name='ApplicantId']").val(getdata[i].ApplicantId)
                }
                if (getdata[i].TypeDesc == "担保人") {
                    GuaranteeCount++;
                    CopyTemp("Guarantee", GuaranteeCount, "担保人", getdata[i].ApplicantId);
                }
                if (data.Applicants[i].TypeDesc == "联系人") {
                    ContactsConut++;
                    CopyTemp("Contacts", ContactsConut, "联系人", getdata[i].ApplicantId);
                }
            }
        }
    });
    $("#GuaranteeDiv").append(GuaranteeTemp);
    $("#ContactsDiv").append(ContactsTemp);
}

// 克隆模版
function CopyTemp(name, Rcount, TempFieldsetLegend, applicantId) {
    tempfs.attr('id', name + Rcount);
    tempfs.find("input[name='ApplicantId']").val(applicantId);//赋值applicantid
    tempfs.find("legend").empty();
    tempfs.find("legend").append(TempFieldsetLegend);
    if (name == "Guarantee") {
        GuaranteeTemp += jQuery(tempfs)[0].outerHTML;
    }
    if (name == "Contacts") {
        ContactsTemp += jQuery(tempfs)[0].outerHTML;
    }
}

// label for input[type=checkbox]
function labelcheck(lab) {
    // 点击对应的checkbox
    $(lab).parent().parent().find("td>input[type=checkbox]").click();
}

// 获取所有引用，并将引用Id设为对应checkbox的值
function GetReferenceID() {
    $.ajax({
        async: false,
        type: "Get",
        data: { financeid: query.FinanceId },
        url: "../api/ImageUpload/GetAllRef",
        success: function (data) {
            var fieldset = $(".container").find("fieldset");
            // 遍历fieldset
            for (var i = 0; i < fieldset.length  ; i++) {
                var input = $($(".container").find("fieldset")[i]).find("input[name='ReferenceId']");
                var inputval = $($(".container").find("fieldset")[i]).find("input[name='cb']");
                var model = $($(".container").find("fieldset")[i]).find("input[name='ReferencedModule']").val();
                var financeid = $($(".container").find("fieldset")[i]).find("input[name='ApplicantId']").val();
                // 遍历第i个fieldset下的checkbox
                for (var j = 0; j < input.length; j++) {
                    for (var k = 0; k < data.length; k++) {
                        if (inputval[j].value == data[k].ReferencedSid && data[k].ReferencedModule == model && financeid == data[k].ReferencedId) {
                            input[j].value = data[k].ReferenceId;
                        }
                    }
                }
            }
        }
    });
}

// 文件名展示div的父节点td
var thirdth;

//预览
function view() {
    if ($("input:checked").length == 1) {
        var refid = $("input[name='cb']:checked").next().val();
        if (refid == "") {
            $.messager.show({ msg: "无图片预览!" });
            return;
        }

        $("#dd_upload_view").dialog({ top: $(document).scrollTop() + 100 }).dialog("open");
        maxNumber = 0
        var imageCount = 0;

        $.ajax({
            async: false,
            type: "Get",
            data: { ReferenceId: refid },
            url: "../api/ImageUpload/GetFiles",
            success: function (data) {
                //绑定幻灯片数据
                $('#BigPicture').empty();
                $('#Small').empty();
                for (var i = 0; i < data.length; i++) {
                    var ReferenceId = data[i]["ReferenceId"];
                    if (ReferenceId == refid) {
                        imageCount++;
                        var filepath = data[i]["FilePath"];
                        var fp = filepath.substring(1);//截取出 ~ 以后的字符串
                        var path = ".." + fp + data[i]["NewName"] + data[i]["ExtName"];
                        var OldName = data[i]["OldName"];

                        var s = imageCount;
                        maxNumber = s;

                        var BigPic = '<div style="height: 590px;width:860px;" align="center" id="c' + s + '"><table style="width:100%; height:100%;"><tr><td style="width:100%; height:100%;" align="center" valign="middle"> <img src="' + path + '" style="max-height: 588px;max-width:858px;vertical-align:middle;" /></td></tr></table></div>';
                        $('#BigPicture').append(BigPic);
                        var SmaPic = ' <img id="t' + s + '" onclick="shows(' + s + ')" src="' + path + '"  style="height:50px;" />';
                        $('#Small').append(SmaPic);
                    }
                }
            }
        });
    } else {
        $.messager.show({ msg: "请选中一项!" });
    }
    initpic();//初始化幻灯片
}

// 初始化图片影像上传控件（count:uploadLimit，RefId:formDate.ReferenceId）
function InitDetePic(count, RefId) {
    // 文件格式扩展名
    var fileTypeExts = {};

    // 图片格式
    fileTypeExts.PicTypeExts = "*.jpg;*.png;*.jpeg;*.gif;*.bmp;";

    // office格式
    fileTypeExts.WordTypeExts = "*.pdf;*.doc;*.docx;*.docm;*.dotx;*.dotm;*.dot;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;";
    fileTypeExts.ExcelTypeExts = "*.xl;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xls;*.xlt;*.xla;*.xlm;*.xlw;*odc;*.ods;";
    fileTypeExts.PowerPointTypeExts = "*.pptx;*.ppt;*.pptm;*.ppsx;*.pps;*.ppsm;*.potx;*.pot;*.potm;*.odp;";

    // 视频格式
    fileTypeExts.VideoTypeExts = "*.mp4;*.wmv;*.avi;*.3gp;*.rm;*.rmvb;*.amv;*.dmv;";

    var fileTypeExts = fileTypeExts.PicTypeExts + fileTypeExts.WordTypeExts + fileTypeExts.ExcelTypeExts + fileTypeExts.PowerPointTypeExts + fileTypeExts.VideoTypeExts;

    $("#pic_upload").uploadify({
        auto: false,
        buttonText: "选择",
        fileSizeLimit: "500MB",
        fileTypeExts: fileTypeExts,
        height: 20,
        width: 60,
        queueID: "file_queue",
        formData: { ReferenceId: RefId },
        removeTimeout: 10,
        removeCompleted: true,
        swf: '../Content/uploadify/uploadify.swf',
        uploader: "../api/File/Upload",
        uploadLimit: count,
        onQueueComplete: function () {
            $("#file_queue").empty();
            ddClose();
        },
        onUploadSuccess: function (file, data, response) {
            // 显示图片文件名div容器
            $(thirdth).find("div").show();

            $(thirdth).find("div").append("<span style='margin-left:6px;background-color:wheat;float:left'>" + file.name + "</span>");
        }
    });
    $("#pic_upload").css("float", "left").find("object").css("left", "0");
}

// 上传窗体关闭
function ddClose() {
    $('#dd_upload').dialog({
        closed: true,
    });
    //$("#pic_upload").uploadify("cancel", "*");
    $("#file_queue").empty();
}

//上传方法
function Add() {
    var ckcheckedlength = $("input:checked").length;

    if (ckcheckedlength == 1) {
        thirdth = $("input:checked").parent().parent().find('td').eq(2);
        var RefModule = $("input:checked")[0].parentNode.children[2].value;
        var RefSId = $("input:checked")[0].value;
        var financeId = "";
        //RefModule==2未融资id,否则为申请人id
        if (RefModule == 2) {
            financeId = query.FinanceId;
        } else {
            var applicantid = $("input:checked").parents("fieldset").find("input[name='ApplicantId']").val();
            financeId = applicantid;
        }

        getOneRef(financeId, RefSId, RefModule);//查找是否存在引用数据
        $("#dd_upload").dialog({ top: $(document).scrollTop() + 300 }).dialog("open");
        InitDetePic(0, ReferenceIdstr);
    }
    else {
        $.messager.show({ msg: "请选中要上传的一项!" });
    }
}

//删除，ReferencedModule暂时为2
function del() {
    var ckchecked = $("input:checked");
    var referenceIds = [];
    if (ckchecked.length > 0) {
        for (var i = 0; i < ckchecked.length; i++) {
            if ($(ckchecked[i]).next() != undefined && $(ckchecked[i]).next().val().length > 0) {
                referenceIds.push($(ckchecked[i]).next().val());
            }
        }

        if (referenceIds.length > 0) {
            picNum = i;
            $.ajax({
                type: "Get",
                data: { referenceIds: referenceIds.join(",") },
                url: "../api/ImageUpload/Delete",
                success: function (data) {
                    for (var k = 0; k < ckchecked.length; k++) {
                        var delthirdth = $(ckchecked[k]).parent().next().next().find("div");
                        $(ckchecked[k]).attr("checked", false);

                        // 隐藏图片文件名div容器
                        delthirdth.hide();

                        delthirdth.empty();
                    }
                }
            });
        }

    }
    else if (referenceIds.length == 0) {
        $.messager.show({ msg: "请至少选中一项进行删除!" });
    }
}

//从引用模块查找是否有相呼应的referenceId
function getOneRef(financeId, RefSId, RefModule) {
    $.ajax({
        async: false,
        type: "Get",
        data: { referencedId: financeId, referencedModule: RefModule, referencedSid: RefSId },
        url: "../api/ImageUpload/Get",
        success: function (data) {
            if (data.ReferenceId > 0) {
                ReferenceIdstr = data.ReferenceId;
                $("input:checked").next().val(data.ReferenceId);//将引用id 绑定在页面上
            }
        }
    });
}

// 最大编号
var maxNumber = 0;

// 当前照片序号
var current = 0;

// 开始/结束
var stopORstart = "stop";

// 初始化照片查看
function initpic() {
    if (maxNumber <= 1) {
        $("#BigPleft_absolute").hide();
        $("#BigPright_absolute").hide();
    }
    else {
        $("#BigPleft_absolute").show();
        $("#BigPright_absolute").show();
    }
    if (maxNumber > 1) {
        $("#hrshow").show();
    }
    for (var i = 1; i <= maxNumber; i++) {
        document.getElementById("c" + i).style.display = "none";
    }
    autoChange();
}

// 显示
function shows(index) {
    for (var i = 1; i <= maxNumber; i++) {
        document.getElementById("t" + i).style.backgroundColor = "white";
        document.getElementById("t" + i).style.color = "black";
        document.getElementById("c" + i).style.display = "none";
        if (i == index) {
            document.getElementById("t" + i).style.backgroundColor = "blue";
            document.getElementById("t" + i).style.color = "white";
            document.getElementById("c" + i).style.display = "block";
        }
    }
}

// 启动自动播放
function OpenAutoChange() {
    if (stopORstart == "start") {
        autoChange();
        stopORstart == "stop";
        $("#BigPleft_absolute").show();//cais
        $("#BigPright_absolute").show();//cais
    }
    if (stopORstart == "stop") {
        stopORstart == "start";
        autoChange();
    }
}

// 每2秒自动播放下一张图片
function autoChange() {
    shows(1);//默认加载第一张图片
    if (stopORstart == "start") {
        $("#BigPleft_absolute").hide();//cais
        $("#BigPright_absolute").hide();//cais
        current++;
        if (current > maxNumber)
            current = 1;
        shows(current);
        setTimeout("autoChange()", 2000);
    }
}

// 上一张图片
function PreviousPic() {
    current--;
    if (current < 1)
        current = maxNumber;
    shows(current);
}

// 下一张图片
function NextPic() {
    current++;
    if (current > maxNumber)
        current = 1;
    shows(current);
}

// checkbox绑定onClick事件
function InputBindonClick() {
    $("div.container").find("fieldset:visible").find("input[type=checkbox]:visible").each(function (i, e) {
        $(e).click(function () {
            ChecboxSingleCheck(e);
        });
    });
}

// checkbox单选
function ChecboxSingleCheck(inputObj) {
    var inputchecboxs = $("div.container").find("fieldset:visible").find("input[type=checkbox]:checked");

    var inputObjState = $(inputObj)[0].checked;

    if ($("input#cball")[0].checked == false) {
        $(inputchecboxs).each(function (i, e) {
            if ($(e)[0].checked == true) {
                $(e).click();
            }
        });

        // 点击需要被选中的按钮
        if (inputObjState == true) {
            $(inputObj).click();
        }
    }
}