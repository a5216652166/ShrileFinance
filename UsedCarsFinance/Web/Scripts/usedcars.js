var uc = new UsedCars();

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

$.ajaxSetup({
	statusCode: {
		//未授权错误处理, 跳转至登录页
		401: function (data) {
			top.$.messager.confirm("信息", "请重新登录!", function (r) {
				if (r) {
					var pos = top.location.href.lastIndexOf('/');

					top.location.href = top.location.href.substr(0, pos + 1) + "login.html";
				}
			});
		},
		//未找到相应处理
		//404: function (xhr, status, error) {
		//	$.messager.alert("请求失败", "未找到匹配的操作", "error");

		//	console.log(xhr.responseJSON.ExceptionMessage);
		//},
		//系统错误处理
		500: function (xhr, status, error) {
			$.messager.alert("错误", "系统错误!", "error");

			console.log(xhr.responseJSON);
		}
	}
});



function UsedCars() {
	this.form;// = new UCForm();
	this.grid;// = new UCDataGrid();

	/*	Method */
	this.GetParams = function () {
		var querys, params = {};

		if (location.search.length > 1) {
			querys = location.search.substring(1).split("&");

			var item;
			for (var i = 0; i < querys.length; i++) {
				item = querys[i].split("=");

				params[item[0]] = item[1];
			}
		}

		return params;
	}
	this.ShowWindow = function (title, url) {
		top.$("#wiframe").attr("src", url);

		top.$("#win").window({
			title: title,
			closed: false,
			onClose: uc.grid.Closed
		});
	}
	this.CloseWindow = function () {
		top.$("#wiframe").attr("src", "about:blank");
		top.$("#win").window("close");
	}

	//默认 BadRequest 错误处理
	this.E400 = function (xhr, status, error) {
		var message = "";

		if (xhr.responseJSON) {
			if (xhr.responseJSON.ModelState) {
				var modelState = xhr.responseJSON.ModelState;

				for (item in modelState) {
					$(modelState[item]).each(function (i, errMsg) {
						message += errMsg + "<br />";
					});
				}
			} else {
				message = xhr.responseJSON.Message;
			}
		} else {
			message = "请求失败!";
		}

		$.messager.alert("请求失败", message, "error");
	}

	/*	Filter */
	this.FilterCombo = function (data) {
		if (data.success > -1) {
			if (data.rows.length > 0) {
				data = data.rows;
			} else {
				data = [];
			}
		} else {
			Error(data);

			data = [];
		}

		return data;
	}
}


/*	Form */
function UCForm(formId) {

	function getForm() {
		return $(formId || "form");
	}

	//{ async, *url, params, onLoad, onLoadSuccess }
	this.LoadForm = function (options) {
		$.ajax({
			async: options.async || false,
			data: options.params || {},
			type: "GET",
			url: options.url,
			statusCode: {
				200: options.onLoad || function (data) {
					if (options.onLoadSuccess)
						data = options.onLoadSuccess(data) || data;

					getForm().form("load", data);
				}
			}
		});
	}
	this.Load = function (data, selector) {
		//var data = options.data;
		var selector = $(selector || "fieldset");
		var fieldTypes = ["combobox", "combotree", "datetimebox", "datebox", "combo", "textbox"];

		for (var name in data) {
			var val = data[name];

			if (!_513(name, val)) {
				selector.find("input[name='" + name + "']").val(val);
				selector.find("textarea[name='" + name + "']").val(val);
				selector.find("select[name='" + name + "']").val(val);
			}
		}

		function _513(name, val) {
			var _515 = getForm().find("[textboxName=\"" + name + "\"]");
			if (_515.length) {
				for (var i = 0; i < fieldTypes.length; i++) {
					var type = fieldTypes[i];
					var _516 = _515.data(type);
					if (_516) {
						if (_516.options.multiple || _516.options.range) {
							_515[type]("setValues", val);
						} else {
							_515[type]("setValue", val);
						}
						return true;
					}
				}
			}
			return false;
		};
	}

	//{ async, method, *url, *data, statusCode }
	this.Submit = function (options) {
		var form = getForm();

		//验证表单
		if (form.form("validate")) {
			$("#save").linkbutton("disable");
		} else {
			$.messager.show({ msg: "请填写剩下的必填内容!" });

			return false;
		}

		if (options.method == "auto") {
			var method = uc.GetParams().method;

			if (method == "add") {
				options.method = "POST";
				options.url += "/POST";
			} else if (method == "mod") {
				options.method = "PUT"
				options.url += "/PUT";
			}
		}

		$.ajax({
			async: options.async || true,
			data: options.data,
			method: options.method || "GET",
			url: options.url,
			statusCode: options.statusCode || {
				200: function (data) {
					top.$.messager.show({ msg: "保存成功！" });

					uc.form.Cancel();
				}
			},
			error: function () {
				$("#save").linkbutton("enable");
			}
		});
	}

	this.Cancel = function () {
		getForm().form("reset");
		uc.CloseWindow();
	}

	this.DisableForm = function (selector) {
		selector = selector || "fieldset";

		$(selector + " select.easyui-combobox").combobox("disable");
		$(selector + " input.easyui-combobox").combobox("disable");
        $(selector + " input.easyui-datebox").datebox("disable");
        $(selector + " input.easyui-textbox").textbox("disable");
        $(selector + " input.easyui-combotree").combotree("disable");
        $(selector + " select.easyui-combotree").combotree("disable");
	}
}

