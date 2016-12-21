using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.IO;

namespace Core.Tests
{
    /// <summary>
    /// PackingTest 的摘要说明
    /// </summary>
    [TestClass]
    public class PackingTest
    {
        /// <summary>
        /// 运行测试报文封装
        /// </summary>
        [TestMethod]
        public void PackTest()
        {
            var baseParagraph = new BaseParagraph
            {
                信息记录长度 = 88,
                信息记录类型 = 04,
                借款人名称 = "严冬",
                贷款卡编号 = "DK01234567898888",
                报表年份 = 2016,
                报表类型 = 08,
                报表类型细分 = 3,
                审计事务所名称 = "云为科技事务所",
                审计人员名称 = "王鹏飞",
                审计时间 = 20161221,
                信息记录操作类型 = 1,
                业务发生日期 = 20161220,
            };
            StringBuilder builder = new StringBuilder();
            baseParagraph.Packaging(builder);
            System.Diagnostics.Debug.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 类数据配置封装测试
        /// </summary>
        [TestMethod]
        public void ConvertEntity()
        {
            StringBuilder builder = new StringBuilder();
            Model2Entity.ConvertEntity<BaseParagraph>(builder);

            string filePath = "c:\\Entity.txt";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            byte[] data = Encoding.Default.GetBytes(builder.ToString());

            fs.Write(data, 0, data.Length);

            fs.Flush();
            fs.Close();

            System.Diagnostics.Debug.WriteLine(builder.ToString());
        }
    }
}
