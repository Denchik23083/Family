using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.LastName).IsRequired();
            builder.Property(_ => _.Age).IsRequired();

            builder.ToTable("Parents").HasData(
                new Parent
                {
                    Id = 1,
                    FirstName = "Alex",
                    LastName = "Kudryavov",
                    Age = 45
                },
                new Parent
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Kudryavova",
                    Age = 45
                });
        }
    }
}
