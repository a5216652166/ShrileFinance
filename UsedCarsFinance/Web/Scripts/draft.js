﻿// 草稿功能. 保存方法: onSave(), 加载方法: onLoad(data)
function Draft(onSave, onLoad) {
	var pageLink =
		location.pathname +
		location.search;

	// 保存草稿. When data is null, Then use onSave method.
	this.Save = function (data) {
		var data = data || onSave();
		var jsonData = JSON.stringify(data);

		var postedData = {
			PageLink: pageLink,
			PageData: jsonData
		};

		$.ajax({
			async: true,
			data: postedData,
			method: "POST",
			url: "../api/Draft/Save",
			statusCode: {
				200: function () {
					top.$.messager.show({ msg: "草稿保存成功！" });
				},
				400: function () {
					top.$.messager.show({ msg: "草稿保存失败！" });
				}
			}
		});
	}

	// 加载草稿
	this.Load = function () {
		var searchData = {
			pageLink: pageLink
		};

		$.ajax({
			async: true,
			data: searchData,
			method: "GET",
			url: "../api/Draft/Read",
			statusCode: {
				200: function (jsonData) {
					var data = $.parseJSON(jsonData);

					onLoad(data);
				},
				404: function () {
					// console.log("draft not found, link: " + pageLink);
				}
			}
		});
	}

	// 清除草稿
	this.Clear = function () {
		var searchData = {
			pageLink: pageLink
		};

		$.ajax({
			async: true,
			data: searchData,
			method: "DELETE",
			url: "../api/Draft/Clear",
			statusCode: {
				200: function () {
				}
			}
		});
	}

	// 自动保存. 自动保存间隔(毫秒): millisec
	this.AutoSave = function (millisec) {
		setInterval(this.Save, millisec || (3 * 60 * 1000));
	}
}