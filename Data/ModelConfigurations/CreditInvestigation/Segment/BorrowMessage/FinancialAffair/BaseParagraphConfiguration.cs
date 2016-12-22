using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    public class BaseParagraphConfiguration : EntityTypeConfiguration<BaseParagraph>
    {
        public BaseParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.��Ϣ��¼����).HasMaxLength(4);
            Property(m => m.��Ϣ��¼����).HasMaxLength(2);
            Property(m => m.��Ϣ���).HasMaxLength(1);
            Property(m => m.���ڻ�������).HasMaxLength(11);
            Property(m => m.���������).HasMaxLength(80);
            Property(m => m.������).HasMaxLength(16);
            Property(m => m.�������).HasMaxLength(4);
            Property(m => m.��������).HasMaxLength(2);
            Property(m => m.��������ϸ��).HasMaxLength(1);
            Property(m => m.�������������).HasMaxLength(80);
            Property(m => m.�����Ա����).HasMaxLength(30);
            Property(m => m.���ʱ��).HasMaxLength(8);
            Property(m => m.��Ϣ��¼��������).HasMaxLength(1);
            Property(m => m.ҵ��������).HasMaxLength(8);
            Property(m => m.��Ϣ��¼���ٱ��).HasMaxLength(20);

            ToTable("CIDG_BaseParagraph");
        }
    }
}
