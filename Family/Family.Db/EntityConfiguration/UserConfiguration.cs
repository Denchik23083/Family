using Family.Core.Utilities;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.FirstName).IsRequired();
        }
    }
}
