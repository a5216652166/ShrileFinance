namespace Data.ModelConfigurations.CreditInvestigation
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation;

    public class MessageTrackConfiguration : EntityTypeConfiguration<MessageTrack>
    {
       public MessageTrackConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.MessageData);
            Property(m => m.MessageStatus);
            Property(m => m.Name).HasMaxLength(20);
            Property(m => m.OperationType);
            Property(m => m.ReferenceId);
            Property(m => m.TrackDate);

            ToTable("CIDG_MessageTrack");
        }
    }
}
