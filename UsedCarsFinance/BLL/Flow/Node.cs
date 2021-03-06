﻿using System;
using System.Collections.Generic;
using Models;
using Models.Flow;

namespace BLL.Flow
{
    public class Node
    {
        private readonly static DAL.Flow.NodeMapper nodeMapper = new DAL.Flow.NodeMapper();

        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// qiy     16.04.29
        /// <param name="nodeId">节点标识</param>
        /// <returns></returns>
		public NodeInfo Get(int nodeId)
        {
            return nodeMapper.Find(nodeId);
        }

        /// <summary>
        /// 获取流程内的初始节点
        /// </summary>
        /// qiy     16.05.10
        /// <param name="flowId">流程标识</param>
        /// <returns></returns>
        public NodeInfo GetDefault(int flowId)
        {
            return Get(1);
        }

        /// <summary>
        /// 节点选项
        /// </summary>
        /// qiy     16.05.09
        /// <param name="flowId">流程标识</param>
        /// <returns></returns>
        public List<ComboInfo> Option(Guid? flowId)
        {
            return nodeMapper.Option(flowId);
        }
    }
}
