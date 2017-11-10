using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WebApi2.EntityModels.Localization;

namespace WebApi2.Repositories.Configuration
{
    internal class KeyGroupConfiguration : EntityTypeConfiguration<KeyGroup>
    {
        internal KeyGroupConfiguration()
        {
            ToTable("KeyGroups");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.KeyGroupCode)
                .HasColumnName("KeyGroup")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.LocalizationKeys)
                .HasColumnName("LocalizationKeys")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();
        }
    }
}
