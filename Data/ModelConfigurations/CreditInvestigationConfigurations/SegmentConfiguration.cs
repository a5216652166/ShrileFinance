namespace Data.ModelConfigurations.CreditInvestigationConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment;

    public class SegmentConfiguration : EntityTypeConfiguration<Segment>
    {
        public SegmentConfiguration()
        {
            ToTable("CIDG_Segment");
        }
    }
}
