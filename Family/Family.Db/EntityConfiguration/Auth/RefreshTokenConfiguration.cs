using Family.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration.Auth
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Value).IsRequired();

            builder.HasOne(_ => _.User)
                .WithOne(_ => _.RefreshToken)
                .HasForeignKey<RefreshToken>(_ => _.UserId);
        }
    }
}
