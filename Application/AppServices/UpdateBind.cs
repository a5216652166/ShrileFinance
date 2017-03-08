namespace Application
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Interfaces;

    public class UpdateBind
    {
        public void Bind<TEntity, TViewModel>(ICollection<TEntity> entities, IEnumerable<TViewModel> models) where TEntity : IEntity where TViewModel : ViewModels.IEntityViewModel
        {
            // 参数空校验及处理
            entities = entities ?? new List<TEntity>();
            models = models ?? new List<TViewModel>();

            // 获取models集合包含的Id
            var modelIds = models.Select(m => m.Id);

            // 从实体集合中移除Id不在models的Id集合中的项
            entities.Where(m => !modelIds.Contains(m.Id)).ToList()
                .ForEach(m => entities.Remove(m));

            // 遍历models的每一项，若entities存在对象项，则直接进行映射，反之，则通过该项映射产生entities的对应项，并加入entities集合中
            foreach (var model in models)
            {
                var entity = entities.SingleOrDefault(m => m.Id == model.Id);

                if (entity != null)
                {
                    Mapper.Map(model, entity);
                }
                else
                {
                    entity = Mapper.Map<TEntity>(model);
                    
                    entities.Add(entity);
                }
            }
        }
    }
}
