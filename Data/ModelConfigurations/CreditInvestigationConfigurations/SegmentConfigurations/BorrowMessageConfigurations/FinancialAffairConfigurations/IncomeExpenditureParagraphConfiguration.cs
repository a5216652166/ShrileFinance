namespace Data.ModelConfigurations.CreditInvestigationConfigurations.SegmentConfigurations.BorrowMessageConfigurations.FinancialAffairConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;

    public class IncomeExpenditureParagraphConfiguration : EntityTypeConfiguration<IncomeExpenditureParagraph>
    {
        public IncomeExpenditureParagraphConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.������������).HasMaxLength(20);
            Property(m => m.�ϼ���������).HasMaxLength(20);
            Property(m => m.������λ�ɿ�).HasMaxLength(20);
            Property(m => m.��ҵ����).HasMaxLength(20);
            Property(m => m.Ԥ�����ʽ�����).HasMaxLength(20);
            Property(m => m.��������).HasMaxLength(20);
            Property(m => m.��ҵ����С��).HasMaxLength(20);
            Property(m => m.��Ӫ����).HasMaxLength(20);
            Property(m => m.��Ӫ����С��).HasMaxLength(20);
            Property(m => m.����ר��).HasMaxLength(20);
            Property(m => m.����ר��С��).HasMaxLength(20);
            Property(m => m.�����ܼ�).HasMaxLength(20);
            Property(m => m.��������).HasMaxLength(20);
            Property(m => m.�Ͻ��ϼ�֧��).HasMaxLength(20);
            Property(m => m.�Ը�����λ����).HasMaxLength(20);
            Property(m => m.��ҵ֧��).HasMaxLength(20);
            Property(m => m.��������֧��).HasMaxLength(20);
            Property(m => m.Ԥ�����ʽ�֧��).HasMaxLength(20);
            Property(m => m.����˰��).HasMaxLength(20);
            Property(m => m.��ת�Գ����).HasMaxLength(20);
            Property(m => m.��ҵ֧��С��).HasMaxLength(20);
            Property(m => m.��Ӫ֧��).HasMaxLength(20);
            Property(m => m.����˰��1).HasMaxLength(20);
            Property(m => m.��Ӫ֧��С��).HasMaxLength(20);
            Property(m => m.����ר��).HasMaxLength(20);
            Property(m => m.ר��֧��).HasMaxLength(20);
            Property(m => m.ר��С��).HasMaxLength(20);
            Property(m => m.֧���ܼ�).HasMaxLength(20);
            Property(m => m.��ҵ����).HasMaxLength(20);
            Property(m => m.�����������).HasMaxLength(20);
            Property(m => m.�ջ���ǰ�����ҵ֧��).HasMaxLength(20);
            Property(m => m.��Ӫ����).HasMaxLength(20);
            Property(m => m.��ǰ��Ⱦ�Ӫ����).HasMaxLength(20);
            Property(m => m.�������).HasMaxLength(20);
            Property(m => m.Ӧ������˰).HasMaxLength(20);
            Property(m => m.��ȡר�û���).HasMaxLength(20);
            Property(m => m.ת����ҵ����).HasMaxLength(20);
            Property(m => m.�����������).HasMaxLength(20);

            ToTable("CIDG_IncomeExpenditureParagraph");
        }
    }
}
