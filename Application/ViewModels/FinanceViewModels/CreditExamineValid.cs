﻿namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 身份证校验
    /// </summary>
    public class IdCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            return true;
        }
    }

    /// <summary>
    /// 信用状况范围
    /// </summary>
    public class CreditConditionRangAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            var array = new string[] { "良好", "90+", "60+", "累6", "呆账" };

            return array.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 年龄区间
    /// </summary>
    public class AgeRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            var array = new string[] { "20-28岁", "28-55岁", "55-65岁", "其他" };

            return array.Contains(value.ToString());
        }
    }

    /// <summary>
    /// 房产
    /// </summary>
    public class RealEstateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            value = value ?? string.Empty;

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            var array = new string[] { "60平以上", "30万以上", "两套以上（含）", "其他" };

            return array.Contains(value.ToString());
        }
    }





}