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
            builder.Property(_ => _.Email).IsRequired();
            builder.Property(_ => _.Password).IsRequired();
            builder.Property(_ => _.BirthDay).IsRequired();

            builder.HasOne(_ => _.Gender)
                .WithMany(_ => _.Users)
                .HasForeignKey(_ => _.GenderId);

            builder.HasOne(_ => _.Role)
                .WithMany()
                .HasForeignKey(_ => _.RoleId);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "God",
                    Email = "god@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(),
                    GenderId = 1,
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "0000",
                    BirthDay = DateTime.Now.AddYears(-30),
                    GenderId = 1,
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    FirstName = "Alex",
                    Email = "alex@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(1976, 10, 16),
                    GenderId = 1,
                    RoleId = 3
                },
                new User
                {
                    Id = 4,
                    FirstName = "Anna",
                    Email = "anna@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(1976, 08, 25),
                    GenderId = 2,
                    RoleId = 3
                },
                new User
                {
                    Id = 5,
                    FirstName = "Denis",
                    Email = "denis@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2003, 08, 23),
                    GenderId = 1,
                    RoleId = 4
                },
                new User
                {
                    Id = 6,
                    FirstName = "Daria",
                    Email = "daria@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2019, 09, 19),
                    GenderId = 2,
                    RoleId = 4
                });
        }
    }
}
