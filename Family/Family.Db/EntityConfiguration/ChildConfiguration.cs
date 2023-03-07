﻿using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.LastName).IsRequired();
            builder.Property(_ => _.Age).IsRequired();

            builder.HasOne(_ => _.Gender)
                .WithMany()
                .HasForeignKey(_ => _.GenderId);

            builder.ToTable("Children").HasData(
                new Child
                {
                    Id = 1,
                    FirstName = "Denis",
                    LastName = "Kudryavov",
                    Age = 19,
                    GenderId = 2
                },
                new Child
                {
                    Id = 2,
                    FirstName = "Daria",
                    LastName = "Kudryavova",
                    Age = 3,
                    GenderId = 1
                });
        }
    }
}
