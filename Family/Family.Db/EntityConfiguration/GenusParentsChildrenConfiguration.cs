using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class GenusParentsChildrenConfiguration : IEntityTypeConfiguration<GenusParentsChildren>
    {
        public void Configure(EntityTypeBuilder<GenusParentsChildren> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.Genus)
                .WithMany()
                .HasForeignKey(_ => _.GenusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(_ => _.ParentsChildren)
                .WithMany()
                .HasForeignKey(_ => _.ParentsChildrenId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("GenusParentsChildren").HasData(
                new GenusParentsChildren
                {
                    Id = 1,
                    GenusId = 1,
                    ParentsChildrenId = 1,
                },
                new GenusParentsChildren
                {
                    Id = 2,
                    GenusId = 1,
                    ParentsChildrenId = 2,
                },
                new GenusParentsChildren
                {
                    Id = 3,
                    GenusId = 1,
                    ParentsChildrenId = 3,
                },
                new GenusParentsChildren
                {
                    Id = 4,
                    GenusId = 1,
                    ParentsChildrenId = 4,
                });
        }
    }
}
