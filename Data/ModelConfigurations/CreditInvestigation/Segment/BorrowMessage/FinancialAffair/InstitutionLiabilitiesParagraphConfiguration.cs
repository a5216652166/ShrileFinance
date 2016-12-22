using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    public class InstitutionLiabilitiesParagraphConfiguration : EntityTypeConfiguration<InstitutionLiabilitiesParagraph>
    {
        public InstitutionLiabilitiesParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Type).HasMaxLength(1);
            Property(m => m.�ֽ�).HasMaxLength(20);
            Property(m => m.���д��).HasMaxLength(20);
            Property(m => m.Ӧ��Ʊ��).HasMaxLength(20);
            Property(m => m.Ӧ���˿�).HasMaxLength(20);
            Property(m => m.Ԥ���˿�).HasMaxLength(20);
            Property(m => m.����Ӧ�տ�).HasMaxLength(20);
            Property(m => m.����).HasMaxLength(20);
            Property(m => m.����Ʒ).HasMaxLength(20);
            Property(m => m.����Ͷ��).HasMaxLength(20);
            Property(m => m.�̶��ʲ�).HasMaxLength(20);
            Property(m => m.�����ʲ�).HasMaxLength(20);
            Property(m => m.�ʲ��ϼ�).HasMaxLength(20);
            Property(m => m.��������).HasMaxLength(20);
            Property(m => m.����ר��).HasMaxLength(20);
            Property(m => m.ר��֧��).HasMaxLength(20);
            Property(m => m.��ҵ֧��).HasMaxLength(20);
            Property(m => m.��Ӫ֧��).HasMaxLength(20);
            Property(m => m.�ɱ�����).HasMaxLength(20);
            Property(m => m.����˰��).HasMaxLength(20);
            Property(m => m.�Ͻ��ϼ�֧��).HasMaxLength(20);
            Property(m => m.�Ը�����λ����).HasMaxLength(20);
            Property(m => m.��ת�Գ����).HasMaxLength(20);
            Property(m => m.֧���ϼ�).HasMaxLength(20);
            Property(m => m.�ʲ������ܼ�).HasMaxLength(20);
            Property(m => m.��ǿ���).HasMaxLength(20);
            Property(m => m.Ӧ��Ʊ��).HasMaxLength(20);
            Property(m => m.Ӧ���˿�).HasMaxLength(20);
            Property(m => m.Ԥ���˿�).HasMaxLength(20);
            Property(m => m.����Ӧ����).HasMaxLength(20);
            Property(m => m.Ӧ��Ԥ���).HasMaxLength(20);
            Property(m => m.Ӧ�ɲ���ר����).HasMaxLength(20);
            Property(m => m.Ӧ��˰��).HasMaxLength(20);
            Property(m => m.��ծ�ϼ�).HasMaxLength(20);
            Property(m => m.��ҵ����).HasMaxLength(20);
            Property(m => m.һ�����).HasMaxLength(20);
            Property(m => m.Ͷ�ʻ���).HasMaxLength(20);
            Property(m => m.�̶�����).HasMaxLength(20);
            Property(m => m.ר�û���).HasMaxLength(20);
            Property(m => m.��ҵ����).HasMaxLength(20);
            Property(m => m.��Ӫ����).HasMaxLength(20);
            Property(m => m.���ʲ��ϼ�).HasMaxLength(20);
            Property(m => m.������������).HasMaxLength(20);
            Property(m => m.�ϼ���������).HasMaxLength(20);
            Property(m => m.����ר��).HasMaxLength(20);
            Property(m => m.��ҵ����).HasMaxLength(20);
            Property(m => m.��Ӫ����).HasMaxLength(20);
            Property(m => m.������λ�ɿ�).HasMaxLength(20);
            Property(m => m.��������).HasMaxLength(20);
            Property(m => m.����ϼ�).HasMaxLength(20);
            Property(m => m.��ծ�����ܼ�).HasMaxLength(20);

            ToTable("CIDG_InstitutionLiabilitiesParagraph");
        }
    }
}
