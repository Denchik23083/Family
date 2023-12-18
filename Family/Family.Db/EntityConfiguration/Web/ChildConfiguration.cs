using Family.Db.Entities.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration.Web
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.User)
                .WithOne(_ => _.Child)
                .HasForeignKey<Child>(_ => _.UserId);

            builder.HasOne(_ => _.Genus)
                .WithMany(_ => _.Children)
                .HasForeignKey(_ => _.GenusId);

            builder.HasData(
                new Child
                {
                    Id = 1,
                    UserId = 5,
                    GenusId = 1
                },
                new Child
                {
                    Id = 2,
                    UserId = 6,
                    GenusId = 1
                },
                new Child
                {
                    Id = 3,
                    UserId = 8,
                    GenusId = 2
                });
        }
    }
}
