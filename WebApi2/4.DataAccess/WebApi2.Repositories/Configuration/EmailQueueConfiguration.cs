using WebApi2.EntityModels.Queues;
using System.Data.Entity.ModelConfiguration;

namespace WebApi2.Repositories.Configuration
{
    internal class EmailQueueConfiguration : EntityTypeConfiguration<EmailQueue>
    {

        internal EmailQueueConfiguration()
        {
            ToTable("EmailQueues");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.FromEmailId)
                .HasColumnName("FromEmailId")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.ToEmailId)
                .HasColumnName("ToEmailId")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.EmailSubject)
                .HasColumnName("EmailSubject")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.MessageBody)
                .HasColumnName("MessageBody")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.AttachedFiles)
                .HasColumnName("AttachedFiles")
                .HasColumnType("nvarchar");

            Property(x => x.IsSucceedEmailSent)
                .HasColumnName("IsSucceedEmailSent")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");

        }
    }
}
