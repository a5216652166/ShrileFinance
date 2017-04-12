namespace Core.Entities.Vehicle
{
    using System;

    public class Vehicle : Entity
    {
        public enum ConditionEnum : byte
        {
            /// <summary>
            /// 新车
            /// </summary>
            新车 = 0,

            /// <summary>
            /// 二手车
            /// </summary>
            二手车 = 1
        }

        public enum BusinessTypeEnum : byte
        {
            /// <summary>
            /// 新车交易贷
            /// </summary>
            新车交易贷 = 0,

            /// <summary>
            /// 二手车交易贷
            /// </summary>
            二手车交易贷 = 1,

            /// <summary>
            /// 车抵贷
            /// </summary>
            车抵贷 = 2,

            /// <summary>
            /// 押车贷
            /// </summary>
            押车贷 = 3,

            /// <summary>
            /// 快速贷
            /// </summary>
            快速贷 = 4,

            /// <summary>
            /// 以租代购
            /// </summary>
            以租代购 = 5
        }

        /// <summary>
        /// 品牌
        /// </summary>
        public string MakeCode { get; set; }

        /// <summary>
        /// 车况
        /// </summary>
        public int VehicleCondition { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        public string FamilyCode { get; set; }

        /// <summary>
        /// 车型ID
        /// </summary>
        public string VehicleKey { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 上牌城市
        /// </summary>
        public string RegisterCity { get; set; }

        /// <summary>
        /// 卖家姓名
        /// </summary>
        public string SallerName { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string FrameNo { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNo { get; set; }

        /// <summary>
        /// 注册登记日期
        /// </summary>
        public string RegisterDate { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public int? RunningMiles { get; set; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        public string FactoryDate { get; set; }

        /// <summary>
        /// 购买年份
        /// </summary>
        public int? BuyCarYears { get; set; }

        /// <summary>
        /// 车身颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 车况
        /// </summary>
        public ConditionEnum Condition { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public BusinessTypeEnum BusinessType { get; set; }
    }
}
