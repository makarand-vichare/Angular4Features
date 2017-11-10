using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApi2.EntityModels.Location;

namespace WebApi2.Repositories.Configuration
{
    internal class CityConfiguration : EntityTypeConfiguration<City>
    {
        internal CityConfiguration()
        {
            ToTable("Cities");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasRequired(x => x.Country)
                .WithMany()
                .HasForeignKey(f => f.CountryId);

            //Property(x => x.CountryId)
            //    .HasColumnName("CountryId")
            //    .HasColumnType("bigint")
            //    .IsRequired();

            Property(x => x.CityName)
                .HasColumnName("CityName")
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
