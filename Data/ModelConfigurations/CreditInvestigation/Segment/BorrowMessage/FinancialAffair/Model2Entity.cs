namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Core.Entities.CreditInvestigation;

    public class Model2Entity
    {
        public static void ConvertEntity<T>(StringBuilder builder) where T : class, new()
        {
            Type objType = typeof(T);

            builder.AppendLine("using Core.Entities.CreditInvestigation.Segment.BorrowMessage.FinancialAffair;");
            builder.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
            builder.AppendLine("using System.Data.Entity.ModelConfiguration;");
            builder.AppendLine();
            builder.AppendLine("namespace Data.ModelConfigurations.CreditInvestigation.Segment.BorrowMessage.FinancialAffair");
            builder.AppendLine("{");

            builder.AppendLine(
                string.Format(
                    "     public class {0}Configuration : EntityTypeConfiguration<{1}>",
                objType.Name,
                objType.Name));

            builder.AppendLine("    {");

            builder.AppendLine(string.Format("      public {0}Configuration()", objType.Name));
            builder.AppendLine("        {");

            builder.AppendLine("            HasKey(m => m.Id);");
            builder.AppendLine("            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);");
            builder.AppendLine();

            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                var metaAttrs = propInfo.GetCustomAttributes(typeof(MetaCodeAttribute), true)
                    .FirstOrDefault() as MetaCodeAttribute;

                if (metaAttrs == null)
                {
                    continue;
                }

                builder.AppendLine(
                  string.Format("           Property(m => m.{0}).HasMaxLength({1});", propInfo.Name, metaAttrs.Length));
            }

            builder.AppendLine();
            builder.AppendLine(string.Format("          ToTable(\"CIDG_{0}\");", objType.Name));

            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("}");
        }
    }
}
