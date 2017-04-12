
// 启动图片影像上传控件（ReferenceId,uploadLimit）
function StartUploader(feferenceId, uploadLimit) {
    if (feferenceId == null)
    {
        feferenceId = 2;
    }

    if (uploadLimit == null) {
        uploadLimit = 0;
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

    $("#pic_upload").uploadify({
        auto: false,
        multi: true,
        buttonText: "选择",
        fileSizeLimit: "500MB",
        fileTypeExts: fileTypeExts.TotalExts,
        height: 20,
        width: 60,
        queueID: "file_queue",
        formData: { ReferenceId: feferenceId },
        removeTimeout: 10,
        removeCompleted: true,
        swf: "Content/uploadify/uploadify.swf",
        uploader: "../api/File/Upload",
        uploadLimit: uploadLimit,
        onQueueComplete: function () {
            $("#file_queue").empty();
            uploadFormClose();
        },
        onUploadSuccess: function (file, data, response) {
            // 上传成功回调函数
            UploadSuccess(file, data, response);
        }
    });

    $("#pic_upload").css("float", "left").find("object").css("left", "0");
}

// 上传成功回调函数
function UploadSuccess(file, data, response) {
    UploadSuccessInstance(file, data, response);
}

// 上传窗体关闭
function uploadFormClose() {
    $('#dd_upload').dialog({
        closed: true,
    });
    //$("#pic_upload").uploadify("cancel", "*");
    $("#file_queue").empty();
}

// 获取所有图片
function LoadAllImages(financeId) {
    if (financeId == null) {
        financeId = "B5E95692-A6B0-E611-80C7-507B9DE4A488";
    }

    var resultData = null;

    $.ajax({
        async: false,
        type: "Get",
        data: { financeid: financeId },
        url: "../api/ImageUpload/GetAll",
        success: function (data) {
            if (data) {
                // 拼接产生路径
                $(data).each(function (i, e) {
                    e.path = e.FilePath.substring(1) + e.NewName + e.ExtName;
                });

                resultData = data;
            }
        }
    });

    return resultData;
}

// 获取文件
function GetFiles(referenceId) {
    if (referenceId == null) {
        referenceId = 2;
    }

    var resultData = null;
    $.ajax({
        async: false,
        type: "Get",
        data: { ReferenceId: referenceId },
        url: "../api/ImageUpload/GetFiles",
        success: function (data) {
            if (data) {
                debugger
                // 拼接产生路径
                $(data).each(function (i, e) {
                    e.path = e.FilePath.substring(1) + e.NewName + e.ExtName;
                });

                resultData = data;
            }
        }
    });

    return resultData;
}

// 删除文件
function DeleteFiles(referenceIds) {
    var resultData = null;
    if (Object.prototype.toString.call(referenceIds) === '[object Array]' && referenceIds.length > 0) {
        $.ajax({
            async: false,
            type: "Get",
            data: { referenceIds: referenceIds.join(",") },
            url: "../api/ImageUpload/Delete",
            success: function (data) {
                resultData = referenceIds;
            }
        });
    }

    return resultData;
}
