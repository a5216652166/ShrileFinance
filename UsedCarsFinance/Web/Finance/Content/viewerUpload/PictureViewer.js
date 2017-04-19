// 初始化图片查看器 Obj：图片查看器对象
function InitPicViewer(Obj) {
    if (Obj == undefined) {
        return null;
    }

    return new Viewer($(Obj)[0], options);
}

var viewer = null;

// 图片查看器加载图片 UrlArray：图片路径数组，viewerContainer：照片查看器对应的DOM节点
function PicViewerLoadPic(UrlArray, viewerContainer) {
    // 图片加入照片查看器
    if (Object.prototype.toString.call(UrlArray) === '[object Array]') {
        var template = '<div id="li" style="float:left;padding-right:10px;"><img data-original="" src="" alt="" ><label style="text-align:center;display:block;width:100px;height:40px;word-wrap:break-word;word-break:keep-all;overflow:hidden;"></label></div>';

        template = $(viewerContainer).next("template").html();

        // 图片格式
        var picTypeExts = ['.jpg','.JPEG','.png','.PNG','.jpeg','.JPEG','.gif','.GIF','.bmp','.BMP'];

        // 清空预览
        $(viewerContainer).find("div").remove();

        $(UrlArray).each(function (i, e) {
            $(viewerContainer).append(template);

            var picPath = e.Path.toString();
            
            $(viewerContainer).find("div.picBox:last img").attr("data-original", picPath);

            $(viewerContainer).find("div.picBox:last img").attr("src", picPath);

            $(viewerContainer).find("div.picBox:last img").attr("alt", e.Name);

            $(viewerContainer).find("div.picBox:last").attr("name", e.Id);

            $(viewerContainer).find("div.picBox:last span.picName").text(e.Name);

            if ($.inArray(picPath.substr(picPath.lastIndexOf('.')), picTypeExts) == -1) {
                $(viewerContainer).find("div.picBox:last img").remove();
                //$(viewerContainer).find("div.picBox:last div:first").css('background-image','Content/img/默认图片.png');
            }
            else {
                $(viewerContainer).find("div.picBox:last img").click(function () {
                    if (viewer) {
                        viewer.destroy();
                    }

                    viewer = InitPicViewer($(viewerContainer));

                    viewer.show();
                });
            }
        });

        // 销毁照片查看器
        if (viewer) {
            viewer.destroy();
        }
    }
}
