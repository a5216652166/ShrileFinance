﻿namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.CreditInvestigation;
    using Core.Interfaces.Repositories.MessageRepository;
    using Core.Services.CreditInvestigation;
    using ViewModels.Message;
    using X.PagedList;
    public class MessageAppService
    {
        private readonly IMessageTrackRepostitory respository;
        private readonly DatagramFactoryService factory;

        public MessageAppService(IMessageTrackRepostitory respository, DatagramFactoryService factory)
        {
            this.respository = respository;
            this.factory = factory;
        }

        /// <summary>
        /// 报文追踪
        /// </summary>
        /// <param name="id">引用ID</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="name">默认名称</param>
        public void MessageTrack(Guid id, MessageOperationTypeEnum operationType, string name)
        {
            if (respository.Get(id) != null)
            {
                return;
            }

            var track = new MessageTrack() {
                MessageStatus = MessageStatusEmum.待生成,
                Name = name,
                OperationType = operationType,
                ReferenceId = id,
            };

            respository.Create(track);
            respository.Commit();
        }

        public void Generate()
        {
            factory.Generate(new List<MessageTrack> {
                new MessageTrack { ReferenceId = Guid.Parse("0727FF76-8BC2-E611-80C7-507B9DE4A488"), OperationType = MessageOperationTypeEnum.借款 } });
        }

        /// <summary>
        /// 获取报文跟踪列表
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<MessageTrackViewModel> GetPageList(string search, int page, int size)
        {
            var messageTrack = respository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                messageTrack = messageTrack.Where(m => m.Name.Contains(search));
            }

            messageTrack = messageTrack.OrderByDescending(m => m.Id);
            var pageList = messageTrack.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<MessageTrackViewModel>>(pageList);

            return models;
        }

        /// <summary>
        /// 修改名称后保存
        /// </summary>
        /// <param name="model"></param>
        public void Modify(MessageTrackViewModel model)
        {
            if (model == null || model.Id == null)
            {
                return;
            }

            var messageTrack = respository.Get(model.Id.Value);

            if (messageTrack == null)
            {
                return;
            }

            Mapper.Map(model, messageTrack);

            respository.Modify(messageTrack);

            respository.Commit();
        }
    }
}
