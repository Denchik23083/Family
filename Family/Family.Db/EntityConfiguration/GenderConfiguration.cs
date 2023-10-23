﻿using Family.Core.Utilities;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Family.Db.EntityConfiguration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Type).HasConversion<int>();

            builder.ToTable("Genders").HasData(
                new Gender
                {
                    Id = 1,
                    Type = GenderType.Male
                },
                new Gender
                {
                    Id = 2,
                    Type = GenderType.Female
                });
        }
    }
}
