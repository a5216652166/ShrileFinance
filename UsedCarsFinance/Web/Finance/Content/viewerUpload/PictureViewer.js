// 初始化图片查看器 Obj：图片查看器对象
function InitPicViewer(Obj) {
    if (Obj == undefined) {
        return null;
    }

    return new Viewer($(Obj)[0], options);
}

// 启动照片查看器 viewer：照片查看器
function PicViewerStart(viewer) {
    if (viewer != null) {
        viewer.show();
    }
}

// 图片查看器加载图片 UrlArray：图片路径数组，viewerContainer：照片查看器对应的DOM节点
function PicViewerLoadPic(UrlArray, viewerContainer) {
    // 图片加入照片查看器
    if (Object.prototype.toString.call(UrlArray) === '[object Array]') {
        var template = '<div id="li" style="float:left"><img data-original="" src="" alt="" ><label style="text-align:center;display:block"></label></div>';

        $(UrlArray).each(function (i, e) {
            $(viewerContainer).append(template);

            $(viewerContainer).find("div#li:last").find("img").attr("data-original", e.Path.toString());

            $(viewerContainer).find("div#li:last").find("img").attr("src", e.Path.toString());

            $(viewerContainer).find("div#li:last").find("img").attr("alt", e.Name);

            $(viewerContainer).find("div#li:last").find("label").text(e.Name);

            $(viewerContainer).find("div#li:last").find("img").click(function () {
                viewer.destroy();
                viewer = InitPicViewer($(viewerContainer));

                if (viewer) {
                    viewer.show();
                }
            });
        });

        // 重新实例化照片查看器
        viewer.destroy();
        viewer = InitPicViewer($(viewerContainer));
    }
}
