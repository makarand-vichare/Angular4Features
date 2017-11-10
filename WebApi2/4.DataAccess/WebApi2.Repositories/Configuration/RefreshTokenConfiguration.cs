using WebApi2.EntityModels.Identity;
using System.Data.Entity.ModelConfiguration;

namespace WebApi2.Repositories.Configuration
{
    internal class RefreshTokenConfiguration : EntityTypeConfiguration<RefreshToken>
    {
        internal RefreshTokenConfiguration()
        {
            ToTable("RefreshTokens");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.TokenId)
                .HasColumnName("TokenId")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.Subject)
                .HasColumnName("Subject")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.ClientId)
                .HasColumnName("ClientId")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.IssuedUtc)
                .HasColumnName("IssuedUtc")
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExpiresUtc)
                .HasColumnName("ExpiresUtc")
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ProtectedTicket)
                .HasColumnName("ProtectedTicket")
                .HasColumnType("nvarchar")
                .IsRequired();

            HasRequired(x => x.Client)
                .WithMany(x => x.RefreshTokens)
                .HasForeignKey(x => x.ClientId);
        }
    }
}
