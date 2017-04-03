namespace Application
{
    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    using Mappings;

    /// <summary>
    /// 自动映射的配置
    /// </summary>
    public partial class Startup
    {
        public void ConfigureMapper()
        {
            Mapper.Initialize(config =>
            {
                config.AddCollectionMappers();
                config.AddProfile<DomainToViewModelMappingProfile>();
                config.AddProfile<ViewModelToDomainMappingProfile>();
                config.AddProfile<LoanDomainToViewModelProfile>();
                config.AddProfile<LoanViewModelToDomianProfile>();
                config.AddProfile<DomainToCreditInvestigationProfile>();
                config.AddProfile<FinanceDomainToCreditInvestigationProfile>();
                config.AddProfile<FinanceViewModelToDomainMappingProfile>();
                config.AddProfile<BindModelToProduceMappingProfile>();
                config.AddProfile<ProduceToViewModelMappingProfile>();
            });
        }
    }
}
