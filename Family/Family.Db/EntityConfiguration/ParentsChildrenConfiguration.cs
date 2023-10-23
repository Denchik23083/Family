using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class ParentsChildrenConfiguration : IEntityTypeConfiguration<ParentsChildren>
    {
        public void Configure(EntityTypeBuilder<ParentsChildren> builder)
        {
            builder.HasKey(_ => _.Id);
        }
    }
}
