using WebApi2.EntityModels.Queues;
using System.Data.Entity.ModelConfiguration;

namespace WebApi2.Repositories.Configuration
{
    internal class RequestQueueConfiguration : EntityTypeConfiguration<RequestQueue>
    {
        internal RequestQueueConfiguration()
        {
            ToTable("RequestQueues");

            HasKey(x => x.Id)
                 .Property(x => x.Id)
                 .HasColumnName("Id")
                 .HasColumnType("bigint")
                 .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                 .IsRequired();

            Property(x => x.SearchParameters)
                .HasColumnName("SearchParameters")
                .HasColumnType("nvarchar");

            Property(x => x.IsRequestSucceed)
                .HasColumnName("IsRequestSucceed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");
        }
    }
}
