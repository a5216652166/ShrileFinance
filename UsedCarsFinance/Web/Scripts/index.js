$(function () {
    GetUserInfo();
    //Timeer();
    MessageCount();
    RanderMenus();
});
function GetUserInfo() {
    $.ajax({
        async: true,
        type: "GET",
        url: "api/User/CurrentUser",
        statusCode: {
        	200: function (data) {
        		$("#user_id").val(data.Id);
        		$("#user_name").text(data.Name);
        		$("#role_name").text(data.Role);
            }
        }
    });
}

function Timeer() {
    setTimeout(function () { Timeer(); MessageCount() },500000)
}

function MessageCount() {
    $.ajax({
        async: true,
        type: "GET",
        url: "api/Instance/DingCount",
        statusCode: {
            200: function (data) {
                $("span#message").text(data);//.css({ "color": "red", "text-align": "center" })
            }
        }
    });
}

function RanderMenus() {
    $.ajax({
        async: true,
        method: "GET",
        url: "api/Menu/GetOnlyAuthorization",
        statusCode: {
            200: function (data) {
                $(data).each(function (i, e) {
                    var ul = $("<ul>");

                    $(e.Children).each(function (subi, sube) {
                        $("<li>").append(
                            $("<a>").append(sube.Name).attr("href", "javascript:void(0);").data("url", sube.Link)
                        ).appendTo(ul);
                    });

                    $("#menus").accordion("add", {
                        title: e.Name,
                        content: ul,
                    });
                });

                $("#menus").accordion("select", 0);

                $("#menus ul li a").click(function () {
                    $("#menus ul li a.active").removeClass("active");
                    $(this).addClass("active");

                    addTab(
                        $(this).text(),
                        $(this).data("url")
                    );
                });
            }
        }
    });
}

function addTab(title, url) {
    if ($('#tabs').tabs('exists', title)) {
        $('#tabs').tabs('select', title);
    } else {
        var content = "<iframe name='tabframe' scrolling='auto' frameborder='0'  src='" + url + "' style='width:100%;height:99%;'></iframe>";

        $("#tabs").tabs("add", {
            title: title,
            content: content,
            closable: true
        });
    }
}

function myinfo() {
    addTab("我的信息", "Account/UserInfo.html");
}
function logout() {
    $.ajax({
        url: "api/User/SignOut",
        method: "GET",
        statusCode: {
            200: function (data) {
                location.href = "Login.html";
            }
        }
    });
}