/*	Datagrid */
function UCGrid(datagridId) {

	function getDatagrid() {
		return $(datagridId || ".easyui-datagrid");
	}

	this.GetSelected = function () {
		var row = getDatagrid().datagrid("getSelected");

		if (!row) {
			top.$.messager.show({ msg: "请选择一条记录!" });
		}

		return row;
	}
	this.Reload = function () {
		getDatagrid().datagrid("reload");
	}
	this.Reset = function () {
		$(".datagrid-toolbar div:first .textbox-f").textbox("reset");
		$(".datagrid-toolbar div:first .combobox-f").combobox("reset");
		$(".datagrid-toolbar form .textbox-f").textbox("reset");
		$(".datagrid-toolbar form .combobox-f").combobox("reset");

		uc.grid.Reload();
	}
	this.Closed = function () {
		uc.grid.Reload();
	}
}


$.extend($.fn.validatebox.defaults.rules, {
	//整数
	Integer: {
		validator: function (value, param) {
			return /^\-?\d+$/.test(value);
		},
		message: "请输入正确的整数！"
	},
	//数字
	Numerical: {
		validator: function (value, param) {
			return /^\d+(\.\d+)?$/.test(value);
		},
		message: "请输入正确的数值！"
	},
	// 价格
	Price: {
		validator: function (value, param) {
			return /^(\d{1,10})(\.\d{1,2})?$/.test(value);
		},
		message: "请输入数字,小数点后最多2位！"
    },
    // 利率
    Rate: {
        validator: function (value) {
            return /^(-?)(\d+)(\.?)(\d*)$/.test(value);
        },
        message: "请输入正确的利率。"
    },
    // 比例
    Ratio: {
        validator: function (value) {
            if (isNaN(value) == false) {
                if (value >= 0 && value <= 100)
                    return true;
            }

            return false;
        },
        message: '比例区间[0,100]'
    },
    // 日期
    Date: {
        validator: function (value) {
            return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000-01-01)"
    },
    // 日期时间
    DateTime: {
        validator: function (value) {
            return /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/.test(value);
        },
        message: "请输入正确的时间！(如:2000-01-01 00:00:00)"
    },
    // 年月
    YearMonth: {
        validator: function (value) {
            return /^\d{4}-\d{2}$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000-01)"
    },
    // 年
    Year: {
        validator: function (value) {
            return /^\d{4}$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000)"
    },
	//手机
	Mobile: {
		validator: function (value) {
			return /^[1](3|4|5|8)\d{9}$/.test(value);
		},
		message: "请输入正确的手机号码！(如:13800000000)"
    },
    // 邮箱
	Email: {
		validator: function (value) {
			return /^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$/.test(value);
		},
		message: "请输入正确的邮箱地址！"
    },
    // 身份证
	Identity: {
		validator: function (value) {
			return /^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$/.test(value);
		},
		message: "请输入正确的身份证号！"
	},
	// 邮编
	PostCode: {
		validator: function (value) {
			return /^\d{6}$/.test(value);
		},
		message: "请输入6位纯数字邮政编码！"
	},
	// 车牌号
	PlateNo: {
		validator: function (value) {
			return /^[\u4e00-\u9fa5]{1}[a-zA-Z]{1}[\da-zA-Z]{5}$/.test(value);
		},
		message: "请输入正确的车牌号！"
	},
	// 组织机构代码证
	OrganizationCode: {
		validator: function (value) {
			return /^[\da-zA-Z]{8}\-[\da-zA-Z]$/.test(value)
		},
		message: "请输入有效的组织机构代码证！(如：00000000-0)"
	},
	// 验证手机或电话
	PhoneOrMobile: {
		validator: function (value) {
			return /^(13|15|18)\d{9}$/i.test(value) || /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
		},
		message: '请填入手机或电话号码,如13800000000或010-8888888'
    },
	// 帐号
	checkUsernameFormat: {
		validator: function (value) {
			return /^[a-z\_]{1}\w{1,18}$/i.test(value);
		},
		message: "请输入正确的用户名，由字母、数字和下划线组成。不可以数字开头,长度在2-18位之间!"
    },
    // 帐号重复验证 [否决的]
    checkUsernameRepeat: {
        validator: function (value, param) {
            var result = true;

            $.ajax({
                async: false,
                data: { username: value },
                type: "GET",
                url: "../api/User/CheckUsername",
                statusCode: {
                    200: function (data) {
                        result = data == "False" ? false : true;
                    },
                    400: function (data) {
                    }
                }
            });

            return result;
        },
        message: '用户名已使用!'
    },
    // [否决的,使用 Price]
    Money: {
        validator: function (value) {
            if (/^-?\d+\.\d{2}$/.test(value) || /^\d+$/.test(value)) {
                if (value.length >= 2 && /^[0][0-9]*$/.test(value.substr(0, 2))) {
                    return false;
                }

                return true;
            }

            return false;
        },
        message: '请输入整数或两位小数！'
    },
    // [否决的, 使用 Ratio]
    ScaleRange: {
        validator: function (value, param) {
            if (param == undefined) {
                return value <= 100 && value >= 0;
            }
            else {
                return value <= param[1] && value >= param[0];
            }

            return false;
        },
        message: '比例区间超出边界！'
    }
});