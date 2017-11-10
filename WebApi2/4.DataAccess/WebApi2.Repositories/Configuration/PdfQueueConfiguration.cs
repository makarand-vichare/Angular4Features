using WebApi2.EntityModels.Queues;
using System.Data.Entity.ModelConfiguration;

namespace WebApi2.Repositories.Configuration
{
    internal class PdfQueueConfiguration : EntityTypeConfiguration<PdfQueue>
    {

        internal PdfQueueConfiguration()
        {
            ToTable("PdfQueues");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.CriminalId)
                .HasColumnName("CriminalId")
                .HasColumnType("bigint")
                .IsRequired();

            Property(x => x.GeneratedHtml)
                .HasColumnName("GeneratedHtml")
                .HasColumnType("nvarchar");

            Property(x => x.ReGenerationRequired)
                .HasColumnName("ReGenerationRequired")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.IsPdfGenerationSucceed)
                .HasColumnName("IsPdfGenerationSucceed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");
        }
    }
}
