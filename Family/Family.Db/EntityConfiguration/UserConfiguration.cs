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
            builder.Property(_ => _.LastName).IsRequired();
            builder.Property(_ => _.Email).IsRequired();
            builder.Property(_ => _.Password).IsRequired();
            builder.Property(_ => _.Age).IsRequired();

            builder.HasOne(_ => _.Gender)
                .WithMany(_ => _.Users)
                .HasForeignKey(_ => _.GenderId);

            builder.HasOne(_ => _.Role)
                .WithMany()
                .HasForeignKey(_ => _.RoleId);

            builder.ToTable("Users").HasData(
                new User
                {
                    Id = 1,
                    FirstName = "God",
                    LastName = "Full",
                    Email = "god@gmail.com",
                    Password = "0000",
                    Age = 5000,
                    GenderId = 1,
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Full",
                    Email = "admin@gmail.com",
                    Password = "0000",
                    Age = 30,
                    GenderId = 1,
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    FirstName = "Alex",
                    LastName = "Kudryavov",
                    Email = "alex@gmail.com",
                    Password = "0000",
                    Age = 45,
                    GenderId = 1,
                    RoleId = 3
                },
                new User
                {
                    Id = 4,
                    FirstName = "Anna",
                    LastName = "Kudryavova",
                    Email = "anna@gmail.com",
                    Password = "0000",
                    Age = 45,
                    GenderId = 2,
                    RoleId = 3
                },
                new User
                {
                    Id = 5,
                    FirstName = "Denis",
                    LastName = "Kudryavov",
                    Email = "denis@gmail.com",
                    Password = "0000",
                    Age = 20,
                    GenderId = 1,
                    RoleId = 4
                },
                new User
                {
                    Id = 6,
                    FirstName = "Daria",
                    LastName = "Kudryavova",
                    Email = "daria@gmail.com",
                    Password = "0000",
                    Age = 4,
                    GenderId = 2,
                    RoleId = 4
                });
        }
    }
}
