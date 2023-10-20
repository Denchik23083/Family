using Family.Core.Utilities;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.GenderType).HasConversion<int>();

            builder.ToTable("Genders").HasData(
                new Gender
                {
                    Id = 1,
                    GenderType = GenderType.Female
                },
                new Gender
                {
                    Id = 2,
                    GenderType = GenderType.Male
                });
        }
    }
}
