namespace BLL.BankCredit
{
    using System;
    using System.Collections.Generic;

    public class CodeProofMethod : BaseProofMethod
    {
        private static readonly DAL.BankCredit.DictionaryCodeMapper DictionaryCode = new DAL.BankCredit.DictionaryCodeMapper();
        private static readonly DAL.BankCredit.SegmentRulesMapper SegmentRulesMapper = new DAL.BankCredit.SegmentRulesMapper();

        /// <summary>
        /// 代码校验
        /// </summary>
        /// yangj 16.9.20
        /// <param name="segmentRulesId">段规则标识</param>
        /// <param name="code">字典代码</param>
        /// <returns></returns>
        public bool CodePoorfMethod(int segmentRulesId, string code)
        {
            // 查询字典表并返回校验结果
            int result = DictionaryCode.CodeProofMethod(segmentRulesId, code);

            if (result <= 0)
            {
                return false;
            }

            // 如果存在返回true
            return true;
        }

        /// <summary>
        /// 获取信息记录下的下拉框,并调用代码校验方法
        /// </summary>
        /// yangj   16.9.20
        /// <param name="infoTypeId">信息记录ID</param>
        /// <param name="dic">集合</param>
        /// <returns></returns>
        public bool BaseInfo(int infoTypeId, KeyValuePair<string, string> dic)
        {
            int name = 0;
            bool result = true;
            string value = string.Empty;

            // 标签类型为“4-下拉框”
            int htmlId = 4;

            // 数据段规则ID
            name = Convert.ToInt32(dic.Key.Substring(1, dic.Key.Length - 1));

            // Value值
            value = dic.Value;

            // 查找所有下拉框的数据段规则ID
            var segmentRulesList = SegmentRulesMapper.CodeProofMethod(infoTypeId, htmlId) ?? new System.Data.DataTable();

            // 遍历所有下拉框数据段规则ID
            for (var i = 0; i < segmentRulesList.Rows.Count; i++)
            {
                var segmentRulesId = segmentRulesList.Rows[i][0];

                if (!(segmentRulesId is DBNull))
                {
                    if (name == Convert.ToInt32(segmentRulesId))
                    {
                        // 调用校验方法
                        result = CodePoorfMethod(name, value);
                    }
                }
            }

            return result;
        }
    }
}
