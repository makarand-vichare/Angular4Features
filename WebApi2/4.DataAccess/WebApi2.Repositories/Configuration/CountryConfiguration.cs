using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApi2.EntityModels.Location;

namespace WebApi2.Repositories.Configuration
{
    internal class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        internal CountryConfiguration()
        {
            ToTable("Countries");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.CountryCode)
                .HasColumnName("CountryCode")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.CountryName)
                .HasColumnName("CountryName")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.IsActive)
            .HasColumnName("IsActive")
            .HasColumnType("bit")
            .IsRequired();
        }
    }
}
