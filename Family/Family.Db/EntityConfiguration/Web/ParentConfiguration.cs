using Family.Db.Entities.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration.Web
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.User)
                .WithOne(_ => _.Parent)
                .HasForeignKey<Parent>(_ => _.UserId);

            builder.HasOne(_ => _.Genus)
                .WithMany(_ => _.Parents)
                .HasForeignKey(_ => _.GenusId);

            builder.HasData(
                new Parent
                {
                    Id = 1,
                    UserId = 3,
                    GenusId = 1
                },
                new Parent
                {
                    Id = 2,
                    UserId = 4,
                    GenusId = 1
                },
                new Parent
                {
                    Id = 3,
                    UserId = 7,
                    GenusId = 2
                });
        }
    }
}
