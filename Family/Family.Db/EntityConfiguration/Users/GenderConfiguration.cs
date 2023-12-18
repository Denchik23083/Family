using Family.Core.Utilities;
using Family.Db.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration.Users
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Type).HasConversion<int>();

            builder.HasData(
                new Gender
                {
                    Id = 1,
                    Type = GenderType.Male
                },
                new Gender
                {
                    Id = 2,
                    Type = GenderType.Female
                });
        }
    }
}
