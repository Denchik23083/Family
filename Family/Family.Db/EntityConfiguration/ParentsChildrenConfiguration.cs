using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    internal class ParentsChildrenConfiguration : IEntityTypeConfiguration<ParentsChildren>
    {
        public void Configure(EntityTypeBuilder<ParentsChildren> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.Parent)
                .WithMany(_ => _.ParentsChildren)
                .HasForeignKey(_ => _.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(_ => _.Child)
                .WithMany(_ => _.ParentsChildren)
                .HasForeignKey(_ => _.ChildId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("ParentsChildren").HasData(
                new ParentsChildren
                {
                    Id = 1,
                    ParentId = 1,
                    ChildId = 1,
                },
                new ParentsChildren
                {
                    Id = 2,
                    ParentId = 2,
                    ChildId = 1,
                },
                new ParentsChildren
                {
                    Id = 3,
                    ParentId = 1,
                    ChildId = 2,
                },
                new ParentsChildren
                {
                    Id = 4,
                    ParentId = 2,
                    ChildId = 2,
                });
        }
    }
}
