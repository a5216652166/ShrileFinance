using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class JKRCWValidates: BaseValidate
    {
        private int  typeId ;
        //借款人财务信息记录
        public JKRCWValidates(  int infoTypeId,MessageInfo data) : base(data)
        {
            typeId = infoTypeId;
            Valid(infoTypeId,data);
        }
        public override void Valid(int infoTypeId,MessageInfo data)
        {
            base.Valid(infoTypeId,data);

            if (!string.IsNullOrEmpty(PData.SegmentRules["G173"]))
            {
                if (PData.SegmentRules["G165"] == "") PData.SegmentRules["G165"] = "0.0";
                if (PData.SegmentRules["G172"] == "") PData.SegmentRules["G172"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["G173"])!= Convert.ToDecimal(PData.SegmentRules["G165"])+ Convert.ToDecimal(PData.SegmentRules["G172"]))
                {
                    throw new ApplicationException("“负债和所有者权益合计”的值必须等于“负债合计”+“所有者权益合计”之和;正确值为："+ (Convert.ToDecimal(PData.SegmentRules["G165"]) + Convert.ToDecimal(PData.SegmentRules["G172"])) +"");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["G140"]))
            {
                if(PData.SegmentRules["G173"]!= PData.SegmentRules["G140"])
                {
                    throw new ApplicationException("“资产总计”的值必须等于“负债和所有者权益合计”；正确值为" + PData.SegmentRules["G173"] + "");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["I260"]))
            {
                if (PData.SegmentRules["I254"] == "") PData.SegmentRules["I254"] = "0.0";
                if (PData.SegmentRules["I259"] == "") PData.SegmentRules["I259"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["I260"]) != Convert.ToDecimal(PData.SegmentRules["I254"]) - Convert.ToDecimal(PData.SegmentRules["I259"]))
                {
                    throw new ApplicationException("“经营活动产生的现金流量净额”的值必须等于“经营活动现金流入小计”-“经营活动现金流出小计”之差；正确值为："+(Convert.ToDecimal(PData.SegmentRules["I254"]) - Convert.ToDecimal(PData.SegmentRules["I259"])) +"'"  );
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["I275"]))
            {
                if (PData.SegmentRules["I267"] == "") PData.SegmentRules["I267"] = "0.0";
                if (PData.SegmentRules["I274"] == "") PData.SegmentRules["I274"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["I275"]) != Convert.ToDecimal(PData.SegmentRules["I267"]) - Convert.ToDecimal(PData.SegmentRules["I274"]))
                {
                    throw new ApplicationException("“投资活动产生的现金流量净额”的值必须等于“投资活动现金流入小计”-“投资活动现金流出小计”之差；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["I267"]) - Convert.ToDecimal(PData.SegmentRules["I274"])) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["I284"]))
            {
                if (PData.SegmentRules["I279"] == "") PData.SegmentRules["I279"] = "0.0";
                if (PData.SegmentRules["I283"] == "") PData.SegmentRules["I283"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["I284"]) != Convert.ToDecimal(PData.SegmentRules["I279"]) - Convert.ToDecimal(PData.SegmentRules["I283"]))
                {
                    throw new ApplicationException("“筹集活动产生的现金流量净额”的值必须等于“筹资活动现金流入小计”-“筹资活动现金流出小计”之差；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["I279"]) - Convert.ToDecimal(PData.SegmentRules["I283"])) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["I286"]))
            {
                if (PData.SegmentRules["I260"] == "") PData.SegmentRules["I260"] = "0.0";
                if (PData.SegmentRules["I275"] == "") PData.SegmentRules["I275"] = "0.0";
                if (PData.SegmentRules["I284"] == "") PData.SegmentRules["I284"] = "0.0";
                if (PData.SegmentRules["I285"] == "") PData.SegmentRules["I285"] = "0.0";

                if (Convert.ToDecimal(PData.SegmentRules["I286"]) != Convert.ToDecimal(PData.SegmentRules["I260"]) + Convert.ToDecimal(PData.SegmentRules["I275"]) + Convert.ToDecimal(PData.SegmentRules["I284"]) + Convert.ToDecimal(PData.SegmentRules["I285"]))
                {
                    throw new ApplicationException("“现金及现金等价物净增加额(五)”的值必须等于“经营活动产生的现金流量净额”+“投资活动产生的现金流量净额”+“筹集活动产生的现金流量净额”+“汇率变动对现金及现金等价物的影响”之和；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["I260"]) + Convert.ToDecimal(PData.SegmentRules["I275"]) + Convert.ToDecimal(PData.SegmentRules["I284"]) + Convert.ToDecimal(PData.SegmentRules["I285"]) + "'"));
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["I288"]))
            {
                if (PData.SegmentRules["I286"] == "") PData.SegmentRules["I286"] = "0.0";
                if (PData.SegmentRules["I287"] == "") PData.SegmentRules["I287"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["I288"]) != Convert.ToDecimal(PData.SegmentRules["I286"])+ Convert.ToDecimal(PData.SegmentRules["I287"]))
                {
                    throw new ApplicationException("“期末现金及现金等价物余额(六)”的值必须等于“现金及现金等价物净增加额(五)”+“期初现金及现金等价物余额”之和；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["I286"]) + Convert.ToDecimal(PData.SegmentRules["I287"])) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["J360"]))
            {
                if (PData.SegmentRules["J348"] == "") PData.SegmentRules["J348"] = "0.0";
                if (PData.SegmentRules["J359"] == "") PData.SegmentRules["J359"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["J360"]) != Convert.ToDecimal(PData.SegmentRules["J348"]) + Convert.ToDecimal(PData.SegmentRules["J359"]))
                {
                    throw new ApplicationException("“资产部类总计”的值必须等于“资产合计”+“支出合计”之和；正确值为：" +( Convert.ToDecimal(PData.SegmentRules["J348"]) + Convert.ToDecimal(PData.SegmentRules["J359"])) + "'");
                }
            }
          
            if (!string.IsNullOrEmpty(PData.SegmentRules["J387"]))
            {
                if (PData.SegmentRules["J370"] == "") PData.SegmentRules["J370"] = "0.0";
                if (PData.SegmentRules["J378"] == "") PData.SegmentRules["J378"] = "0.0";
                if (PData.SegmentRules["J386"] == "") PData.SegmentRules["J386"] = "0.0";

                if (Convert.ToDecimal(PData.SegmentRules["J387"]) != Convert.ToDecimal(PData.SegmentRules["J370"]) + Convert.ToDecimal(PData.SegmentRules["J378"]) + Convert.ToDecimal(PData.SegmentRules["J386"]))
                {
                    throw new ApplicationException("“负债部类总计”的值必须等于“负债合计”+“净资产合计”+“收入合计”之和；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["J370"]) + Convert.ToDecimal(PData.SegmentRules["J378"]) + Convert.ToDecimal(PData.SegmentRules["J386"])) + "'");
                }
            }
          
            if (!string.IsNullOrEmpty(PData.SegmentRules["K437"]))
            {
                if (PData.SegmentRules["K415"] == "") PData.SegmentRules["K415"] = "0.0";
                if (PData.SegmentRules["K429"] == "") PData.SegmentRules["K429"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["K437"]) != Convert.ToDecimal(PData.SegmentRules["K415"]) - Convert.ToDecimal(PData.SegmentRules["K429"]))
                {
                    throw new ApplicationException("“事业结余”的值必须等于“事业收入小计”-“事业支出小计”之差；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["K415"]) - Convert.ToDecimal(PData.SegmentRules["K429"])) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["K440"]))
            {
                if (PData.SegmentRules["K417"] == "") PData.SegmentRules["K417"] = "0.0";
                if (PData.SegmentRules["K432"] == "") PData.SegmentRules["K432"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["K440"]) != Convert.ToDecimal(PData.SegmentRules["K417"]) - Convert.ToDecimal(PData.SegmentRules["K432"]))
                {
                    throw new ApplicationException("“经营结余”的值必须等于“经营收入小计”-“经营支出小计”之差；正确值为：" + (Convert.ToDecimal(PData.SegmentRules["K417"]) - Convert.ToDecimal(PData.SegmentRules["K432"])) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.Mates["2591"]))
            {
                if (Convert.ToInt32(PData.Mates["2591"]) <= 1900)
                {
                    throw new ApplicationException("“报表年份”必须为有效年份并且大于1900");
                }
            }

            if (!string.IsNullOrEmpty(PData.SegmentRules["K420"])|| string.IsNullOrEmpty(PData.SegmentRules["K420"]))
            {
                if(PData.SegmentRules["K420"]=="") PData.SegmentRules["K420"] = "0.0";
                if (PData.SegmentRules["K415"] == "") PData.SegmentRules["K415"] = "0.0";
                if (PData.SegmentRules["K417"] == "") PData.SegmentRules["K417"] = "0.0";
                if (PData.SegmentRules["K419"] == "") PData.SegmentRules["K419"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["K420"]) != Convert.ToDecimal(PData.SegmentRules["K415"]) + Convert.ToDecimal(PData.SegmentRules["K417"]) + Convert.ToDecimal(PData.SegmentRules["K419"]))
                {
                    throw new ApplicationException("“收入总计”的值必须等于“事业收入小计”+“经营收入小计”+“拨入专款小计”之和；正确值为：" + Convert.ToDecimal(PData.SegmentRules["K415"]) + Convert.ToDecimal(PData.SegmentRules["K417"]) + Convert.ToDecimal(PData.SegmentRules["K419"]) + "'");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["K436"])|| string.IsNullOrEmpty(PData.SegmentRules["K436"]))
            {
                if (PData.SegmentRules["K436"] == "") PData.SegmentRules["K436"] = "0.0";
                if (PData.SegmentRules["K429"] == "") PData.SegmentRules["K429"] = "0.0";
                if (PData.SegmentRules["K432"] == "") PData.SegmentRules["K432"] = "0.0";
                if (PData.SegmentRules["K435"] == "") PData.SegmentRules["K435"] = "0.0";
                if (Convert.ToDecimal(PData.SegmentRules["K436"]) != Convert.ToDecimal(PData.SegmentRules["K429"]) + Convert.ToDecimal(PData.SegmentRules["K432"]) + Convert.ToDecimal(PData.SegmentRules["K435"]))
                {
                    throw new ApplicationException("“支出总计”的值必须等于“事业支出小计”+“经营支出小计”+“专款小计”之和；正确值为：" + Convert.ToDecimal(PData.SegmentRules["K429"]) + Convert.ToDecimal(PData.SegmentRules["K432"]) + Convert.ToDecimal(PData.SegmentRules["K435"]) + "'");
                }
            }
            //校验报表类型
            if (!string.IsNullOrEmpty(PData.Mates["7507"]))
            {
                string[] result = new string[] { };
                if(infoTypeId == 3 || infoTypeId == 4)
                {
                    result = new string[] { "11","12","21","22","31","32","41","42","51","52","61","62","71","72"};
                }
                else if (infoTypeId == 5)
                {
                    result = new string[] { "10","20","30", "40","50","60","70" };
                }
                else if (infoTypeId == 6)
                {
                    result = new string[] { "11","12" };
                }
                else if (infoTypeId == 7)
                {
                    result = new string[] { "10" };
                }
                if (!result.Contains(PData.Mates["7507"]))
                {
                    throw new ApplicationException("“报表类型”值不正确");
                }
            }
        }

        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            string[] segment = new string[] { };
            if (typeId == 3)
            {
                segment = new string[] { "B", "G" };
            }
            else if(typeId == 4)
            {
                segment = new string[] { "B", "H" };
            }
            else if (typeId == 5)
            {
                segment = new string[] { "B", "I" };
            }
            else if (typeId == 6)
            {
                segment = new string[] { "B", "J" };
            }
            else if (typeId == 7)
            {
                segment = new string[] { "B", "K" };
            }
            segments = segment;
            // 分别对报表类型段规则,G173负债和所有者权益合计,G165负债合计,G172所有者权益合计,G173负债和所有者权益合计,G140资产总计,I260经营活动产生的现金流量净额,
            // I254经营活动现金流入小计,I259经营活动现金流出小计,I275投资活动产生的现金流量净额,i267投资活动现金流入小计,I274投资活动现金流出小计,i284筹集活动产生的现金流量净额,I279筹资活动现金流入小计
            // I283筹资活动现金流出小计,I286现金及现金等价物净增加额(五),I285汇率变动对现金及现金等价物的影响,I287期初现金及现金等价物余额,I288期末现金及现金等价物余额(六),J360,J348资产合计,J359支出合计
            // J387负债部类总计,J370负债合计,J378净资产合计,J386收入合计,K420收入总计,K415事业收入小计,K417经营收入小计,K419拨入专款小计,K436支出总计,K429事业支出小计,K432经营支出小计,K435专款小计,K437事业结余,K440经营结余
            // G918\H943\I976证件类型;G919\H944\I977证件号码
            segmentRules = new string[] { "B193","B179","B181","B201","G173" ,"G165","G172","G140","I260","I254","I259","I275","I267","I274","I284","I279","I283","I286","I285","I287","I288","J360","J348","J359","J387",
            "J370","J378","J386","K420","K415","K417","K419","K436","K429","K432","K435","K437","K440","G918","H943","I976","G919","H944","I977",""};
            //分别对报表类型数据元ID,9159负债和所有者权益合计,9152负债合计,9158所有者权益合计,9130资产总计,9208经营活动产生的现金流量净额,9202经营活动现金流入小计
            //,9207经营活动现金流出小计,9220投资活动产生的现金流量净额,9214投资活动现金流入小计,9219投资活动现金流出小计,9229筹集活动产生的现金流量净额,9224筹资活动现金流入小计,9228筹资活动现金流出小计
            //9231现金及现金等价物净增加额(五),9230汇率变动对现金及现金等价物的影响,9232期初现金及现金等价物余额,9233期末现金及现金等价物余额(六),9294资产部类总计,9282资产合计,9293支出合计
            //9320负债部类总计,9303负债合计,9311净资产合计,9319收入合计,9341收入总计,9336事业收入小计,9338经营收入小计,9340拨入专款小计,9357支出总计,9350事业支出小计,9353经营支出小计,9356专款小计,9358事业结余,9361经营结余
            //5511证件类型,5553证件号码,2591报表年份
            mates = new string[] { "7507","9159","9152","9158","9130","9208","9202","9207","9220","9214","9219","9229","9224","9228","9231","9230","9232","9233",
                "9294","9282","9293","9320","9303","9311","9319","9341","9336","9338","9340","9357","9350","9353","9356","9358","9361","5511","5553","2591"};
        }
    }
}