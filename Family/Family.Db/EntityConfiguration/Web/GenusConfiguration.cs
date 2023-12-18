using Family.Db.Entities.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration.Web
{
    public class GenusConfiguration : IEntityTypeConfiguration<Genus>
    {
        public void Configure(EntityTypeBuilder<Genus> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired();

            builder.HasData(
                new Genus
                {
                    Id = 1,
                    Name = "Kudryavovs"
                },
                new Genus
                {
                    Id = 2,
                    Name = "TestGenus"
                });
        }
    }
}
