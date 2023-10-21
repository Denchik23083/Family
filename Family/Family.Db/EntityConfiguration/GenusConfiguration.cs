using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class GenusConfiguration : IEntityTypeConfiguration<Genus>
    {
        public void Configure(EntityTypeBuilder<Genus> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired();
            
            builder.HasOne(_ => _.Father)
                .WithOne()
                .HasForeignKey<Genus>(_ => _.FatherId);

            builder.HasOne(_ => _.Mother)
                .WithOne()
                .HasForeignKey<Genus>(_ => _.MotherId);

            builder.ToTable("Genus").HasData(
                new Genus
                {
                    Id = 1,
                    Name = "Kudryavovs",
                    FatherId = 1,
                    MotherId = 2,
                });
        }
    }
}
