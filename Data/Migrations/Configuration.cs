namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Core.Entities;
    using Core.Entities.Identity;
    using Core.Entities.Process;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyContext context)
        {
            IdentitySeed(context);

            FlowSeed(context);

            context.SaveChanges();
        }

        /// <summary>
        /// Identity Seed
        /// </summary>
        /// <param name="context">context</param>
        private void IdentitySeed(MyContext context)
        {
            context.Set<AppRole>().AddOrUpdate(
                m => m.Id,
                /* 系统角色 */
                new AppRole { Id = "BB42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "系统管理员", Power = 1 },
                new AppRole { Id = "BC42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "管理员", Power = 2 },

                /* 流程公共角色 */
                new AppRole { Id = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "客户经理", Power = 4 },
                new AppRole { Id = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "总经理", Power = 2 },

                /* 个人业务系统特有角色 */
                new AppRole { Id = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "风控初审员", Power = 3 },
                new AppRole { Id = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "风控复审员", Power = 3 },
                new AppRole { Id = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营初审员", Power = 3 },
                new AppRole { Id = "C042BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营复审员", Power = 3 },
                new AppRole { Id = "C142BEE1-05A4-E611-80C5-507B9DE4A488", Name = "财务总监", Power = 3 },

                /* 机构业务系统特有角色 */
                new AppRole { Id = "C542BEE1-05A4-E611-80C5-507B9DE4A488", Name = "出纳", Power = 3 },
                new AppRole { Id = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "有权审核人", Power = 3 });

            context.Set<AppUser>().AddOrUpdate(
                m => m.Id,
                new AppUser
                {
                    Id = "0075D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "sysadmin",
                    Name = "系统管理员",
                    Email = "sysadmin@shrile.com",
                    PasswordHash = "AFTVSgxvNx+xKz3M7mlM2oNXEleZYIshilT7hA139cXW/4GI6sPVt051PL1WEZ4jhQ==",
                    SecurityStamp = "f7ed34ab-484b-4660-aa15-58d8384ef6fb"
                },
                new AppUser
                {
                    Id = "0175D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "foolishqi",
                    Name = "七月",
                    Email = "qiy@ywsoftware.com",
                    PhoneNumber = "18858261668",
                    PasswordHash = "ACIJtS4jqQUARKbBSMOwza0fOQmx9WTAi1C3Y4K9cP7/nXzu5sfLCvNgppBKGHvgcQ==",
                    SecurityStamp = "9312a299-ca53-43ee-9d03-b01dcd9cd2fe",
                },
                new AppUser
                {
                    Id = "0275D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "admin",
                    Name = "管理员",
                    Email = "admin@shrile.com",
                    PasswordHash = "ABGSBqolk/br5dLd1Lb4XHrzh5WaZ3/f8EIns+n5dm0tUEbfbHU2n1shAMIi+cAOdA==",
                    SecurityStamp = "527428b7-c5af-40f1-95b8-f2383c606057"
                });

            context.Set<IdentityUserRole>().AddOrUpdate(
                m => m.UserId,
                new IdentityUserRole { UserId = "0075D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BB42BEE1-05A4-E611-80C5-507B9DE4A488" },
                new IdentityUserRole { UserId = "0175D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BB42BEE1-05A4-E611-80C5-507B9DE4A488" },
                new IdentityUserRole { UserId = "0275D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BC42BEE1-05A4-E611-80C5-507B9DE4A488" });

            context.SaveChanges();
        }

        /// <summary>
        /// Flow Seed
        /// </summary>
        /// <param name="context">context</param>
        private void FlowSeed(MyContext context)
        {
            context.Set<Flow>().AddOrUpdate(
                m => m.Id,
                /* 个人业务系统特有流程 */
                new Flow { Id = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资流程" },

                /* 机构业务系统特有流程 */
                new Flow { Id = new Guid("{04824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "新增机构流程" },
                new Flow { Id = new Guid("{05824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "贷款流程" },
                new Flow { Id = new Guid("{06824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "借据流程" },
                new Flow { Id = new Guid("{07824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "还款流程" },
                new Flow { Id = new Guid("{08824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "机构变更流程" });

            context.Set<Node>().AddOrUpdate(
                m => m.Id,

                // 融资流程节点 
                // 融资申请
                new Node { Id = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "融资申请" },
                // 申请人资料上传
                new Node { Id = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "申请人资料上传" },
                // 风控初审
                new Node { Id = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "风控初审" },
                // 风控复审
                new Node { Id = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "风控复审" },
                // 总经理审批(风控)
                new Node { Id = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "总经理审批(风控)" },
                // 放款资料整理
                new Node { Id = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款资料整理" },
                // 放款资料上传
                new Node { Id = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款资料上传" },
                // 运营初审
                new Node { Id = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营初审" },
                // 运营复审
                new Node { Id = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营复审" },
                // 总经理审批(放款)
                new Node { Id = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "总经理审批(放款)" },
                // 财务放款
                new Node { Id = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", Name = "财务放款" },

                /* 新增机构节点（客户经理 —— 有权审核人 -- 总经理） */
                new Node { Id = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{04824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构信息" },
                new Node { Id = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{04824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构审核" },
                new Node { Id = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{04824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构审批" },

                /* 新增贷款节点（客户经理 —— 有权审核人 -- 总经理） */
                new Node { Id = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{05824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "贷款合同" },
                new Node { Id = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{05824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "贷款合同审核" },
                new Node { Id = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{05824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "贷款合同审批" },

                /* 新增借据节点（客户经理 —— 有权审核人 -- 总经理） */
                new Node { Id = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{06824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "借据管理" },
                new Node { Id = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{06824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "借据管理审核" },
                new Node { Id = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{06824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "借据管理审批" },

                /* 新增还款节点（客户经理 -- 出纳 —— 有权审核人）  */
                new Node { Id = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{07824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "还款管理" },
                new Node { Id = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{07824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C542BEE1-05A4-E611-80C5-507B9DE4A488", Name = "还款管理审核" },
                new Node { Id = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{07824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "还款管理审批" },

                /* 机构变更节点（客户经理 —— 有权审核人 -- 总经理） */
                new Node { Id = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{08824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构变更信息" },
                new Node { Id = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{08824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构变更审核" },
                new Node { Id = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FlowId = new Guid("{08824FE1-78D1-E611-80CA-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "机构变更审批" });

            context.Set<FAction>().AddOrUpdate(
                m => m.Id,

                /* 融资流程节点行为 */
                // 融资申请(流转至申请人资料上传节点)
                new FAction { Id = new Guid("{294B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.发起者, Method = "FinanceApply" },

                // 申请人资料上传(流转至风控初审节点)
                new FAction { Id = new Guid("{284B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },

                // 风控初审(流转至风控复审)
                new FAction { Id = new Guid("{2A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "FinanceAudit" },

                // 风控初审(退回至融资申请)
                new FAction { Id = new Guid("{2B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 风控复审(流转至总经理审批(风控))
                new FAction { Id = new Guid("{2C4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "FinanceReaudit" },

                // 风控复审(退回至融资申请)
                new FAction { Id = new Guid("{2D4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 总经理审批(风控)(流转至放款资料整理)
                new FAction { Id = new Guid("{2E4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },

                // 总经理审批(风控)(退回至融资申请)
                new FAction { Id = new Guid("{2F4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至客户", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 总经理审批(风控)(退回至风控复审)
                new FAction { Id = new Guid("{304B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至复审", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 总经理审批(风控)(终止)
                new FAction { Id = new Guid("{314B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },

                // 放款资料整理(流转至放款资料上传)
                new FAction { Id = new Guid("{324B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = "FinanceOperation" },

                // 放款资料上传(流转至运营初审)
                new FAction { Id = new Guid("{334B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "FinanceCustomer" },

                // 运营初审(流转至运营复审)
                new FAction { Id = new Guid("{344B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },

                // 运营初审(退回至放款资料上传)
                new FAction { Id = new Guid("{354B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 运营复审(流转至总经理审批(放款))
                new FAction { Id = new Guid("{364B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },

                // 运营复审(退回至放款资料上传)
                new FAction { Id = new Guid("{374B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 总经理审批(放款)(流转至财务放款)
                new FAction { Id = new Guid("{384B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },

                // 总经理审批(放款)(退回至放款资料上传)
                new FAction { Id = new Guid("{394B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },

                // 总经理审批(放款)(终止)
                new FAction { Id = new Guid("{3A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },

                // 财务放款(完成)
                new FAction { Id = new Guid("{3B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "FinanceFinish" },

                /* 机构流程节点行为  */
                // 客户经理（发起）
                new FAction { Id = new Guid("{A36FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.指定, Method = "Organization" },

                // 有权审核人（通过、退回）
                new FAction { Id = new Guid("{A46FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{A56FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },

                // 总经理（通过、退回）
                new FAction { Id = new Guid("{A66FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "OrganizationFinish" },
                new FAction { Id = new Guid("{A76FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },

                /* 贷款流程  */
                // 客户经理
                new FAction { Id = new Guid("{A86FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.指定, Method = "CreditContract" },
                new FAction { Id = new Guid("{A96FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{AA6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },
                new FAction { Id = new Guid("{AB6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "CreditContractSigned" },
                new FAction { Id = new Guid("{AC6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },

                /* 借据流程 */
                new FAction { Id = new Guid("{AD6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.指定, Method = "Loan" },
                new FAction { Id = new Guid("{AE6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{AF6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },
                new FAction { Id = new Guid("{B06FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "LoanFinish" },
                new FAction { Id = new Guid("{B16FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },

                /* 还款流程  */
                new FAction { Id = new Guid("{B26FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.指定, Method = "Payment" },
                new FAction { Id = new Guid("{B36FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{B46FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },
                new FAction { Id = new Guid("{B56FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "PaymentFinish" },
                new FAction { Id = new Guid("{B66FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },

                /* 机构变更流程  */
                new FAction { Id = new Guid("{B76FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.指定, Method = "OrganizateChange" },
                new FAction { Id = new Guid("{B86FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{B96FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null },
                new FAction { Id = new Guid("{BA6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "OrganizateChangeFinish" },
                new FAction { Id = new Guid("{BB6FA6EB-62D1-E611-80CA-507B9DE4A488}"), NodeId = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), TransferId = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = null });

            context.Set<Form>().AddOrUpdate(
                m => m.Id,

                /* 个人业务系统表单 */
                // 融资申请
                new Form { Id = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资申请", Link = "../Finance/FinanceEdit.html", Sort = 200 },

                // 申请人资料上传
                new Form { Id = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "申请人资料上传", Link = "../Finance/UploadForApplicant.html", Sort = 200 },

                // 融资审核  (风控初审、风控复审)
                new Form { Id = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资审核", Link = "../Finance/FinanceAudit.html", Sort = 200 },

                // 信息补充  (放款资料整理)
                new Form { Id = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "信息补充", Link = "../Finance/FinanceOperation.html", Sort = 200 },

                // 放款资料上传
                new Form { Id = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "放款资料上传", Link = "../Finance/UploadForLoan.html", Sort = 200 },

                ////// 运营审核  (运营初审、运营复审)
                ////new Form { Id = new Guid("{15DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "运营审核", Link = "../Finance/FinanceApproval.html", Sort = 200 },

                // 财务放款
                new Form { Id = new Guid("{16DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "财务信息", Link = "../Finance/LoanInfo.html", Sort = 200 },

                // 审核意见(通用)
                new Form { Id = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "审核意见", Link = "../Process/ExamineOpinion.html", Sort = 200 },

                /* 企业业务系统表单 */
                new Form { Id = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{04824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "机构管理", Link = "../Borrowers/OrganizatePage.html", Sort = 200 },
                new Form { Id = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{05824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "贷款合同", Link = "../Loan/CreditContractEdit.html", Sort = 200 },
                new Form { Id = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{06824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "借据申请", Link = "../Loan/LoanEdit.html?view=loan", Sort = 200 },
                new Form { Id = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{07824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "还款管理", Link = "../Loan/LoanEdit.html?view=payment", Sort = 200 },
                new Form { Id = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{08824FE1-78D1-E611-80CA-507B9DE4A488}"), Name = "机构变更", Link = "../Borrowers/OrganizateChange.html", Sort = 200 });

            context.Set<FormNode>().AddOrUpdate(
                m => new { m.NodeId, m.FormId },
                /* 融资流程 */

                // 融资申请 (融资申请 + 审核意见)
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 申请人资料上传 (融资申请 + 申请人资料上传 + 审核意见)
                new FormNode { NodeId = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0895D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 风控初审 (融资申请 + 申请人资料上传 + 融资审核 + 审核意见)
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 风控复审 (融资申请 + 申请人资料上传 + 融资审核 + 审核意见)
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.部分启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 总经理审批(风控) (融资申请 + 申请人资料上传 + 融资审核 + 审核意见)
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 放款资料整理 (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 审核意见)
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 放款资料上传 (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 审核意见)
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.部分启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 运营初审 (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 审核意见)
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 运营复审 (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 审核意见)
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 总经理审批(放款)  (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 审核意见)
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                // 财务放款  (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 财务放款 + 审核意见)
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{10DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{11DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{12DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{13DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{14DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{16DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                /* 新增机构  */
                new FormNode { NodeId = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{A8EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{A9EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{AAEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                /* 新增贷款 */
                // 客户经理发起贷款
                new FormNode { NodeId = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{ABEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{ACEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{ADEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                /* 新增借据  */
                new FormNode { NodeId = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{AEEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{AFEDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B0EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                /* 新增还款  */
                new FormNode { NodeId = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.还款, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{B1EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{B2EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{B3EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },

                /* 机构变更 */
                new FormNode { NodeId = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{B4EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B5EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{B6EDA2A7-79D1-E611-80CA-507B9DE4A488}"), FormId = new Guid("{EEDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false });

            context.Set<FormRole>().AddOrUpdate(
                m => new { m.RoleId, m.FormId },

                /* 客户经理（个人） */  // (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 审核意见)
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("13DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("14DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 风控初审员  */  // (融资申请 + 申请人资料上传 + 融资审核 + 审核意见)
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 风控复审员 */  // (融资申请 + 申请人资料上传 + 融资审核 + 审核意见)
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 运营初审员 */  // (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 运营审核 + 审核意见)
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("13DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("14DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                ////new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("15DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 运营复审员 */  // (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 运营审核 + 审核意见)
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("13DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("14DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                ////new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("15DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 财务总监 */  // (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 运营审核 + 财务放款 + 审核意见)
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("13DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("14DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                ////new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("15DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("16DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 总经理(个人) */  // (融资申请 + 申请人资料上传 + 融资审核 + 信息补充 + 放款资料上传 + 运营审核 + 财务放款 + 审核意见)
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("10DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("11DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("12DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("13DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("14DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                ////new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("15DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("16DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 总经理(企业) */
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5FDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("60DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("61DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 客户经理（企业） */
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5FDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("60DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("61DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("62DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 有权审核人 */
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5FDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("60DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("61DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("62DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C642BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") },

                /* 出纳 */
                new FormRole { RoleId = "C542BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("62DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C542BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("EEDC5FCF-18A4-E611-80C5-507B9DE4A488") });

            context.SaveChanges();
        }
    }
}
