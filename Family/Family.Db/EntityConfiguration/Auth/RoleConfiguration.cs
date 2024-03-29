﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Family.Core.Utilities;
using Family.Db.Entities.Auth;

namespace Family.Db.EntityConfiguration.Auth
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.RoleType).HasConversion<int>();

            builder.HasMany(_ => _.RolePermissions)
                .WithOne(_ => _.Role)
                .HasForeignKey(_ => _.RoleId);

            builder.HasData(
                new Role
                {
                    Id = 1,
                    RoleType = RoleType.God
                },
                new Role
                {
                    Id = 2,
                    RoleType = RoleType.Admin
                },
                new Role
                {
                    Id = 3,
                    RoleType = RoleType.Parent
                },
                new Role
                {
                    Id = 4,
                    RoleType = RoleType.Child
                },
                new Role
                {
                    Id = 5,
                    RoleType = RoleType.User
                });
        }
    }
}
