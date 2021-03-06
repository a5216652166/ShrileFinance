﻿
// 启动图片影像上传控件
function StartUploader(referenceId, referenceType, ReferenceSid) {
    if (referenceId == null || referenceType == null || ReferenceSid == null) {
        return;
    }

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

    fileTypeExts.TotalExts = fileTypeExts.PicTypeExts + fileTypeExts.WordTypeExts + fileTypeExts.ExcelTypeExts + fileTypeExts.PowerPointTypeExts + fileTypeExts.VideoTypeExts;

    var uploadLimit = 0;

    ////$("#file_upload").uploadifive({
    ////    auto: false,
    ////    multi: true,
    ////    buttonText: "选择",
    ////    fileSizeLimit: "500MB",
    ////    fileTypeExts: fileTypeExts.TotalExts,
    ////    height: 20,
    ////    width: 60,
    ////    queueID: "file_queue",
    ////    formData: { ReferenceId: referenceId, ReferenceType: referenceType, ReferenceSid: ReferenceSid },
    ////    removeTimeout: 10,
    ////    removeCompleted: true,
    ////    //swf: "Content/uploadify/uploadify.swf",
    ////    uploader: "../api/UploadFile/Upload",
    ////    uploadScript: '../api/UploadFile/Upload',
    ////    uploadLimit: uploadLimit,
    ////    onQueueComplete: function (file, data) {
    ////        debugger
    ////        // 上传成功回调函数
    ////        UploadSuccess(file, data);
    ////        debugger
    ////        $("#file_queue").empty();
    ////        uploadFormClose();
    ////    },
    ////    onUploadSuccess: function (file, data, response) {
    ////        // 上传成功回调函数
    ////        //UploadSuccess(file, data);
    ////    }
    ////});

    $('#file_upload').uploadifive({
        'auto': false,
        'buttonText': "选择",
        'fileSizeLimit': '500MB',
        'height': 25,
        'width':60,
        'fileTypeExts': fileTypeExts.TotalExts,
        'queueID': 'file_queue',
        'formData': { ReferenceId: referenceId, ReferenceType: referenceType, ReferenceSid: ReferenceSid },
        'uploadScript': '../api/UploadFile/Upload',
        'onUploadComplete': function (file, data) {
                // 上传成功回调函数
                UploadSuccess(file, data);

                // 上传窗体关闭
                uploadFormClose();
        },
        'onError': function (error) {
            return error;
        }
    });

    $("#file_upload").css("float", "left").find("object").css("left", "0");
}

// 上传成功回调函数
function UploadSuccess(file, data) {
    data = JSON.parse(data);

    UploadSuccessInstance(file, data);
}

// 上传窗体关闭
function uploadFormClose() {
    $('#dd_upload').dialog({
        closed: true,
    });
    //$("#pic_upload").uploadify("cancel", "*");
    $("#file_queue").empty();
}

// 加载所有影像资料
function LoadAllFiles(value) {
    var picData = GetFiles(value.referenceId, value.referenceType, value.referenceSid);

    if (picData.length == 0) {
        return;
    }

    $("fieldset input[type=checkbox]").each(function (i, e) {
        var id = $(e).parents("div.container").find("div[id*=viewerContainer]").attr("id");
        var referenceSid = id.substr(id.lastIndexOf('_') + 1) + flag;

        var urlArray = $(picData).map(function (j, k) {
            if (k.ReferenceType = 1 && k.ReferenceSid == referenceSid.toLowerCase()) {
                return k;
            }
        }).toArray();

        if (urlArray.length > 0) {
            // 上传的图片加入viewer
            PicViewerLoadPic(urlArray, $("div#" + id));
        }
    });
}

// 获取文件
function GetFiles(referenceId, referenceType, referenceSid) {
    if (referenceId == null || referenceType == null) {
        return;
    }

    var resultData = null;
    $.ajax({
        async: false,
        type: "Get",
        data: { referenceId: referenceId, referenceType: referenceType, referenceSid: referenceSid },
        url: "../api/UploadFile/GetFiles",
        success: function (data) {
            if (data) {
                // 拼接产生路径
                $(data).each(function (i, e) {
                    e.Path = "..\\" + e.FullName.substring(1);
                    e.Name = e.OldName;
                });

                resultData = data;
            }
        }
    });

    return resultData;
}

// 删除文件
function DeleteFiles(referenceId, referenceType, Ids) {
    var data = {};
    data.ReferenceId = referenceId;
    data.ReferenceType = referenceType;
    data.Ids = Ids;
    
    var result = false;

    $.ajax({
        async: false,
        type: "POST",
        data: data,
        url: "../api/UploadFile/DeleteAll",
        success: function (data) {
            result = true;
        }
    });

    return result;
}
