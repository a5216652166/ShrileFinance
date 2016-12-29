$.extend($.fn.validatebox.defaults.rules, {
    AN: {
        validator: function (value) {
            return !/[\u4E00-\u9FA5\uF900-\uFA2D]/.test(value);
        },
        message: '只能输入字母或数字或字母数字组合'
    },
    N: {
        validator: function (value) {
            //return /^(\+|-)?\d+($|\.\d+$)/.test(value);
            return /^(\+|-)?\d+($|\d+$)/.test(value);
        },
        message: '请输入数字'
    },
    Integer: {// 验证整数
        validator: function (value) {
            return /^\d+$/.test(value);
        },
        message: '请输入整数'
    },
    PositiveInteger: {//验证正整数
        validator: function (value) {
            return /^[0-9]*[1-9][0-9]*$/.test(value);
        },
        message: '请输入正整数'
    },

    CodeLength: {
        validator: function (value, param) {
            return /^[a-zA-Z\d]{8}\-[a-zA-Z\d]$/.test(value)
        },
        message: '不是有效的组织机构代码证，如：46650460-6'
    },
    Date: {
        validator: function (value) {
            //格式yyyy-MM-dd或yyyy-M-d
            return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i.test(value);
        },
        message: '日期格式不正确(正确格式如:2010-01-02)'
    },
    DateTime: {//验证日期格式
        validator: function (value) {
            return /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/i.test(value);
        },
        message: '日期格式不对，如2015-12-31 00:00:00'
    }, Phone: {// 验证电话号码
        validator: function (value) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '格式不正确,请使用下面格式:010-88888888'
    },
    Mobile: {// 验证手机号码
        validator: function (value) {
            return /^(13|14|15|18)\d{9}$/i.test(value);
        },
        message: '手机号码格式不正确(正确格式如：13812345678)'
    },
    PhoneOrMobile: {//验证手机或电话
        validator: function (value) {
            return /^(13|15|18)\d{9}$/i.test(value) || /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '请填入手机或电话号码,如13800000000或010-8888888'
    },
    IDCard: {
        validator: function (value, param) {
            var flag = isCardID(value);
            return flag == true ? true : false;
        },
        message: '不是有效的身份证号码'
    },
    PostCode: {//验证邮政编码
        validator: function (value) {
            return /^[0-9][0-9]{5}?$/i.test(value);
        },
        message: '请输入6位纯数字邮政编码'
    },
    Amount: {// 验证金额
        validator: function (value) {
            return /^-?\d+\.\d{2}$/.test(value);
        },
        message: '金额保留两位小数，例如：1.00'
    },
    TimeTypeValid: {// 验证时间
        validator: function (value) {
            return value > '19000101';
        },
        message: '时间必须大于19000101'
    },
    GreaterThanZero: {// 验证大于0
        validator: function (value) {
            return value > 0;
        },
        message: '请输入大于0的数'
    },
    EffectiveYear: {// 验证有效年份
        validator: function (value) {
            return /^\d{4}$/.test(value) && value > 1900 && value <= new Date().getFullYear();
        },
        message: '年份区间 (1900,' + new Date().getFullYear() + "]"
    },
    CreditCard: {// 贷款卡编码 value:被校验值
        validator: function (value) {
            if (value.length > 16) {
                return true;
            }
            var regResult = false;

            // 基础校验（前3位为数字或者大写英文字母、后13位数字）
            regResult = /^[A-Z0-9]{3}\d{13}$|^\d{16}$/.test(value);

            // 后两位校验 前十四位乘以权重相加后除以97后的余数再加1后得到的数字
            if (regResult) {
                // 权重
                var array = new Array(1, 3, 5, 7, 11, 2, 13, 1, 1, 17, 19, 97, 23, 29);

                // 后两位校验
                var lastValue = 0;
                $(array).each(function (index, itemValue) {
                    // 十六进制转十进制后再进行计算
                    lastValue += itemValue * parseInt(value[index], 16);
                });

                lastValue = 1 + lastValue % 97;

                lastValue = lastValue > 10 ? lastValue : '0' + lastValue;
                regResult = lastValue == value.substr(14, 2);
            }

            return regResult;
        },
        message: '贷款卡编码错误'
    },
    LoanCardCode: {
        validator: function (value) {
            if (value.length > 16) {
                return true;
            }
            var regResult = false;

            // 基础校验（前3位为数字或者大写英文字母、后13位数字）
            regResult = /^[A-Z0-9]{3}\d{13}$|^\d{16}$/.test(value);

            // 后两位校验 前十四位乘以权重相加后除以97后的余数再加1后得到的数字
            if (regResult) {
                // 权重
                var array = new Array(1, 3, 5, 7, 11, 2, 13, 1, 1, 17, 19, 97, 23, 29);

                // 后两位校验
                var lastValue = 0;
                $(array).each(function (index, itemValue) {
                    // 十六进制转十进制后再进行计算
                    lastValue += itemValue * parseInt(value[index], 16);
                });

                lastValue = 1 + lastValue % 97;

                lastValue = lastValue > 10 ? lastValue : '0' + lastValue;
                regResult = lastValue == value.substr(14, 2);
            }

            return regResult;
        },
        message: '中征码错误'
    },
    OrganizateCode: {// 组织机构代码 value:被校验值，param:是否考虑10个'#'的特殊情况
        validator: function (value, param) {
            if (value.length > 10) {
                return true;
            }

            var regResult = false;

            // 10个'#'通过校验
            if (param[0] == true && /^[#]{10}/.test(value)) {
                return true;
            }

            // 基础校验（前8位为数字或者大写英文字母、后1位为校验码）
            regResult = /^[A-Z0-9]{8}-[A-Z0-9]$/.test(value);

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            value = value.replace('-', '');

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            if (regResult) {
                var W = new Array(3, 7, 9, 10, 5, 8, 4, 2);

                var C9 = 0;
                $(W).each(function (index, itemValue) {
                    C9 += parseInt(value[index], 36) * W[index];
                });
                C9 = 11 - C9 % 11;

                // 校验  当C9的值为10时，校验码应用大写的拉丁字母X表示；当C9的值为11时校验码用0表示。
                if (C9 == 10) {
                    regResult = value[8] == 'X';
                }
                else if (C9 == 11) {
                    regResult = value[8] == 0;
                }
                else {
                    // 三十六进制转十进制后进行校验
                    regResult = parseInt(value[8], 36) == C9;
                }
            }

            return regResult;
        },
        message: '组织机构代码错误，如：46650460-6'
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
    SharesProportion: {// 验证持股比例
        validator: function (value) {
            return /^\d+\.\d{2}$/.test(value) && value > 0 && value < 100;
        },
        message: '持股比例：(0.00,100.00)，且保留两位小数，例如：1.00'
    },
    PositiveNumber: {// 验证正实数
        validator: function (value) {
            return /^\d+\.\d+$/.test(value) || /^\d+$/.test(value);
        },
        message: '请输入正实数'
    },
    Money: {
        validator: function (value) {
            if (/^-?\d+\.\d{1}$/.test(value)) {
                return true;
            }

            if (/^-?\d+\.\d{2}$/.test(value) || /^\d+$/.test(value)) {
                if (value.length >= 2 && /^[0][0-9]*$/.test(value.substr(0, 2))) {
                    return false;
                }

                return true;
            }

            return false;
        },
        message: '请输入整数、一位小数或两位小数！'
    },
    InCredit: {
        validator: function (value) {
            if (value.toString().length != 18)
            {
                return true;
            }

            // 不得使用大写英文字母“I”、“O”、“Z”、“S”和“V”
            if (/[(I)|(O)|(Z)|(S)|(V)]/.test(value)) {
                return false;
            }

            var regx = /^[0-9A-Z][0-9]{5}[0-9A-Z]{9}[0-9A-Z]/;

            if (!regx.test(value.toString())) {
                return false;
            }

            return true;
        },
        message: '机构信用代码错误！'
    },
    TaxpayerIdentify: {
        validator: function (value) {
            if (value.toString().length != 15) {
                return true;
            }
            // 校验前6位
            if (!/^[0-9]+$/.test(value.substr(0, 6)))
            {
                return false;
            }

            // 校验后9位
            var temp = value.substr(6);
            
            // 基础校验（前8位为数字或者大写英文字母、后1位为校验码）
            var regResult = /^[A-Z0-9]{8}[A-Z0-9]$/.test(temp);

            // 校验码 C9=11-MOD(∑Ci(i=1→8)×Wi,11)
            if (regResult) {
                var W = new Array(3, 7, 9, 10, 5, 8, 4, 2);

                var C9 = 0;
                $(W).each(function (index, itemValue) {
                    C9 += parseInt(temp[index], 36) * W[index];
                });
                C9 = 11 - C9 % 11;

                // 校验  当C9的值为10时，校验码应用大写的拉丁字母X表示；当C9的值为11时校验码用0表示。
                if (C9 == 10) {
                    regResult = temp[8] == 'X';
                }
                else if (C9 == 11) {
                    regResult = temp[8] == 0;
                }
                else {
                    // 三十六进制转十进制后进行校验
                    regResult = parseInt(temp[8], 36) == C9;
                }
            }

            return regResult;
        },
        message: '纳税人识别号错误！'
    },
    ManagementerCode: {
        validator: function (value) {
            if (value == null || value.toString().length <= 1 || !/[A-Za-z0-9]+$/.test(value)) {
                return false;
            }

            var validValue = 10;
            for (var i = 0; i < value.toString().length - 1; i++) {
                var temp = (parseInt(value[i]) + validValue) % 10;

                validValue = temp == 0 ? 9 : (temp * 2) % 11;
            }

            return (11 - validValue) % 11 == parseInt(value[value.toString().length - 1]);
        },
        message: '管理行代码错误！'
    }
});